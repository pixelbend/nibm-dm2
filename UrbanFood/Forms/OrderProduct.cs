using MaterialSkin.Controls;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrbanFood.Database.OracleDB;
using UrbanFood.LocalState;
using UrbanFood.Utils;

namespace UrbanFood.Forms
{
    public partial class OrderProduct : MaterialForm
    {
        private string _productID;
        private int _maxQuantity;
        private decimal _price;
        private string _productName;

        public OrderProduct(string productId)
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            _productID = productId;
            PopulateProductData();
            QuantityUpDown.Maximum = _maxQuantity;
        }

        private void BuyProduct_Load(object sender, EventArgs e)
        {
            DisplayTotalPrice();
            Text = $"Order {_productName}";
        }

        private void QuantityUpDown_ValueChanged(object sender, EventArgs e)
        {
            DisplayTotalPrice();
        }

        private void QuantityUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            DisplayTotalPrice();
        }

        private void ConfirmPurchaseButton_Click(object sender, EventArgs e)
        {
            var result = OrderProductQuery(_productID, Convert.ToInt32(QuantityUpDown.Value));
            if (result != null)
            {
                Close();
            }
        }

        private void DisplayTotalPrice()
        {
            TotalPriceTextBox.Text = $"Rs: {QuantityUpDown.Value * _price}";
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        public void PopulateProductData()
        {
            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand getProductByIdCmd = new("Get_Product_By_ID", conn);
                getProductByIdCmd.CommandType = CommandType.StoredProcedure;

                OracleParameter cursor = new OracleParameter("vCursor", OracleDbType.RefCursor)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                getProductByIdCmd.Parameters.Add(cursor);


                getProductByIdCmd.Parameters.Add("pProductID", OracleDbType.Varchar2).Value = _productID;


                using OracleDataReader reader = getProductByIdCmd.ExecuteReader();
                if (reader.Read())
                {
                    _productName = reader["Name"].ToString();
                    _maxQuantity = Convert.ToInt32(reader["StockQuantity"].ToString());
                    _price = Convert.ToDecimal(reader["Price"].ToString());

                }

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
        }

        public string OrderProductQuery(string productId, int quantity)
        {
            string createdOrderID = null;

            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand cmd = new("Order_Product", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                OracleParameter orderIdParam = new OracleParameter("vOrderId", OracleDbType.Varchar2, 32)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                cmd.Parameters.Add(orderIdParam);

                cmd.Parameters.Add("pCustomerId", OracleDbType.Varchar2).Value = UserState.Instance.GetUserId();
                cmd.Parameters.Add("pProductId", OracleDbType.Varchar2).Value = productId;
                cmd.Parameters.Add("pQuantity", OracleDbType.Int32).Value = quantity;

                cmd.ExecuteNonQuery();

                createdOrderID = orderIdParam.Value?.ToString();
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

            return createdOrderID;
        }
    }
}
