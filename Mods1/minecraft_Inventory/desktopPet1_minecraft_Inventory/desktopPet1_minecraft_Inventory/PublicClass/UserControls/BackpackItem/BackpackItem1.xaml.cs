using desktopPet1_minecraft_Inventory.PublicClass.InventoryItem;
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

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.BackpackItem
{
    public partial class BackpackItem1 : UserControl, ScaleTransform.Apis.IScaleTransform1
    {
        public BackpackItem1()
        {
            InitializeComponent();

            toolTip = new Tip.ToolTip_InventoryItem();
            Event_Drag = new Events.Event_Drag();
            Event_Drag.Drag += () => Drag?.Invoke();

            ToolTip = toolTip;

            MouseMove += (s, e) =>
            {
                Event_Drag.MouseMove();

                toolTip.HorizontalOffset = e.GetPosition((IInputElement)s).X;
                toolTip.VerticalOffset = e.GetPosition((IInputElement)s).Y;
            };

            MouseLeftButtonDown += (s, e) =>
            {
                Event_Drag.MouseDown();
            };
            MouseLeftButtonUp += (s, e) =>
            {
                Event_Drag.MouseUp();
            };
            MouseLeave += (s, e) =>
            {
                Event_Drag.MouseLeave();
            };
        }


        private Tip.ToolTip_InventoryItem toolTip = null;
        private Events.Event_Drag Event_Drag = null;
        /// <summary>
        /// 发生拖动的那一刻触发
        /// </summary>
        public event Action Drag = null;


        public void SetData(InventoryItemObject iio)
        {
            ToolTip = iio == null ? null : toolTip;
            toolTip.Visibility = iio == null ? Visibility.Collapsed : Visibility.Visible;

            ico_border1.Child = iio?.InventoryItem_GetUI();

            toolTip?.SetData(iio);
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
