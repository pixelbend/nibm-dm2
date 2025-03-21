namespace UrbanFood.Controls
{
    partial class SupplierOrder
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
            SupplierOrderListPanel = new FlowLayoutPanel();
            StatusComboBox = new MaterialSkin.Controls.MaterialComboBox();
            SuspendLayout();
            // 
            // SupplierOrderListPanel
            // 
            SupplierOrderListPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SupplierOrderListPanel.Location = new Point(20, 86);
            SupplierOrderListPanel.Name = "SupplierOrderListPanel";
            SupplierOrderListPanel.Size = new Size(1225, 502);
            SupplierOrderListPanel.TabIndex = 1;
            // 
            // StatusComboBox
            // 
            StatusComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StatusComboBox.AutoResize = true;
            StatusComboBox.BackColor = Color.FromArgb(255, 255, 255);
            StatusComboBox.Depth = 0;
            StatusComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            StatusComboBox.DropDownHeight = 174;
            StatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusComboBox.DropDownWidth = 184;
            StatusComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            StatusComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            StatusComboBox.FormattingEnabled = true;
            StatusComboBox.IntegralHeight = false;
            StatusComboBox.ItemHeight = 43;
            StatusComboBox.Items.AddRange(new object[] { "Confirmed", "Fulfilled", "Delivered", "Canceled" });
            StatusComboBox.Location = new Point(1061, 18);
            StatusComboBox.MaxDropDownItems = 4;
            StatusComboBox.MouseState = MaterialSkin.MouseState.OUT;
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(184, 49);
            StatusComboBox.StartIndex = 0;
            StatusComboBox.TabIndex = 18;
            StatusComboBox.SelectedIndexChanged += StatusComboBox_SelectedIndexChanged;
            // 
            // SupplierOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(StatusComboBox);
            Controls.Add(SupplierOrderListPanel);
            Name = "SupplierOrder";
            Size = new Size(1266, 610);
            Load += SupplierOrder_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel SupplierOrderListPanel;
        private MaterialSkin.Controls.MaterialComboBox StatusComboBox;
    }
}
