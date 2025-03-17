namespace UrbanFood.Controls
{
    partial class MarketListingItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketListingItem));
            ProductNameLable = new Label();
            ProductPictureBox = new PictureBox();
            ProdcutQuantityLable = new Label();
            ProductDescriptionLable = new Label();
            ViewProductReviews = new MaterialSkin.Controls.MaterialButton();
            ImageList = new ImageList(components);
            BuyButton = new MaterialSkin.Controls.MaterialButton();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            CategoryLable = new Label();
            PriceLable = new Label();
            ((System.ComponentModel.ISupportInitialize)ProductPictureBox).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // ProductNameLable
            // 
            ProductNameLable.AutoSize = true;
            ProductNameLable.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductNameLable.Location = new Point(241, 17);
            ProductNameLable.Name = "ProductNameLable";
            ProductNameLable.Size = new Size(252, 38);
            ProductNameLable.TabIndex = 0;
            ProductNameLable.Text = "ProductNameLable";
            // 
            // ProductPictureBox
            // 
            ProductPictureBox.BackColor = Color.Transparent;
            ProductPictureBox.Image = Properties.Resources.icons8_placeholder_96;
            ProductPictureBox.Location = new Point(17, 10);
            ProductPictureBox.Name = "ProductPictureBox";
            ProductPictureBox.Size = new Size(200, 180);
            ProductPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ProductPictureBox.TabIndex = 1;
            ProductPictureBox.TabStop = false;
            // 
            // ProdcutQuantityLable
            // 
            ProdcutQuantityLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProdcutQuantityLable.Location = new Point(241, 160);
            ProdcutQuantityLable.Name = "ProdcutQuantityLable";
            ProdcutQuantityLable.Size = new Size(301, 28);
            ProdcutQuantityLable.TabIndex = 5;
            ProdcutQuantityLable.Text = "ProdcutQuantityLable";
            ProdcutQuantityLable.Click += ProdcutQuantityLable_Click;
            // 
            // ProductDescriptionLable
            // 
            ProductDescriptionLable.BackColor = Color.Transparent;
            ProductDescriptionLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductDescriptionLable.Location = new Point(241, 57);
            ProductDescriptionLable.Name = "ProductDescriptionLable";
            ProductDescriptionLable.Size = new Size(449, 93);
            ProductDescriptionLable.TabIndex = 4;
            ProductDescriptionLable.Text = "ProductDescriptionLable";
            // 
            // ViewProductReviews
            // 
            ViewProductReviews.AutoSize = false;
            ViewProductReviews.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ViewProductReviews.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            ViewProductReviews.Depth = 0;
            ViewProductReviews.HighEmphasis = true;
            ViewProductReviews.Icon = null;
            ViewProductReviews.Location = new Point(992, 20);
            ViewProductReviews.Margin = new Padding(4, 6, 4, 6);
            ViewProductReviews.MouseState = MaterialSkin.MouseState.HOVER;
            ViewProductReviews.Name = "ViewProductReviews";
            ViewProductReviews.NoAccentTextColor = Color.Empty;
            ViewProductReviews.Size = new Size(123, 36);
            ViewProductReviews.TabIndex = 6;
            ViewProductReviews.Text = "Reviews";
            ViewProductReviews.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            ViewProductReviews.UseAccentColor = false;
            ViewProductReviews.UseVisualStyleBackColor = true;
            ViewProductReviews.Click += ViewProductDetail_Click;
            // 
            // ImageList
            // 
            ImageList.ColorDepth = ColorDepth.Depth32Bit;
            ImageList.ImageStream = (ImageListStreamer)resources.GetObject("ImageList.ImageStream");
            ImageList.TransparentColor = Color.Transparent;
            ImageList.Images.SetKeyName(0, "icons8-details-32.png");
            // 
            // BuyButton
            // 
            BuyButton.AutoSize = false;
            BuyButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BuyButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BuyButton.Depth = 0;
            BuyButton.HighEmphasis = true;
            BuyButton.Icon = null;
            BuyButton.Location = new Point(992, 68);
            BuyButton.Margin = new Padding(4, 6, 4, 6);
            BuyButton.MouseState = MaterialSkin.MouseState.HOVER;
            BuyButton.Name = "BuyButton";
            BuyButton.NoAccentTextColor = Color.Empty;
            BuyButton.Size = new Size(123, 36);
            BuyButton.TabIndex = 7;
            BuyButton.Text = "Order";
            BuyButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            BuyButton.UseAccentColor = false;
            BuyButton.UseVisualStyleBackColor = true;
            BuyButton.Click += BuyButton_Click;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(PriceLable);
            materialCard1.Controls.Add(CategoryLable);
            materialCard1.Controls.Add(ProductPictureBox);
            materialCard1.Controls.Add(BuyButton);
            materialCard1.Controls.Add(ProductNameLable);
            materialCard1.Controls.Add(ViewProductReviews);
            materialCard1.Controls.Add(ProductDescriptionLable);
            materialCard1.Controls.Add(ProdcutQuantityLable);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(1135, 200);
            materialCard1.TabIndex = 14;
            // 
            // CategoryLable
            // 
            CategoryLable.AutoSize = true;
            CategoryLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CategoryLable.Location = new Point(788, 160);
            CategoryLable.Name = "CategoryLable";
            CategoryLable.Size = new Size(119, 23);
            CategoryLable.TabIndex = 21;
            CategoryLable.Text = "CategoryLable";
            // 
            // PriceLable
            // 
            PriceLable.AutoSize = true;
            PriceLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PriceLable.Location = new Point(548, 160);
            PriceLable.Name = "PriceLable";
            PriceLable.Size = new Size(87, 23);
            PriceLable.TabIndex = 23;
            PriceLable.Text = "PriceLable";
            // 
            // MarketListingItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(materialCard1);
            Name = "MarketListingItem";
            Size = new Size(1135, 200);
            Load += MarketListingItem_Load;
            ((System.ComponentModel.ISupportInitialize)ProductPictureBox).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label ProductNameLable;
        private PictureBox ProductPictureBox;
        private Label ProdcutQuantityLable;
        private Label ProductDescriptionLable;
        private MaterialSkin.Controls.MaterialButton ViewProductReviews;
        private ImageList ImageList;
        private MaterialSkin.Controls.MaterialButton BuyButton;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Label CategoryLable;
        private Label PriceLable;
    }
}
