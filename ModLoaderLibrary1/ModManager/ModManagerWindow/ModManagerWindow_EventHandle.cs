using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace ModLoaderLibrary1.ModManager
{
    public partial class ModManagerWindow
    {
        private void Window_Activated(object sender, EventArgs e)
        {
            ModList_RefreshList_Activated();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            Close_();
        }

        #region 窗体标题上的按钮
        private void e_TitleRight_Buttons_Close_Click(object sender, RoutedEventArgs e)
        {
            Close_();
        }

        private bool e_TitleRight_Buttons_RefreshList_isCooled = true;
        private async void e_TitleRight_Buttons_RefreshList_Click(object sender, RoutedEventArgs e)
        {
            if (!e_TitleRight_Buttons_RefreshList_isCooled) return;
            e_TitleRight_Buttons_RefreshList_isCooled = false;

            JumpPage_ModList();

            ModList_RefreshList();

            await Task.Delay(1000);

            e_TitleRight_Buttons_RefreshList_isCooled = true;
        }

        private bool e_TitleRight_Buttons_ReloadMod_isCooled = true;
        private async void e_TitleRight_Buttons_ReloadMod_Click(object sender, RoutedEventArgs e)
        {
            if (!e_TitleRight_Buttons_ReloadMod_isCooled) return;
            e_TitleRight_Buttons_ReloadMod_isCooled = false;

            JumpPage_ModList();

            ModList_ReloadMod();

            await Task.Delay(1000);

            e_TitleRight_Buttons_ReloadMod_isCooled = true;
        }

        private void e_TitleLeft_Buttons_SelectAll_Click(object sender, RoutedEventArgs e)
        {
            if (ModList_ListBox1.Items.Count == ModList_ListBox1.SelectedItems.Count)
            {
                ModList_DeselectAll();
                return;
            }
            ModList_SelectAll();
        }

        private void e_TitleLeft2_Buttons_BackJumpPage_Click(object sender, RoutedEventArgs e)
        {
            JumpPage_ModList();
        }

        private void e_TitleLeft2_Buttons_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JumpPage_ModSettings_IModSettings?.SettingsSave();

                TS(GetResources_Text(PublicClass1.Keys.res_Text1.TS_message11));
            }
            catch (Exception ex)
            {
                TS($"{GetResources_Text(PublicClass1.Keys.res_Text1.TS_message12)}:{ex.Message}");
            }
        }
        #endregion

        #region mod列表项上的按钮
        private void e_ModList_ModSettings(UserControls.items.item1 item)
        {
            ModList_ModSettings(item);
        }
        private void e_ModList_DisableMod(UserControls.items.item1 item)
        {
            ModList_DisableMod(item);
        }
        private void e_ModList_EnableMod(UserControls.items.item1 item)
        {
            ModList_EnableMod(item);
        }
        private void e_ModList_DeleteMod(UserControls.items.item1 item)
        {
            ModList_DeleteMod(item);
        }
        #endregion

        #region mod操作窗口1上的按钮
        private void OperationWindow1_Buttons_DeselectAll_Click(object sender, RoutedEventArgs e)
        {
            ModList_DeselectAll();
        }

        private void OperationWindow1_Buttons_ModDelete_Click(object sender, RoutedEventArgs e)
        {
            ModList_DeleteSelectMod();
        }

        private void OperationWindow1_Buttons_ModDisable_Click(object sender, RoutedEventArgs e)
        {
            ModList_DisableSelectMod();
        }

        private void OperationWindow1_Buttons_ModEnable_Click(object sender, RoutedEventArgs e)
        {
            ModList_EnableSelectMod();
        }
        #endregion

        private void e_ModList_ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshUi_OperationWindow1();
        }

        private void e_Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Left += e.HorizontalChange;
            Top += e.VerticalChange;
        }

        private void e_Window_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (files == null || files.Length < 1) return;

                if (Directory.Exists(files[0]))
                {
                    bool a1 = ModList_InstallMod(files[0]);

                    TS(a1 ? PublicClass1.Resource.Get.GetString(PublicClass1.Keys.res_Text1.TS_message13):
                        PublicClass1.Resource.Get.GetString(PublicClass1.Keys.res_Text1.TS_message14));

                    return;
                }
            }
        }
    }
}
