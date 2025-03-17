using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrbanFood.Utils;

namespace UrbanFood.Forms
{
    public partial class ViewProductReviews: MaterialForm
    {
        private string _productID;

        public ViewProductReviews(string productID)
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            _productID = productID;
        }
    }
}
