using MaterialSkin.Controls;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Text.RegularExpressions;
using UrbanFood.Controls;
using UrbanFood.Database.OracleDB;
using UrbanFood.LocalState;
using UrbanFood.UserControls;
using UrbanFood.Utils;

namespace UrbanFood.Forms
{
    public partial class Auth : MaterialForm
    {
        private RoleSelection roleSelection;

        public Auth(RoleSelection roleSelection)
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            this.roleSelection = roleSelection;
            InitializeAuthTabs();
        }

        private void Auth_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserState.Instance.Clear();
            roleSelection.Show();
        }


        private void InitializeAuthTabs()
        {
            AuthTabControl.TabPages[0].Controls.Clear();
            AuthTabControl.TabPages[0].Controls.Add(new Login(this));

            AuthTabControl.TabPages[1].Controls.Clear();
            AuthTabControl.TabPages[1].Controls.Add(new Signup(this));
        }

        private void AuthTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            AuthTabControl.TabPages[0].Controls.Clear();
            AuthTabControl.TabPages[1].Controls.Clear();

            if (AuthTabControl.SelectedIndex == 0)
            {
                AuthTabControl.TabPages[0].Controls.Add(new Login(this));
            }
            else if (AuthTabControl.SelectedIndex == 1)
            {
                AuthTabControl.TabPages[1].Controls.Add(new Signup(this));
            }
        }

    }
}
