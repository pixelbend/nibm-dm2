namespace UrbanFood.Forms
{
    partial class UpdateProduct
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
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            ProductPriceTextBox = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            ProductCategoryComboBox = new MaterialSkin.Controls.MaterialComboBox();
            UpdateProductButton = new MaterialSkin.Controls.MaterialButton();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            ProductStockQuantityTextBox = new MaterialSkin.Controls.MaterialTextBox();
            ProductDescriptionTextBox = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            ProductNameTextBox = new MaterialSkin.Controls.MaterialTextBox();
            SuspendLayout();
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(34, 446);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(90, 19);
            materialLabel5.TabIndex = 22;
            materialLabel5.Text = "Unit Price Rs";
            // 
            // ProductPriceTextBox
            // 
            ProductPriceTextBox.AnimateReadOnly = false;
            ProductPriceTextBox.BorderStyle = BorderStyle.None;
            ProductPriceTextBox.Depth = 0;
            ProductPriceTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            ProductPriceTextBox.LeadingIcon = null;
            ProductPriceTextBox.Location = new Point(34, 467);
            ProductPriceTextBox.MaxLength = 50;
            ProductPriceTextBox.MouseState = MaterialSkin.MouseState.OUT;
            ProductPriceTextBox.Multiline = false;
            ProductPriceTextBox.Name = "ProductPriceTextBox";
            ProductPriceTextBox.Size = new Size(732, 50);
            ProductPriceTextBox.TabIndex = 21;
            ProductPriceTextBox.Text = "";
            ProductPriceTextBox.TrailingIcon = null;
            ProductPriceTextBox.KeyPress += ProductPriceTextBox_KeyPress;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(34, 553);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(123, 19);
            materialLabel4.TabIndex = 20;
            materialLabel4.Text = "Product Category";
            // 
            // ProductCategoryComboBox
            // 
            ProductCategoryComboBox.AutoResize = false;
            ProductCategoryComboBox.BackColor = Color.FromArgb(255, 255, 255);
            ProductCategoryComboBox.Depth = 0;
            ProductCategoryComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            ProductCategoryComboBox.DropDownHeight = 174;
            ProductCategoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ProductCategoryComboBox.DropDownWidth = 121;
            ProductCategoryComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            ProductCategoryComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            ProductCategoryComboBox.FormattingEnabled = true;
            ProductCategoryComboBox.IntegralHeight = false;
            ProductCategoryComboBox.ItemHeight = 43;
            ProductCategoryComboBox.Items.AddRange(new object[] { "", "vegetables", "fruits", "dairy products", "baked goods", "handmade crafts" });
            ProductCategoryComboBox.Location = new Point(34, 575);
            ProductCategoryComboBox.MaxDropDownItems = 4;
            ProductCategoryComboBox.MouseState = MaterialSkin.MouseState.OUT;
            ProductCategoryComboBox.Name = "ProductCategoryComboBox";
            ProductCategoryComboBox.Size = new Size(732, 49);
            ProductCategoryComboBox.StartIndex = 0;
            ProductCategoryComboBox.TabIndex = 19;
            // 
            // UpdateProductButton
            // 
            UpdateProductButton.AutoSize = false;
            UpdateProductButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            UpdateProductButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            UpdateProductButton.Depth = 0;
            UpdateProductButton.HighEmphasis = true;
            UpdateProductButton.Icon = null;
            UpdateProductButton.Location = new Point(301, 651);
            UpdateProductButton.Margin = new Padding(4, 6, 4, 6);
            UpdateProductButton.MouseState = MaterialSkin.MouseState.HOVER;
            UpdateProductButton.Name = "UpdateProductButton";
            UpdateProductButton.NoAccentTextColor = Color.Empty;
            UpdateProductButton.Size = new Size(198, 45);
            UpdateProductButton.TabIndex = 18;
            UpdateProductButton.Text = "Save";
            UpdateProductButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            UpdateProductButton.UseAccentColor = false;
            UpdateProductButton.UseVisualStyleBackColor = true;
            UpdateProductButton.Click += UpdateProductButton_Click;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(34, 348);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(137, 19);
            materialLabel3.TabIndex = 17;
            materialLabel3.Text = "Stock Unit Quantity";
            // 
            // ProductStockQuantityTextBox
            // 
            ProductStockQuantityTextBox.AnimateReadOnly = false;
            ProductStockQuantityTextBox.BorderStyle = BorderStyle.None;
            ProductStockQuantityTextBox.Depth = 0;
            ProductStockQuantityTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            ProductStockQuantityTextBox.LeadingIcon = null;
            ProductStockQuantityTextBox.Location = new Point(34, 369);
            ProductStockQuantityTextBox.MaxLength = 50;
            ProductStockQuantityTextBox.MouseState = MaterialSkin.MouseState.OUT;
            ProductStockQuantityTextBox.Multiline = false;
            ProductStockQuantityTextBox.Name = "ProductStockQuantityTextBox";
            ProductStockQuantityTextBox.Size = new Size(732, 50);
            ProductStockQuantityTextBox.TabIndex = 16;
            ProductStockQuantityTextBox.Text = "";
            ProductStockQuantityTextBox.TrailingIcon = null;
            ProductStockQuantityTextBox.KeyPress += ProductStockQuantityTextBox_KeyPress;
            // 
            // ProductDescriptionTextBox
            // 
            ProductDescriptionTextBox.AnimateReadOnly = false;
            ProductDescriptionTextBox.BackgroundImageLayout = ImageLayout.None;
            ProductDescriptionTextBox.CharacterCasing = CharacterCasing.Normal;
            ProductDescriptionTextBox.Depth = 0;
            ProductDescriptionTextBox.HideSelection = true;
            ProductDescriptionTextBox.Location = new Point(34, 206);
            ProductDescriptionTextBox.MaxLength = 32767;
            ProductDescriptionTextBox.MouseState = MaterialSkin.MouseState.OUT;
            ProductDescriptionTextBox.Name = "ProductDescriptionTextBox";
            ProductDescriptionTextBox.PasswordChar = '\0';
            ProductDescriptionTextBox.ReadOnly = false;
            ProductDescriptionTextBox.ScrollBars = ScrollBars.None;
            ProductDescriptionTextBox.SelectedText = "";
            ProductDescriptionTextBox.SelectionLength = 0;
            ProductDescriptionTextBox.SelectionStart = 0;
            ProductDescriptionTextBox.ShortcutsEnabled = true;
            ProductDescriptionTextBox.Size = new Size(732, 125);
            ProductDescriptionTextBox.TabIndex = 15;
            ProductDescriptionTextBox.TabStop = false;
            ProductDescriptionTextBox.TextAlign = HorizontalAlignment.Left;
            ProductDescriptionTextBox.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(34, 184);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(140, 19);
            materialLabel2.TabIndex = 14;
            materialLabel2.Text = "Product Description";
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(34, 98);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(102, 19);
            materialLabel1.TabIndex = 13;
            materialLabel1.Text = "Product Name";
            // 
            // ProductNameTextBox
            // 
            ProductNameTextBox.AnimateReadOnly = false;
            ProductNameTextBox.BorderStyle = BorderStyle.None;
            ProductNameTextBox.Depth = 0;
            ProductNameTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            ProductNameTextBox.LeadingIcon = null;
            ProductNameTextBox.Location = new Point(34, 120);
            ProductNameTextBox.MaxLength = 50;
            ProductNameTextBox.MouseState = MaterialSkin.MouseState.OUT;
            ProductNameTextBox.Multiline = false;
            ProductNameTextBox.Name = "ProductNameTextBox";
            ProductNameTextBox.Size = new Size(732, 50);
            ProductNameTextBox.TabIndex = 12;
            ProductNameTextBox.Text = "";
            ProductNameTextBox.TrailingIcon = null;
            // 
            // UpdateProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 718);
            Controls.Add(materialLabel5);
            Controls.Add(ProductPriceTextBox);
            Controls.Add(materialLabel4);
            Controls.Add(ProductCategoryComboBox);
            Controls.Add(UpdateProductButton);
            Controls.Add(materialLabel3);
            Controls.Add(ProductStockQuantityTextBox);
            Controls.Add(ProductDescriptionTextBox);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Controls.Add(ProductNameTextBox);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateProduct";
            Sizable = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update Product";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialTextBox ProductPriceTextBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialComboBox ProductCategoryComboBox;
        private MaterialSkin.Controls.MaterialButton UpdateProductButton;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialTextBox ProductStockQuantityTextBox;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 ProductDescriptionTextBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox ProductNameTextBox;
    }
}