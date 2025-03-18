using MaterialSkin.Controls;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UrbanFood.Database.OracleDB;
using UrbanFood.LocalState;
using UrbanFood.Utils;

namespace UrbanFood.Forms
{
    public partial class UpdateProduct : MaterialForm
    {
        private string _productID;

        public UpdateProduct(string productId)
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            _productID = productId;
            PopulateProductData();
        }

        private void ProductStockQuantityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ProductPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == '.' && ProductPriceTextBox.Text.Contains("."))
            {
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }


        private void UpdateProductButton_Click(object sender, EventArgs e)
        {
            string name = ProductNameTextBox.Text.Trim();
            string description = ProductDescriptionTextBox.Text.Trim();
            string stockText = ProductStockQuantityTextBox.Text.Trim();
            string priceText = ProductPriceTextBox.Text.Trim();
            string category = ProductCategoryComboBox.SelectedItem?.ToString().ToLower();

            if (!ValidateProductInputs(name, priceText, stockText, category))
            {
                return;
            }

            decimal price = Convert.ToDecimal(priceText);
            int stockQuantity = Convert.ToInt32(stockText);
            string supplierId = UserState.Instance.GetUserId();

            string updatedProductId = UpdateProductQuery(_productID, name, description, price, stockQuantity, category);

            if (!string.IsNullOrEmpty(updatedProductId))
            {
                MaterialMessageBox.Show("Product Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void PopulateProductData()
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
                    ProductNameTextBox.Text = reader["Name"].ToString();
                    ProductDescriptionTextBox.Text = reader["Description"].ToString();
                    ProductStockQuantityTextBox.Text = reader["StockQuantity"].ToString();
                    ProductPriceTextBox.Text = reader["Price"].ToString();
                    string category = reader["Category"].ToString().ToLower();
                    int index = ProductCategoryComboBox.Items.IndexOf(category);
                    if (index != -1)
                    {
                        ProductCategoryComboBox.SelectedIndex = index;
                    }
                    else
                    {
                        ProductCategoryComboBox.SelectedIndex = 0;
                    }
                }
                else
                {
                    Close();
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

        private bool ValidateProductInputs(string name, string priceText, string stockText, string category)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MaterialMessageBox.Show("Product name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(priceText, out decimal price) || price <= 0)
            {
                MaterialMessageBox.Show("Enter a valid price greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(stockText, out int stock) || stock < 0)
            {
                MaterialMessageBox.Show("Stock quantity must be a valid non-negative number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string[] validCategories = { "vegetables", "fruits", "dairy products", "baked goods", "handmade crafts" };
            if (!string.IsNullOrEmpty(category) && !validCategories.Contains(category))
            {
                MaterialMessageBox.Show("Invalid category. Allowed values: vegetable, fruit, dairy, baked, craft.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public string UpdateProductQuery(string productId, string name, string description, decimal? price, int? stockQuantity, string category)
        {
            string updatedProductId = null;

            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand cmd = new("Update_Product", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                OracleParameter productIdParam = new OracleParameter("vProductId", OracleDbType.Varchar2, 32)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                cmd.Parameters.Add(productIdParam);

                cmd.Parameters.Add("pSupplierId", OracleDbType.Varchar2).Value = UserState.Instance.GetUserId();
                cmd.Parameters.Add("pProductId", OracleDbType.Varchar2).Value = productId;
                cmd.Parameters.Add("pName", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(name) ? DBNull.Value : name;
                cmd.Parameters.Add("pDescription", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(description) ? DBNull.Value : description;
                cmd.Parameters.Add("pPrice", OracleDbType.Decimal).Value = price.HasValue ? (object)price.Value : DBNull.Value;
                cmd.Parameters.Add("pStockQuantity", OracleDbType.Int32).Value = stockQuantity.HasValue ? (object)stockQuantity.Value : DBNull.Value;
                cmd.Parameters.Add("pCategory", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(category) ? DBNull.Value : category;

                cmd.ExecuteNonQuery();

                updatedProductId = productIdParam.Value?.ToString();
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

            return updatedProductId;
        }
    }
}
