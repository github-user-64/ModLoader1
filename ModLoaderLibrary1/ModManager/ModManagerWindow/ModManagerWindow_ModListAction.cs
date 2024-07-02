using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModLoaderLibrary1.ModManager
{
    public partial class ModManagerWindow
    {
        private bool ModList_InstallMod(string path)
        {
            if (!Directory.Exists(path))
            {
                TS($"{PublicClass1.Resource.Get.GetString(PublicClass1.Keys.res_Text1.TS_message3)}:{path}");
                return false;
            }

            PublicLibrary1.Mod.ModConfig modConfig = null;

            try
            {
                string config = $"{path}\\{PublicLibrary1.Inventory.FileRelative.Mod.config}";
                if (!File.Exists(config))
                {
                    TS(PublicClass1.Resource.Get.GetString(PublicClass1.Keys.res_Text1.TS_message15));
                    return false;
                }
                modConfig = new PublicLibrary1.JsonDispose1.MyJson1(config).Get2<PublicLibrary1.Mod.ModConfig>();
            }
            catch
            {
                modConfig = null;
            }

            if (modConfig == null)
            {
                TS(PublicClass1.Resource.Get.GetString(PublicClass1.Keys.res_Text1.TS_message15));
                return false;
            }

            try
            {
                PublicClass1.IO.Directory1.Copy(path,
                    $"{PublicLibrary1.Program.ProgramInformation.ProgramPath}\\{PublicLibrary1.Inventory.Folder.mods}\\{Path.GetFileName(path)}");

                Initialize_ModList();

                return true;
            }
            catch (Exception ex)
            {
                TS(ex.Message);
            }

            return false;
        }

        private void ModList_DeleteMod(UserControls.items.item1 item1)
        {
            if (item1?.d_mm?.mc?.fullPath == null) return;
            if (item1.d_mm.mc == null) return;
            if (item1.d_mm.mc.isEnable)
            {
                TS(GetResources_Text(PublicClass1.Keys.res_Text1.TS_message5));//启用
                return;
            }

            List<PublicLibrary1.Mod.ModObject> mos = program1.api_Program1_Mod_GetModList();
            for (int i = 0; i < mos.Count; ++i)
            {
                if (mos[i].modConfig.key != item1.d_mm.mc.key) continue;

                TS(GetResources_Text(PublicClass1.Keys.res_Text1.TS_message6));//正在使用

                return;
            }

            if (!Directory.Exists(item1.d_mm.mc.fullPath))
            {
                TS(GetResources_Text(PublicClass1.Keys.res_Text1.TS_message4));
                return;
            }

            try
            {
                int v = PublicClass1.IO.Directory1.DeleteFileToRecyclebin(item1.d_mm.mc.fullPath);
                if (v != 0) throw new Exception("文件夹删除失败");
            }
            catch (Exception ex)
            {
                program1.api_Program1_TS("文件操作失败", $"mod删除失败: {ex.Message}",
                    PublicLibrary1.TS.GetBtn("确认", () => { Initialize_ModList(); }));

                return;
            }

            Initialize_ModList();

            TS($"{item1.d_mm?.mi?.Title ?? item1.d_mm.mc.key} 已移动到回收站");
        }

        private void ModList_DeleteSelectMod()
        {
            int SelectedCount = ModList_ListBox1.SelectedItems.Count;
            int failCount = 0;

            for (int i = 0; i < ModList_ListBox1.SelectedItems.Count; ++i)
            {
                try
                {
                    UserControls.items.item1 item1 = ModList_ListBox1.SelectedItems[i] as UserControls.items.item1;

                    if (item1?.d_mm?.mc == null) throw new Exception();
                    if (item1.d_mm.mc.isEnable) throw new Exception();

                    List<PublicLibrary1.Mod.ModObject> mos = program1.api_Program1_Mod_GetModList();
                    for (int i2 = 0; i2 < mos.Count; ++i2)
                    {
                        if (mos[i2].modConfig.key != item1.d_mm.mc.key) continue;

                        TS(GetResources_Text(PublicClass1.Keys.res_Text1.TS_message6));

                        return;
                    }

                    if (!Directory.Exists(item1.d_mm.mc.fullPath)) throw new Exception();

                    int v = PublicClass1.IO.Directory1.DeleteFileToRecyclebin(item1.d_mm.mc.fullPath);
                    if (v != 0) throw new Exception();
                }
                catch
                {
                    ++failCount;
                    continue;
                }
            }

            Initialize_ModList();

            TS($"已移动到回收站 {SelectedCount - failCount} 项{(failCount > 0 ? $", 失败 {failCount} 项" : null)}");
        }

        private void ModList_ModSettings(UserControls.items.item1 item1)
        {
            JumpPage_ModSettings(item1?.d_mm);
        }

        private void ModList_DisableMod(UserControls.items.item1 item1)
        {
            ModList_SetIsEnable(item1, false);
        }

        private void ModList_DisableSelectMod()
        {
            ModList_SetIsEnable(ModList_ListBox1.SelectedItems, false);
        }

        private void ModList_EnableMod(UserControls.items.item1 item1)
        {
            ModList_SetIsEnable(item1, true);
        }

        private void ModList_EnableSelectMod()
        {
            ModList_SetIsEnable(ModList_ListBox1.SelectedItems, true);
        }

        private void ModList_RefreshList()
        {
            Initialize_ModList();

            TS(GetResources_Text(PublicClass1.Keys.res_Text1.TS_message2));
        }

        //用于在窗体获取焦点时, 如果模组列表项的数量和模组文件夹的模组数量不同时自动刷新模组列表
        private void ModList_RefreshList_Activated()
        {
            string path1 = $"{PublicLibrary1.Program.ProgramInformation.ProgramPath}\\{PublicLibrary1.Inventory.Folder.mods}";

            if (!Directory.Exists(path1)) return;

            DirectoryInfo di = new DirectoryInfo(path1);

            if (di.GetDirectories().Length == ModList_ListBox1.Items.Count) return;

            Initialize_ModList();
        }

        private void ModList_ReloadMod()
        {
            try
            {
                program1.api_Program1_ModLoad();

                TS(PublicClass1.Resource.Get.GetString(PublicClass1.Keys.res_Text1.TS_message7));
            }
            catch (Exception ex)
            {
                program1.api_Program1_TS("mod加载失败", ex.Message,
                    PublicLibrary1.TS.GetBtn("继续", null),
                    PublicLibrary1.TS.GetBtn("重试", () => { ModList_ReloadMod(); }),
                    PublicLibrary1.TS.GetBtn("退出", () => { program1.api_Program1_ExitProgram(); }));
            }
        }

        private void ModList_DeselectAll()
        {
            ModList_ListBox1.UnselectAll();
        }

        private void ModList_SelectAll()
        {
            ModList_ListBox1.SelectAll();
        }

        private void ModList_SaveSingle(PublicLibrary1.Mod.ModConfig mc)
        {
            try
            {
                PublicLibrary1.Program.Mod.ModConfigAction.SaveModConfig_path(mc);
            }
            catch
            {
                TS($"保存配置失败:{mc.fullPath}");
            }
        }

        #region
        private void ModList_SetIsEnable(UserControls.items.item1 item1, bool isEnable)
        {
            if (item1?.d_mm?.mc == null) return;

            item1.d_mm.mc.isEnable = isEnable;

            RefreshUi_ListBox_Item(item1);

            ModList_SaveSingle(item1.d_mm.mc);

            RefreshUi_OperationWindow1();
        }

        private void ModList_SetIsEnable(System.Collections.IList item1s, bool isEnable)
        {
            ModList_Processing1((i) =>
            {
                if (i?.d_mm?.mc == null) return;
                i.d_mm.mc.isEnable = isEnable;

                RefreshUi_ListBox_Item(i);

                ModList_SaveSingle(i.d_mm.mc);
            }, item1s);

            RefreshUi_OperationWindow1();
        }

        private void ModList_Processing1(Action<UserControls.items.item1> action, System.Collections.IList item1s)
        {
            for (int i = 0; i < item1s?.Count; ++i)
            {
                action?.Invoke(item1s[i] as UserControls.items.item1);
            }
        }
        #endregion
    }
}
