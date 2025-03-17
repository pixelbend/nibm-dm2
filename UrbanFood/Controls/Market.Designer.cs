namespace UrbanFood.Controls
{
    partial class Market
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
            InStockCheckBox = new MaterialSkin.Controls.MaterialCheckbox();
            ProductComboBox = new MaterialSkin.Controls.MaterialComboBox();
            pictureBox1 = new PictureBox();
            ProductSearchBox = new MaterialSkin.Controls.MaterialTextBox();
            ProductListPanel = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // InStockCheckBox
            // 
            InStockCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            InStockCheckBox.AutoSize = true;
            InStockCheckBox.Depth = 0;
            InStockCheckBox.Location = new Point(1144, 16);
            InStockCheckBox.Margin = new Padding(0);
            InStockCheckBox.MouseLocation = new Point(-1, -1);
            InStockCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            InStockCheckBox.Name = "InStockCheckBox";
            InStockCheckBox.ReadOnly = false;
            InStockCheckBox.Ripple = true;
            InStockCheckBox.Size = new Size(92, 37);
            InStockCheckBox.TabIndex = 15;
            InStockCheckBox.Text = "In Stock";
            InStockCheckBox.UseVisualStyleBackColor = true;
            InStockCheckBox.CheckedChanged += InStockCheckBox_CheckedChanged;
            // 
            // ProductComboBox
            // 
            ProductComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ProductComboBox.AutoResize = true;
            ProductComboBox.BackColor = Color.FromArgb(255, 255, 255);
            ProductComboBox.Depth = 0;
            ProductComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            ProductComboBox.DropDownHeight = 174;
            ProductComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ProductComboBox.DropDownWidth = 176;
            ProductComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            ProductComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            ProductComboBox.FormattingEnabled = true;
            ProductComboBox.IntegralHeight = false;
            ProductComboBox.ItemHeight = 43;
            ProductComboBox.Items.AddRange(new object[] { "", "vegetables", "fruits", "dairy products", "baked goods", "handmade crafts" });
            ProductComboBox.Location = new Point(965, 17);
            ProductComboBox.MaxDropDownItems = 4;
            ProductComboBox.MouseState = MaterialSkin.MouseState.OUT;
            ProductComboBox.Name = "ProductComboBox";
            ProductComboBox.Size = new Size(176, 49);
            ProductComboBox.StartIndex = 0;
            ProductComboBox.TabIndex = 16;
            ProductComboBox.SelectedIndexChanged += ProductComboBox_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.icons8_search_60;
            pictureBox1.Location = new Point(23, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 49);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 13;
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
            ProductSearchBox.Location = new Point(79, 16);
            ProductSearchBox.MaxLength = 50;
            ProductSearchBox.MouseState = MaterialSkin.MouseState.OUT;
            ProductSearchBox.Multiline = false;
            ProductSearchBox.Name = "ProductSearchBox";
            ProductSearchBox.Size = new Size(880, 50);
            ProductSearchBox.TabIndex = 12;
            ProductSearchBox.Text = "";
            ProductSearchBox.TrailingIcon = null;
            ProductSearchBox.TextChanged += ProductSearchBox_TextChanged;
            // 
            // ProductListPanel
            // 
            ProductListPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ProductListPanel.AutoScroll = true;
            ProductListPanel.BackColor = Color.Transparent;
            ProductListPanel.Location = new Point(21, 82);
            ProductListPanel.Name = "ProductListPanel";
            ProductListPanel.Size = new Size(1225, 513);
            ProductListPanel.TabIndex = 14;
            // 
            // Market
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(InStockCheckBox);
            Controls.Add(ProductComboBox);
            Controls.Add(ProductListPanel);
            Controls.Add(pictureBox1);
            Controls.Add(ProductSearchBox);
            Name = "Market";
            Size = new Size(1266, 610);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialCheckbox InStockCheckBox;
        private MaterialSkin.Controls.MaterialComboBox ProductComboBox;
        private PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialTextBox ProductSearchBox;
        private FlowLayoutPanel ProductListPanel;
    }
}
