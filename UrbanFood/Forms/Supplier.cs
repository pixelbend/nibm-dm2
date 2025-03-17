using MaterialSkin.Controls;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using UrbanFood.Controls;
using UrbanFood.Database.OracleDB;
using UrbanFood.LocalState;
using UrbanFood.UserControls;
using UrbanFood.Utils;

namespace UrbanFood.Forms
{
    public partial class Supplier : MaterialForm
    {
        public Supplier()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            InitializeMainTabBar();
        }

        private void SupplierMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void Supplier_Load(object sender, EventArgs e)
        {

        }

        private void InitializeMainTabBar()
        {
            MainTabBar.TabPages[0].Controls.Clear();
            MainTabBar.TabPages[0].Controls.Add(new SupplierInventory() { Dock = DockStyle.Fill });
            MainTabBar.TabPages[3].Controls.Clear();
            MainTabBar.TabPages[3].Controls.Add(new Profile() { Dock = DockStyle.Fill });
        }

        private void MainTabBar_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainTabBar.TabPages[0].Controls.Clear();
            MainTabBar.TabPages[3].Controls.Clear();

            if (MainTabBar.SelectedIndex == 0)
            {
                MainTabBar.TabPages[0].Controls.Add(new SupplierInventory() { Dock = DockStyle.Fill });
            }
            else if (MainTabBar.SelectedIndex == 3)
            {
                MainTabBar.TabPages[3].Controls.Add(new Profile() { Dock = DockStyle.Fill });
            }
        }
    }
}
