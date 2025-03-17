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
            OrderDateLable = new Label();
            OrderStatusLable = new Label();
            CancelButton = new MaterialSkin.Controls.MaterialButton();
            NoUnitsLabel = new Label();
            UnitPriceLabel = new Label();
            TotalLabel = new Label();
            CategoryLable = new Label();
            ProductPictureBox = new PictureBox();
            ProductNameLable = new Label();
            CheckoutButton = new MaterialSkin.Controls.MaterialButton();
            ProductDescriptionLable = new Label();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ProductPictureBox).BeginInit();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(OrderDateLable);
            materialCard1.Controls.Add(OrderStatusLable);
            materialCard1.Controls.Add(CancelButton);
            materialCard1.Controls.Add(NoUnitsLabel);
            materialCard1.Controls.Add(UnitPriceLabel);
            materialCard1.Controls.Add(TotalLabel);
            materialCard1.Controls.Add(CategoryLable);
            materialCard1.Controls.Add(ProductPictureBox);
            materialCard1.Controls.Add(ProductNameLable);
            materialCard1.Controls.Add(CheckoutButton);
            materialCard1.Controls.Add(ProductDescriptionLable);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(1135, 200);
            materialCard1.TabIndex = 15;
            // 
            // OrderDateLable
            // 
            OrderDateLable.AutoSize = true;
            OrderDateLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OrderDateLable.Location = new Point(644, 164);
            OrderDateLable.Name = "OrderDateLable";
            OrderDateLable.Size = new Size(90, 23);
            OrderDateLable.TabIndex = 26;
            OrderDateLable.Text = "OrderDate";
            // 
            // OrderStatusLable
            // 
            OrderStatusLable.AutoSize = true;
            OrderStatusLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OrderStatusLable.Location = new Point(459, 163);
            OrderStatusLable.Name = "OrderStatusLable";
            OrderStatusLable.Size = new Size(100, 23);
            OrderStatusLable.TabIndex = 25;
            OrderStatusLable.Text = "OrderStatus";
            // 
            // CancelButton
            // 
            CancelButton.AutoSize = false;
            CancelButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            CancelButton.Depth = 0;
            CancelButton.HighEmphasis = true;
            CancelButton.Icon = null;
            CancelButton.Location = new Point(994, 56);
            CancelButton.Margin = new Padding(4, 6, 4, 6);
            CancelButton.MouseState = MaterialSkin.MouseState.HOVER;
            CancelButton.Name = "CancelButton";
            CancelButton.NoAccentTextColor = Color.Empty;
            CancelButton.Size = new Size(123, 36);
            CancelButton.TabIndex = 24;
            CancelButton.Text = "Cancel";
            CancelButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            CancelButton.UseAccentColor = false;
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // NoUnitsLabel
            // 
            NoUnitsLabel.AutoSize = true;
            NoUnitsLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NoUnitsLabel.Location = new Point(959, 106);
            NoUnitsLabel.Name = "NoUnitsLabel";
            NoUnitsLabel.Size = new Size(77, 23);
            NoUnitsLabel.TabIndex = 23;
            NoUnitsLabel.Text = "No Units";
            // 
            // UnitPriceLabel
            // 
            UnitPriceLabel.AutoSize = true;
            UnitPriceLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UnitPriceLabel.Location = new Point(959, 136);
            UnitPriceLabel.Name = "UnitPriceLabel";
            UnitPriceLabel.Size = new Size(84, 23);
            UnitPriceLabel.TabIndex = 22;
            UnitPriceLabel.Text = "Unit Price";
            // 
            // TotalLabel
            // 
            TotalLabel.AutoSize = true;
            TotalLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TotalLabel.Location = new Point(959, 167);
            TotalLabel.Name = "TotalLabel";
            TotalLabel.Size = new Size(46, 23);
            TotalLabel.TabIndex = 21;
            TotalLabel.Text = "Total";
            // 
            // CategoryLable
            // 
            CategoryLable.AutoSize = true;
            CategoryLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CategoryLable.Location = new Point(241, 164);
            CategoryLable.Name = "CategoryLable";
            CategoryLable.Size = new Size(119, 23);
            CategoryLable.TabIndex = 20;
            CategoryLable.Text = "CategoryLable";
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
            // ProductNameLable
            // 
            ProductNameLable.AutoSize = true;
            ProductNameLable.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductNameLable.Location = new Point(241, 14);
            ProductNameLable.Name = "ProductNameLable";
            ProductNameLable.Size = new Size(252, 38);
            ProductNameLable.TabIndex = 0;
            ProductNameLable.Text = "ProductNameLable";
            // 
            // CheckoutButton
            // 
            CheckoutButton.AutoSize = false;
            CheckoutButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CheckoutButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            CheckoutButton.Depth = 0;
            CheckoutButton.HighEmphasis = true;
            CheckoutButton.Icon = null;
            CheckoutButton.Location = new Point(994, 14);
            CheckoutButton.Margin = new Padding(4, 6, 4, 6);
            CheckoutButton.MouseState = MaterialSkin.MouseState.HOVER;
            CheckoutButton.Name = "CheckoutButton";
            CheckoutButton.NoAccentTextColor = Color.Empty;
            CheckoutButton.Size = new Size(123, 36);
            CheckoutButton.TabIndex = 6;
            CheckoutButton.Text = "Check Out";
            CheckoutButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            CheckoutButton.UseAccentColor = false;
            CheckoutButton.UseVisualStyleBackColor = true;
            CheckoutButton.Click += CheckoutButton_Click;
            // 
            // ProductDescriptionLable
            // 
            ProductDescriptionLable.BackColor = Color.Transparent;
            ProductDescriptionLable.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductDescriptionLable.Location = new Point(241, 62);
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
            Size = new Size(1135, 200);
            Load += CustomerOrderItem_Load;
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ProductPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private PictureBox ProductPictureBox;
        private Label ProductNameLable;
        private MaterialSkin.Controls.MaterialButton CheckoutButton;
        private Label ProductDescriptionLable;
        private Label CategoryLable;
        private Label TotalLabel;
        private Label UnitPriceLabel;
        private Label NoUnitsLabel;
        private MaterialSkin.Controls.MaterialButton CancelButton;
        private Label OrderStatusLable;
        private Label OrderDateLable;
    }
}
