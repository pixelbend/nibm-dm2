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
        public event EventHandler OrderItemUpdated;
        public event EventHandler OrderItemRemoved;

        private string _orderItemID;
        private string _orderItemQuantity;
        private string _orderTotal;
        private string _orderStatus;
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

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var result = MaterialMessageBox.Show("This order itme will be removed this cannot be undone", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                string qresult = RemoveOrderItemQuery(_orderItemID);
                if (qresult != null)
                {
                    OrderItemRemoved?.Invoke(this, e);
                    Dispose();
                }
            }
        }

        [Category("Custom Props")]
        public string OrderItemID
        {
            get { return _orderItemID; }
            set { _orderItemID = value; }
        }

        [Category("Custom Props")]
        public string OrderItemQuantity
        {
            get { return _orderItemQuantity; }
            set { _orderItemQuantity = value; NoUnitsLabel.Text = _orderItemQuantity; }
        }

        [Category("Custom Props")]
        public string OrderItemTotal
        {
            get { return _orderTotal; }
            set { _orderTotal = value; TotalLabel.Text = _orderTotal; }
        }

        [Category("Custom Props")]
        public string OrderItemStatus
        {
            get { return _orderStatus; }
            set { _orderStatus = value; OrderStatusLable.Text = $"Status: {_orderStatus}"; }
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

        public string RemoveOrderItemQuery(string orderId)
        {
            string removedOrderItemId = null;

            try
            {
                OracleConnection conn = OracleDBConnection.Instance.GetConnection();

                using OracleCommand cmd = new("Customer_Remove_OrderItem", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                OracleParameter resultParam = new OracleParameter("vOrderID", OracleDbType.Varchar2, 32)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                cmd.Parameters.Add(resultParam);

                cmd.Parameters.Add("pCustomerID", OracleDbType.Varchar2).Value = UserState.Instance.GetUserId();

                cmd.Parameters.Add("pOrderId", OracleDbType.Varchar2).Value = orderId;

                cmd.ExecuteNonQuery();

                removedOrderItemId = resultParam.Value?.ToString();
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

            return removedOrderItemId;
        }
    }

}
