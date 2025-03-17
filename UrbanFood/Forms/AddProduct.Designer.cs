namespace UrbanFood.Forms
{
    partial class AddProduct
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
            ProductNameTextBox = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            ProductDescriptionTextBox = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            ProductStockQuantityTextBox = new MaterialSkin.Controls.MaterialTextBox();
            ProductAddButton = new MaterialSkin.Controls.MaterialButton();
            ProductCategoryComboBox = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            ProductPriceTextBox = new MaterialSkin.Controls.MaterialTextBox();
            SuspendLayout();
            // 
            // ProductNameTextBox
            // 
            ProductNameTextBox.AnimateReadOnly = false;
            ProductNameTextBox.BorderStyle = BorderStyle.None;
            ProductNameTextBox.Depth = 0;
            ProductNameTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            ProductNameTextBox.LeadingIcon = null;
            ProductNameTextBox.LeaveOnEnterKey = true;
            ProductNameTextBox.Location = new Point(37, 107);
            ProductNameTextBox.MaxLength = 50;
            ProductNameTextBox.MouseState = MaterialSkin.MouseState.OUT;
            ProductNameTextBox.Multiline = false;
            ProductNameTextBox.Name = "ProductNameTextBox";
            ProductNameTextBox.Size = new Size(732, 50);
            ProductNameTextBox.TabIndex = 0;
            ProductNameTextBox.Text = "";
            ProductNameTextBox.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(37, 85);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(102, 19);
            materialLabel1.TabIndex = 1;
            materialLabel1.Text = "Product Name";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(37, 171);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(140, 19);
            materialLabel2.TabIndex = 2;
            materialLabel2.Text = "Product Description";
            // 
            // ProductDescriptionTextBox
            // 
            ProductDescriptionTextBox.AnimateReadOnly = false;
            ProductDescriptionTextBox.BackgroundImageLayout = ImageLayout.None;
            ProductDescriptionTextBox.CharacterCasing = CharacterCasing.Normal;
            ProductDescriptionTextBox.Depth = 0;
            ProductDescriptionTextBox.HideSelection = true;
            ProductDescriptionTextBox.LeaveOnEnterKey = true;
            ProductDescriptionTextBox.Location = new Point(37, 193);
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
            ProductDescriptionTextBox.TabIndex = 4;
            ProductDescriptionTextBox.TabStop = false;
            ProductDescriptionTextBox.TextAlign = HorizontalAlignment.Left;
            ProductDescriptionTextBox.UseSystemPasswordChar = false;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(37, 335);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(137, 19);
            materialLabel3.TabIndex = 6;
            materialLabel3.Text = "Stock Unit Quantity";
            // 
            // ProductStockQuantityTextBox
            // 
            ProductStockQuantityTextBox.AnimateReadOnly = false;
            ProductStockQuantityTextBox.BorderStyle = BorderStyle.None;
            ProductStockQuantityTextBox.Depth = 0;
            ProductStockQuantityTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            ProductStockQuantityTextBox.LeadingIcon = null;
            ProductStockQuantityTextBox.LeaveOnEnterKey = true;
            ProductStockQuantityTextBox.Location = new Point(37, 356);
            ProductStockQuantityTextBox.MaxLength = 50;
            ProductStockQuantityTextBox.MouseState = MaterialSkin.MouseState.OUT;
            ProductStockQuantityTextBox.Multiline = false;
            ProductStockQuantityTextBox.Name = "ProductStockQuantityTextBox";
            ProductStockQuantityTextBox.Size = new Size(732, 50);
            ProductStockQuantityTextBox.TabIndex = 5;
            ProductStockQuantityTextBox.Text = "";
            ProductStockQuantityTextBox.TrailingIcon = null;
            ProductStockQuantityTextBox.KeyPress += ProductStockQuantityTextBox_KeyPress;
            // 
            // ProductAddButton
            // 
            ProductAddButton.AutoSize = false;
            ProductAddButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ProductAddButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            ProductAddButton.Depth = 0;
            ProductAddButton.HighEmphasis = true;
            ProductAddButton.Icon = null;
            ProductAddButton.Location = new Point(304, 645);
            ProductAddButton.Margin = new Padding(4, 6, 4, 6);
            ProductAddButton.MouseState = MaterialSkin.MouseState.HOVER;
            ProductAddButton.Name = "ProductAddButton";
            ProductAddButton.NoAccentTextColor = Color.Empty;
            ProductAddButton.Size = new Size(198, 45);
            ProductAddButton.TabIndex = 7;
            ProductAddButton.Text = "Save";
            ProductAddButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            ProductAddButton.UseAccentColor = false;
            ProductAddButton.UseVisualStyleBackColor = true;
            ProductAddButton.Click += ProductAddButton_Click;
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
            ProductCategoryComboBox.Items.AddRange(new object[] { "vegetables", "fruits", "dairy products", "baked goods", "handmade crafts" });
            ProductCategoryComboBox.Location = new Point(37, 562);
            ProductCategoryComboBox.MaxDropDownItems = 4;
            ProductCategoryComboBox.MouseState = MaterialSkin.MouseState.OUT;
            ProductCategoryComboBox.Name = "ProductCategoryComboBox";
            ProductCategoryComboBox.Size = new Size(732, 49);
            ProductCategoryComboBox.StartIndex = 0;
            ProductCategoryComboBox.TabIndex = 8;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(37, 540);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(123, 19);
            materialLabel4.TabIndex = 9;
            materialLabel4.Text = "Product Category";
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(37, 433);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(90, 19);
            materialLabel5.TabIndex = 11;
            materialLabel5.Text = "Unit Price Rs";
            // 
            // ProductPriceTextBox
            // 
            ProductPriceTextBox.AnimateReadOnly = false;
            ProductPriceTextBox.BorderStyle = BorderStyle.None;
            ProductPriceTextBox.Depth = 0;
            ProductPriceTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            ProductPriceTextBox.LeadingIcon = null;
            ProductPriceTextBox.LeaveOnEnterKey = true;
            ProductPriceTextBox.Location = new Point(37, 454);
            ProductPriceTextBox.MaxLength = 50;
            ProductPriceTextBox.MouseState = MaterialSkin.MouseState.OUT;
            ProductPriceTextBox.Multiline = false;
            ProductPriceTextBox.Name = "ProductPriceTextBox";
            ProductPriceTextBox.Size = new Size(732, 50);
            ProductPriceTextBox.TabIndex = 10;
            ProductPriceTextBox.Text = "";
            ProductPriceTextBox.TrailingIcon = null;
            ProductPriceTextBox.KeyPress += ProductPriceTextBox_KeyPress;
            // 
            // AddProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 714);
            Controls.Add(materialLabel5);
            Controls.Add(ProductPriceTextBox);
            Controls.Add(materialLabel4);
            Controls.Add(ProductCategoryComboBox);
            Controls.Add(ProductAddButton);
            Controls.Add(materialLabel3);
            Controls.Add(ProductStockQuantityTextBox);
            Controls.Add(ProductDescriptionTextBox);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Controls.Add(ProductNameTextBox);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddProduct";
            Sizable = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Product";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox ProductNameTextBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 ProductDescriptionTextBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialTextBox ProductStockQuantityTextBox;
        private MaterialSkin.Controls.MaterialButton ProductAddButton;
        private MaterialSkin.Controls.MaterialComboBox ProductCategoryComboBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialTextBox ProductPriceTextBox;
    }
}