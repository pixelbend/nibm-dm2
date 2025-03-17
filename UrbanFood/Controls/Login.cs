using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrbanFood.Forms;
using MaterialSkin.Controls;
using Oracle.ManagedDataAccess.Client;
using System.Text.RegularExpressions;
using UrbanFood.Database.OracleDB;
using UrbanFood.LocalState;
using UrbanFood.Utils;

namespace UrbanFood.Controls
{
    public partial class Login : UserControl
    {
        private Customer customerMianForm;
        private Supplier supplierMainForm;
        private Auth authForm;

        public Login(Auth authForm)
        {
            InitializeComponent();
            this.authForm = authForm;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (ValidateLoginTextBoxes())
            {
                switch (UserState.Instance.GetUserType())
                {
                    case UserType.Customer:
                        {
                            CustomerLogin();
                            break;
                        }
                    case UserType.Supplier:
                        {
                            SupplierLogin();
                            break;
                        }
                }
            }
        }

        private void CustomerLogin()
        {
            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand cmd = new("Login_Customer", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pEmail", OracleDbType.Varchar2).Value = LoginEmailTextBox.Text;

                OracleParameter CustomerID = new OracleParameter("pCustomerID", OracleDbType.Varchar2, 32)
                {
                    Direction = ParameterDirection.Output,
                };
                cmd.Parameters.Add(CustomerID);

                OracleParameter PasswordHash = new OracleParameter("pPassword", OracleDbType.Varchar2, 255)
                {
                    Direction = ParameterDirection.Output,
                };
                cmd.Parameters.Add(PasswordHash);

                cmd.ExecuteNonQuery();

                if (BCrypt.Net.BCrypt.Verify(LoginPasswordTextBox.Text, PasswordHash.Value.ToString()))
                {
                    UserState.Instance.SetUserId(CustomerID.Value.ToString());
                    customerMianForm = new Customer();
                    customerMianForm.Show();
                    ClearLoginTextBoxes();
                    authForm.Hide();
                }
                else
                {
                    MaterialMessageBox.Show("The Given Password is Invalid.", "Error");
                }
            }
            catch (OracleException ex)
            {
                MaterialMessageBox.Show(ErrorHandler.GetOracleErrorMessage(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
            finally
            {
                OracleDBConnection.Instance.CloseConnection();
            }
        }


        private void SupplierLogin()
        {
            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand cmd = new("Login_Supplier", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pEmail", OracleDbType.Varchar2).Value = LoginEmailTextBox.Text;

                OracleParameter SupplierID = new OracleParameter("pSupplierID", OracleDbType.Varchar2, 32)
                {
                    Direction = ParameterDirection.Output,
                };
                cmd.Parameters.Add(SupplierID);

                OracleParameter PasswordHash = new OracleParameter("pPassword", OracleDbType.Varchar2, 255)
                {
                    Direction = ParameterDirection.Output,
                };
                cmd.Parameters.Add(PasswordHash);

                cmd.ExecuteNonQuery();

                if (BCrypt.Net.BCrypt.Verify(LoginPasswordTextBox.Text, PasswordHash.Value.ToString()))
                {
                    UserState.Instance.SetUserId(SupplierID.Value.ToString());
                    supplierMainForm = new Supplier();
                    supplierMainForm.Show();
                    ClearLoginTextBoxes();
                    authForm.Hide();
                }
                else
                {
                    MaterialMessageBox.Show("The Given Password is Invalid.", "Error");
                }
            }
            catch (OracleException ex)
            {
                MaterialMessageBox.Show(ErrorHandler.GetOracleErrorMessage(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
            finally
            {
                OracleDBConnection.Instance.CloseConnection();
            }
        }

        private bool ValidateLoginTextBoxes()
        {
            if (!IsValidEmail(LoginEmailTextBox.Text))
            {
                MaterialMessageBox.Show("Email format is invalid.", "Validation Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(LoginPasswordTextBox.Text) || LoginPasswordTextBox.Text.Length < 8)
            {
                MaterialMessageBox.Show("Password must be at least 8 characters long.", "Validation Error");
                return false;
            }

            return true;
        }

        private void ClearLoginTextBoxes()
        {
            LoginPasswordTextBox.Clear();
            LoginEmailTextBox.Clear();
        }

        private static bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@]+@[^@]+\.[^@]+$");
            return emailRegex.IsMatch(email);
        }
    }
}
