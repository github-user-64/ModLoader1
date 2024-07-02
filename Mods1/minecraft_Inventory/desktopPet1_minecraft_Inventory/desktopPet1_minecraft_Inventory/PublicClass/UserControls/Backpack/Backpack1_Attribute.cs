using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using usingInventory = desktopPet1_minecraft_Inventory.PublicClass.Inventory;
using usingInventoryItem = desktopPet1_minecraft_Inventory.PublicClass.InventoryItem;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Backpack
{
    public partial class Backpack1
    {
        private usingInventory.InventoryObject<usingInventoryItem.InventoryItemObject> inventory = null;
        private List<BackpackItem.BackpackItem1> backpackItems = null;

        private int Backpack_Row_Lenght = 0;
        private double scaleTransform = 1;//缩放
        private ContextMenu contextMenu = null;
        private int InventoryItem_index_ContextMenu = -1;

        public bool isOpen { get; private set; } = false;
    }
}
