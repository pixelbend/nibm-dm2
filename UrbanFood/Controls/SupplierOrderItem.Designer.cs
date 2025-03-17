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
            TotalLabel = new Label();
            UnitPriceLabel = new Label();
            NoUnitsLabel = new Label();
            materialComboBox1 = new MaterialSkin.Controls.MaterialComboBox();
            OrderDateLable = new Label();
            OrderStatusLable = new Label();
            CategoryLable = new Label();
            ProductNameLable = new Label();
            label1 = new Label();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(label1);
            materialCard1.Controls.Add(TotalLabel);
            materialCard1.Controls.Add(UnitPriceLabel);
            materialCard1.Controls.Add(NoUnitsLabel);
            materialCard1.Controls.Add(materialComboBox1);
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
            // materialComboBox1
            // 
            materialComboBox1.AutoResize = false;
            materialComboBox1.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox1.Depth = 0;
            materialComboBox1.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox1.DropDownHeight = 174;
            materialComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox1.DropDownWidth = 121;
            materialComboBox1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox1.FormattingEnabled = true;
            materialComboBox1.IntegralHeight = false;
            materialComboBox1.ItemHeight = 43;
            materialComboBox1.Items.AddRange(new object[] { "Confirmed", "Processing", "Fulfilled", "Returned", "Canceled" });
            materialComboBox1.Location = new Point(891, 17);
            materialComboBox1.MaxDropDownItems = 4;
            materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox1.Name = "materialComboBox1";
            materialComboBox1.Size = new Size(218, 49);
            materialComboBox1.StartIndex = 0;
            materialComboBox1.TabIndex = 28;
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
            ProductNameLable.Location = new Point(20, 81);
            ProductNameLable.Name = "ProductNameLable";
            ProductNameLable.Size = new Size(210, 31);
            ProductNameLable.TabIndex = 1;
            ProductNameLable.Text = "ProductNameLable";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 17);
            label1.Name = "label1";
            label1.Size = new Size(116, 38);
            label1.TabIndex = 32;
            label1.Text = "OrderID";
            // 
            // SupplierOrderItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(materialCard1);
            Name = "SupplierOrderItem";
            Size = new Size(1135, 200);
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
        private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
        private Label NoUnitsLabel;
        private Label UnitPriceLabel;
        private Label TotalLabel;
        private Label label1;
    }
}
