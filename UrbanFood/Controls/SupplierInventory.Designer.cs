namespace UrbanFood.Controls
{
    partial class SupplierInventory
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
            InventoryStockComboBox = new MaterialSkin.Controls.MaterialComboBox();
            InventoryProductComboBox = new MaterialSkin.Controls.MaterialComboBox();
            pictureBox1 = new PictureBox();
            InventorySearchBox = new MaterialSkin.Controls.MaterialTextBox();
            InventoryListPanel = new FlowLayoutPanel();
            AddProductButton = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // InventoryStockComboBox
            // 
            InventoryStockComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            InventoryStockComboBox.AutoResize = true;
            InventoryStockComboBox.BackColor = Color.FromArgb(255, 255, 255);
            InventoryStockComboBox.Depth = 0;
            InventoryStockComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            InventoryStockComboBox.DropDownHeight = 174;
            InventoryStockComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            InventoryStockComboBox.DropDownWidth = 131;
            InventoryStockComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            InventoryStockComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            InventoryStockComboBox.FormattingEnabled = true;
            InventoryStockComboBox.IntegralHeight = false;
            InventoryStockComboBox.ItemHeight = 43;
            InventoryStockComboBox.Items.AddRange(new object[] { "", "In Stock", "Out of Stock" });
            InventoryStockComboBox.Location = new Point(1111, 19);
            InventoryStockComboBox.MaxDropDownItems = 4;
            InventoryStockComboBox.MouseState = MaterialSkin.MouseState.OUT;
            InventoryStockComboBox.Name = "InventoryStockComboBox";
            InventoryStockComboBox.Size = new Size(131, 49);
            InventoryStockComboBox.StartIndex = 0;
            InventoryStockComboBox.TabIndex = 21;
            InventoryStockComboBox.SelectedIndexChanged += InventoryStockComboBox_SelectedIndexChanged;
            // 
            // InventoryProductComboBox
            // 
            InventoryProductComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            InventoryProductComboBox.AutoResize = true;
            InventoryProductComboBox.BackColor = Color.FromArgb(255, 255, 255);
            InventoryProductComboBox.Depth = 0;
            InventoryProductComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            InventoryProductComboBox.DropDownHeight = 174;
            InventoryProductComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            InventoryProductComboBox.DropDownWidth = 184;
            InventoryProductComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            InventoryProductComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            InventoryProductComboBox.FormattingEnabled = true;
            InventoryProductComboBox.IntegralHeight = false;
            InventoryProductComboBox.ItemHeight = 43;
            InventoryProductComboBox.Items.AddRange(new object[] { "", "vegetables", "fruits", "dairy products", "baked goods", "handmade crafts" });
            InventoryProductComboBox.Location = new Point(921, 19);
            InventoryProductComboBox.MaxDropDownItems = 4;
            InventoryProductComboBox.MouseState = MaterialSkin.MouseState.OUT;
            InventoryProductComboBox.Name = "InventoryProductComboBox";
            InventoryProductComboBox.Size = new Size(184, 49);
            InventoryProductComboBox.StartIndex = 0;
            InventoryProductComboBox.TabIndex = 20;
            InventoryProductComboBox.SelectedIndexChanged += InventoryProductComboBox_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.icons8_search_60;
            pictureBox1.Location = new Point(19, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // InventorySearchBox
            // 
            InventorySearchBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            InventorySearchBox.AnimateReadOnly = false;
            InventorySearchBox.BorderStyle = BorderStyle.None;
            InventorySearchBox.Depth = 0;
            InventorySearchBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            InventorySearchBox.LeadingIcon = null;
            InventorySearchBox.Location = new Point(75, 18);
            InventorySearchBox.MaxLength = 50;
            InventorySearchBox.MouseState = MaterialSkin.MouseState.OUT;
            InventorySearchBox.Multiline = false;
            InventorySearchBox.Name = "InventorySearchBox";
            InventorySearchBox.Size = new Size(840, 50);
            InventorySearchBox.TabIndex = 18;
            InventorySearchBox.Text = "";
            InventorySearchBox.TrailingIcon = null;
            InventorySearchBox.TextChanged += InventorySearchBox_TextChanged;
            // 
            // InventoryListPanel
            // 
            InventoryListPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            InventoryListPanel.AutoScroll = true;
            InventoryListPanel.BackColor = Color.Transparent;
            InventoryListPanel.Location = new Point(19, 86);
            InventoryListPanel.Name = "InventoryListPanel";
            InventoryListPanel.Size = new Size(1225, 467);
            InventoryListPanel.TabIndex = 22;
            // 
            // AddProductButton
            // 
            AddProductButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AddProductButton.AutoSize = false;
            AddProductButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AddProductButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            AddProductButton.Depth = 0;
            AddProductButton.HighEmphasis = true;
            AddProductButton.Icon = null;
            AddProductButton.Location = new Point(1091, 562);
            AddProductButton.Margin = new Padding(4, 6, 4, 6);
            AddProductButton.MouseState = MaterialSkin.MouseState.HOVER;
            AddProductButton.Name = "AddProductButton";
            AddProductButton.NoAccentTextColor = Color.Empty;
            AddProductButton.Size = new Size(151, 42);
            AddProductButton.TabIndex = 23;
            AddProductButton.Text = "Add Prodcut";
            AddProductButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            AddProductButton.UseAccentColor = false;
            AddProductButton.UseVisualStyleBackColor = true;
            AddProductButton.Click += AddProductButton_Click;
            // 
            // SupplierInventory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(AddProductButton);
            Controls.Add(InventoryListPanel);
            Controls.Add(InventoryStockComboBox);
            Controls.Add(InventoryProductComboBox);
            Controls.Add(pictureBox1);
            Controls.Add(InventorySearchBox);
            Name = "SupplierInventory";
            Size = new Size(1266, 610);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox InventoryStockComboBox;
        private MaterialSkin.Controls.MaterialComboBox InventoryProductComboBox;
        private PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialTextBox InventorySearchBox;
        private FlowLayoutPanel InventoryListPanel;
        private MaterialSkin.Controls.MaterialButton AddProductButton;
    }
}
