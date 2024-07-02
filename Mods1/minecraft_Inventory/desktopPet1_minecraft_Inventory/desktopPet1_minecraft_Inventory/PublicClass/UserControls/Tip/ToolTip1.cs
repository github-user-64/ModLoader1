using desktopPet1_minecraft_Inventory.PublicClass.InventoryItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Tip
{
    /// <summary>
    /// mc样式的物品提示
    /// </summary>
    public class ToolTip1 : ToolTip, ScaleTransform.Apis.IScaleTransform1
    {
        public ToolTip1()
        {
            toolTip_Content = new ToolTip_Content();

            Content = toolTip_Content;
            Placement = System.Windows.Controls.Primitives.PlacementMode.Right;
            PlacementRectangle = new Rect(20, -64, 0, 0);
            Background = new SolidColorBrush(Colors.Transparent);
            Padding = new Thickness(0);
            BorderThickness = new Thickness(0);

            Opened += (s, e) => toolTip_Content.RefreshUI();
        }


        protected ToolTip_Content toolTip_Content = null;


        public void SetScaleTransform(double v)
        {
            SetScaleTransform_transmit(v);
        }

        public void SetScaleTransform_transmit(double v)
        {
            toolTip_Content.SetScaleTransform_transmit(v);
        }

        public void SetText(string v)
        {
            toolTip_Content.SetText(v);
        }
    }
}
