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
using UrbanFood.LocalState;
using Oracle.ManagedDataAccess.Client;
using UrbanFood.Database.OracleDB;
using UrbanFood.Utils;
using UrbanFood.Forms;

namespace UrbanFood.Controls
{
    public partial class CustomerOrderItem : UserControl
    {
        private string _orderID;
        private string _orderUnits;
        private string _orderTotal;
        private string _orderStatus;
        private string _orderDate;
        private string _productPrice;
        private string _productName;
        private string _productDescription;
        private string _productCategory;

        public CustomerOrderItem()
        {
            InitializeComponent();
        }

        private void CustomerOrderItem_Load(object sender, EventArgs e)
        {
            if (_orderStatus != "Pending")
            {
                CheckoutButton.Enabled = false;
                CheckoutButton.Visible = false;

                CancelButton.Enabled = false;
                CancelButton.Visible = false;
            }
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            CheckoutOrder checkoutOrder = new(_orderID);
            checkoutOrder.ConfirmButtonClicked += CheckoutOrder_ConfirmButtonClicked;
            checkoutOrder.ShowDialog();
        }

        private void CheckoutOrder_ConfirmButtonClicked(object sender, EventArgs e)
        {
            OrderStatusLable.Text = $"Status: Confirmed";
            CheckoutButton.Enabled = false;
            CheckoutButton.Visible = false;
            CancelButton.Enabled = false;
            CancelButton.Visible = false;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var result = MaterialMessageBox.Show("This order will be canceled this cannot be undone", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                string qresult = CancelOrderQuery(_orderID);
                if (qresult != null)
                {
                    OrderStatusLable.Text = $"Status: Canceled";
                }
            }
        }

        [Category("Custom Props")]
        public string OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        [Category("Custom Props")]
        public string OrderUnits
        {
            get { return _orderUnits; }
            set { _orderUnits = value; NoUnitsLabel.Text = _orderUnits; }
        }

        [Category("Custom Props")]
        public string OrderTotal
        {
            get { return _orderTotal; }
            set { _orderTotal = value; TotalLabel.Text = _orderTotal; }
        }

        [Category("Custom Props")]
        public string OrderStatus
        {
            get { return _orderStatus; }
            set { _orderStatus = value; OrderStatusLable.Text = $"Status: {_orderStatus}"; }
        }

        [Category("Custom Props")]
        public string OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; OrderDateLable.Text = $"Order Date: {_orderDate}"; }
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
        public string ProductDescription
        {
            get { return _productDescription; }
            set { _productDescription = value; ProductDescriptionLable.Text = _productDescription; }
        }

        [Category("Custom Props")]
        public string ProductCategory
        {
            get { return _productCategory; }
            set { _productCategory = value; CategoryLable.Text = _productCategory; }
        }

        public string CancelOrderQuery(string orderId)
        {
            string canceledOrderId = null;

            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand cmd = new("Customer_Cancel_Order", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                OracleParameter resultParam = new OracleParameter("result", OracleDbType.Varchar2, 32)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                cmd.Parameters.Add(resultParam);

                cmd.Parameters.Add("pCustomerId", OracleDbType.Varchar2).Value = UserState.Instance.GetUserId();

                cmd.Parameters.Add("pOrderId", OracleDbType.Varchar2).Value = orderId;

                cmd.ExecuteNonQuery();

                canceledOrderId = resultParam.Value?.ToString();
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

            return canceledOrderId;
        }
    }

}
