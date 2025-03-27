namespace UrbanFood.Forms
{
    partial class CustomerOrderHistoryDetail
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
            OrderItemListPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // OrderItemListPanel
            // 
            OrderItemListPanel.AutoScroll = true;
            OrderItemListPanel.Location = new Point(20, 85);
            OrderItemListPanel.Name = "OrderItemListPanel";
            OrderItemListPanel.Size = new Size(910, 395);
            OrderItemListPanel.TabIndex = 17;
            // 
            // CustomerOrderHistoryDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 500);
            Controls.Add(OrderItemListPanel);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomerOrderHistoryDetail";
            Sizable = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Order Items";
            Load += CustomerOrderHistoryDetail_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel OrderItemListPanel;
    }
}