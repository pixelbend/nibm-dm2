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
using UrbanFood.Forms;
using UrbanFood.LocalState;
using MaterialSkin.Controls;
using UrbanFood.Utils;

namespace UrbanFood.Controls
{
    public partial class SupplierInventory : UserControl
    {
        private System.Windows.Forms.Timer searchTimer;
        private const int debounceDelay = 1000;

        public SupplierInventory()
        {
            InitializeComponent();
            PopulateInvetoryProductList();
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = debounceDelay;
            searchTimer.Tick += SearchTimer_Tick;
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new();
            addProduct.FormClosed += AddProduct_FormClosed;
            addProduct.ShowDialog();
        }

        private void AddProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            PopulateInvetoryProductList();
        }

        private void InventorySearchBox_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            PopulateInvetoryProductList();
        }


        private void InventoryProductComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateInvetoryProductList();
        }

        private void InventoryStockComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateInvetoryProductList();
        }

        private void PopulateInvetoryProductList()
        {
            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand inventoryListCmd = new("List_Inventory_Products", conn);
                inventoryListCmd.CommandType = CommandType.StoredProcedure;

                OracleParameter cursor = new OracleParameter("vCursor", OracleDbType.RefCursor)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                inventoryListCmd.Parameters.Add(cursor);


                inventoryListCmd.Parameters.Add("pSupplierID", OracleDbType.Varchar2).Value = UserState.Instance.GetUserId();

                if (InventoryProductComboBox.SelectedItem == null || InventoryProductComboBox.SelectedItem.ToString() == "")
                {
                    inventoryListCmd.Parameters.Add("pCategory", OracleDbType.Varchar2).Value = DBNull.Value;
                }
                else
                {
                    inventoryListCmd.Parameters.Add("pCategory", OracleDbType.Varchar2).Value = InventoryProductComboBox.SelectedItem.ToString();
                }

                if (InventorySearchBox.TextLength == 0)
                {
                    inventoryListCmd.Parameters.Add("pName", OracleDbType.Varchar2).Value = DBNull.Value;
                }
                else
                {
                    inventoryListCmd.Parameters.Add("pName", OracleDbType.Varchar2).Value = InventorySearchBox.Text;
                }

                if (InventoryStockComboBox.SelectedItem == null)
                {
                    inventoryListCmd.Parameters.Add("pStockAvailable", OracleDbType.Int32).Value = DBNull.Value;
                }
                else
                {
                    switch (InventoryStockComboBox.SelectedItem.ToString())
                    {
                        case "In Stock":
                            inventoryListCmd.Parameters.Add("pStockAvailable", OracleDbType.Int32).Value = 1;
                            break;
                        case "Out of Stock":
                            inventoryListCmd.Parameters.Add("pStockAvailable", OracleDbType.Int32).Value = 0;
                            break;
                        default:
                            inventoryListCmd.Parameters.Add("pStockAvailable", OracleDbType.Int32).Value = DBNull.Value;
                            break;
                    }
                }



                using OracleDataReader reader = inventoryListCmd.ExecuteReader();

                InventoryListPanel.Controls.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SupplierInventoryItem item = new()
                        {
                            ProductID = reader["ProductID"].ToString(),
                            ProductName = reader["Name"].ToString(),
                            ProductDescription = reader["Description"] == DBNull.Value ? "No Description" : reader["Description"].ToString(),
                            ProductStockQuantity = reader["StockQuantity"].ToString(),
                            ProductPrice = reader["Price"].ToString(),
                            ProductCatogory = reader["Category"] == DBNull.Value ? "Category: N/A" : $"Category: {reader["Category"].ToString()}"
                        };

                        InventoryListPanel.Controls.Add(item);
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
