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

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Tip
{
    /// <summary>
    /// ToolTip_Content.xaml 的交互逻辑
    /// </summary>
    public partial class ToolTip_Content : UserControl, ScaleTransform.Apis.IScaleTransform1
    {
        public ToolTip_Content()
        {
            InitializeComponent();
        }


        private double scaleTransform = 1;


        public void SetText(string s)
        {
            TextBlock1.Text = s;

            RefreshUI();
        }

        public void SetScaleTransform(double v)
        {
            scaleTransform = v;

            SetScaleTransform_transmit(v);
        }

        public void SetScaleTransform_transmit(double v)
        {
            scaleTransform = v;

            RefreshUI();
        }

        public void RefreshUI()
        {
            UpdateLayout();

            ScaleTransform_Viewbox1.Width = ContentControl1.ActualWidth * scaleTransform;
            ScaleTransform_Viewbox1.Height = ContentControl1.ActualHeight * scaleTransform;
        }
    }
}
