using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ModLoaderLibrary1.ModManager.UserControls.items
{
    public partial class item1
    {
        //阻止事件冒泡, 让控件被按下后不被选中
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsSelected = !IsSelected;
        }

        private void Buttons1_openModFolder_Click(object sender, RoutedEventArgs e)
        {
            Button_openModFolder_Click?.Invoke(this);
        }
        private void Buttons1_settings_Click(object sender, RoutedEventArgs e)
        {
            Button_settings_Click?.Invoke(this);
        }
        private void Buttons1_EnableOrDisableMod_Click(object sender, RoutedEventArgs e)
        {
            if (d_mm.mc.isEnable)
            {
                Button_disableMod_Click?.Invoke(this);
            }
            else
            {
                Button_enableMod_Click?.Invoke(this);
            }

            RefreshUi();
            Buttons1_EnableOrDisableMod_Click_ff1();
        }
        private async void Buttons1_EnableOrDisableMod_Click_ff1()
        {
            IsHitTestVisible = false;
            await Task.Delay(100);
            IsHitTestVisible = true;
        }
        private void Buttons1_deleteMod_Click(object sender, RoutedEventArgs e)
        {
            Button_deleteMod_Click?.Invoke(this);
        }

        private void Button_openModFolder_Click_Handle(item1 item1)
        {
            if (!System.IO.Directory.Exists(item1?.d_mm?.mc?.fullPath))
            {
                ts.ModManagerTS(PublicClass1.Resource.Get.GetString(PublicClass1.Keys.res_Text1.TS_message3));
                return;
            }

            try
            {
                _ = System.Diagnostics.Process.Start("explorer.exe", item1.d_mm.mc.fullPath);
            }
            catch
            {

            }
        }
    }
}
