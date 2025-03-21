namespace UrbanFood.Controls
{
    partial class CustomerOrderHistory
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
            CustomerOrderHistoyListPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // CustomerOrderHistoyListPanel
            // 
            CustomerOrderHistoyListPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CustomerOrderHistoyListPanel.AutoSize = true;
            CustomerOrderHistoyListPanel.Location = new Point(14, 15);
            CustomerOrderHistoyListPanel.Name = "CustomerOrderHistoyListPanel";
            CustomerOrderHistoyListPanel.Size = new Size(1238, 580);
            CustomerOrderHistoyListPanel.TabIndex = 1;
            // 
            // CustomerOrderHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(CustomerOrderHistoyListPanel);
            Name = "CustomerOrderHistory";
            Size = new Size(1266, 610);
            Load += CustomerOrderHistory_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel CustomerOrderHistoyListPanel;
    }
}
