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
            SaveButton = new MaterialSkin.Controls.MaterialButton();
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
            // SaveButton
            // 
            SaveButton.AutoSize = false;
            SaveButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SaveButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            SaveButton.Depth = 0;
            SaveButton.HighEmphasis = true;
            SaveButton.Icon = null;
            SaveButton.Location = new Point(550, 394);
            SaveButton.Margin = new Padding(4, 6, 4, 6);
            SaveButton.MouseState = MaterialSkin.MouseState.HOVER;
            SaveButton.Name = "SaveButton";
            SaveButton.NoAccentTextColor = Color.Empty;
            SaveButton.Size = new Size(198, 45);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Save";
            SaveButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            SaveButton.UseAccentColor = false;
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // AddProductReview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 450);
            Controls.Add(SaveButton);
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
        private MaterialSkin.Controls.MaterialButton SaveButton;
    }
}