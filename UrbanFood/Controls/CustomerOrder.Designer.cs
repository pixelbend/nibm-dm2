namespace UrbanFood.Controls
{
    partial class CustomerOrder
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
            CustomerOrderListPanel = new FlowLayoutPanel();
            CheckoutButton = new MaterialSkin.Controls.MaterialButton();
            CancelButton = new MaterialSkin.Controls.MaterialButton();
            OrderDateLabel = new Label();
            OrderTotalLabel = new Label();
            OrderStatusLabel = new Label();
            SuspendLayout();
            // 
            // CustomerOrderListPanel
            // 
            CustomerOrderListPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CustomerOrderListPanel.AutoScroll = true;
            CustomerOrderListPanel.AutoSize = true;
            CustomerOrderListPanel.Location = new Point(16, 16);
            CustomerOrderListPanel.Name = "CustomerOrderListPanel";
            CustomerOrderListPanel.Size = new Size(975, 580);
            CustomerOrderListPanel.TabIndex = 0;
            // 
            // CheckoutButton
            // 
            CheckoutButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CheckoutButton.AutoSize = false;
            CheckoutButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CheckoutButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            CheckoutButton.Depth = 0;
            CheckoutButton.HighEmphasis = true;
            CheckoutButton.Icon = null;
            CheckoutButton.Location = new Point(1130, 560);
            CheckoutButton.Margin = new Padding(4, 6, 4, 6);
            CheckoutButton.MouseState = MaterialSkin.MouseState.HOVER;
            CheckoutButton.Name = "CheckoutButton";
            CheckoutButton.NoAccentTextColor = Color.Empty;
            CheckoutButton.Size = new Size(123, 36);
            CheckoutButton.TabIndex = 18;
            CheckoutButton.Text = "Check Out";
            CheckoutButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            CheckoutButton.UseAccentColor = false;
            CheckoutButton.UseVisualStyleBackColor = true;
            CheckoutButton.Click += CheckoutButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CancelButton.AutoSize = false;
            CancelButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            CancelButton.Depth = 0;
            CancelButton.HighEmphasis = true;
            CancelButton.Icon = null;
            CancelButton.Location = new Point(999, 560);
            CancelButton.Margin = new Padding(4, 6, 4, 6);
            CancelButton.MouseState = MaterialSkin.MouseState.HOVER;
            CancelButton.Name = "CancelButton";
            CancelButton.NoAccentTextColor = Color.Empty;
            CancelButton.Size = new Size(123, 36);
            CancelButton.TabIndex = 19;
            CancelButton.Text = "Cancel";
            CancelButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            CancelButton.UseAccentColor = false;
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // OrderDateLabel
            // 
            OrderDateLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            OrderDateLabel.AutoSize = true;
            OrderDateLabel.Font = new Font("Segoe UI", 12F);
            OrderDateLabel.Location = new Point(999, 18);
            OrderDateLabel.Name = "OrderDateLabel";
            OrderDateLabel.Size = new Size(109, 28);
            OrderDateLabel.TabIndex = 20;
            OrderDateLabel.Text = "Order Date";
            OrderDateLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrderTotalLabel
            // 
            OrderTotalLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            OrderTotalLabel.AutoSize = true;
            OrderTotalLabel.Font = new Font("Segoe UI", 12F);
            OrderTotalLabel.Location = new Point(999, 81);
            OrderTotalLabel.Name = "OrderTotalLabel";
            OrderTotalLabel.Size = new Size(110, 28);
            OrderTotalLabel.TabIndex = 21;
            OrderTotalLabel.Text = "Order Total";
            OrderTotalLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrderStatusLabel
            // 
            OrderStatusLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            OrderStatusLabel.AutoSize = true;
            OrderStatusLabel.Font = new Font("Segoe UI", 12F);
            OrderStatusLabel.Location = new Point(999, 142);
            OrderStatusLabel.Name = "OrderStatusLabel";
            OrderStatusLabel.Size = new Size(121, 28);
            OrderStatusLabel.TabIndex = 22;
            OrderStatusLabel.Text = "Order Status";
            OrderStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CustomerOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(OrderStatusLabel);
            Controls.Add(OrderTotalLabel);
            Controls.Add(OrderDateLabel);
            Controls.Add(CancelButton);
            Controls.Add(CheckoutButton);
            Controls.Add(CustomerOrderListPanel);
            Name = "CustomerOrder";
            Size = new Size(1266, 610);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel CustomerOrderListPanel;
        private MaterialSkin.Controls.MaterialButton CheckoutButton;
        private MaterialSkin.Controls.MaterialButton CancelButton;
        private Label OrderDateLabel;
        private Label OrderTotalLabel;
        private Label OrderStatusLabel;
    }
}
