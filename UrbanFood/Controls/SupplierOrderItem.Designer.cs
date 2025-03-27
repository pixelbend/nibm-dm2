namespace UrbanFood.Controls
{
    partial class SupplierOrderItem
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
            DeliverButton = new MaterialSkin.Controls.MaterialButton();
            CancelButton = new MaterialSkin.Controls.MaterialButton();
            FulfillButton = new MaterialSkin.Controls.MaterialButton();
            OrderIDLabel = new Label();
            TotalLabel = new Label();
            UnitPriceLabel = new Label();
            NoUnitsLabel = new Label();
            OrderDateLable = new Label();
            OrderStatusLable = new Label();
            CategoryLable = new Label();
            ProductNameLable = new Label();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(DeliverButton);
            materialCard1.Controls.Add(CancelButton);
            materialCard1.Controls.Add(FulfillButton);
            materialCard1.Controls.Add(OrderIDLabel);
            materialCard1.Controls.Add(TotalLabel);
            materialCard1.Controls.Add(UnitPriceLabel);
            materialCard1.Controls.Add(NoUnitsLabel);
            materialCard1.Controls.Add(OrderDateLable);
            materialCard1.Controls.Add(OrderStatusLable);
            materialCard1.Controls.Add(CategoryLable);
            materialCard1.Controls.Add(ProductNameLable);
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
            // DeliverButton
            // 
            DeliverButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DeliverButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            DeliverButton.Depth = 0;
            DeliverButton.HighEmphasis = true;
            DeliverButton.Icon = null;
            DeliverButton.Location = new Point(1045, 13);
            DeliverButton.Margin = new Padding(4, 6, 4, 6);
            DeliverButton.MouseState = MaterialSkin.MouseState.HOVER;
            DeliverButton.Name = "DeliverButton";
            DeliverButton.NoAccentTextColor = Color.Empty;
            DeliverButton.Size = new Size(79, 36);
            DeliverButton.TabIndex = 35;
            DeliverButton.Text = "Deliver";
            DeliverButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            DeliverButton.UseAccentColor = false;
            DeliverButton.UseVisualStyleBackColor = true;
            DeliverButton.Click += DeliverButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            CancelButton.Depth = 0;
            CancelButton.HighEmphasis = true;
            CancelButton.Icon = null;
            CancelButton.Location = new Point(1045, 13);
            CancelButton.Margin = new Padding(4, 6, 4, 6);
            CancelButton.MouseState = MaterialSkin.MouseState.HOVER;
            CancelButton.Name = "CancelButton";
            CancelButton.NoAccentTextColor = Color.Empty;
            CancelButton.Size = new Size(77, 36);
            CancelButton.TabIndex = 34;
            CancelButton.Text = "Cancel";
            CancelButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            CancelButton.UseAccentColor = false;
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // FulfillButton
            // 
            FulfillButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FulfillButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            FulfillButton.Depth = 0;
            FulfillButton.HighEmphasis = true;
            FulfillButton.Icon = null;
            FulfillButton.Location = new Point(961, 13);
            FulfillButton.Margin = new Padding(4, 6, 4, 6);
            FulfillButton.MouseState = MaterialSkin.MouseState.HOVER;
            FulfillButton.Name = "FulfillButton";
            FulfillButton.NoAccentTextColor = Color.Empty;
            FulfillButton.Size = new Size(76, 36);
            FulfillButton.TabIndex = 33;
            FulfillButton.Text = "Fulfill";
            FulfillButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            FulfillButton.UseAccentColor = false;
            FulfillButton.UseVisualStyleBackColor = true;
            FulfillButton.Click += FulfillButton_Click;
            // 
            // OrderIDLabel
            // 
            OrderIDLabel.AutoSize = true;
            OrderIDLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OrderIDLabel.Location = new Point(17, 14);
            OrderIDLabel.Name = "OrderIDLabel";
            OrderIDLabel.Size = new Size(82, 28);
            OrderIDLabel.TabIndex = 32;
            OrderIDLabel.Text = "OrderID";
            // 
            // TotalLabel
            // 
            TotalLabel.AutoSize = true;
            TotalLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TotalLabel.Location = new Point(891, 163);
            TotalLabel.Name = "TotalLabel";
            TotalLabel.Size = new Size(46, 23);
            TotalLabel.TabIndex = 31;
            TotalLabel.Text = "Total";
            // 
            // UnitPriceLabel
            // 
            UnitPriceLabel.AutoSize = true;
            UnitPriceLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UnitPriceLabel.Location = new Point(891, 132);
            UnitPriceLabel.Name = "UnitPriceLabel";
            UnitPriceLabel.Size = new Size(84, 23);
            UnitPriceLabel.TabIndex = 30;
            UnitPriceLabel.Text = "Unit Price";
            // 
            // NoUnitsLabel
            // 
            NoUnitsLabel.AutoSize = true;
            NoUnitsLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NoUnitsLabel.Location = new Point(891, 109);
            NoUnitsLabel.Name = "NoUnitsLabel";
            NoUnitsLabel.Size = new Size(77, 23);
            NoUnitsLabel.TabIndex = 29;
            NoUnitsLabel.Text = "No Units";
            // 
            // OrderDateLable
            // 
            OrderDateLable.AutoSize = true;
            OrderDateLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OrderDateLable.Location = new Point(489, 163);
            OrderDateLable.Name = "OrderDateLable";
            OrderDateLable.Size = new Size(90, 23);
            OrderDateLable.TabIndex = 27;
            OrderDateLable.Text = "OrderDate";
            // 
            // OrderStatusLable
            // 
            OrderStatusLable.AutoSize = true;
            OrderStatusLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OrderStatusLable.Location = new Point(253, 163);
            OrderStatusLable.Name = "OrderStatusLable";
            OrderStatusLable.Size = new Size(100, 23);
            OrderStatusLable.TabIndex = 26;
            OrderStatusLable.Text = "OrderStatus";
            // 
            // CategoryLable
            // 
            CategoryLable.AutoSize = true;
            CategoryLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CategoryLable.Location = new Point(17, 163);
            CategoryLable.Name = "CategoryLable";
            CategoryLable.Size = new Size(119, 23);
            CategoryLable.TabIndex = 21;
            CategoryLable.Text = "CategoryLable";
            // 
            // ProductNameLable
            // 
            ProductNameLable.AutoSize = true;
            ProductNameLable.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductNameLable.Location = new Point(17, 80);
            ProductNameLable.Name = "ProductNameLable";
            ProductNameLable.Size = new Size(210, 31);
            ProductNameLable.TabIndex = 1;
            ProductNameLable.Text = "ProductNameLable";
            // 
            // SupplierOrderItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(materialCard1);
            Name = "SupplierOrderItem";
            Size = new Size(1135, 200);
            Load += SupplierOrderItem_Load;
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Label ProductNameLable;
        private Label CategoryLable;
        private Label OrderStatusLable;
        private Label OrderDateLable;
        private Label NoUnitsLabel;
        private Label UnitPriceLabel;
        private Label TotalLabel;
        private MaterialSkin.Controls.MaterialButton FulfillButton;
        private MaterialSkin.Controls.MaterialButton CancelButton;
        private Label OrderIDLabel;
        private MaterialSkin.Controls.MaterialButton DeliverButton;
    }
}
