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
            pictureBox1 = new PictureBox();
            ProductSearchBox = new MaterialSkin.Controls.MaterialTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // SupplierOrderListPanel
            // 
            SupplierOrderListPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SupplierOrderListPanel.Location = new Point(20, 73);
            SupplierOrderListPanel.Name = "SupplierOrderListPanel";
            SupplierOrderListPanel.Size = new Size(1225, 515);
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
            StatusComboBox.Items.AddRange(new object[] { "Confirmed", "Fulfilled", "Returned", "Canceled" });
            StatusComboBox.Location = new Point(1061, 18);
            StatusComboBox.MaxDropDownItems = 4;
            StatusComboBox.MouseState = MaterialSkin.MouseState.OUT;
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(184, 49);
            StatusComboBox.StartIndex = 0;
            StatusComboBox.TabIndex = 18;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.icons8_search_60;
            pictureBox1.Location = new Point(22, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 49);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // ProductSearchBox
            // 
            ProductSearchBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ProductSearchBox.AnimateReadOnly = false;
            ProductSearchBox.BorderStyle = BorderStyle.None;
            ProductSearchBox.Depth = 0;
            ProductSearchBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            ProductSearchBox.LeadingIcon = null;
            ProductSearchBox.Location = new Point(78, 17);
            ProductSearchBox.MaxLength = 50;
            ProductSearchBox.MouseState = MaterialSkin.MouseState.OUT;
            ProductSearchBox.Multiline = false;
            ProductSearchBox.Name = "ProductSearchBox";
            ProductSearchBox.Size = new Size(977, 50);
            ProductSearchBox.TabIndex = 19;
            ProductSearchBox.Text = "";
            ProductSearchBox.TrailingIcon = null;
            // 
            // SupplierOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(ProductSearchBox);
            Controls.Add(StatusComboBox);
            Controls.Add(SupplierOrderListPanel);
            Name = "SupplierOrder";
            Size = new Size(1266, 610);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel SupplierOrderListPanel;
        private MaterialSkin.Controls.MaterialComboBox StatusComboBox;
        private PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialTextBox ProductSearchBox;
    }
}
