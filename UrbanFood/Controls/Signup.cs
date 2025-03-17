using MaterialSkin.Controls;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Text.RegularExpressions;
using UrbanFood.Database.OracleDB;
using UrbanFood.Forms;
using UrbanFood.LocalState;
using UrbanFood.Utils;

namespace UrbanFood.UserControls
{
    public partial class Signup : UserControl
    {
        private Customer customerMianForm;
        private Supplier supplierMainForm;
        private Auth authForm;
        
        public Signup(Auth authForm)
        {
            InitializeComponent();
            this.authForm = authForm;
        }

        private void SignupButton_Click(object sender, EventArgs e)
        {
            if (ValidateSignupTextBoxes())
            {
                switch (UserState.Instance.GetUserType())
                {
                    case UserType.Customer:
                        CustomerSignup();
                        break;
                    case UserType.Supplier:
                        SupplierSignup();
                        break;
                }
            }
        }

        private void CustomerSignup()
        {
            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand cmd = new("Signup_Customer", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter CustomerID = new OracleParameter("vCustomerID", OracleDbType.Varchar2, 32)
                {
                    Direction = ParameterDirection.ReturnValue,
                };
                cmd.Parameters.Add(CustomerID);


                cmd.Parameters.Add("pName", OracleDbType.Varchar2).Value = SignupNameTextBox.Text;
                cmd.Parameters.Add("pEmail", OracleDbType.Varchar2).Value = SignupEmailTextBox.Text;
                cmd.Parameters.Add("pHashedPassword", OracleDbType.Varchar2).Value = BCrypt.Net.BCrypt.HashPassword(SignupPasswordTextBox.Text);
                cmd.Parameters.Add("pPhone", OracleDbType.Varchar2).Value = SignupPhoneTextBox.Text;
                cmd.Parameters.Add("pAddress", OracleDbType.Varchar2).Value = SignupAddressTextBox.Text;

                cmd.ExecuteNonQuery();

                UserState.Instance.SetUserId(CustomerID.Value.ToString());

                ClearSignupTextBoxes();

                customerMianForm = new Customer();
                customerMianForm.Show();
                authForm.Hide();
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

        private void SupplierSignup()
        {
            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand cmd = new("Signup_Supplier", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter SupplierID = new OracleParameter("vSupplierID", OracleDbType.Varchar2, 32)
                {
                    Direction = ParameterDirection.ReturnValue,
                };
                cmd.Parameters.Add(SupplierID);

                cmd.Parameters.Add("pName", OracleDbType.Varchar2).Value = SignupNameTextBox.Text;
                cmd.Parameters.Add("pEmail", OracleDbType.Varchar2).Value = SignupEmailTextBox.Text;
                cmd.Parameters.Add("pHashedPassword", OracleDbType.Varchar2).Value = BCrypt.Net.BCrypt.HashPassword(SignupPasswordTextBox.Text);
                cmd.Parameters.Add("pPhone", OracleDbType.Varchar2).Value = SignupPhoneTextBox.Text;
                cmd.Parameters.Add("pAddress", OracleDbType.Varchar2).Value = SignupAddressTextBox.Text;

                cmd.ExecuteNonQuery();

                UserState.Instance.SetUserId(SupplierID.Value.ToString());

                ClearSignupTextBoxes();

                supplierMainForm = new Supplier();
                supplierMainForm.Show();
                authForm.Hide();
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

        private bool ValidateSignupTextBoxes()
        {
            if (string.IsNullOrWhiteSpace(SignupNameTextBox.Text))
            {
                MaterialMessageBox.Show("Name cannot be empty.", "Validation Error");
                return false;
            }

            if (!IsValidEmail(SignupEmailTextBox.Text))
            {
                MaterialMessageBox.Show("Email format is invalid.", "Validation Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(SignupPasswordTextBox.Text) || SignupPasswordTextBox.Text.Length < 8)
            {
                MaterialMessageBox.Show("Password must be at least 8 characters long.", "Validation Error");
                return false;
            }

            if (!IsValidPhone(SignupPhoneTextBox.Text))
            {
                MaterialMessageBox.Show("Phone number format is invalid.", "Validation Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(SignupAddressTextBox.Text))
            {
                MaterialMessageBox.Show("Address cannot be empty.", "Validation Error");
                return false;
            }

            return true;
        }

        private static bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@]+@[^@]+\.[^@]+$");
            return emailRegex.IsMatch(email);
        }

        private static bool IsValidPhone(string phone)
        {
            var phoneRegex = new Regex(@"^\+?\d{10,15}$");
            return phoneRegex.IsMatch(phone);
        }

        private void ClearSignupTextBoxes()
        {
            SignupNameTextBox.Clear();
            SignupAddressTextBox.Clear();
            SignupPasswordTextBox.Clear();
            SignupEmailTextBox.Clear();
            SignupPhoneTextBox.Clear();
        }
    }
}
