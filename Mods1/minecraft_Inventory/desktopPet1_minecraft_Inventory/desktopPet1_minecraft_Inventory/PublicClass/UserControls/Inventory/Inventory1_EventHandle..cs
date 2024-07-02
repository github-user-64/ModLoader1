using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Inventory
{
    public partial class Inventory1
    {
        private void e_UserControl_Inventory_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D1: Action_InventoryItem_Select(0); return;
                case Key.D2: Action_InventoryItem_Select(1); return;
                case Key.D3: Action_InventoryItem_Select(2); return;
                case Key.D4: Action_InventoryItem_Select(3); return;
                case Key.D5: Action_InventoryItem_Select(4); return;
                case Key.D6: Action_InventoryItem_Select(5); return;
                case Key.D7: Action_InventoryItem_Select(6); return;
                case Key.D8: Action_InventoryItem_Select(7); return;
                case Key.D9: Action_InventoryItem_Select(8); return;
                case Key.Q: Action_InventoryItem_cover(null, InventoryItem_index_Checked); return;
                case Key.Enter: Action_InventoryItem_Checked_apply(); return;
                default: return;
            }
        }

        private void e_InventoryItemChanged(int[] indexs)
        {
            RefreshUI_InventoryItem(indexs);
        }

        private void e_InventoryItem_Checked(object sender, RoutedEventArgs e)
        {
            InventoryItem.InventoryItem1 ii = sender as InventoryItem.InventoryItem1;

            if (ii == null) return;

            #region 记录选中的index
            InventoryItem_index_Checked = Inventory_StackPanel1.Children.IndexOf(ii);
            #endregion

            #region 修改选中显示的边框的位置
            Point point = ii.TranslatePoint(new Point(0, 0), Inventory_StackPanel1);

            //

            double hOffset = (ii.ActualWidth - Inventory_Checked_Border_Image1.ActualWidth) / 2;//居中
            hOffset += 8;

            Inventory_Checked_Border_Image1.Margin = new Thickness(point.X + hOffset, 0, 0, 0);

            //

            double hOffset_border = (ii.ActualWidth - Inventory_Checked_Border_Bottom_Border1.ActualWidth) / 2;
            hOffset_border += 8;

            Inventory_Checked_Border_Bottom_Border1.Margin = new Thickness(point.X + hOffset_border, 0, 0, 0);
            #endregion
        }

        private void e_Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            SetPoint(
                GetPoint().X + e.HorizontalChange * scaleTransform,
                GetPoint().Y + e.VerticalChange * scaleTransform);
        }
    }
}
