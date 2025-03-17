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
            ProductPictureBox = new PictureBox();
            ProductNameLable = new Label();
            DeleteProductButton = new MaterialSkin.Controls.MaterialButton();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            CategoryLable = new Label();
            PriceLable = new Label();
            ((System.ComponentModel.ISupportInitialize)ProductPictureBox).BeginInit();
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
            ProdcutQuantityLable.Location = new Point(231, 161);
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
            ProductDescriptionLable.Location = new Point(231, 58);
            ProductDescriptionLable.Name = "ProductDescriptionLable";
            ProductDescriptionLable.Size = new Size(449, 91);
            ProductDescriptionLable.TabIndex = 9;
            ProductDescriptionLable.Text = "ProductDescriptionLable";
            // 
            // ProductPictureBox
            // 
            ProductPictureBox.Image = Properties.Resources.icons8_placeholder_96;
            ProductPictureBox.Location = new Point(14, 12);
            ProductPictureBox.Name = "ProductPictureBox";
            ProductPictureBox.Size = new Size(200, 180);
            ProductPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ProductPictureBox.TabIndex = 8;
            ProductPictureBox.TabStop = false;
            // 
            // ProductNameLable
            // 
            ProductNameLable.AutoSize = true;
            ProductNameLable.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductNameLable.Location = new Point(230, 13);
            ProductNameLable.Name = "ProductNameLable";
            ProductNameLable.Size = new Size(252, 38);
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
            materialCard1.Controls.Add(PriceLable);
            materialCard1.Controls.Add(CategoryLable);
            materialCard1.Controls.Add(DeleteProductButton);
            materialCard1.Controls.Add(ProductPictureBox);
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
            // CategoryLable
            // 
            CategoryLable.AutoSize = true;
            CategoryLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CategoryLable.Location = new Point(777, 160);
            CategoryLable.Name = "CategoryLable";
            CategoryLable.Size = new Size(119, 23);
            CategoryLable.TabIndex = 21;
            CategoryLable.Text = "CategoryLable";
            // 
            // PriceLable
            // 
            PriceLable.AutoSize = true;
            PriceLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PriceLable.Location = new Point(576, 161);
            PriceLable.Name = "PriceLable";
            PriceLable.Size = new Size(87, 23);
            PriceLable.TabIndex = 22;
            PriceLable.Text = "PriceLable";
            // 
            // SupplierInventoryItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(materialCard1);
            Name = "SupplierInventoryItem";
            Size = new Size(1135, 200);
            ((System.ComponentModel.ISupportInitialize)ProductPictureBox).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton UpdateProductButton;
        private Label ProdcutQuantityLable;
        private Label ProductDescriptionLable;
        private PictureBox ProductPictureBox;
        private Label ProductNameLable;
        private MaterialSkin.Controls.MaterialButton DeleteProductButton;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Label CategoryLable;
        private Label PriceLable;
    }
}
