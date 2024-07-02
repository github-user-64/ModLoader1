using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModLoaderLibrary1.ModManager
{
    public partial class ModManagerWindow
    {
        public void RefreshUi()
        {
            RefreshUi_ListBox_Items();
            RefreshUi_OperationWindow1();
        }

        private void RefreshUi_OperationWindow1()
        {
            bool withEnable = false;
            bool withDisable = false;

            for (int i = 0; i < ModList_ListBox1.SelectedItems.Count; ++i)
            {
                UserControls.items.item1 item1 = ModList_ListBox1.SelectedItems[i] as UserControls.items.item1;

                if (item1?.d_mm?.mc == null) continue;

                if (item1.d_mm.mc.isEnable) withEnable = true;
                else withDisable = true;

                if (withEnable && withDisable) break;
            }

            OperationWindow1_Buttons1_ModEnable.IsEnabled = withDisable;
            OperationWindow1_Buttons1_ModDisable.IsEnabled = withEnable;
        }

        private void RefreshUi_ListBox_Items()
        {
            for (int i = 0; i < ModList_ListBox1.Items.Count; ++i)
            {
                RefreshUi_ListBox_Item(ModList_ListBox1.Items[i] as UserControls.items.item1);
            }
        }

        private void RefreshUi_ListBox_Item(UserControls.items.item1 item1)
        {
            item1?.RefreshUi();
        }
    }
}
