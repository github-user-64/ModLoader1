using desktopPet1_Front.Expansion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace desktopPet1_expansion_ldnn
{
    public partial class Class1 : PublicLibrary1.Mod.Apis.IModSettings
    {
        private PublicClass1.ModSettings.ModSettingsUI GetSettingsUI_This = null;
        public FrameworkElement SettingsGetUI()
        {
            return GetSettingsUI_This = new PublicClass1.ModSettings.ModSettingsUI();
        }

        public void SettingsSave()
        {
            GetSettingsUI_This?.SettingsSave();

            modSettings?.SetData(modSettings?.GetNewData());
        }
    }
}
