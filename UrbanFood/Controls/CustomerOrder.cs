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
using System.Diagnostics;
using MaterialSkin.Controls;
using UrbanFood.Utils;

namespace UrbanFood.Controls
{
    public partial class CustomerOrder : UserControl
    {
        private string orderID;
        private string orderStatus;
        private string orderDate;
        private string orderTotal;

        public CustomerOrder()
        {
            InitializeComponent();
            GetPendingOrderByCustomerQuery();
            ListOrderItemsByOrderQuery();
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }

        private void Referesh_Order(object sender, EventArgs e)
        {
            GetPendingOrderByCustomerQuery();
        }

        private void GetPendingOrderByCustomerQuery()
        {
            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand orderListCmd = new("Get_Pending_Orders_By_Customer", conn);
                orderListCmd.CommandType = CommandType.StoredProcedure;

                OracleParameter cursor = new OracleParameter("vCursor", OracleDbType.RefCursor)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                orderListCmd.Parameters.Add(cursor);

                orderListCmd.Parameters.Add("pCustomerID", OracleDbType.Varchar2).Value = UserState.Instance.GetUserId();

                using OracleDataReader reader = orderListCmd.ExecuteReader();

                CustomerOrderListPanel.Controls.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        orderID = reader["OrderID"].ToString();
                        orderStatus = reader["Status"].ToString();
                        orderDate = reader["OrderDate"].ToString();
                        orderTotal = reader["OrderTotal"].ToString();

                        OrderDateLabel.Text = $"Date: {orderDate.Split(' ')[0]}";
                        OrderTotalLabel.Text = $"Total: Rs {orderTotal}";
                        OrderStatusLabel.Text = $"Status: {orderStatus}";
                    }
                } else
                {
                    OrderDateLabel.Text = "Date: N/A";
                    OrderDateLabel.Font = new("Segoe UI", 12, FontStyle.Regular);
                    OrderTotalLabel.Text = "Total: Rs 0";
                    OrderTotalLabel.Font = new("Segoe UI", 12, FontStyle.Regular);
                    OrderStatusLabel.Text = "Status: No Pending Orders";
                    OrderStatusLabel.Font = new("Segoe UI", 12, FontStyle.Regular);
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


        private void ListOrderItemsByOrderQuery()
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

                orderListCmd.Parameters.Add("pOrderID", OracleDbType.Varchar2).Value = orderID;
                orderListCmd.Parameters.Add("pStatus", OracleDbType.Varchar2).Value = DBNull.Value;

                using OracleDataReader reader = orderListCmd.ExecuteReader();

                CustomerOrderListPanel.Controls.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CustomerOrderItem item = new()
                        {
                            OrderItemID = reader["OrderItemID"].ToString(),
                            OrderItemQuantity = $"No Units: {reader["Quantity"].ToString()}",
                            ProductPrice = $"Unit Price Rs: {reader["Price"].ToString()}",
                            OrderItemTotal = $"Total Rs: {Convert.ToInt32(reader["Quantity"].ToString()) * Convert.ToDecimal(reader["Price"].ToString())}",
                            OrderItemStatus = reader["Status"].ToString(),
                            ProductName = reader["Name"].ToString(),
                            ProductDescription = reader["Description"] == DBNull.Value ? "No Description" : reader["Description"].ToString(),
                            ProductCategory = reader["Category"] == DBNull.Value ? "Category: N/A" : $"Category: {reader["Category"].ToString()}"
                        };

                        item.Dock = DockStyle.Top;

                        item.OrderItemUpdated += Referesh_Order;
                        item.OrderItemRemoved += Referesh_Order;

                        CustomerOrderListPanel.Controls.Add(item);
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
