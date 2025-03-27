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
        private System.Windows.Forms.Timer searchTimer;
        private const int debounceDelay = 1000;

        public SupplierOrder()
        {
            InitializeComponent();
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = debounceDelay;
            searchTimer.Tick += SearchTimer_Tick;
        }

        private void SupplierOrder_Load(object sender, EventArgs e)
        {
            PopulateSupplierOrderList();
        }

        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSupplierOrderList();
        }

        private void OrderProductNameSearchBox_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            PopulateSupplierOrderList();
        }

        private void PopulateSupplierOrderList()
        {
            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand orderListCmd = new("List_OrderItems_By_Supplier", conn);
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

                if (OrderProductNameSearchBox.TextLength == 0)
                {
                    orderListCmd.Parameters.Add("pProductName", OracleDbType.Varchar2).Value = DBNull.Value;
                }
                else
                {
                    orderListCmd.Parameters.Add("pProductName", OracleDbType.Varchar2).Value = OrderProductNameSearchBox.Text;
                }

                using OracleDataReader reader = orderListCmd.ExecuteReader();

                SupplierOrderListPanel.Controls.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SupplierOrderItem item = new()
                        {

                            OrderItemID = reader["OrderItemID"].ToString(),
                            OrderItemUnits = $"No Units: {reader["Quantity"].ToString()}",
                            ProductPrice = $"Unit Price Rs: {reader["Price"].ToString()}",
                            OrderItemTotal = $"Total Rs: {Convert.ToInt32(reader["Quantity"].ToString()) * Convert.ToDecimal(reader["Price"].ToString())}",
                            OrderItemStatus = reader["OrderStatus"].ToString(),
                            OrderItemDate = reader["OrderDate"].ToString(),
                            ProductName = reader["Name"].ToString(),
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
