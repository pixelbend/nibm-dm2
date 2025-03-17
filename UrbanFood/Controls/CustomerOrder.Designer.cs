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
            StatusComboBox = new MaterialSkin.Controls.MaterialComboBox();
            SuspendLayout();
            // 
            // CustomerOrderListPanel
            // 
            CustomerOrderListPanel.Location = new Point(20, 79);
            CustomerOrderListPanel.Name = "CustomerOrderListPanel";
            CustomerOrderListPanel.Size = new Size(1225, 511);
            CustomerOrderListPanel.TabIndex = 0;
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
            StatusComboBox.Items.AddRange(new object[] { "Pending", "Confirmed", "Processing", "Fulfilled", "Returned", "Canceled" });
            StatusComboBox.Location = new Point(1061, 19);
            StatusComboBox.MaxDropDownItems = 4;
            StatusComboBox.MouseState = MaterialSkin.MouseState.OUT;
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(184, 49);
            StatusComboBox.StartIndex = 0;
            StatusComboBox.TabIndex = 17;
            StatusComboBox.SelectedIndexChanged += StatusComboBox_SelectedIndexChanged;
            // 
            // CustomerOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(StatusComboBox);
            Controls.Add(CustomerOrderListPanel);
            Name = "CustomerOrder";
            Size = new Size(1266, 610);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel CustomerOrderListPanel;
        private MaterialSkin.Controls.MaterialComboBox StatusComboBox;
    }
}
