namespace UrbanFood.Forms
{
    partial class AddProductReview
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
            ReviewTextBox = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // ReviewTextBox
            // 
            ReviewTextBox.AnimateReadOnly = false;
            ReviewTextBox.BackgroundImageLayout = ImageLayout.None;
            ReviewTextBox.CharacterCasing = CharacterCasing.Normal;
            ReviewTextBox.Depth = 0;
            ReviewTextBox.HideSelection = true;
            ReviewTextBox.LeaveOnEnterKey = true;
            ReviewTextBox.Location = new Point(19, 82);
            ReviewTextBox.MaxLength = 32767;
            ReviewTextBox.MouseState = MaterialSkin.MouseState.OUT;
            ReviewTextBox.Name = "ReviewTextBox";
            ReviewTextBox.PasswordChar = '\0';
            ReviewTextBox.ReadOnly = false;
            ReviewTextBox.ScrollBars = ScrollBars.None;
            ReviewTextBox.SelectedText = "";
            ReviewTextBox.SelectionLength = 0;
            ReviewTextBox.SelectionStart = 0;
            ReviewTextBox.ShortcutsEnabled = true;
            ReviewTextBox.Size = new Size(729, 302);
            ReviewTextBox.TabIndex = 0;
            ReviewTextBox.TabStop = false;
            ReviewTextBox.TextAlign = HorizontalAlignment.Left;
            ReviewTextBox.UseSystemPasswordChar = false;
            // 
            // materialButton1
            // 
            materialButton1.AutoSize = false;
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(550, 393);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(198, 45);
            materialButton1.TabIndex = 1;
            materialButton1.Text = "Save";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            // 
            // AddProductReview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 450);
            Controls.Add(materialButton1);
            Controls.Add(ReviewTextBox);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddProductReview";
            Sizable = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Review";
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialMultiLineTextBox2 ReviewTextBox;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}