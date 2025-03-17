using MaterialSkin.Controls;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanFood.Utils
{
    public static class ThemeManager
    {
        private static MaterialSkinManager? materialSkinManager;

        public static void ApplyTheme(MaterialForm form)
        {
            if (materialSkinManager == null)
            {
                materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

                materialSkinManager.ColorScheme = new ColorScheme(
                    Primary.Purple700,  
                    Primary.Grey900,    
                    Primary.Grey800,    
                    Accent.Pink200,     
                    TextShade.WHITE     
                );
            }

            materialSkinManager.AddFormToManage(form);
        }
    }
}
