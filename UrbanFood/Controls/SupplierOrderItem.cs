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
    public partial class SupplierOrderItem : UserControl
    {
        private string _orderItemID;
        private string _orderUnits;
        private string _orderTotal;
        private string _orderStatus;
        private string _orderDate;
        private string _productPrice;
        private string _productName;
        private string _productCategory;
        
        public SupplierOrderItem()
        {
            InitializeComponent();
        }

        [Category("Custom Props")]
        public string OrderItemID
        {
            get { return _orderItemID; }
            set { _orderItemID = value; OrderIDLabel.Text = $"Id: {_orderItemID}"; }
        }

        [Category("Custom Props")]
        public string OrderItemUnits
        {
            get { return _orderUnits; }
            set { _orderUnits = value; NoUnitsLabel.Text = _orderUnits; }
        }

        [Category("Custom Props")]
        public string OrderItemTotal
        {
            get { return _orderTotal; }
            set { _orderTotal = value; TotalLabel.Text = $"Total Rs: {_orderTotal}"; }
        }

        [Category("Custom Props")]
        public string OrderItemStatus
        {
            get { return _orderStatus; }
            set
            {
                _orderStatus = value;
                OrderStatusLable.Text = $"Status: {_orderStatus}";
                SetButtonState(_orderStatus);
            }
        }

        [Category("Custom Props")]
        public string OrderItemDate
        {
            get { return _orderDate; }
            set { _orderDate = value; OrderDateLable.Text = $"Date: {_orderDate}"; }
        }

        [Category("Custom Props")]
        public string ProductPrice
        {
            get { return _productPrice; }
            set { _productPrice = value; UnitPriceLabel.Text = _productPrice; }
        }

        [Category("Custom Props")]
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; ProductNameLable.Text = _productName; }
        }

        [Category("Custom Props")]
        public string ProductCategory
        {
            get { return _productCategory; }
            set { _productCategory = value; CategoryLable.Text = _productCategory; }
        }

        private void SupplierOrderItem_Load(object sender, EventArgs e)
        {
         
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var result = MaterialMessageBox.Show("This order will be canceled this cannot be undone", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                string qresult = CancelOrderItemQuery();
                if (qresult != null)
                {
                    Dispose();
                }
            }
        }

        private void FulfillButton_Click(object sender, EventArgs e)
        {
            string qresult = FulfillOrderItemQuery();
            if (qresult != null)
            {
                Dispose();
            }
        }

        private void DeliverButton_Click(object sender, EventArgs e)
        {
            string qresult = DeliverOrderItemQuery();
            if (qresult != null)
            {
                Dispose();
            }
        }

        public void SetButtonState(string state)
        {
            switch (state)
            {
                case "Confirmed":
                    CancelButton.Enabled = true;
                    FulfillButton.Enabled = true;
                    DeliverButton.Enabled = false;
                    DeliverButton.Visible = false;
                    break;
                case "Canceled":
                    CancelButton.Enabled = false;
                    CancelButton.Visible = false;
                    FulfillButton.Enabled = false;
                    FulfillButton.Visible = false;
                    DeliverButton.Enabled = false;
                    DeliverButton.Visible = false;
                    break;
                case "Fulfilled":
                    CancelButton.Enabled = false;
                    CancelButton.Visible = false;
                    FulfillButton.Enabled = false;
                    FulfillButton.Visible = false;
                    DeliverButton.Enabled = true;
                    DeliverButton.Visible = true;
                    break;
                case "Delivered":
                    CancelButton.Enabled = false;
                    CancelButton.Visible = false;
                    FulfillButton.Enabled = false;
                    FulfillButton.Visible = false;
                    DeliverButton.Enabled = false;
                    DeliverButton.Visible = false;
                    break;
                default:
                    CancelButton.Enabled = false;
                    FulfillButton.Enabled = false;
                    DeliverButton.Enabled = false;
                    break;
            }
        }

        private string CancelOrderItemQuery()
        {
            string canceledOrderItemId = null;

            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand customerCancleOrderCmd = new("Supplier_Cancel_OrderItem", conn);
                customerCancleOrderCmd.CommandType = CommandType.StoredProcedure;

                OracleParameter resultParam = new OracleParameter("vOrderItemID", OracleDbType.Varchar2, 32)
                {
                    Direction = ParameterDirection.ReturnValue
                };

                customerCancleOrderCmd.Parameters.Add(resultParam);

                customerCancleOrderCmd.Parameters.Add("pSupplierID", OracleDbType.Varchar2).Value = UserState.Instance.GetUserId();
                customerCancleOrderCmd.Parameters.Add("pOrderItemID", OracleDbType.Varchar2).Value = _orderItemID;
                customerCancleOrderCmd.ExecuteNonQuery();

                canceledOrderItemId = resultParam.Value?.ToString();
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

            return canceledOrderItemId;
        }

        private string FulfillOrderItemQuery()
        {
            string fullfiledOrderItemId = null;

            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand customerCancleOrderCmd = new("Supplier_Fulfill_OrderItem", conn);
                customerCancleOrderCmd.CommandType = CommandType.StoredProcedure;

                OracleParameter resultParam = new OracleParameter("vOrderItemID", OracleDbType.Varchar2, 32)
                {
                    Direction = ParameterDirection.ReturnValue
                };

                customerCancleOrderCmd.Parameters.Add(resultParam);

                customerCancleOrderCmd.Parameters.Add("pSupplierID", OracleDbType.Varchar2).Value = UserState.Instance.GetUserId();
                customerCancleOrderCmd.Parameters.Add("pOrderItemID", OracleDbType.Varchar2).Value = _orderItemID;
                customerCancleOrderCmd.ExecuteNonQuery();

                fullfiledOrderItemId = resultParam.Value?.ToString();
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

            return fullfiledOrderItemId;
        }

        private string DeliverOrderItemQuery()
        {
            string deliveredOrderItemId = null;

            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand customerCancleOrderCmd = new("Supplier_Deliver_OrderItem", conn);
                customerCancleOrderCmd.CommandType = CommandType.StoredProcedure;

                OracleParameter resultParam = new OracleParameter("vOrderItemID", OracleDbType.Varchar2, 32)
                {
                    Direction = ParameterDirection.ReturnValue
                };

                customerCancleOrderCmd.Parameters.Add(resultParam);

                customerCancleOrderCmd.Parameters.Add("pSupplierID", OracleDbType.Varchar2).Value = UserState.Instance.GetUserId();
                customerCancleOrderCmd.Parameters.Add("pOrderItemID", OracleDbType.Varchar2).Value = _orderItemID;
                customerCancleOrderCmd.ExecuteNonQuery();

                deliveredOrderItemId = resultParam.Value?.ToString();
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

            return deliveredOrderItemId;
        }
    }
}
