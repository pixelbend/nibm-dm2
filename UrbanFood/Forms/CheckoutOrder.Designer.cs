namespace UrbanFood.Forms
{
    partial class CheckoutOrder
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
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            CardNoTextBox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            CVCTextBox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            CardExpiryLbl = new MaterialSkin.Controls.MaterialLabel();
            CardExpiryTimePicker = new DateTimePicker();
            ConfirmButton = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(21, 85);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(58, 19);
            materialLabel2.TabIndex = 5;
            materialLabel2.Text = "Card No";
            // 
            // CardNoTextBox
            // 
            CardNoTextBox.AllowPromptAsInput = true;
            CardNoTextBox.AnimateReadOnly = false;
            CardNoTextBox.AsciiOnly = false;
            CardNoTextBox.BackgroundImageLayout = ImageLayout.None;
            CardNoTextBox.BeepOnError = false;
            CardNoTextBox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            CardNoTextBox.Depth = 0;
            CardNoTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            CardNoTextBox.HidePromptOnLeave = false;
            CardNoTextBox.HideSelection = true;
            CardNoTextBox.InsertKeyMode = InsertKeyMode.Default;
            CardNoTextBox.LeadingIcon = null;
            CardNoTextBox.Location = new Point(21, 107);
            CardNoTextBox.Mask = "";
            CardNoTextBox.MaxLength = 32767;
            CardNoTextBox.MouseState = MaterialSkin.MouseState.OUT;
            CardNoTextBox.Name = "CardNoTextBox";
            CardNoTextBox.PasswordChar = '\0';
            CardNoTextBox.PrefixSuffixText = null;
            CardNoTextBox.PromptChar = '_';
            CardNoTextBox.ReadOnly = false;
            CardNoTextBox.RejectInputOnFirstFailure = false;
            CardNoTextBox.ResetOnPrompt = true;
            CardNoTextBox.ResetOnSpace = true;
            CardNoTextBox.RightToLeft = RightToLeft.No;
            CardNoTextBox.SelectedText = "";
            CardNoTextBox.SelectionLength = 0;
            CardNoTextBox.SelectionStart = 0;
            CardNoTextBox.ShortcutsEnabled = true;
            CardNoTextBox.Size = new Size(463, 48);
            CardNoTextBox.SkipLiterals = true;
            CardNoTextBox.TabIndex = 4;
            CardNoTextBox.TabStop = false;
            CardNoTextBox.TextAlign = HorizontalAlignment.Left;
            CardNoTextBox.TextMaskFormat = MaskFormat.IncludeLiterals;
            CardNoTextBox.TrailingIcon = null;
            CardNoTextBox.UseSystemPasswordChar = false;
            CardNoTextBox.ValidatingType = null;
            // 
            // CVCTextBox
            // 
            CVCTextBox.AllowPromptAsInput = true;
            CVCTextBox.AnimateReadOnly = false;
            CVCTextBox.AsciiOnly = false;
            CVCTextBox.BackgroundImageLayout = ImageLayout.None;
            CVCTextBox.BeepOnError = false;
            CVCTextBox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            CVCTextBox.Depth = 0;
            CVCTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            CVCTextBox.HidePromptOnLeave = false;
            CVCTextBox.HideSelection = true;
            CVCTextBox.InsertKeyMode = InsertKeyMode.Default;
            CVCTextBox.LeadingIcon = null;
            CVCTextBox.Location = new Point(21, 197);
            CVCTextBox.Mask = "";
            CVCTextBox.MaxLength = 32767;
            CVCTextBox.MouseState = MaterialSkin.MouseState.OUT;
            CVCTextBox.Name = "CVCTextBox";
            CVCTextBox.PasswordChar = '\0';
            CVCTextBox.PrefixSuffixText = null;
            CVCTextBox.PromptChar = '_';
            CVCTextBox.ReadOnly = false;
            CVCTextBox.RejectInputOnFirstFailure = false;
            CVCTextBox.ResetOnPrompt = true;
            CVCTextBox.ResetOnSpace = true;
            CVCTextBox.RightToLeft = RightToLeft.No;
            CVCTextBox.SelectedText = "";
            CVCTextBox.SelectionLength = 0;
            CVCTextBox.SelectionStart = 0;
            CVCTextBox.ShortcutsEnabled = true;
            CVCTextBox.Size = new Size(463, 48);
            CVCTextBox.SkipLiterals = true;
            CVCTextBox.TabIndex = 6;
            CVCTextBox.TabStop = false;
            CVCTextBox.TextAlign = HorizontalAlignment.Left;
            CVCTextBox.TextMaskFormat = MaskFormat.IncludeLiterals;
            CVCTextBox.TrailingIcon = null;
            CVCTextBox.UseSystemPasswordChar = false;
            CVCTextBox.ValidatingType = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(21, 175);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(31, 19);
            materialLabel1.TabIndex = 7;
            materialLabel1.Text = "CVC";
            // 
            // CardExpiryLbl
            // 
            CardExpiryLbl.AutoSize = true;
            CardExpiryLbl.Depth = 0;
            CardExpiryLbl.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            CardExpiryLbl.Location = new Point(21, 265);
            CardExpiryLbl.MouseState = MaterialSkin.MouseState.HOVER;
            CardExpiryLbl.Name = "CardExpiryLbl";
            CardExpiryLbl.Size = new Size(81, 19);
            CardExpiryLbl.TabIndex = 9;
            CardExpiryLbl.Text = "Card Expiry";
            // 
            // CardExpiryTimePicker
            // 
            CardExpiryTimePicker.Location = new Point(21, 287);
            CardExpiryTimePicker.Name = "CardExpiryTimePicker";
            CardExpiryTimePicker.Size = new Size(463, 27);
            CardExpiryTimePicker.TabIndex = 10;
            // 
            // ConfirmButton
            // 
            ConfirmButton.AutoSize = false;
            ConfirmButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ConfirmButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            ConfirmButton.Depth = 0;
            ConfirmButton.HighEmphasis = true;
            ConfirmButton.Icon = null;
            ConfirmButton.Location = new Point(150, 346);
            ConfirmButton.Margin = new Padding(4, 6, 4, 6);
            ConfirmButton.MouseState = MaterialSkin.MouseState.HOVER;
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.NoAccentTextColor = Color.Empty;
            ConfirmButton.Size = new Size(198, 45);
            ConfirmButton.TabIndex = 11;
            ConfirmButton.Text = "Confirm";
            ConfirmButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            ConfirmButton.UseAccentColor = false;
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // CheckoutOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 420);
            Controls.Add(ConfirmButton);
            Controls.Add(CardExpiryTimePicker);
            Controls.Add(CardExpiryLbl);
            Controls.Add(materialLabel1);
            Controls.Add(CVCTextBox);
            Controls.Add(materialLabel2);
            Controls.Add(CardNoTextBox);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CheckoutOrder";
            Sizable = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Checkout";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialMaskedTextBox CardNoTextBox;
        private MaterialSkin.Controls.MaterialMaskedTextBox CVCTextBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel CardExpiryLbl;
        private DateTimePicker CardExpiryTimePicker;
        private MaterialSkin.Controls.MaterialButton ConfirmButton;
    }
}