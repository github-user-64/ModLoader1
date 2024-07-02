using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Backpack
{
    public partial class Backpack1 : ScaleTransform.Apis.IScaleTransform1
    {
        public void SetScaleTransform(double v)
        {
            scaleTransform = v;

            System.Windows.Media.ScaleTransform st = new System.Windows.Media.ScaleTransform();
            st.ScaleX = scaleTransform;
            st.ScaleY = scaleTransform;
            RenderTransformOrigin = new Point(0.5, 0.5);
            RenderTransform = st;

            SetScaleTransform_transmit(v);
        }

        public void SetScaleTransform_transmit(double v)
        {
            for (int i = 0; i < backpackItems.Count; ++i)
            {
                backpackItems[i]?.SetScaleTransform_transmit(v);
            }
        }
    }
}
