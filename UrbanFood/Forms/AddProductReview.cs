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
using UrbanFood.Database.MongoDB;
using UrbanFood.LocalState;
using UrbanFood.Utils;

namespace UrbanFood.Forms
{
    public partial class AddProductReview : MaterialForm
    {
        private string _productID;

        public AddProductReview(string productID)
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            _productID = productID;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ReviewTextBox.Text))
            {
                MaterialMessageBox.Show("Please enter a review.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var reviewModel = new ReviewModel
            {
                ProductID = _productID,
                CustomerID = UserState.Instance.GetUserId(),
                Content = ReviewTextBox.Text.Trim()
            };

            string result = CreateProductReview(reviewModel);
            if (!string.IsNullOrWhiteSpace(result))
            {
                Close();
            }
            else
            {
                MaterialMessageBox.Show("An error occurred while saving the review.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string CreateProductReview(ReviewModel reviewModel)
        {
            try
            {
                var collection = ReviewCollection.Instance.GetCollection();
                collection.InsertOne(reviewModel);
            } catch (MongoWriteException ex)
            {
                if (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
                {
                    MaterialMessageBox.Show("You have already reviewed this product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MaterialMessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return reviewModel.Id.ToString();
        }
    }
}
