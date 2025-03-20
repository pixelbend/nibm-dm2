namespace UrbanFood.Forms
{
    partial class OrderProduct
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
            QuantityUpDown = new NumericUpDown();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            TotalPriceTextBox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            ConfirmPurchaseButton = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)QuantityUpDown).BeginInit();
            SuspendLayout();
            // 
            // QuantityUpDown
            // 
            QuantityUpDown.Location = new Point(29, 113);
            QuantityUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            QuantityUpDown.Name = "QuantityUpDown";
            QuantityUpDown.ReadOnly = true;
            QuantityUpDown.Size = new Size(263, 27);
            QuantityUpDown.TabIndex = 0;
            QuantityUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            QuantityUpDown.ValueChanged += QuantityUpDown_ValueChanged;
            QuantityUpDown.KeyPress += QuantityUpDown_KeyPress;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(29, 91);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(88, 19);
            materialLabel1.TabIndex = 1;
            materialLabel1.Text = "Unit Quantiy";
            materialLabel1.Click += materialLabel1_Click;
            // 
            // TotalPriceTextBox
            // 
            TotalPriceTextBox.AllowPromptAsInput = true;
            TotalPriceTextBox.AnimateReadOnly = false;
            TotalPriceTextBox.AsciiOnly = false;
            TotalPriceTextBox.BackgroundImageLayout = ImageLayout.None;
            TotalPriceTextBox.BeepOnError = false;
            TotalPriceTextBox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            TotalPriceTextBox.Depth = 0;
            TotalPriceTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TotalPriceTextBox.HidePromptOnLeave = false;
            TotalPriceTextBox.HideSelection = true;
            TotalPriceTextBox.InsertKeyMode = InsertKeyMode.Default;
            TotalPriceTextBox.LeadingIcon = null;
            TotalPriceTextBox.Location = new Point(29, 182);
            TotalPriceTextBox.Mask = "";
            TotalPriceTextBox.MaxLength = 32767;
            TotalPriceTextBox.MouseState = MaterialSkin.MouseState.OUT;
            TotalPriceTextBox.Name = "TotalPriceTextBox";
            TotalPriceTextBox.PasswordChar = '\0';
            TotalPriceTextBox.PrefixSuffixText = null;
            TotalPriceTextBox.PromptChar = '_';
            TotalPriceTextBox.ReadOnly = true;
            TotalPriceTextBox.RejectInputOnFirstFailure = false;
            TotalPriceTextBox.ResetOnPrompt = true;
            TotalPriceTextBox.ResetOnSpace = true;
            TotalPriceTextBox.RightToLeft = RightToLeft.No;
            TotalPriceTextBox.SelectedText = "";
            TotalPriceTextBox.SelectionLength = 0;
            TotalPriceTextBox.SelectionStart = 0;
            TotalPriceTextBox.ShortcutsEnabled = true;
            TotalPriceTextBox.Size = new Size(263, 48);
            TotalPriceTextBox.SkipLiterals = true;
            TotalPriceTextBox.TabIndex = 2;
            TotalPriceTextBox.TabStop = false;
            TotalPriceTextBox.TextAlign = HorizontalAlignment.Left;
            TotalPriceTextBox.TextMaskFormat = MaskFormat.IncludeLiterals;
            TotalPriceTextBox.TrailingIcon = null;
            TotalPriceTextBox.UseSystemPasswordChar = false;
            TotalPriceTextBox.ValidatingType = null;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(29, 160);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(77, 19);
            materialLabel2.TabIndex = 3;
            materialLabel2.Text = "Total Price";
            // 
            // ConfirmPurchaseButton
            // 
            ConfirmPurchaseButton.AutoSize = false;
            ConfirmPurchaseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ConfirmPurchaseButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            ConfirmPurchaseButton.Depth = 0;
            ConfirmPurchaseButton.HighEmphasis = true;
            ConfirmPurchaseButton.Icon = null;
            ConfirmPurchaseButton.Location = new Point(61, 260);
            ConfirmPurchaseButton.Margin = new Padding(4, 6, 4, 6);
            ConfirmPurchaseButton.MouseState = MaterialSkin.MouseState.HOVER;
            ConfirmPurchaseButton.Name = "ConfirmPurchaseButton";
            ConfirmPurchaseButton.NoAccentTextColor = Color.Empty;
            ConfirmPurchaseButton.Size = new Size(198, 45);
            ConfirmPurchaseButton.TabIndex = 4;
            ConfirmPurchaseButton.Text = "Confirm";
            ConfirmPurchaseButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            ConfirmPurchaseButton.UseAccentColor = false;
            ConfirmPurchaseButton.UseVisualStyleBackColor = true;
            ConfirmPurchaseButton.Click += ConfirmPurchaseButton_Click;
            // 
            // OrderProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 345);
            Controls.Add(ConfirmPurchaseButton);
            Controls.Add(materialLabel2);
            Controls.Add(TotalPriceTextBox);
            Controls.Add(materialLabel1);
            Controls.Add(QuantityUpDown);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OrderProduct";
            Sizable = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Order Product";
            Load += BuyProduct_Load;
            ((System.ComponentModel.ISupportInitialize)QuantityUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown QuantityUpDown;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialMaskedTextBox TotalPriceTextBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialButton ConfirmPurchaseButton;
    }
}