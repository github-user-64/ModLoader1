using desktopPet1_Front.Pet;
using PublicLibrary1.Mod.Apis;
using PublicLibrary1.Program.Apis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace desktopPet1
{
    public partial class Class1 : IModSettings
    {
        private PublicClass1.ModSettings.ModSettingsUI GetSettingsUI_This = null;
        public FrameworkElement SettingsGetUI()
        {
            GetSettingsUI_This = new PublicClass1.ModSettings.ModSettingsUI();
            GetSettingsUI_This.Custom_Refresh += () =>
            {
                if (modSettings?.thisModSettingsData?.ManagerWindow_isEnabledCustomUI != true)
                {
                    apiProcedure1?.api_Program1_TS("刷新自定义背景失败", $"未启用自定义背景, 是不是没有保存设置(￣▽￣)\"", PublicLibrary1.TS.GetBtn("确定", null));
                    return;
                }

                CustomUI_Refresh();
            };
            GetSettingsUI_This.Custom_OpenFolder += () =>
            {
                if (!Directory.Exists(thisMO?.modConfig?.fullPath)) return;
                try
                {
                    _ = Process.Start(thisMO?.modConfig?.fullPath);
                }
                catch
                {

                }
            };
            GetSettingsUI_This.Custom_Enabled += () =>
            {
                if (!Directory.Exists(thisMO?.modConfig?.fullPath)) return;

                string file1 = "Custom_Top1.xaml";
                string file2 = "Custom_Bottom1.xaml";
                bool file1_ = !File.Exists($"{thisMO?.modConfig?.fullPath}\\{file1}");
                bool file2_ = !File.Exists($"{thisMO?.modConfig?.fullPath}\\{file2}");
                if (!file1_ && !file2_) return;

                try
                {
                    if (file1_) File.WriteAllText($"{thisMO?.modConfig?.fullPath}\\{file1}", Properties.Resources.Custom_Top1, Encoding.UTF8);
                    if (file2_) File.WriteAllText($"{thisMO?.modConfig?.fullPath}\\{file2}", Properties.Resources.Custom_Bottom1, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    apiProcedure1?.api_Program1_TS("自定义背景启用", $"创建自定义文件失败: {ex.Message}", PublicLibrary1.TS.GetBtn("确定", null));
                    return;
                }

                string message = $"已创建自定义文件{(file1_ ? file1 : null)}{(file1_ && file2_ ? "和" : null)}{(file2_ ? file2 : null)}";

                apiProcedure1?.api_Program1_TS("启用后记得保存设置, 记得!", message, PublicLibrary1.TS.GetBtn("确定", null));
                try
                {
                    _ = Process.Start(thisMO?.modConfig?.fullPath);
                }
                catch
                {

                }
            };

            return GetSettingsUI_This;
        }

        public void SettingsSave()
        {
            GetSettingsUI_This?.SettingsSave();

            modSettings?.SetData(modSettings?.GetNewData());

            #region
            if (modSettings?.thisModSettingsData?.ManagerWindow_isEnabledCustomUI == true)
            {
                CustomUI_Refresh();
            }
            else
            {
                CustomUI_Clear();
            }
            #endregion
        }
    }
}
