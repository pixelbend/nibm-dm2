using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Oracle.ManagedDataAccess.Client;
using UrbanFood.Database.OracleDB;
using UrbanFood.Utils;
using UrbanFood.LocalState;
using System.Text.RegularExpressions;
using UrbanFood.Forms;

namespace UrbanFood.Controls
{
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            PopulateProfileInfo();
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            string result = null;

            if (ValidateSignupTextBoxes())
            {
                switch (UserState.Instance.GetUserType())
                {
                    case UserType.Customer:
                        result = UpdateCustomerProfile();
                        break;
                    case UserType.Supplier:
                        result = UpdateSupplierProfile();
                        break;
                }

                if (result != null)
                {
                    MaterialMessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void PopulateProfileInfo()
        {
            switch (UserState.Instance.GetUserType())
            {
                case UserType.Customer:
                    {
                        try
                        {
                            OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                            using OracleCommand productListCmd = new("Get_Customer_Profile", conn);
                            productListCmd.CommandType = CommandType.StoredProcedure;

                            OracleParameter cursor = new OracleParameter("vCursor", OracleDbType.RefCursor)
                            {
                                Direction = ParameterDirection.ReturnValue
                            };
                            productListCmd.Parameters.Add(cursor);

                            productListCmd.Parameters.Add("pCustomerID", OracleDbType.Varchar2).Value = UserState.Instance.GetUserId();

                            using OracleDataReader reader = productListCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    NameTextBox.Text = reader["Name"].ToString();
                                    EmailTextBox.Text = reader["Email"].ToString();
                                    PhoneTextBox.Text = reader["Phone"].ToString();
                                    AddressTextBox.Text = reader["Address"].ToString();
                                }
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
                    break;
                case UserType.Supplier:
                    {
                        try
                        {
                            OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                            using OracleCommand productListCmd = new("Get_Supplier_Profile", conn);
                            productListCmd.CommandType = CommandType.StoredProcedure;

                            OracleParameter cursor = new OracleParameter("vCursor", OracleDbType.RefCursor)
                            {
                                Direction = ParameterDirection.ReturnValue
                            };
                            productListCmd.Parameters.Add(cursor);

                            productListCmd.Parameters.Add("pSupplierID", OracleDbType.Varchar2).Value = UserState.Instance.GetUserId();

                            using OracleDataReader reader = productListCmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    NameTextBox.Text = reader["Name"].ToString();
                                    EmailTextBox.Text = reader["Email"].ToString();
                                    PhoneTextBox.Text = reader["Phone"].ToString();
                                    AddressTextBox.Text = reader["Address"].ToString();
                                }
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
                    break;
            }
        }

        private string UpdateSupplierProfile()
        {
            string updatedSupplierID = null;

            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand cmd = new("Update_Supplier_Profile", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter SupplierID = new OracleParameter("vSupplierID", OracleDbType.Varchar2, 32)
                {
                    Direction = ParameterDirection.ReturnValue,
                };
                cmd.Parameters.Add(SupplierID);


                cmd.Parameters.Add("pSupplierID", OracleDbType.Varchar2).Value = UserState.Instance.GetUserId();
                cmd.Parameters.Add("pName", OracleDbType.Varchar2).Value = NameTextBox.Text.Trim();
                cmd.Parameters.Add("pEmail", OracleDbType.Varchar2).Value = EmailTextBox.Text.Trim();
                cmd.Parameters.Add("pPhone", OracleDbType.Varchar2).Value = PhoneTextBox.Text.Trim();
                cmd.Parameters.Add("pAddress", OracleDbType.Varchar2).Value = AddressTextBox.Text.Trim();

                cmd.ExecuteNonQuery();

                updatedSupplierID = SupplierID.Value.ToString();
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

            return updatedSupplierID;
        }

        private string UpdateCustomerProfile()
        {
            string updatedCustomerID = null;

            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand cmd = new("Update_Customer_Profile", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter CustomerID = new OracleParameter("vCustomerID", OracleDbType.Varchar2, 32)
                {
                    Direction = ParameterDirection.ReturnValue,
                };
                cmd.Parameters.Add(CustomerID);


                cmd.Parameters.Add("pCustomerID", OracleDbType.Varchar2).Value = UserState.Instance.GetUserId();
                cmd.Parameters.Add("pName", OracleDbType.Varchar2).Value = NameTextBox.Text.Trim();
                cmd.Parameters.Add("pEmail", OracleDbType.Varchar2).Value = EmailTextBox.Text.Trim();
                cmd.Parameters.Add("pPhone", OracleDbType.Varchar2).Value = PhoneTextBox.Text.Trim();
                cmd.Parameters.Add("pAddress", OracleDbType.Varchar2).Value = AddressTextBox.Text.Trim();

                cmd.ExecuteNonQuery();

                updatedCustomerID = CustomerID.Value.ToString();
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

            return updatedCustomerID;
        }

        private bool ValidateSignupTextBoxes()
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MaterialMessageBox.Show("Name cannot be empty.", "Validation Error");
                return false;
            }

            if (!IsValidEmail(EmailTextBox.Text))
            {
                MaterialMessageBox.Show("Email format is invalid.", "Validation Error");
                return false;
            }

            if (!IsValidPhone(PhoneTextBox.Text))
            {
                MaterialMessageBox.Show("Phone number format is invalid.", "Validation Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(AddressTextBox.Text))
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
    }
}
