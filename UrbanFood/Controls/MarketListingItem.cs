using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrbanFood.Forms;
using MaterialSkin.Controls;
using Oracle.ManagedDataAccess.Client;
using UrbanFood.Database.OracleDB;
using UrbanFood.Utils;

namespace UrbanFood.Controls
{
    public partial class MarketListingItem : UserControl
    {
        private string _productID;
        private string _productName;
        private string _productDescription;
        private string _productStockQuantity;
        private string _productPrice;
        private string _productCatogory;

        public MarketListingItem()
        {
            InitializeComponent();
        }

        private void MarketListingItem_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(_productStockQuantity) == 0)
            {
                BuyButton.Enabled = false;
            }
        }


        [Category("Custom Props")]
        public string ProductID
        {
            get { return _productID; }
            set { _productID = value; }
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
        public string ProductStockQuantity
        {
            get { return _productStockQuantity; }
            set { _productStockQuantity = value; ProdcutQuantityLable.Text = $"Available Stock : {_productStockQuantity}"; }
        }

        [Category("Custom Props")]
        public string ProductPrice
        {
            get { return _productPrice; }
            set { _productPrice = value; PriceLable.Text = $"Unit Price Rs: {_productPrice}"; }
        }

        [Category("Custom Props")]
        public string ProductCatogory
        {
            get { return _productCatogory; }
            set { _productCatogory = value; CategoryLable.Text = _productCatogory; }
        }

        private void ProdcutQuantityLable_Click(object sender, EventArgs e)
        {

        }

        private void ViewProductDetail_Click(object sender, EventArgs e)
        {
            ViewProductReviews viewProductReviews = new(_productID);
            viewProductReviews.ShowDialog();
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            OrderProduct OrderProduct = new(_productID);
            OrderProduct.ShowDialog();
        }
    }
}
