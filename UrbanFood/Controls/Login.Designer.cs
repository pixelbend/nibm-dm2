namespace UrbanFood.Controls
{
    partial class Login
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
            PasswordLbl = new MaterialSkin.Controls.MaterialLabel();
            LoginEmailTextBox = new MaterialSkin.Controls.MaterialTextBox();
            EmailLbl = new MaterialSkin.Controls.MaterialLabel();
            LoginPasswordTextBox = new MaterialSkin.Controls.MaterialTextBox();
            LoginButton = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // PasswordLbl
            // 
            PasswordLbl.AutoSize = true;
            PasswordLbl.Depth = 0;
            PasswordLbl.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            PasswordLbl.Location = new Point(37, 256);
            PasswordLbl.MouseState = MaterialSkin.MouseState.HOVER;
            PasswordLbl.Name = "PasswordLbl";
            PasswordLbl.Size = new Size(71, 19);
            PasswordLbl.TabIndex = 16;
            PasswordLbl.Text = "Password";
            // 
            // LoginEmailTextBox
            // 
            LoginEmailTextBox.AnimateReadOnly = false;
            LoginEmailTextBox.BorderStyle = BorderStyle.None;
            LoginEmailTextBox.Depth = 0;
            LoginEmailTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            LoginEmailTextBox.LeadingIcon = null;
            LoginEmailTextBox.LeaveOnEnterKey = true;
            LoginEmailTextBox.Location = new Point(33, 159);
            LoginEmailTextBox.MaxLength = 50;
            LoginEmailTextBox.MouseState = MaterialSkin.MouseState.OUT;
            LoginEmailTextBox.Multiline = false;
            LoginEmailTextBox.Name = "LoginEmailTextBox";
            LoginEmailTextBox.Size = new Size(430, 50);
            LoginEmailTextBox.TabIndex = 12;
            LoginEmailTextBox.Text = "";
            LoginEmailTextBox.TrailingIcon = null;
            // 
            // EmailLbl
            // 
            EmailLbl.AutoSize = true;
            EmailLbl.Depth = 0;
            EmailLbl.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            EmailLbl.Location = new Point(35, 137);
            EmailLbl.MouseState = MaterialSkin.MouseState.HOVER;
            EmailLbl.Name = "EmailLbl";
            EmailLbl.Size = new Size(41, 19);
            EmailLbl.TabIndex = 15;
            EmailLbl.Text = "Email";
            // 
            // LoginPasswordTextBox
            // 
            LoginPasswordTextBox.AnimateReadOnly = false;
            LoginPasswordTextBox.BorderStyle = BorderStyle.None;
            LoginPasswordTextBox.Depth = 0;
            LoginPasswordTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            LoginPasswordTextBox.LeadingIcon = null;
            LoginPasswordTextBox.LeaveOnEnterKey = true;
            LoginPasswordTextBox.Location = new Point(33, 278);
            LoginPasswordTextBox.MaxLength = 50;
            LoginPasswordTextBox.MouseState = MaterialSkin.MouseState.OUT;
            LoginPasswordTextBox.Multiline = false;
            LoginPasswordTextBox.Name = "LoginPasswordTextBox";
            LoginPasswordTextBox.Password = true;
            LoginPasswordTextBox.Size = new Size(432, 50);
            LoginPasswordTextBox.TabIndex = 13;
            LoginPasswordTextBox.Text = "";
            LoginPasswordTextBox.TrailingIcon = null;
            // 
            // LoginButton
            // 
            LoginButton.AutoSize = false;
            LoginButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LoginButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            LoginButton.Depth = 0;
            LoginButton.HighEmphasis = true;
            LoginButton.Icon = null;
            LoginButton.Location = new Point(150, 368);
            LoginButton.Margin = new Padding(4, 6, 4, 6);
            LoginButton.MouseState = MaterialSkin.MouseState.HOVER;
            LoginButton.Name = "LoginButton";
            LoginButton.NoAccentTextColor = Color.Empty;
            LoginButton.Size = new Size(198, 45);
            LoginButton.TabIndex = 14;
            LoginButton.Text = "Login";
            LoginButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            LoginButton.UseAccentColor = false;
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PasswordLbl);
            Controls.Add(LoginEmailTextBox);
            Controls.Add(EmailLbl);
            Controls.Add(LoginPasswordTextBox);
            Controls.Add(LoginButton);
            Name = "Login";
            Size = new Size(500, 550);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel PasswordLbl;
        private MaterialSkin.Controls.MaterialTextBox LoginEmailTextBox;
        private MaterialSkin.Controls.MaterialLabel EmailLbl;
        private MaterialSkin.Controls.MaterialTextBox LoginPasswordTextBox;
        private MaterialSkin.Controls.MaterialButton LoginButton;
    }
}
