namespace UrbanFood.Controls
{
    partial class SupplierInventoryItem
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
            UpdateProductButton = new MaterialSkin.Controls.MaterialButton();
            ProdcutQuantityLable = new Label();
            ProductDescriptionLable = new Label();
            ProductNameLable = new Label();
            DeleteProductButton = new MaterialSkin.Controls.MaterialButton();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            PriceLable = new Label();
            CategoryLable = new Label();
            ViewProductReviews = new MaterialSkin.Controls.MaterialButton();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // UpdateProductButton
            // 
            UpdateProductButton.AutoSize = false;
            UpdateProductButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            UpdateProductButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            UpdateProductButton.Depth = 0;
            UpdateProductButton.HighEmphasis = true;
            UpdateProductButton.Icon = null;
            UpdateProductButton.Location = new Point(970, 17);
            UpdateProductButton.Margin = new Padding(4, 6, 4, 6);
            UpdateProductButton.MouseState = MaterialSkin.MouseState.HOVER;
            UpdateProductButton.Name = "UpdateProductButton";
            UpdateProductButton.NoAccentTextColor = Color.Empty;
            UpdateProductButton.Size = new Size(147, 36);
            UpdateProductButton.TabIndex = 11;
            UpdateProductButton.Text = "Update";
            UpdateProductButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            UpdateProductButton.UseAccentColor = false;
            UpdateProductButton.UseVisualStyleBackColor = true;
            UpdateProductButton.Click += UpdateProductButton_Click;
            // 
            // ProdcutQuantityLable
            // 
            ProdcutQuantityLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProdcutQuantityLable.Location = new Point(17, 158);
            ProdcutQuantityLable.Name = "ProdcutQuantityLable";
            ProdcutQuantityLable.Size = new Size(306, 28);
            ProdcutQuantityLable.TabIndex = 10;
            ProdcutQuantityLable.Text = "ProdcutQuantityLable";
            ProdcutQuantityLable.Click += ProdcutQuantityLable_Click;
            // 
            // ProductDescriptionLable
            // 
            ProductDescriptionLable.BackColor = Color.Transparent;
            ProductDescriptionLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductDescriptionLable.Location = new Point(17, 55);
            ProductDescriptionLable.Name = "ProductDescriptionLable";
            ProductDescriptionLable.Size = new Size(449, 91);
            ProductDescriptionLable.TabIndex = 9;
            ProductDescriptionLable.Text = "ProductDescriptionLable";
            // 
            // ProductNameLable
            // 
            ProductNameLable.AutoSize = true;
            ProductNameLable.FlatStyle = FlatStyle.Flat;
            ProductNameLable.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ProductNameLable.Location = new Point(16, 10);
            ProductNameLable.Name = "ProductNameLable";
            ProductNameLable.Size = new Size(267, 38);
            ProductNameLable.TabIndex = 7;
            ProductNameLable.Text = "ProductNameLable";
            // 
            // DeleteProductButton
            // 
            DeleteProductButton.AutoSize = false;
            DeleteProductButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DeleteProductButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            DeleteProductButton.Depth = 0;
            DeleteProductButton.HighEmphasis = true;
            DeleteProductButton.Icon = null;
            DeleteProductButton.Location = new Point(970, 65);
            DeleteProductButton.Margin = new Padding(4, 6, 4, 6);
            DeleteProductButton.MouseState = MaterialSkin.MouseState.HOVER;
            DeleteProductButton.Name = "DeleteProductButton";
            DeleteProductButton.NoAccentTextColor = Color.Empty;
            DeleteProductButton.Size = new Size(147, 36);
            DeleteProductButton.TabIndex = 12;
            DeleteProductButton.Text = "Delete";
            DeleteProductButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            DeleteProductButton.UseAccentColor = false;
            DeleteProductButton.UseVisualStyleBackColor = true;
            DeleteProductButton.Click += DeleteProductButton_Click;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(ViewProductReviews);
            materialCard1.Controls.Add(PriceLable);
            materialCard1.Controls.Add(CategoryLable);
            materialCard1.Controls.Add(DeleteProductButton);
            materialCard1.Controls.Add(ProdcutQuantityLable);
            materialCard1.Controls.Add(UpdateProductButton);
            materialCard1.Controls.Add(ProductDescriptionLable);
            materialCard1.Controls.Add(ProductNameLable);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(1135, 200);
            materialCard1.TabIndex = 13;
            // 
            // PriceLable
            // 
            PriceLable.AutoSize = true;
            PriceLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PriceLable.Location = new Point(341, 158);
            PriceLable.Name = "PriceLable";
            PriceLable.Size = new Size(87, 23);
            PriceLable.TabIndex = 22;
            PriceLable.Text = "PriceLable";
            // 
            // CategoryLable
            // 
            CategoryLable.AutoSize = true;
            CategoryLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CategoryLable.Location = new Point(563, 157);
            CategoryLable.Name = "CategoryLable";
            CategoryLable.Size = new Size(119, 23);
            CategoryLable.TabIndex = 21;
            CategoryLable.Text = "CategoryLable";
            // 
            // ViewProductReviews
            // 
            ViewProductReviews.AutoSize = false;
            ViewProductReviews.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ViewProductReviews.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            ViewProductReviews.Depth = 0;
            ViewProductReviews.HighEmphasis = true;
            ViewProductReviews.Icon = null;
            ViewProductReviews.Location = new Point(994, 145);
            ViewProductReviews.Margin = new Padding(4, 6, 4, 6);
            ViewProductReviews.MouseState = MaterialSkin.MouseState.HOVER;
            ViewProductReviews.Name = "ViewProductReviews";
            ViewProductReviews.NoAccentTextColor = Color.Empty;
            ViewProductReviews.Size = new Size(123, 36);
            ViewProductReviews.TabIndex = 23;
            ViewProductReviews.Text = "Reviews";
            ViewProductReviews.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            ViewProductReviews.UseAccentColor = false;
            ViewProductReviews.UseVisualStyleBackColor = true;
            ViewProductReviews.Click += ViewProductReviews_Click;
            // 
            // SupplierInventoryItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(materialCard1);
            Name = "SupplierInventoryItem";
            Size = new Size(1135, 200);
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton UpdateProductButton;
        private Label ProdcutQuantityLable;
        private Label ProductDescriptionLable;
        private Label ProductNameLable;
        private MaterialSkin.Controls.MaterialButton DeleteProductButton;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Label CategoryLable;
        private Label PriceLable;
        private MaterialSkin.Controls.MaterialButton ViewProductReviews;
    }
}
