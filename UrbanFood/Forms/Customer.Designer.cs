namespace UrbanFood.Forms
{
    partial class Customer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customer));
            MainTabBar = new MaterialSkin.Controls.MaterialTabControl();
            MarketPage = new TabPage();
            OrderPage = new TabPage();
            ProfilePage = new TabPage();
            TabBarImageList = new ImageList(components);
            MainTabBar.SuspendLayout();
            SuspendLayout();
            // 
            // MainTabBar
            // 
            MainTabBar.Controls.Add(MarketPage);
            MainTabBar.Controls.Add(OrderPage);
            MainTabBar.Controls.Add(ProfilePage);
            MainTabBar.Depth = 0;
            MainTabBar.Dock = DockStyle.Fill;
            MainTabBar.ImageList = TabBarImageList;
            MainTabBar.Location = new Point(3, 64);
            MainTabBar.MouseState = MaterialSkin.MouseState.HOVER;
            MainTabBar.Multiline = true;
            MainTabBar.Name = "MainTabBar";
            MainTabBar.SelectedIndex = 0;
            MainTabBar.Size = new Size(1274, 653);
            MainTabBar.TabIndex = 5;
            MainTabBar.SelectedIndexChanged += MainTabBar_SelectedIndexChanged;
            // 
            // MarketPage
            // 
            MarketPage.BackColor = Color.Transparent;
            MarketPage.ImageKey = "icons8-market-32.png";
            MarketPage.Location = new Point(4, 39);
            MarketPage.Name = "MarketPage";
            MarketPage.Padding = new Padding(3);
            MarketPage.Size = new Size(1266, 610);
            MarketPage.TabIndex = 0;
            MarketPage.Text = "Market";
            // 
            // OrderPage
            // 
            OrderPage.ImageKey = "icons8-order-32.png";
            OrderPage.Location = new Point(4, 39);
            OrderPage.Name = "OrderPage";
            OrderPage.Padding = new Padding(3);
            OrderPage.Size = new Size(1266, 610);
            OrderPage.TabIndex = 1;
            OrderPage.Text = "Order";
            OrderPage.UseVisualStyleBackColor = true;
            // 
            // ProfilePage
            // 
            ProfilePage.ImageKey = "icons8-profile-32.png";
            ProfilePage.Location = new Point(4, 39);
            ProfilePage.Name = "ProfilePage";
            ProfilePage.Padding = new Padding(3);
            ProfilePage.Size = new Size(1266, 610);
            ProfilePage.TabIndex = 2;
            ProfilePage.Text = "Profile";
            ProfilePage.UseVisualStyleBackColor = true;
            // 
            // TabBarImageList
            // 
            TabBarImageList.ColorDepth = ColorDepth.Depth32Bit;
            TabBarImageList.ImageStream = (ImageListStreamer)resources.GetObject("TabBarImageList.ImageStream");
            TabBarImageList.TransparentColor = Color.Transparent;
            TabBarImageList.Images.SetKeyName(0, "icons8-profile-32.png");
            TabBarImageList.Images.SetKeyName(1, "icons8-order-32.png");
            TabBarImageList.Images.SetKeyName(2, "icons8-market-32.png");
            // 
            // Customer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(MainTabBar);
            DrawerAutoShow = true;
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = MainTabBar;
            Name = "Customer";
            Text = "UrbanFood";
            FormClosing += CustomerMainForm_FormClosing;
            Load += CustomerMainForm_Load;
            MainTabBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private MaterialSkin.Controls.MaterialTabControl MainTabBar;
        private TabPage MarketPage;
        private TabPage OrderPage;
        private TabPage ProfilePage;
        private ImageList TabBarImageList;
    }
}