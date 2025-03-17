namespace UrbanFood.Forms
{
    partial class Auth
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auth));
            AuthTabControl = new MaterialSkin.Controls.MaterialTabControl();
            LoginPage = new TabPage();
            SignupPage = new TabPage();
            AutImageList = new ImageList(components);
            AuthTabControl.SuspendLayout();
            SuspendLayout();
            // 
            // AuthTabControl
            // 
            AuthTabControl.Controls.Add(LoginPage);
            AuthTabControl.Controls.Add(SignupPage);
            AuthTabControl.Depth = 0;
            AuthTabControl.Dock = DockStyle.Fill;
            AuthTabControl.ImageList = AutImageList;
            AuthTabControl.Location = new Point(3, 64);
            AuthTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            AuthTabControl.Multiline = true;
            AuthTabControl.Name = "AuthTabControl";
            AuthTabControl.SelectedIndex = 0;
            AuthTabControl.Size = new Size(544, 633);
            AuthTabControl.TabIndex = 2;
            AuthTabControl.SelectedIndexChanged += AuthTabControl_SelectedIndexChanged;
            // 
            // LoginPage
            // 
            LoginPage.ImageKey = "icons8-login-32.png";
            LoginPage.Location = new Point(4, 29);
            LoginPage.Name = "LoginPage";
            LoginPage.Padding = new Padding(3);
            LoginPage.Size = new Size(536, 600);
            LoginPage.TabIndex = 0;
            LoginPage.Text = "Login";
            LoginPage.UseVisualStyleBackColor = true;
            // 
            // SignupPage
            // 
            SignupPage.ImageKey = "icons8-signup-32.png";
            SignupPage.Location = new Point(4, 29);
            SignupPage.Name = "SignupPage";
            SignupPage.Padding = new Padding(3);
            SignupPage.Size = new Size(536, 600);
            SignupPage.TabIndex = 1;
            SignupPage.Text = "Signup";
            SignupPage.UseVisualStyleBackColor = true;
            // 
            // AutImageList
            // 
            AutImageList.ColorDepth = ColorDepth.Depth32Bit;
            AutImageList.ImageStream = (ImageListStreamer)resources.GetObject("AutImageList.ImageStream");
            AutImageList.TransparentColor = Color.Transparent;
            AutImageList.Images.SetKeyName(0, "icons8-login-32.png");
            AutImageList.Images.SetKeyName(1, "icons8-signup-32.png");
            // 
            // Auth
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 700);
            Controls.Add(AuthTabControl);
            DrawerAutoShow = true;
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = AuthTabControl;
            MaximizeBox = false;
            Name = "Auth";
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Auth";
            FormClosing += Auth_FormClosing;
            AuthTabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialTabControl AuthTabControl;
        private TabPage LoginPage;
        private TabPage SignupPage;
        private ImageList AutImageList;
    }
}