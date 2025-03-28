﻿namespace UrbanFood.Forms
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
            TabBarImageList = new ImageList(components);
            OrderPage = new TabPage();
            InventoryPage = new TabPage();
            MainTabBar = new MaterialSkin.Controls.MaterialTabControl();
            SalsePage = new TabPage();
            ProfilePage = new TabPage();
            MainTabBar.SuspendLayout();
            SuspendLayout();
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
            // MainTabBar
            // 
            MainTabBar.Controls.Add(SalsePage);
            MainTabBar.Controls.Add(InventoryPage);
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
            MainTabBar.TabIndex = 6;
            MainTabBar.SelectedIndexChanged += MainTabBar_SelectedIndexChanged;
            // 
            // SalsePage
            // 
            SalsePage.ImageKey = "icons8-sales-32.png";
            SalsePage.Location = new Point(4, 39);
            SalsePage.Name = "SalsePage";
            SalsePage.Padding = new Padding(3);
            SalsePage.Size = new Size(1266, 610);
            SalsePage.TabIndex = 6;
            SalsePage.Text = "Salse";
            SalsePage.UseVisualStyleBackColor = true;
            // 
            // ProfilePage
            // 
            ProfilePage.ImageKey = "icons8-profile-32.png";
            ProfilePage.Location = new Point(4, 39);
            ProfilePage.Name = "ProfilePage";
            ProfilePage.Padding = new Padding(3);
            ProfilePage.Size = new Size(1266, 610);
            ProfilePage.TabIndex = 5;
            ProfilePage.Text = "Profile";
            ProfilePage.UseVisualStyleBackColor = true;
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
        private ImageList TabBarImageList;
        private TabPage OrderPage;
        private TabPage InventoryPage;
        private MaterialSkin.Controls.MaterialTabControl MainTabBar;
        private TabPage ProfilePage;
        private TabPage SalsePage;
    }
}