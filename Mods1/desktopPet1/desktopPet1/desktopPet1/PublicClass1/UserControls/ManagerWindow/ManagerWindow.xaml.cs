using desktopPet1.PublicClass1.Datas;
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

namespace desktopPet1.PublicClass1.UserControls
{
    public partial class ManagerWindow : UserControl
    {
        public ManagerWindow(List<ExpansionObject> eos, Apis.IWindow1 window)
        {
            InitializeComponent();

            Initialize(eos, window);

            Close();

            Loaded += (s, e) =>
            {
                FrameworkElement p = Parent as FrameworkElement;
                if (p == null) return;
                Margin = new Thickness(p.ActualWidth / 2 - Width / 2, p.ActualHeight / 2 - Height / 2, 0, 0);
            };
        }
    }
}
