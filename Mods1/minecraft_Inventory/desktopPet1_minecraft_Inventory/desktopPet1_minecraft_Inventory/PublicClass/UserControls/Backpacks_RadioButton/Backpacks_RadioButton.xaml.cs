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

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Backpacks
{
    public partial class Backpacks_RadioButton : RadioButton, ScaleTransform.Apis.IScaleTransform1
    {
        public Backpacks_RadioButton()
        {
            InitializeComponent();

            toolTip = new Tip.ToolTip1();

            ToolTip = toolTip;

            MouseMove += (s, e) =>
            {
                toolTip.HorizontalOffset = e.GetPosition((IInputElement)s).X;
                toolTip.VerticalOffset = e.GetPosition((IInputElement)s).Y;
            };
        }

        private Tip.ToolTip1 toolTip = null;

        public void SetText(string v)
        {
            toolTip.SetText(v);
        }

        public void SetScaleTransform(double v)
        {
            SetScaleTransform_transmit(v);
        }

        public void SetScaleTransform_transmit(double v)
        {
            toolTip?.SetScaleTransform_transmit(v);
        }
    }
}
