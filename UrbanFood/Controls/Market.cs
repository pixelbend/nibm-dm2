using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using UrbanFood.Database.OracleDB;
using UrbanFood.LocalState;
using MaterialSkin.Controls;
using UrbanFood.Utils;

namespace UrbanFood.Controls
{
    public partial class Market : UserControl
    {
        private System.Windows.Forms.Timer searchTimer;
        private const int debounceDelay = 1000;

        public Market()
        {
            InitializeComponent();
            PopulateInvetoryProductList();
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = debounceDelay;
            searchTimer.Tick += SearchTimer_Tick;
        }

        private void ProductSearchBox_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            PopulateInvetoryProductList();
        }

        private void ProductComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateInvetoryProductList();
        }

        private void InStockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PopulateInvetoryProductList();
        }

        private void PopulateInvetoryProductList()
        {
            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand productListCmd = new("List_Products", conn);
                productListCmd.CommandType = CommandType.StoredProcedure;

                OracleParameter cursor = new OracleParameter("vCursor", OracleDbType.RefCursor)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                productListCmd.Parameters.Add(cursor);

                if (ProductComboBox.SelectedItem == null || ProductComboBox.SelectedItem.ToString() == "")
                {
                    productListCmd.Parameters.Add("pCategory", OracleDbType.Varchar2).Value = DBNull.Value;
                }
                else
                {
                    productListCmd.Parameters.Add("pCategory", OracleDbType.Varchar2).Value = ProductComboBox.Text;
                }

                if (ProductSearchBox.TextLength == 0)
                {
                    productListCmd.Parameters.Add("pName", OracleDbType.Varchar2).Value = DBNull.Value;
                }
                else
                {
                    productListCmd.Parameters.Add("pName", OracleDbType.Varchar2).Value = ProductSearchBox.Text;
                }

                if (InStockCheckBox.Checked)
                {
                    productListCmd.Parameters.Add("pStockAvailable", OracleDbType.Int32).Value = 1;
                }
                else
                {
                    productListCmd.Parameters.Add("pStockAvailable", OracleDbType.Int32).Value = DBNull.Value;
                }



                using OracleDataReader reader = productListCmd.ExecuteReader();

                ProductListPanel.Controls.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MarketListingItem item = new()
                        {
                            ProductID = reader["ProductID"].ToString(),
                            ProductName = reader["Name"].ToString(),
                            ProductDescription = reader["Description"] == DBNull.Value ? "No Description" : reader["Description"].ToString(),
                            ProductStockQuantity = reader["StockQuantity"].ToString(),
                            ProductPrice = reader["Price"].ToString(),
                            ProductCatogory = reader["Category"] == DBNull.Value ? "Category: N/A" : $"Category: {reader["Category"].ToString()}"
                        };

                        ProductListPanel.Controls.Add(item);
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
    }
}
