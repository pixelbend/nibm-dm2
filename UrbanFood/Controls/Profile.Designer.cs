namespace UrbanFood.Controls
{
    partial class Profile
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
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            PhoneTextBox = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            AddressTextBox = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            NameTextBox = new MaterialSkin.Controls.MaterialTextBox();
            EmailLbl = new MaterialSkin.Controls.MaterialLabel();
            EmailTextBox = new MaterialSkin.Controls.MaterialTextBox();
            SaveChangesButton = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(40, 199);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(46, 19);
            materialLabel3.TabIndex = 26;
            materialLabel3.Text = "Phone";
            // 
            // PhoneTextBox
            // 
            PhoneTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PhoneTextBox.AnimateReadOnly = false;
            PhoneTextBox.BorderStyle = BorderStyle.None;
            PhoneTextBox.Depth = 0;
            PhoneTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            PhoneTextBox.LeadingIcon = null;
            PhoneTextBox.LeaveOnEnterKey = true;
            PhoneTextBox.Location = new Point(38, 221);
            PhoneTextBox.MaxLength = 50;
            PhoneTextBox.MouseState = MaterialSkin.MouseState.OUT;
            PhoneTextBox.Multiline = false;
            PhoneTextBox.Name = "PhoneTextBox";
            PhoneTextBox.Size = new Size(1181, 50);
            PhoneTextBox.TabIndex = 25;
            PhoneTextBox.Text = "";
            PhoneTextBox.TrailingIcon = null;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(40, 113);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(58, 19);
            materialLabel2.TabIndex = 24;
            materialLabel2.Text = "Address";
            // 
            // AddressTextBox
            // 
            AddressTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AddressTextBox.AnimateReadOnly = false;
            AddressTextBox.BorderStyle = BorderStyle.None;
            AddressTextBox.Depth = 0;
            AddressTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            AddressTextBox.LeadingIcon = null;
            AddressTextBox.LeaveOnEnterKey = true;
            AddressTextBox.Location = new Point(38, 135);
            AddressTextBox.MaxLength = 50;
            AddressTextBox.MouseState = MaterialSkin.MouseState.OUT;
            AddressTextBox.Multiline = false;
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(1181, 50);
            AddressTextBox.TabIndex = 23;
            AddressTextBox.Text = "";
            AddressTextBox.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(40, 26);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(43, 19);
            materialLabel1.TabIndex = 22;
            materialLabel1.Text = "Name";
            // 
            // NameTextBox
            // 
            NameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NameTextBox.AnimateReadOnly = false;
            NameTextBox.BorderStyle = BorderStyle.None;
            NameTextBox.Depth = 0;
            NameTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            NameTextBox.LeadingIcon = null;
            NameTextBox.LeaveOnEnterKey = true;
            NameTextBox.Location = new Point(38, 48);
            NameTextBox.MaxLength = 50;
            NameTextBox.MouseState = MaterialSkin.MouseState.OUT;
            NameTextBox.Multiline = false;
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(1181, 50);
            NameTextBox.TabIndex = 21;
            NameTextBox.Text = "";
            NameTextBox.TrailingIcon = null;
            // 
            // EmailLbl
            // 
            EmailLbl.AutoSize = true;
            EmailLbl.Depth = 0;
            EmailLbl.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            EmailLbl.Location = new Point(40, 282);
            EmailLbl.MouseState = MaterialSkin.MouseState.HOVER;
            EmailLbl.Name = "EmailLbl";
            EmailLbl.Size = new Size(41, 19);
            EmailLbl.TabIndex = 20;
            EmailLbl.Text = "Email";
            // 
            // EmailTextBox
            // 
            EmailTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            EmailTextBox.AnimateReadOnly = false;
            EmailTextBox.BorderStyle = BorderStyle.None;
            EmailTextBox.Depth = 0;
            EmailTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            EmailTextBox.LeadingIcon = null;
            EmailTextBox.LeaveOnEnterKey = true;
            EmailTextBox.Location = new Point(38, 304);
            EmailTextBox.MaxLength = 50;
            EmailTextBox.MouseState = MaterialSkin.MouseState.OUT;
            EmailTextBox.Multiline = false;
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(1181, 50);
            EmailTextBox.TabIndex = 19;
            EmailTextBox.Text = "";
            EmailTextBox.TrailingIcon = null;
            // 
            // SaveChangesButton
            // 
            SaveChangesButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SaveChangesButton.AutoSize = false;
            SaveChangesButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SaveChangesButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            SaveChangesButton.Depth = 0;
            SaveChangesButton.HighEmphasis = true;
            SaveChangesButton.Icon = null;
            SaveChangesButton.Location = new Point(557, 493);
            SaveChangesButton.Margin = new Padding(4, 6, 4, 6);
            SaveChangesButton.MouseState = MaterialSkin.MouseState.HOVER;
            SaveChangesButton.Name = "SaveChangesButton";
            SaveChangesButton.NoAccentTextColor = Color.Empty;
            SaveChangesButton.Size = new Size(198, 45);
            SaveChangesButton.TabIndex = 27;
            SaveChangesButton.Text = "Save Changes";
            SaveChangesButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            SaveChangesButton.UseAccentColor = false;
            SaveChangesButton.UseVisualStyleBackColor = true;
            SaveChangesButton.Click += SaveChangesButton_Click;
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(SaveChangesButton);
            Controls.Add(materialLabel3);
            Controls.Add(PhoneTextBox);
            Controls.Add(materialLabel2);
            Controls.Add(AddressTextBox);
            Controls.Add(materialLabel1);
            Controls.Add(NameTextBox);
            Controls.Add(EmailLbl);
            Controls.Add(EmailTextBox);
            Name = "Profile";
            Size = new Size(1266, 610);
            Load += Profile_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialTextBox PhoneTextBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox AddressTextBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox NameTextBox;
        private MaterialSkin.Controls.MaterialLabel EmailLbl;
        private MaterialSkin.Controls.MaterialTextBox EmailTextBox;
        private MaterialSkin.Controls.MaterialButton SaveChangesButton;
    }
}
