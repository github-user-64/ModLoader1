using ModLoaderLibrary1.ModManager.PublicClass1.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ModLoaderLibrary1.ModManager.UserControls.items
{
    public partial class item1
    {
        public void RefreshUi()
        {
            if (d_mm.mc.isEnable)
            {
                Buttons1_EnableOrDisable.Content = String_Ico_Disable;
                Buttons1_EnableOrDisable.SetResourceReference(Button.TagProperty, res_Text1.ModItem1_disableMod);
                mod_title_label1.Opacity = 1;
                mod_disabledIco_border1.Visibility = Visibility.Collapsed;
            }
            else
            {
                Buttons1_EnableOrDisable.Content = String_Ico_Enable;
                Buttons1_EnableOrDisable.SetResourceReference(Button.TagProperty, res_Text1.ModItem1_enableMod);
                mod_title_label1.Opacity = 0.5;
                mod_disabledIco_border1.Visibility = Visibility.Visible;
            }

            Refresh_ModIco();
        }

        public void Refresh_ModIco()
        {
            try
            {
                string path1 = $@"{d_mm.mc.fullPath}\{PublicClass1.Inventory.FileRelative.Mod.ico}";

                if (!System.IO.File.Exists(path1)) return;

                mod_Ico_ImageSource = PublicClass1.IO.Stream.Conversion.BytesToBitmapSource(PublicClass1.IO.GetBit1.ReadBit(path1));
            }
            catch
            {
                mod_Ico_ImageSource = null;
                return;
            }
        }
    }
}
