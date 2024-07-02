using PublicLibrary1.Mod;
using PublicLibrary1.Program;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace ModLoaderLibrary1.ModManager
{
    public partial class ModManagerWindow
    {
        #region
        public void Open_()
        {
            Visibility = Visibility.Visible;
            _ = Activate();

            JumpPage_ModList();

            Initialize_ModList();
        }

        public void Close_()
        {
            Visibility = Visibility.Collapsed;
        }

        public void SwitchOpenOrClose()
        {
            if (Visibility == Visibility.Visible)
            {
                Close_();
                return;
            }
            Open_();
        }
        #endregion

        #region
        private LinearGradientBrush TS_LinearGradientBrush = new LinearGradientBrush(Color.FromArgb(64, 255, 255, 255), Colors.Transparent, new Point(0, 0), new Point(0, 0.5));
        private SolidColorBrush[] TS_SolidColorBrushs =
        {
            new SolidColorBrush(Color.FromRgb(17, 111, 205)),
            new SolidColorBrush(Color.FromRgb(0, 211, 25))
        };
        private void TS(string val)
        {
            if (!IsLoaded) return;

            int index = program1.api_Program1_GetRandom().Next(0, TS_SolidColorBrushs.Length);

            Dispatcher.Invoke(new Action(delegate
            {
                TextBlock textBlock = new TextBlock()
                {
                    Text = val,
                    Margin = new Thickness(7, 5, 5, 7),
                    Foreground = new SolidColorBrush(Colors.White),
                    TextTrimming = TextTrimming.WordEllipsis
                };
                Border border2 = new Border()
                {
                    CornerRadius = new CornerRadius(0, 4, 4, 0),
                    Background = TS_LinearGradientBrush,
                    Child = textBlock,
                };
                Border border1 = new Border()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    CornerRadius = new CornerRadius(0, 4, 4, 0),
                    Background = TS_SolidColorBrushs[index],
                    Child = border2,
                    RenderTransform = new TranslateTransform()
                };


                DoubleAnimation da1 = new DoubleAnimation
                {
                    Duration = TimeSpan.FromSeconds(0.2),
                    From = -32,
                    To = 0,
                    DecelerationRatio = 1
                };
                DoubleAnimation da1_2 = new DoubleAnimation
                {
                    Duration = TimeSpan.FromSeconds(0.1),
                    From = 0,
                    To = 1,
                    DecelerationRatio = 1
                };
                DoubleAnimation da2 = new DoubleAnimation
                {
                    Duration = TimeSpan.FromSeconds(0.5),
                    To = 0,
                    DecelerationRatio = 1,
                    BeginTime = TimeSpan.FromSeconds(3)
                };
                da2.Completed += (_, e) =>
                {
                    if (TS_UI.Children.Contains(border1)) TS_UI.Children.RemoveAt(0);
                };

                border1.RenderTransform.BeginAnimation(TranslateTransform.XProperty, da1);
                border1.BeginAnimation(OpacityProperty, da1_2);
                border1.BeginAnimation(OpacityProperty, da2);

                _ = TS_UI.Children.Add(border1);
                if (TS_UI.Children.Count > 8) TS_UI.Children.RemoveAt(0);
            }), DispatcherPriority.ApplicationIdle);
        }
        #endregion

        private string GetResources_Text(string key)
        {
            return PublicClass1.Resource.Get.GetString(key);
        }

        private List<PublicClass1.Mod.Data_ModConfigAModInfor> GetData_ModConfigAModInfors()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo($@"{ProgramInformation.ProgramPath}\{PublicLibrary1.Inventory.Folder.mods}");
                DirectoryInfo[] dis = di.GetDirectories();
                List<PublicClass1.Mod.Data_ModConfigAModInfor> d_mms = new List<PublicClass1.Mod.Data_ModConfigAModInfor>();

                for (int i = 0; i < dis.Length; ++i)
                {
                    string configpath = $@"{dis[i].FullName}\{PublicLibrary1.Inventory.FileRelative.Mod.config}";
                    string inforpath = $@"{dis[i].FullName}\{PublicClass1.Inventory.FileRelative.Mod.infor}";

                    //

                    ModConfig mc = ModConfig.Read(configpath);

                    if (mc == null) continue;

                    mc.fullPath = dis[i].FullName;

                    //

                    PublicClass1.Mod.ModInfor mi = null;
                    try
                    {
                        mi = new PublicLibrary1.JsonDispose1.MyJson1(inforpath).Get2<PublicClass1.Mod.ModInfor>();
                    }
                    catch
                    {
                        mi = new PublicClass1.Mod.ModInfor();
                    }

                    mi = mi ?? new PublicClass1.Mod.ModInfor();

                    //

                    d_mms.Add(new PublicClass1.Mod.Data_ModConfigAModInfor(mc, mi));
                }

                return d_mms;
            }
            catch
            {
                return null;
            }
        }

        private void JumpPage_ModList()
        {
            JumpPage_ModSettings_IModSettings = null;
            ModSettings_Border1.Child = null;

            Title_Left_2.Visibility = Visibility.Collapsed;
            ModSettings_ScrollViewer1.Visibility = Visibility.Collapsed;
            Title_Left.Visibility = Visibility.Visible;
            ModList_ListBox1.Visibility = Visibility.Visible;
        }

        private PublicLibrary1.Mod.Apis.IModSettings JumpPage_ModSettings_IModSettings = null;
        private void JumpPage_ModSettings(PublicClass1.Mod.Data_ModConfigAModInfor d_mm)
        {
            if (d_mm?.mc?.key == null)
            {
                TS(GetResources_Text(PublicClass1.Keys.res_Text1.TS_message8));
                return;
            }

            List<ModObject> mos = program1.api_Program1_Mod_GetModList();
            ModObject mo = null;
            PublicLibrary1.Mod.Apis.IModSettings ms = null;
            string modname = d_mm.mi?.Title ?? d_mm.mc.key;

            for (int i = 0; i < mos?.Count; ++i)
            {
                if (mos[i].modConfig.key != d_mm.mc.key) continue;

                mo = mos[i];
            }

            if (mo == null)
            {
                TS($"{GetResources_Text(PublicClass1.Keys.res_Text1.TS_message9)}:[{modname}]");
                return;
            }

            ms = mo.mod as PublicLibrary1.Mod.Apis.IModSettings;

            if (ms == null)
            {
                TS($"{GetResources_Text(PublicClass1.Keys.res_Text1.TS_message10)}:[{modname}]");
                return;
            }

            ModList_DeselectAll();

            Title_Left.Visibility = Visibility.Collapsed;
            ModList_ListBox1.Visibility = Visibility.Collapsed;
            Title_Left_2.Visibility = Visibility.Visible;
            ModSettings_ScrollViewer1.Visibility = Visibility.Visible;

            ModSettings_Border1.Child = ms.SettingsGetUI();

            JumpPage_ModSettings_IModSettings = ms;
        }
    }
}
