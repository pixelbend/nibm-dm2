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
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            DeleteButton = new MaterialSkin.Controls.MaterialButton();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // ContentLabel
            // 
            ContentLabel.Location = new Point(17, 14);
            ContentLabel.Name = "ContentLabel";
            ContentLabel.Size = new Size(712, 73);
            ContentLabel.TabIndex = 0;
            ContentLabel.Text = "Content";
            // 
            // CreatedAtLabel
            // 
            CreatedAtLabel.AutoSize = true;
            CreatedAtLabel.Location = new Point(17, 113);
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
            EditButton.Location = new Point(582, 97);
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
            EditButton.Click += EditButton_Click;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(DeleteButton);
            materialCard1.Controls.Add(CreatedAtLabel);
            materialCard1.Controls.Add(EditButton);
            materialCard1.Controls.Add(ContentLabel);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(745, 150);
            materialCard1.TabIndex = 3;
            // 
            // DeleteButton
            // 
            DeleteButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DeleteButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            DeleteButton.Depth = 0;
            DeleteButton.HighEmphasis = true;
            DeleteButton.Icon = null;
            DeleteButton.Location = new Point(654, 97);
            DeleteButton.Margin = new Padding(4, 6, 4, 6);
            DeleteButton.MouseState = MaterialSkin.MouseState.HOVER;
            DeleteButton.Name = "DeleteButton";
            DeleteButton.NoAccentTextColor = Color.Empty;
            DeleteButton.Size = new Size(73, 36);
            DeleteButton.TabIndex = 3;
            DeleteButton.Text = "Delete";
            DeleteButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            DeleteButton.UseAccentColor = false;
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // ProductReviewItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(materialCard1);
            Name = "ProductReviewItem";
            Size = new Size(745, 150);
            Load += ProductReviewItem_Load;
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label ContentLabel;
        private Label CreatedAtLabel;
        private MaterialSkin.Controls.MaterialButton EditButton;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialButton DeleteButton;
    }
}
