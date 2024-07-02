using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Backpack
{
    public partial class Backpack1
    {
        private void e_UserControl_Inventory_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D1: inventory.InventoryAction_exchange(0, backpackItems.IndexOf(GetIsMouseOverItem())); return;
                case Key.D2: inventory.InventoryAction_exchange(1, backpackItems.IndexOf(GetIsMouseOverItem())); return;
                case Key.D3: inventory.InventoryAction_exchange(2, backpackItems.IndexOf(GetIsMouseOverItem())); return;
                case Key.D4: inventory.InventoryAction_exchange(3, backpackItems.IndexOf(GetIsMouseOverItem())); return;
                case Key.D5: inventory.InventoryAction_exchange(4, backpackItems.IndexOf(GetIsMouseOverItem())); return;
                case Key.D6: inventory.InventoryAction_exchange(5, backpackItems.IndexOf(GetIsMouseOverItem())); return;
                case Key.D7: inventory.InventoryAction_exchange(6, backpackItems.IndexOf(GetIsMouseOverItem())); return;
                case Key.D8: inventory.InventoryAction_exchange(7, backpackItems.IndexOf(GetIsMouseOverItem())); return;
                case Key.D9: inventory.InventoryAction_exchange(8, backpackItems.IndexOf(GetIsMouseOverItem())); return;
                case Key.Q: Action_InventoryItem_cover(null, backpackItems.IndexOf(GetIsMouseOverItem())); return;
                default: return;
            }
        }

        private void e_InventoryItemChanged(int[] indexs)
        {
            RefreshUI_BackpackItem(indexs);
        }
    }
}
