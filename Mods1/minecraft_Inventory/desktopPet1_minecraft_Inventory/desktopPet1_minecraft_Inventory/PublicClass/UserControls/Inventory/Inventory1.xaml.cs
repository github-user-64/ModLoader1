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

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Inventory
{
    /// <summary>
    /// 物品栏UI
    /// </summary>
    public partial class Inventory1 : UserControl
    {
        //物品栏长度只能在初始化的时候设置一次
        public Inventory1(usingInventory.InventoryObject<usingInventoryItem.InventoryItemObject> inventory)
        {
            this.inventory = inventory;

            if (inventory == null) return;
            if (Class1.modSettings?.thisModSettingsData == null) return;
            if (inventory.Length < Class1.modSettings.thisModSettingsData.Inventory_Column) return;

            InitializeComponent();

            Initialize();
        }

        private int Length = 0;
        private usingInventory.InventoryObject<usingInventoryItem.InventoryItemObject> inventory = null;
        private int InventoryItem_index_Checked = -1;
        private int InventoryItem_index_ContextMenu = -1;
        private ContextMenu contextMenu = null;
        private double scaleTransform = 1;//缩放

        public void Action_InventoryItem_apply(int index)
        {
            if (0 > index || index > Length - 1) return;

            inventory.Inventory_apply(index);
        }

        public void Action_InventoryItem_Checked_apply()
        {
            Action_InventoryItem_apply(InventoryItem_index_Checked);
        }

        public void Action_InventoryItem_Select(int index)
        {
            if (0 > index || index > Length - 1) return;
            if (index > Inventory_StackPanel1.Children.Count - 1) return;

            InventoryItem.InventoryItem1 ii = Inventory_StackPanel1.Children[index] as InventoryItem.InventoryItem1;

            if (ii == null) return;

            ii.IsChecked = true;
        }

        public void Action_InventoryItem_cover(string path, int index)//路径为null会将指定位置处设为null
        {
            if (0 > index || index > Length - 1) return;

            usingInventoryItem.InventoryItemObject iio = null;

            try
            {
                if (path != null) iio = new usingInventoryItem.InventoryItemObject(path);
            }
            catch
            {
                return;
            }

            inventory.InventoryAction_cover(iio, index);
        }

        public void RefreshUI_Inventory()
        {
            for (int i = 0; i < Inventory_StackPanel1.Children.Count; ++i)
            {
                InventoryItem.InventoryItem1 ii = Inventory_StackPanel1.Children[i] as InventoryItem.InventoryItem1;

                if (ii == null) continue;

                ii.SetData(inventory.Inventory_getItem(i));
            }
        }

        public void RefreshUI_InventoryItem(int[] indexs)
        {
            for (int i = 0; i < indexs?.Length; ++i)
            {
                if (0 > indexs[i] || indexs[i] > Inventory_StackPanel1.Children.Count - 1) continue;

                InventoryItem.InventoryItem1 ii = Inventory_StackPanel1.Children[indexs[i]] as InventoryItem.InventoryItem1;

                ii?.SetData(inventory.Inventory_getItem(indexs[i]));
            }
        }

        private void SetPoint(double x, double y)
        {
            Margin = new Thickness(x, 0, 0, -y);
        }
        private Point GetPoint()
        {
            return new Point(Margin.Left, -Margin.Bottom);
        }
    }
}
