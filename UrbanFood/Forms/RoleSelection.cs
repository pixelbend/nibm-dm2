using MaterialSkin.Controls;
using UrbanFood.Forms;
using UrbanFood.LocalState;
using UrbanFood.Utils;

namespace UrbanFood
{
    public partial class RoleSelection : MaterialForm
    {
        public RoleSelection()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
        }

        private void CustomerSelectionBtn_Click(object sender, EventArgs e)
        {
            TransitonToAuth(UserType.Customer);

        }

        private void SupplierSelectionBtn_Click(object sender, EventArgs e)
        {
            TransitonToAuth(UserType.Supplier);
        }

        private void TransitonToAuth(UserType userType)
        {
            UserState.Instance.SetUserType(userType);
            Auth auth = new(this);
            auth.Show();
            Hide();
        }

        private void RoleSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
