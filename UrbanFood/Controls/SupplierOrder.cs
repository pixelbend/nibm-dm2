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
using UrbanFood.LocalState;
using UrbanFood.Utils;

namespace UrbanFood.Controls
{
    public partial class SupplierOrder : UserControl
    {
        public SupplierOrder()
        {
            InitializeComponent();
        }

        private void PopulateCustomerOrderList()
        {
            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand orderListCmd = new("List_Orders_By_Supplier", conn);
                orderListCmd.CommandType = CommandType.StoredProcedure;

                OracleParameter cursor = new OracleParameter("vCursor", OracleDbType.RefCursor)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                orderListCmd.Parameters.Add(cursor);

                orderListCmd.Parameters.Add("pSupplierID", OracleDbType.Varchar2).Value = UserState.Instance.GetUserId();

                if (StatusComboBox.SelectedItem == null || StatusComboBox.SelectedItem.ToString() == "")
                {
                    orderListCmd.Parameters.Add("pStatus", OracleDbType.Varchar2).Value = DBNull.Value;
                }
                else
                {
                    orderListCmd.Parameters.Add("pStatus", OracleDbType.Varchar2).Value = StatusComboBox.Text;
                }

                using OracleDataReader reader = orderListCmd.ExecuteReader();

                SupplierOrderListPanel.Controls.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CustomerOrderItem item = new()
                        {
                            OrderID = reader["OrderID"].ToString(),
                            OrderUnits = $"No Units: {reader["Quantity"].ToString()}",
                            ProductPrice = $"Unit Price Rs: {reader["Price"].ToString()}",
                            OrderTotal = $"Total Rs: {Convert.ToInt32(reader["Quantity"].ToString()) * Convert.ToDecimal(reader["Price"].ToString())}",
                            OrderStatus = reader["Status"].ToString(),
                            OrderDate = reader["OrderDate"].ToString(),
                            ProductName = reader["Name"].ToString(),
                            ProductDescription = reader["Description"] == DBNull.Value ? "No Description" : reader["Description"].ToString(),
                            ProductCategory = reader["Category"] == DBNull.Value ? "Category: N/A" : $"Category: {reader["Category"].ToString()}"
                        };

                        SupplierOrderListPanel.Controls.Add(item);
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
