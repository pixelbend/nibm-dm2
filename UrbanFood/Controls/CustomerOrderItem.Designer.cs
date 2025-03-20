namespace UrbanFood.Controls
{
    partial class CustomerOrderItem
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
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            UpdateButton = new MaterialSkin.Controls.MaterialButton();
            RemoveButton = new MaterialSkin.Controls.MaterialButton();
            OrderStatusLable = new Label();
            NoUnitsLabel = new Label();
            UnitPriceLabel = new Label();
            TotalLabel = new Label();
            CategoryLable = new Label();
            ProductNameLable = new Label();
            ProductDescriptionLable = new Label();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(UpdateButton);
            materialCard1.Controls.Add(RemoveButton);
            materialCard1.Controls.Add(OrderStatusLable);
            materialCard1.Controls.Add(NoUnitsLabel);
            materialCard1.Controls.Add(UnitPriceLabel);
            materialCard1.Controls.Add(TotalLabel);
            materialCard1.Controls.Add(CategoryLable);
            materialCard1.Controls.Add(ProductNameLable);
            materialCard1.Controls.Add(ProductDescriptionLable);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(920, 200);
            materialCard1.TabIndex = 15;
            // 
            // UpdateButton
            // 
            UpdateButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UpdateButton.AutoSize = false;
            UpdateButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            UpdateButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            UpdateButton.Depth = 0;
            UpdateButton.HighEmphasis = true;
            UpdateButton.Icon = null;
            UpdateButton.Location = new Point(781, 16);
            UpdateButton.Margin = new Padding(4, 6, 4, 6);
            UpdateButton.MouseState = MaterialSkin.MouseState.HOVER;
            UpdateButton.Name = "UpdateButton";
            UpdateButton.NoAccentTextColor = Color.Empty;
            UpdateButton.Size = new Size(123, 36);
            UpdateButton.TabIndex = 28;
            UpdateButton.Text = "Update";
            UpdateButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            UpdateButton.UseAccentColor = false;
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // RemoveButton
            // 
            RemoveButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RemoveButton.AutoSize = false;
            RemoveButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            RemoveButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            RemoveButton.Depth = 0;
            RemoveButton.HighEmphasis = true;
            RemoveButton.Icon = null;
            RemoveButton.Location = new Point(781, 58);
            RemoveButton.Margin = new Padding(4, 6, 4, 6);
            RemoveButton.MouseState = MaterialSkin.MouseState.HOVER;
            RemoveButton.Name = "RemoveButton";
            RemoveButton.NoAccentTextColor = Color.Empty;
            RemoveButton.Size = new Size(123, 36);
            RemoveButton.TabIndex = 27;
            RemoveButton.Text = "Remove";
            RemoveButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            RemoveButton.UseAccentColor = false;
            RemoveButton.UseVisualStyleBackColor = true;
            RemoveButton.Click += RemoveButton_Click;
            // 
            // OrderStatusLable
            // 
            OrderStatusLable.AutoSize = true;
            OrderStatusLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OrderStatusLable.Location = new Point(235, 163);
            OrderStatusLable.Name = "OrderStatusLable";
            OrderStatusLable.Size = new Size(100, 23);
            OrderStatusLable.TabIndex = 25;
            OrderStatusLable.Text = "OrderStatus";
            // 
            // NoUnitsLabel
            // 
            NoUnitsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            NoUnitsLabel.AutoSize = true;
            NoUnitsLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NoUnitsLabel.Location = new Point(746, 108);
            NoUnitsLabel.Name = "NoUnitsLabel";
            NoUnitsLabel.Size = new Size(77, 23);
            NoUnitsLabel.TabIndex = 23;
            NoUnitsLabel.Text = "No Units";
            // 
            // UnitPriceLabel
            // 
            UnitPriceLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UnitPriceLabel.AutoSize = true;
            UnitPriceLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UnitPriceLabel.Location = new Point(746, 138);
            UnitPriceLabel.Name = "UnitPriceLabel";
            UnitPriceLabel.Size = new Size(84, 23);
            UnitPriceLabel.TabIndex = 22;
            UnitPriceLabel.Text = "Unit Price";
            // 
            // TotalLabel
            // 
            TotalLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TotalLabel.AutoSize = true;
            TotalLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TotalLabel.Location = new Point(746, 169);
            TotalLabel.Name = "TotalLabel";
            TotalLabel.Size = new Size(46, 23);
            TotalLabel.TabIndex = 21;
            TotalLabel.Text = "Total";
            // 
            // CategoryLable
            // 
            CategoryLable.AutoSize = true;
            CategoryLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CategoryLable.Location = new Point(17, 164);
            CategoryLable.Name = "CategoryLable";
            CategoryLable.Size = new Size(119, 23);
            CategoryLable.TabIndex = 20;
            CategoryLable.Text = "CategoryLable";
            // 
            // ProductNameLable
            // 
            ProductNameLable.AutoSize = true;
            ProductNameLable.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductNameLable.Location = new Point(17, 14);
            ProductNameLable.Name = "ProductNameLable";
            ProductNameLable.Size = new Size(252, 38);
            ProductNameLable.TabIndex = 0;
            ProductNameLable.Text = "ProductNameLable";
            // 
            // ProductDescriptionLable
            // 
            ProductDescriptionLable.BackColor = Color.Transparent;
            ProductDescriptionLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductDescriptionLable.Location = new Point(17, 62);
            ProductDescriptionLable.Name = "ProductDescriptionLable";
            ProductDescriptionLable.Size = new Size(449, 93);
            ProductDescriptionLable.TabIndex = 4;
            ProductDescriptionLable.Text = "ProductDescriptionLable";
            // 
            // CustomerOrderItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(materialCard1);
            Name = "CustomerOrderItem";
            Size = new Size(920, 200);
            Load += CustomerOrderItem_Load;
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Label ProductNameLable;
        private Label ProductDescriptionLable;
        private Label CategoryLable;
        private Label TotalLabel;
        private Label UnitPriceLabel;
        private Label NoUnitsLabel;
        private Label OrderStatusLable;
        private MaterialSkin.Controls.MaterialButton RemoveButton;
        private MaterialSkin.Controls.MaterialButton UpdateButton;
    }
}
