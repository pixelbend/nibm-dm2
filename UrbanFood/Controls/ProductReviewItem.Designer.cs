namespace UrbanFood.Controls
{
    partial class ProductReviewItem
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
            ContentLabel = new Label();
            CreatedAtLabel = new Label();
            EditButton = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // ContentLabel
            // 
            ContentLabel.Location = new Point(17, 14);
            ContentLabel.Name = "ContentLabel";
            ContentLabel.Size = new Size(616, 85);
            ContentLabel.TabIndex = 0;
            ContentLabel.Text = "Content";
            // 
            // CreatedAtLabel
            // 
            CreatedAtLabel.AutoSize = true;
            CreatedAtLabel.Location = new Point(17, 117);
            CreatedAtLabel.Name = "CreatedAtLabel";
            CreatedAtLabel.Size = new Size(76, 20);
            CreatedAtLabel.TabIndex = 1;
            CreatedAtLabel.Text = "CreatedAt";
            // 
            // EditButton
            // 
            EditButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            EditButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            EditButton.Depth = 0;
            EditButton.HighEmphasis = true;
            EditButton.Icon = null;
            EditButton.Location = new Point(569, 107);
            EditButton.Margin = new Padding(4, 6, 4, 6);
            EditButton.MouseState = MaterialSkin.MouseState.HOVER;
            EditButton.Name = "EditButton";
            EditButton.NoAccentTextColor = Color.Empty;
            EditButton.Size = new Size(64, 36);
            EditButton.TabIndex = 2;
            EditButton.Text = "Edit";
            EditButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            EditButton.UseAccentColor = false;
            EditButton.UseVisualStyleBackColor = true;
            // 
            // ProductReviewItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(EditButton);
            Controls.Add(CreatedAtLabel);
            Controls.Add(ContentLabel);
            Name = "ProductReviewItem";
            Size = new Size(650, 150);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ContentLabel;
        private Label CreatedAtLabel;
        private MaterialSkin.Controls.MaterialButton EditButton;
    }
}
