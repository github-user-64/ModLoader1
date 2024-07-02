using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Backpack
{
    public partial class Backpack1
    {
        private void Initialize()
        {
            Backpack_Row_Lenght = Class1.modSettings.thisModSettingsData.Inventory_Column;

            if (Backpack_Row_Lenght < 1) return;

            backpackItems = new List<BackpackItem.BackpackItem1>();

            Initialize_ContextMenu();
            Initialize_Backpack();
            Initialize_Event();
        }

        private void Initialize_ContextMenu()
        {
            contextMenu = new ContextMenu();
            contextMenu.Style = Resources["ContextMenu1"] as Style;

            MenuItem mi = new MenuItem() { Header = "打开" };
            mi.Click += (s, e) => Action_InventoryItem_apply(InventoryItem_index_ContextMenu);
            _ = contextMenu.Items.Add(mi);
            //
            mi = new MenuItem() { Header = "更改文件" };
            mi.Click += (s, e) =>
            {
                string p = IO.File.Choice.Get();

                if (p == null) return;

                Action_InventoryItem_cover(p, InventoryItem_index_ContextMenu);
            };
            _ = contextMenu.Items.Add(mi);
            //
            mi = new MenuItem() { Header = "更改目录" };
            mi.Click += (s, e) =>
            {
                string p = IO.Folder.Choice.Get();

                if (p == null) return;

                Action_InventoryItem_cover(p, InventoryItem_index_ContextMenu);
            };
            _ = contextMenu.Items.Add(mi);
            //
            mi = new MenuItem() { Header = "丢弃" };
            mi.Click += (s, e) => Action_InventoryItem_cover(null, InventoryItem_index_ContextMenu);
            _ = contextMenu.Items.Add(mi);
        }

        private void Initialize_Backpack()
        {
            int i = 0;

            Backpack_Other.Columns = Backpack_Row_Lenght;//设置控件的最大列数

            Func<BackpackItem.BackpackItem1> getui = () =>
            {
                BackpackItem.BackpackItem1 bi = new BackpackItem.BackpackItem1();
                bi.AllowDrop = true;
                bi.MouseDoubleClick += (s, e) => Action_InventoryItem_apply(backpackItems.IndexOf(bi));
                bi.MouseRightButtonUp += (s, e) =>
                {
                    contextMenu.IsOpen = true;
                    InventoryItem_index_ContextMenu = backpackItems.IndexOf(bi);
                };
                bi.Drop += (s, e) =>
                {
                    PublicClass.InventoryItem.InventoryItemObject data = e.Data.GetData(typeof(PublicClass.InventoryItem.InventoryItemObject)) as PublicClass.InventoryItem.InventoryItemObject;
                    
                    if (data != null)
                    {
                        inventory.InventoryAction_exchange(inventory.Inventory_IndexOf(data), backpackItems.IndexOf(bi));

                        return;
                    }

                    if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    {
                        string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
                        if (files == null || files.Length < 1) return;

                        inventory.InventoryAction_cover(new PublicClass.InventoryItem.InventoryItemObject(files[0]), backpackItems.IndexOf(bi));

                        return;
                    }
                };
                bi.Drag += () =>
                {
                    PublicClass.InventoryItem.InventoryItemObject iio = inventory.Inventory_getItem(backpackItems.IndexOf(bi));
                    if (iio == null) return;

                    _ = DragDrop.DoDragDrop(this, iio, DragDropEffects.Move);//开始拖动物品
                };

                return bi;
            };

            for (; i < Backpack_Row_Lenght; ++i)
            {
                BackpackItem.BackpackItem1 bi = getui();

                backpackItems.Add(bi);
                _ = Backpack_Row.Children.Add(bi);
            }

            for (; i < inventory.Length; ++i)
            {
                BackpackItem.BackpackItem1 bi = getui();
                
                backpackItems.Add(bi);
                _ = Backpack_Other.Children.Add(bi);
            }
        }

        private void Initialize_Event()
        {
            inventory.InventoryItemChanged += (s) => e_InventoryItemChanged(s);

            Loaded += (s, e) => RefreshUI_Backpack();

            Inventory_KeyUp += e_UserControl_Inventory_KeyUp;
        }
    }
}
