using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Inventory
{
    public partial class Inventory1 : ScaleTransform.Apis.IScaleTransform1
    {
        public void SetScaleTransform(double v)
        {
            scaleTransform = v;

            System.Windows.Media.ScaleTransform st = new System.Windows.Media.ScaleTransform();
            st.ScaleX = scaleTransform;
            st.ScaleY = scaleTransform;
            border1_grid1.RenderTransformOrigin = new Point(0.5, 0.5);
            border1_grid1.RenderTransform = st;

            SetScaleTransform_transmit(v);
        }

        public void SetScaleTransform_transmit(double v)
        {
            for (int i = 0; i < Inventory_StackPanel1.Children.Count; ++i)
            {
                (Inventory_StackPanel1.Children[i] as InventoryItem.InventoryItem1)?.SetScaleTransform_transmit(scaleTransform);
            }
        }
    }
}
