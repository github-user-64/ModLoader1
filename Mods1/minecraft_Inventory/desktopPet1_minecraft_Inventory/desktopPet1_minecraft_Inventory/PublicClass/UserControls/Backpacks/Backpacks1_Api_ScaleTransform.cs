using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Backpacks
{
    public partial class Backpacks1 : ScaleTransform.Apis.IScaleTransform1
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
            backpack?.SetScaleTransform_transmit(v);

            Backpacks_RadioButton1.SetScaleTransform_transmit(v);
            Backpacks_RadioButton2.SetScaleTransform_transmit(v);
            Backpacks_RadioButton3.SetScaleTransform_transmit(v);
            Backpacks_RadioButton4.SetScaleTransform_transmit(v);
        }
    }
}
