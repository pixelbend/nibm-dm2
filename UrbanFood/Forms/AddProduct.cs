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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UrbanFood.Forms
{
    public partial class AddProduct : MaterialForm
    {
        public AddProduct()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
        }

        private void ProductAddButton_Click(object sender, EventArgs e)
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
            string supplierID = UserState.Instance.GetUserId();

            string newProductId = CreateProductQuery(supplierID, name, description, price, stockQuantity, category);

            if (!string.IsNullOrEmpty(newProductId))
            {
                MaterialMessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
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

        public string CreateProductQuery(string supplierId, string name, string description, decimal price, int stockQuantity, string category)
        {
            string productId = null;

            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand cmd = new("Create_Product", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                OracleParameter productIdParam = new OracleParameter("vProductId", OracleDbType.Varchar2, 32)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                cmd.Parameters.Add(productIdParam);

                cmd.Parameters.Add("pSupplierId", OracleDbType.Varchar2).Value = supplierId;
                cmd.Parameters.Add("pName", OracleDbType.Varchar2).Value = name;
                cmd.Parameters.Add("pDescription", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(description) ? DBNull.Value : description;
                cmd.Parameters.Add("pPrice", OracleDbType.Decimal).Value = price;
                cmd.Parameters.Add("pStockQuantity", OracleDbType.Int32).Value = stockQuantity;
                cmd.Parameters.Add("pCategory", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(category) ? DBNull.Value : category;

                cmd.ExecuteNonQuery();

                productId = productIdParam.Value?.ToString();
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

            return productId;
        }
}
}
