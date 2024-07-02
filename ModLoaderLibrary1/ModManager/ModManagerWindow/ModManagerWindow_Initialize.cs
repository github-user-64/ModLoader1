using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ModLoaderLibrary1.ModManager
{
    public partial class ModManagerWindow
    {
        /// <summary>
        /// 可重复调用
        /// </summary>
        private void Initialize_ModList()
        {
            if (ModList_ListBox1 == null) return;

            ModList_ListBox1.Items.Clear();

            List<PublicClass1.Mod.Data_ModConfigAModInfor> md_ccis = GetData_ModConfigAModInfors();

            if (md_ccis == null)
            {
                TS(GetResources_Text(PublicClass1.Keys.res_Text1.TS_message1));
                return;
            }

            for (int i = 0; i < md_ccis.Count; ++i)
            {
                UserControls.items.item1 item1 = new UserControls.items.item1(md_ccis[i], this);
                item1.Button_settings_Click += e_ModList_ModSettings;
                item1.Button_disableMod_Click += e_ModList_DisableMod;
                item1.Button_enableMod_Click += e_ModList_EnableMod;
                item1.Button_deleteMod_Click += e_ModList_DeleteMod;

                _ = ModList_ListBox1.Items.Add(item1);
            }
        }
    }
}
