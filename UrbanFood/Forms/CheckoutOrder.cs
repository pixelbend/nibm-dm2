using MaterialSkin.Controls;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrbanFood.Database.OracleDB;
using UrbanFood.LocalState;
using UrbanFood.Utils;

namespace UrbanFood.Forms
{
    public partial class CheckoutOrder : MaterialForm
    {
        private string _orderId;
        public event EventHandler ConfirmButtonClicked;

        public CheckoutOrder(string orderId)
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            _orderId = orderId;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (!ValidateCardDetails())
            {
                return;            
            }

            string transactionKey = 
                $"{BCrypt.Net.BCrypt.HashPassword(CardNoTextBox.Text)}:" +
                $"{BCrypt.Net.BCrypt.HashPassword(CVCTextBox.Text)}:" +
                $"{BCrypt.Net.BCrypt.HashPassword(CardExpiryTimePicker.Text)}";
            
            var result = CheckOutOrderQuery(_orderId,  transactionKey);
            if (result != null) { 
                ConfirmButtonClicked.Invoke(this, EventArgs.Empty);
                Close();
            }
        }

        public bool ValidateCardDetails()
        {
            if (string.IsNullOrEmpty(CardNoTextBox.Text) || !Regex.IsMatch(CardNoTextBox.Text, @"^\d{13,19}$"))
            {
                MaterialMessageBox.Show("Please enter a valid card number (13 to 19 digits).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(CVCTextBox.Text) || !Regex.IsMatch(CVCTextBox.Text, @"^\d{3,4}$"))
            {
                MaterialMessageBox.Show("Please enter a valid CVC (3 or 4 digits).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DateTime expiryDate;
            if (string.IsNullOrEmpty(CardExpiryTimePicker.Text) || !DateTime.TryParse(CardExpiryTimePicker.Text, out expiryDate))
            {
                MaterialMessageBox.Show("Please enter a valid expiry date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (expiryDate <= DateTime.Now)
            {
                MaterialMessageBox.Show("Card expiry date must be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public string CheckOutOrderQuery(string orderId, string transactionKey)
        {
            string checkedoutOrderId = null;

            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand cmd = new("Checkout_Order", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                OracleParameter resultParam = new OracleParameter("vOrderID", OracleDbType.Varchar2, 32)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                cmd.Parameters.Add(resultParam);

                cmd.Parameters.Add("pCustomerID", OracleDbType.Varchar2).Value = UserState.Instance.GetUserId();

                cmd.Parameters.Add("pOrderID", OracleDbType.Varchar2).Value = orderId;

                cmd.Parameters.Add("pTransactionKey", OracleDbType.Varchar2, 255).Value = transactionKey;

                cmd.ExecuteNonQuery();

                checkedoutOrderId = resultParam.Value?.ToString();
            }
            catch (OracleException ex)
            {
                MaterialMessageBox.Show(ErrorHandler.GetOracleErrorMessage(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                OracleDBConnection.Instance.CloseConnection();
            }

            return checkedoutOrderId;
        }
    }
}
