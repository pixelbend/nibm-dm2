using MaterialSkin.Controls;
using MongoDB.Bson;
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
using UrbanFood.Utils;

namespace UrbanFood.Forms
{
    public partial class UpdateProductReview : MaterialForm
    {
        private string _reviewID;

        public UpdateProductReview(string reviewID)
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            _reviewID = reviewID;
        }

        private void UpdateProductReview_Load(object sender, EventArgs e)
        {
            var filter = Builders<ReviewModel>.Filter.Eq(r => r.Id, ObjectId.Parse(_reviewID));
            var collection = ReviewCollection.Instance.GetCollection();
            var review = collection.Find(filter).FirstOrDefault();
            if (review != null) { 
                ReviewTextBox.Text = review.Content;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ReviewTextBox.Text))
            {
                MaterialMessageBox.Show("Please enter a review.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var filter = Builders<ReviewModel>.Filter.Eq(r => r.Id, ObjectId.Parse(_reviewID));
            var update = Builders<ReviewModel>.Update.Set(r => r.Content, ReviewTextBox.Text.Trim());
            var collection = ReviewCollection.Instance.GetCollection();
            var result = collection.UpdateOne(filter, update);
            if (result.IsAcknowledged)
            {
                Close();
            }
            else
            {
                MaterialMessageBox.Show("Failed to update review.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
