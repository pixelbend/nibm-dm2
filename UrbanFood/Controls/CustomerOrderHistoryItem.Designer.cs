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
            OrderStatusLabel = new Label();
            OrderTotalLabel = new Label();
            OrderDateLabel = new Label();
            DetailsButton = new MaterialSkin.Controls.MaterialButton();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(DetailsButton);
            materialCard1.Controls.Add(OrderStatusLabel);
            materialCard1.Controls.Add(OrderTotalLabel);
            materialCard1.Controls.Add(OrderDateLabel);
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
            // DetailsButton
            // 
            DetailsButton.AutoSize = false;
            DetailsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DetailsButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            DetailsButton.Depth = 0;
            DetailsButton.HighEmphasis = true;
            DetailsButton.Icon = null;
            DetailsButton.Location = new Point(976, 18);
            DetailsButton.Margin = new Padding(4, 6, 4, 6);
            DetailsButton.MouseState = MaterialSkin.MouseState.HOVER;
            DetailsButton.Name = "DetailsButton";
            DetailsButton.NoAccentTextColor = Color.Empty;
            DetailsButton.Size = new Size(141, 40);
            DetailsButton.TabIndex = 26;
            DetailsButton.Text = "Details";
            DetailsButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            DetailsButton.UseAccentColor = false;
            DetailsButton.UseVisualStyleBackColor = true;
            DetailsButton.Click += DetailsButton_Click;
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
        private Label OrderStatusLabel;
        private Label OrderTotalLabel;
        private Label OrderDateLabel;
        private MaterialSkin.Controls.MaterialButton DetailsButton;
    }
}
