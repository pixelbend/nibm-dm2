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
using UrbanFood.LocalState;

namespace UrbanFood.Controls
{
    public partial class ProductReviewItem : UserControl
    {
        private string _productID;
        private string _reviewID;
        private string _customerID;
        private string _content;
        private DateTime _createdAt;

        public ProductReviewItem()
        {
            InitializeComponent();
        }

        [Category("Custom Props")]
        public string ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        [Category("Custom Props")]
        public string ReviewID
        {
            get { return _reviewID; }
            set { _reviewID = value; }
        }

        [Category("Custom Props")]
        public string CustomerID
        {
            get { return _customerID; }
            set { 
                _customerID = value;
                SetEditButtonState(_customerID);
            }
        }

        [Category("Custom Props")]
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                ContentLabel.Text = _content;
            }
        }

        [Category("Custom Props")]
        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set
            {
                _createdAt = value;
                CreatedAtLabel.Text = _createdAt.ToString();
            }
        }

        private void ProductReviewItem_Load(object sender, EventArgs e)
        {

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            UpdateProductReview updateProductReview = new (_reviewID);
            updateProductReview.ShowDialog();
        }

        private void SetEditButtonState(string customerID)
        {
            if (customerID == UserState.Instance.GetUserId())
            {
                EditButton.Enabled = true;
                EditButton.Visible = true;
            }
            else
            {
                EditButton.Enabled = false;
                EditButton.Visible = false;
            }
        }
    }
}
