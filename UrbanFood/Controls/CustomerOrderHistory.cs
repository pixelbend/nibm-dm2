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

namespace UrbanFood.Controls
{
    public partial class CustomerOrderHistory : UserControl
    {
        public CustomerOrderHistory()
        {
            InitializeComponent();
        }

        private void CustomerOrderHistory_Load(object sender, EventArgs e)
        {
            PopulateCustomerOrderHistoryList();
        }

        private void PopulateCustomerOrderHistoryList()
        {
            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand inventoryListCmd = new("List_Order_History_By_Customer", conn);
                inventoryListCmd.CommandType = CommandType.StoredProcedure;

                OracleParameter cursor = new OracleParameter("vCursor", OracleDbType.RefCursor)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                inventoryListCmd.Parameters.Add(cursor);


                inventoryListCmd.Parameters.Add("pCustomerID", OracleDbType.Varchar2).Value = UserState.Instance.GetUserId();

                using OracleDataReader reader = inventoryListCmd.ExecuteReader();

                CustomerOrderHistoyListPanel.Controls.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CustomerOrderHistoryItem item = new()
                        {
                            OrderID = reader["OrderID"].ToString(),
                            OrderDate = reader["OrderDate"].ToString(),
                            OrderStatus = reader["Status"].ToString(),
                            OrderTotal = reader["TotalAmount"].ToString(),
                        };

                        CustomerOrderHistoyListPanel.Controls.Add(item);
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
