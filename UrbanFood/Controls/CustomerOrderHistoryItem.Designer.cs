namespace UrbanFood.Controls
{
    partial class CustomerOrderHistoryItem
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
            ViewProductReviews = new MaterialSkin.Controls.MaterialButton();
            OrderStatusLabel = new Label();
            OrderTotalLabel = new Label();
            OrderDateLabel = new Label();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(OrderStatusLabel);
            materialCard1.Controls.Add(OrderTotalLabel);
            materialCard1.Controls.Add(OrderDateLabel);
            materialCard1.Controls.Add(ViewProductReviews);
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
            ViewProductReviews.Text = "Detail";
            ViewProductReviews.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            ViewProductReviews.UseAccentColor = false;
            ViewProductReviews.UseVisualStyleBackColor = true;
            // 
            // OrderStatusLabel
            // 
            OrderStatusLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            OrderStatusLabel.AutoSize = true;
            OrderStatusLabel.Font = new Font("Segoe UI", 12F);
            OrderStatusLabel.Location = new Point(32, 145);
            OrderStatusLabel.Name = "OrderStatusLabel";
            OrderStatusLabel.Size = new Size(121, 28);
            OrderStatusLabel.TabIndex = 25;
            OrderStatusLabel.Text = "Order Status";
            OrderStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrderTotalLabel
            // 
            OrderTotalLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            OrderTotalLabel.AutoSize = true;
            OrderTotalLabel.Font = new Font("Segoe UI", 12F);
            OrderTotalLabel.Location = new Point(32, 84);
            OrderTotalLabel.Name = "OrderTotalLabel";
            OrderTotalLabel.Size = new Size(110, 28);
            OrderTotalLabel.TabIndex = 24;
            OrderTotalLabel.Text = "Order Total";
            OrderTotalLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrderDateLabel
            // 
            OrderDateLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            OrderDateLabel.AutoSize = true;
            OrderDateLabel.Font = new Font("Segoe UI", 12F);
            OrderDateLabel.Location = new Point(32, 21);
            OrderDateLabel.Name = "OrderDateLabel";
            OrderDateLabel.Size = new Size(109, 28);
            OrderDateLabel.TabIndex = 23;
            OrderDateLabel.Text = "Order Date";
            OrderDateLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CustomerOrderHistoryItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(materialCard1);
            Name = "CustomerOrderHistoryItem";
            Size = new Size(1135, 200);
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialButton ViewProductReviews;
        private Label OrderStatusLabel;
        private Label OrderTotalLabel;
        private Label OrderDateLabel;
    }
}
