using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrbanFood.Controls
{
    public partial class CustomerOrderHistoryDetailItem : UserControl
    {
        private string _orderItemQuantity;
        private string _orderTotal;
        private string _orderStatus;
        private string _productName;
        private string _productPrice;

        public CustomerOrderHistoryDetailItem()
        {
            InitializeComponent();
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
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; ProductNameLable.Text = _productName; }
        }

        [Category("Custom Props")]
        public string ProductPrice
        {
            get { return _productPrice; }
            set { _productPrice = value; UnitPriceLabel.Text = _productPrice; }
        }
    }
}
