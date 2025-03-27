namespace UrbanFood.Controls
{
    partial class CustomerOrderHistoryDetailItem
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
            NoUnitsLabel = new Label();
            UnitPriceLabel = new Label();
            TotalLabel = new Label();
            OrderStatusLable = new Label();
            ProductNameLable = new Label();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // NoUnitsLabel
            // 
            NoUnitsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            NoUnitsLabel.AutoSize = true;
            NoUnitsLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NoUnitsLabel.Location = new Point(722, 9);
            NoUnitsLabel.Name = "NoUnitsLabel";
            NoUnitsLabel.Size = new Size(77, 23);
            NoUnitsLabel.TabIndex = 26;
            NoUnitsLabel.Text = "No Units";
            // 
            // UnitPriceLabel
            // 
            UnitPriceLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UnitPriceLabel.AutoSize = true;
            UnitPriceLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UnitPriceLabel.Location = new Point(722, 39);
            UnitPriceLabel.Name = "UnitPriceLabel";
            UnitPriceLabel.Size = new Size(84, 23);
            UnitPriceLabel.TabIndex = 25;
            UnitPriceLabel.Text = "Unit Price";
            // 
            // TotalLabel
            // 
            TotalLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TotalLabel.AutoSize = true;
            TotalLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TotalLabel.Location = new Point(722, 70);
            TotalLabel.Name = "TotalLabel";
            TotalLabel.Size = new Size(46, 23);
            TotalLabel.TabIndex = 24;
            TotalLabel.Text = "Total";
            // 
            // OrderStatusLable
            // 
            OrderStatusLable.AutoSize = true;
            OrderStatusLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OrderStatusLable.Location = new Point(17, 70);
            OrderStatusLable.Name = "OrderStatusLable";
            OrderStatusLable.Size = new Size(100, 23);
            OrderStatusLable.TabIndex = 27;
            OrderStatusLable.Text = "OrderStatus";
            // 
            // ProductNameLable
            // 
            ProductNameLable.AutoSize = true;
            ProductNameLable.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductNameLable.Location = new Point(17, 9);
            ProductNameLable.Name = "ProductNameLable";
            ProductNameLable.Size = new Size(252, 38);
            ProductNameLable.TabIndex = 28;
            ProductNameLable.Text = "ProductNameLable";
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(ProductNameLable);
            materialCard1.Controls.Add(NoUnitsLabel);
            materialCard1.Controls.Add(UnitPriceLabel);
            materialCard1.Controls.Add(OrderStatusLable);
            materialCard1.Controls.Add(TotalLabel);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(900, 100);
            materialCard1.TabIndex = 29;
            // 
            // CustomerOrderHistoryDetailItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(materialCard1);
            Name = "CustomerOrderHistoryDetailItem";
            Size = new Size(900, 100);
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label NoUnitsLabel;
        private Label UnitPriceLabel;
        private Label TotalLabel;
        private Label OrderStatusLable;
        private Label ProductNameLable;
        private MaterialSkin.Controls.MaterialCard materialCard1;
    }
}
