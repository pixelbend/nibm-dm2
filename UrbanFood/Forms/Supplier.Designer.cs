namespace UrbanFood.Forms
{
    partial class Supplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Supplier));
            MainTabBar = new MaterialSkin.Controls.MaterialTabControl();
            InventoryPage = new TabPage();
            OrderPage = new TabPage();
            DeliveryPage = new TabPage();
            ProfilePage = new TabPage();
            TabBarImageList = new ImageList(components);
            MainTabBar.SuspendLayout();
            SuspendLayout();
            // 
            // MainTabBar
            // 
            MainTabBar.Controls.Add(InventoryPage);
            MainTabBar.Controls.Add(OrderPage);
            MainTabBar.Controls.Add(DeliveryPage);
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
            MainTabBar.TabIndex = 6;
            MainTabBar.SelectedIndexChanged += MainTabBar_SelectedIndexChanged;
            // 
            // InventoryPage
            // 
            InventoryPage.BackColor = Color.Transparent;
            InventoryPage.ImageKey = "icons8-inventory-32.png";
            InventoryPage.Location = new Point(4, 39);
            InventoryPage.Name = "InventoryPage";
            InventoryPage.Padding = new Padding(3);
            InventoryPage.Size = new Size(1266, 610);
            InventoryPage.TabIndex = 1;
            InventoryPage.Text = "Inventory";
            // 
            // OrderPage
            // 
            OrderPage.ImageKey = "icons8-order-32.png";
            OrderPage.Location = new Point(4, 39);
            OrderPage.Name = "OrderPage";
            OrderPage.Padding = new Padding(3);
            OrderPage.Size = new Size(1266, 610);
            OrderPage.TabIndex = 4;
            OrderPage.Text = "Order";
            OrderPage.UseVisualStyleBackColor = true;
            // 
            // DeliveryPage
            // 
            DeliveryPage.ImageKey = "icons8-delivery-32.png";
            DeliveryPage.Location = new Point(4, 39);
            DeliveryPage.Name = "DeliveryPage";
            DeliveryPage.Padding = new Padding(3);
            DeliveryPage.Size = new Size(1266, 610);
            DeliveryPage.TabIndex = 3;
            DeliveryPage.Text = "Delivery";
            DeliveryPage.UseVisualStyleBackColor = true;
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
            TabBarImageList.Images.SetKeyName(1, "icons8-delivery-32.png");
            TabBarImageList.Images.SetKeyName(2, "icons8-inventory-32.png");
            TabBarImageList.Images.SetKeyName(3, "icons8-sales-32.png");
            TabBarImageList.Images.SetKeyName(4, "icons8-order-32.png");
            // 
            // Supplier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(MainTabBar);
            DrawerAutoShow = true;
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = MainTabBar;
            Name = "Supplier";
            Text = "UrbanFood";
            FormClosing += SupplierMainForm_FormClosing;
            Load += Supplier_Load;
            MainTabBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl MainTabBar;
        private TabPage InventoryPage;
        private TabPage ProfilePage;
        private ImageList TabBarImageList;
        private TabPage DeliveryPage;
        private TabPage OrderPage;
    }
}