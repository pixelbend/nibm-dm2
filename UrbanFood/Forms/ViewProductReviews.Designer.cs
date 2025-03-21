namespace UrbanFood.Forms
{
    partial class ViewProductReviews
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ProductReviewsButton = new MaterialSkin.Controls.MaterialButton();
            ReviewListPanel = new FlowLayoutPanel();
            SearchReviewsTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ProductReviewsButton
            // 
            ProductReviewsButton.AutoSize = false;
            ProductReviewsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ProductReviewsButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            ProductReviewsButton.Depth = 0;
            ProductReviewsButton.HighEmphasis = true;
            ProductReviewsButton.Icon = null;
            ProductReviewsButton.Location = new Point(580, 611);
            ProductReviewsButton.Margin = new Padding(4, 6, 4, 6);
            ProductReviewsButton.MouseState = MaterialSkin.MouseState.HOVER;
            ProductReviewsButton.Name = "ProductReviewsButton";
            ProductReviewsButton.NoAccentTextColor = Color.Empty;
            ProductReviewsButton.Size = new Size(198, 45);
            ProductReviewsButton.TabIndex = 15;
            ProductReviewsButton.Text = "Add Review";
            ProductReviewsButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            ProductReviewsButton.UseAccentColor = false;
            ProductReviewsButton.UseVisualStyleBackColor = true;
            ProductReviewsButton.Click += ProductReviewsButton_Click;
            // 
            // ReviewListPanel
            // 
            ReviewListPanel.AutoScroll = true;
            ReviewListPanel.Location = new Point(23, 138);
            ReviewListPanel.Name = "ReviewListPanel";
            ReviewListPanel.Size = new Size(755, 452);
            ReviewListPanel.TabIndex = 16;
            // 
            // SearchReviewsTextBox
            // 
            SearchReviewsTextBox.AnimateReadOnly = false;
            SearchReviewsTextBox.BackgroundImageLayout = ImageLayout.None;
            SearchReviewsTextBox.CharacterCasing = CharacterCasing.Normal;
            SearchReviewsTextBox.Depth = 0;
            SearchReviewsTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            SearchReviewsTextBox.HideSelection = true;
            SearchReviewsTextBox.LeadingIcon = null;
            SearchReviewsTextBox.Location = new Point(81, 79);
            SearchReviewsTextBox.MaxLength = 32767;
            SearchReviewsTextBox.MouseState = MaterialSkin.MouseState.OUT;
            SearchReviewsTextBox.Name = "SearchReviewsTextBox";
            SearchReviewsTextBox.PasswordChar = '\0';
            SearchReviewsTextBox.PrefixSuffixText = null;
            SearchReviewsTextBox.ReadOnly = false;
            SearchReviewsTextBox.RightToLeft = RightToLeft.No;
            SearchReviewsTextBox.SelectedText = "";
            SearchReviewsTextBox.SelectionLength = 0;
            SearchReviewsTextBox.SelectionStart = 0;
            SearchReviewsTextBox.ShortcutsEnabled = true;
            SearchReviewsTextBox.Size = new Size(697, 48);
            SearchReviewsTextBox.TabIndex = 17;
            SearchReviewsTextBox.TabStop = false;
            SearchReviewsTextBox.TextAlign = HorizontalAlignment.Left;
            SearchReviewsTextBox.TrailingIcon = null;
            SearchReviewsTextBox.UseSystemPasswordChar = false;
            SearchReviewsTextBox.TextChanged += SearchReviewsTextBox_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.icons8_search_60;
            pictureBox1.Location = new Point(25, 79);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // ViewProductReviews
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 670);
            Controls.Add(pictureBox1);
            Controls.Add(SearchReviewsTextBox);
            Controls.Add(ReviewListPanel);
            Controls.Add(ProductReviewsButton);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ViewProductReviews";
            Sizable = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reviews";
            Load += ViewProductReviews_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private MaterialSkin.Controls.MaterialButton ProductReviewsButton;
        private FlowLayoutPanel ReviewListPanel;
        private MaterialSkin.Controls.MaterialTextBox2 SearchReviewsTextBox;
        private PictureBox pictureBox1;
    }
}