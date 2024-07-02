using desktopPet1_Front.Pet;
using PublicLibrary1.Mod.Apis;
using PublicLibrary1.Program.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace desktopPet1_minecraft_Inventory
{
    public partial class Class1 : IModSettings
    {
        private PublicClass.Settings.Mod.ModSettingsUI GetSettingsUI_This = null;
        public FrameworkElement SettingsGetUI()
        {
            return GetSettingsUI_This = new PublicClass.Settings.Mod.ModSettingsUI();
        }

        public void SettingsSave()
        {
            GetSettingsUI_This?.SettingsSave();

            modSettings?.SetData(modSettings?.GetNewData());
        }
    }
}
