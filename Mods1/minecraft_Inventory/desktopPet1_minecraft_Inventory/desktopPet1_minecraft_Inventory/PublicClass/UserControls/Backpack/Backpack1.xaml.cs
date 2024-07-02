using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using usingInventory = desktopPet1_minecraft_Inventory.PublicClass.Inventory;
using usingInventoryItem = desktopPet1_minecraft_Inventory.PublicClass.InventoryItem;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Backpack
{
    /// <summary>
    /// 背包UI
    /// </summary>
    public partial class Backpack1 : UserControl
    {
        public Backpack1(usingInventory.InventoryObject<usingInventoryItem.InventoryItemObject> inventory)
        {
            this.inventory = inventory;

            if (inventory == null) return;
            if (Class1.modSettings?.thisModSettingsData == null) return;
            if (inventory.Length < Class1.modSettings.thisModSettingsData.Inventory_Column) return;

            InitializeComponent();

            Initialize();
        }
    }
}
