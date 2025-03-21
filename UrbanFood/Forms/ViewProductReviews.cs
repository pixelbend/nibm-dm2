using MaterialSkin.Controls;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrbanFood.Controls;
using UrbanFood.Database.MongoDB;
using UrbanFood.Utils;

namespace UrbanFood.Forms
{
    public partial class ViewProductReviews : MaterialForm
    {
        private string _productID;
        private System.Windows.Forms.Timer searchTimer;
        private const int debounceDelay = 1000;

        public ViewProductReviews(string productID)
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            _productID = productID;
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = debounceDelay;
            searchTimer.Tick += SearchTimer_Tick;
        }

        private void ViewProductReviews_Load(object sender, EventArgs e)
        {
            ListProductReviews();
        }

        private void SearchReviewsTextBox_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void ProductReviewsButton_Click(object sender, EventArgs e)
        {
            AddProductReview addProductReview = new(_productID);
            addProductReview.FormClosed += AddProductReview_FormClosed;
            addProductReview.ShowDialog();
        }

        private void AddProductReview_FormClosed(object sender, FormClosedEventArgs e)
        {
            ListProductReviews();
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            ListProductReviews();
        }

        private void ListProductReviews()
        {
            var collection = ReviewCollection.Instance.GetCollection();
            var filterBuilder = Builders<ReviewModel>.Filter;

            var filter = filterBuilder.Eq(r => r.ProductID, _productID);

            if (!string.IsNullOrWhiteSpace(SearchReviewsTextBox.Text))
            {
                var searchTerm = SearchReviewsTextBox.Text.Trim();

                var searchFilter = filterBuilder.Text(searchTerm);

                filter = filterBuilder.And(filter, searchFilter);
            }

            var reviews = collection.Find(filter).ToList();

            if (reviews.Count != 0)
            {
                ReviewListPanel.Controls.Clear();

                foreach (var review in reviews)
                {
                    var productReviewItem = new ProductReviewItem
                    {
                        ProductID = review.ProductID,
                        ReviewID = review.Id.ToString(),
                        CustomerID = review.CustomerID,
                        Content = review.Content,
                        CreatedAt = review.CreatedAt
                    };

                    ReviewListPanel.Controls.Add(productReviewItem);
                }
            }
        }
    }
}
