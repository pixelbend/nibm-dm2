using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrbanFood.Controls
{
    public partial class SupplierOrderItem: UserControl
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

        public SupplierOrderItem()
        {
            InitializeComponent();
        }
    }
}
