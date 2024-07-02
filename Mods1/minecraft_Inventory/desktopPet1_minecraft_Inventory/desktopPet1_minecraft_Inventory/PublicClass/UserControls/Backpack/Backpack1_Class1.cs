using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Backpack
{
    public partial class Backpack1
    {
        public void Open()
        {
            Visibility = Visibility.Visible;

            isOpen = true;
        }

        public void Close()
        {
            Visibility = Visibility.Collapsed;

            isOpen = false;
        }

        public void SwitchOpenOrClose()
        {
            if (isOpen)
            {
                Close();
                return;
            }
            Open();
        }

        public void RefreshUI_Backpack()
        {
            for (int i = 0; i < backpackItems.Count; ++i)
            {
                backpackItems[i]?.SetData(inventory.Inventory_getItem(i));
            }
        }

        public void RefreshUI_BackpackItem(int[] indexs)
        {
            for (int i = 0; i < indexs?.Length; ++i)
            {
                if (0 > indexs[i] || indexs[i] > backpackItems.Count - 1) continue;

                backpackItems[indexs[i]]?.SetData(inventory.Inventory_getItem(indexs[i]));
            }
        }

        #region
        public void Action_InventoryItem_apply(int index)
        {
            if (0 > index || index > inventory.Length - 1) return;

            inventory.Inventory_apply(index);
        }

        public void Action_InventoryItem_cover(string path, int index)//路径为null会将指定位置处设为null
        {
            if (0 > index || index > inventory.Length - 1) return;

            PublicClass.InventoryItem.InventoryItemObject iio = null;

            try
            {
                if (path != null) iio = new PublicClass.InventoryItem.InventoryItemObject(path);
            }
            catch
            {
                return;
            }

            inventory.InventoryAction_cover(iio, index);
        }
        #endregion

        private BackpackItem.BackpackItem1 GetIsMouseOverItem()
        {
            for (int i = 0; i < backpackItems.Count; ++i)
            {
                if (backpackItems[i]?.IsMouseOver == true) return backpackItems[i];
            }

            return null;
        }
    }
}
