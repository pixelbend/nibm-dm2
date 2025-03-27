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
using UrbanFood.Controls;
using UrbanFood.Database.OracleDB;
using UrbanFood.Utils;

namespace UrbanFood.Forms
{
    public partial class CustomerOrderHistoryDetail : MaterialForm
    {
        private string _orderID;

        public CustomerOrderHistoryDetail(string orderID)
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            _orderID = orderID;
        }

        private void CustomerOrderHistoryDetail_Load(object sender, EventArgs e)
        {
            PopulateOrderItems();
        }

        public void PopulateOrderItems()
        {
            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand orderListCmd = new("List_OrderItems_By_Order", conn);
                orderListCmd.CommandType = CommandType.StoredProcedure;

                OracleParameter cursor = new OracleParameter("vCursor", OracleDbType.RefCursor)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                orderListCmd.Parameters.Add(cursor);

                orderListCmd.Parameters.Add("pOrderID", OracleDbType.Varchar2).Value = _orderID;
                orderListCmd.Parameters.Add("pStatus", OracleDbType.Varchar2).Value = DBNull.Value;

                using OracleDataReader reader = orderListCmd.ExecuteReader();

                OrderItemListPanel.Controls.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CustomerOrderHistoryDetailItem item = new()
                        {
                            OrderItemQuantity = $"No Units: {reader["Quantity"].ToString()}",
                            ProductPrice = $"Unit Price Rs: {reader["Price"].ToString()}",
                            OrderItemTotal = $"Total Rs: {Convert.ToInt32(reader["Quantity"].ToString()) * Convert.ToDecimal(reader["Price"].ToString())}",
                            OrderItemStatus = reader["Status"].ToString(),
                            ProductName = reader["Name"].ToString(),
                        };

                        item.Dock = DockStyle.Top;

                        OrderItemListPanel.Controls.Add(item);
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
