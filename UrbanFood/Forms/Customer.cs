using MaterialSkin.Controls;
using UrbanFood.Controls;
using UrbanFood.Utils;

namespace UrbanFood.Forms
{
    public partial class Customer : MaterialForm
    {
        public Customer()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            InitializeMainTabBar();
        }

        private void CustomerMainForm_Load(object sender, EventArgs e)
        {

        }

        private void CustomerMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void InitializeMainTabBar()
        {
            MainTabBar.TabPages[0].Controls.Clear();
            MainTabBar.TabPages[0].Controls.Add(new Market() { Dock = DockStyle.Fill });
            MainTabBar.TabPages[1].Controls.Clear();
            MainTabBar.TabPages[1].Controls.Add(new CustomerOrder() { Dock = DockStyle.Fill });
            MainTabBar.TabPages[2].Controls.Clear();
            MainTabBar.TabPages[2].Controls.Add(new CustomerOrderHistory() { Dock = DockStyle.Fill });
        }

        private void MainTabBar_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainTabBar.TabPages[0].Controls.Clear();
            MainTabBar.TabPages[1].Controls.Clear();
            MainTabBar.TabPages[2].Controls.Clear();

            if (MainTabBar.SelectedIndex == 0)
            {
                MainTabBar.TabPages[0].Controls.Add(new Market() { Dock = DockStyle.Fill });
            }
            else if (MainTabBar.SelectedIndex == 1)
            {
                MainTabBar.TabPages[1].Controls.Add(new CustomerOrder() { Dock = DockStyle.Fill });
            }
            else if (MainTabBar.SelectedIndex == 2)
            {
                MainTabBar.TabPages[2].Controls.Add(new CustomerOrderHistory() { Dock = DockStyle.Fill });
            }
        }
    }
}
