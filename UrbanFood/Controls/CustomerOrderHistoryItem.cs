using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrbanFood.Forms;

namespace UrbanFood.Controls
{
    public partial class CustomerOrderHistoryItem : UserControl
    {
        private string orderID;
        private string orderDate;
        private string orderTotal;
        private string orderStatus;

        public CustomerOrderHistoryItem()
        {
            InitializeComponent();
        }

        [Category("Custom Props")]
        public string OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        [Category("Custom Props")]
        public string OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; OrderDateLabel.Text = $"Date: {orderDate}"; }
        }

        [Category("Custom Props")]
        public string OrderTotal
        {
            get { return orderTotal; }
            set { orderTotal = value; OrderTotalLabel.Text = $"Total Rs: {orderTotal}"; }
        }

        [Category("Custom Props")]
        public string OrderStatus
        {
            get { return orderStatus; }
            set { orderStatus = value; OrderStatusLabel.Text = $"Status: {orderStatus}"; }
        }

        private void DetailsButton_Click(object sender, EventArgs e)
        {
            CustomerOrderHistoryDetail customerOrderHistoryDetail = new(orderID);
            customerOrderHistoryDetail.ShowDialog();
        }
    }
}
