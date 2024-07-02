using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Inventory
{
    public partial class Inventory1
    {
        private void Initialize()
        {
            Length = Class1.modSettings.thisModSettingsData.Inventory_Column;

            if (Length < 1) return;

            Initialize_ContextMenu();
            Initialize_Inventory();
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
            mi = new MenuItem() { Header = "拖动物品栏" };
            mi.Click += (s, e) =>
            {
                Thumb1.Visibility = Visibility.Visible;
            };
            _ = contextMenu.Items.Add(mi);
            //
            mi = new MenuItem() { Header = "丢弃" };
            mi.Click += (s, e) => Action_InventoryItem_cover(null, InventoryItem_index_ContextMenu);
            _ = contextMenu.Items.Add(mi);
        }

        private void Initialize_Inventory()
        {
            for (int i = 0; i < Length; ++i)
            {
                InventoryItem.InventoryItem1 item = new InventoryItem.InventoryItem1();
                item.SetScaleTransform_transmit(scaleTransform);
                item.AllowDrop = true;
                item.Checked += e_InventoryItem_Checked;
                item.MouseDoubleClick += (s, e) => Action_InventoryItem_Checked_apply();
                item.MouseRightButtonUp += (s, e) =>
                {
                    contextMenu.IsOpen = true;
                    InventoryItem_index_ContextMenu = Inventory_StackPanel1.Children.IndexOf(item);
                };
                item.Drag += () =>
                {
                    PublicClass.InventoryItem.InventoryItemObject iio = inventory.Inventory_getItem(Inventory_StackPanel1.Children.IndexOf(item));
                    if (iio == null) return;

                    _ = DragDrop.DoDragDrop(this, iio, DragDropEffects.Move);//开始拖动物品
                };
                item.Drop += (s, e) =>
                {
                    PublicClass.InventoryItem.InventoryItemObject data = e.Data.GetData(typeof(PublicClass.InventoryItem.InventoryItemObject)) as PublicClass.InventoryItem.InventoryItemObject;

                    if (data != null)
                    {
                        inventory.InventoryAction_exchange(inventory.Inventory_IndexOf(data), Inventory_StackPanel1.Children.IndexOf(item));

                        return;
                    }

                    if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    {
                        string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
                        if (files == null || files.Length < 1) return;

                        inventory.InventoryAction_cover(new PublicClass.InventoryItem.InventoryItemObject(files[0]), Inventory_StackPanel1.Children.IndexOf(item));

                        return;
                    }
                };

                _ = Inventory_StackPanel1.Children.Add(item);
            }
        }

        private void Initialize_Event()
        {
            inventory.InventoryItemChanged += (s) => e_InventoryItemChanged(s);

            Loaded += (s, e) =>
            {
                RefreshUI_Inventory();

                UpdateLayout();
                //选中触发的事件要移动选中边框的位置, 移动位置用到了实际显示宽度.
                //在Loaded事件触发时实际显示宽度会还没算好.
                //所以需要让它先算一下(调用UpdateLayout)
                Action_InventoryItem_Select(0);

                border1.Width = border1_grid1.ActualWidth;//用来防止控件拖动到窗口外会被压缩的情况
                border1.Height = border1_grid1.ActualHeight;//用来防止控件拖动到窗口外会被压缩的情况

                //在其它代码获取实际大小之后再设置位置, 不然在超出屏幕位置的时候获取实际大小会出问题
                SetPoint(Class1.modSettings.thisModSettingsData.horizontalOffset, Class1.modSettings.thisModSettingsData.verticalOffset);
            };

            Inventory_KeyUp += e_UserControl_Inventory_KeyUp;

            //拖动操作之后松开鼠标时
            Thumb1.AddHandler(MouseUpEvent, new MouseButtonEventHandler((s, e) =>
            {
                Thumb1.Visibility = Visibility.Collapsed;

                if (Class1.modSettings?.thisModSettingsData != null)
                {
                    Class1.modSettings.thisModSettingsData.horizontalOffset = GetPoint().X;
                    Class1.modSettings.thisModSettingsData.verticalOffset = GetPoint().Y;
                }
            }), true);
        }
    }
}
