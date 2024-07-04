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
using System.Windows.Shapes;

namespace desktopPet1.PublicClass1.Windows
{
    /// <summary>
    /// PetWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PetWindow : Window
    {
        #region 废弃
        //Win+D后桌面窗口可能会将原本的子窗口移到新的窗口, 这会导致原本的子窗口的大小和最大化等设置改变.
        //当窗口在Win+D产生的新窗口时再次将窗口置底, 这会可能导致窗口到Win+D的新窗口下方, 从而出现窗口消失的问题.
        #endregion

        public PetWindow()
        {
            InitializeComponent();

            windowTop_timer = new System.Windows.Threading.DispatcherTimer();
            windowTop_timer.Interval = new TimeSpan(TimeSpan.TicksPerSecond);
            windowTop_timer.Tick += (s, e) =>
            {
                //置顶窗口会被其它置顶窗口覆盖, 将Topmost设为false再设为true可以重新让窗口显示回上层.
                //不过用这种方法貌似在一些情况下没效果, 而这种方法可以, 所以就使用这种方法解决.
                _ = WinApi.Class1.WindowPlaces.Top(this);
            };
        }


        #region
        public void AddControl(UIElement uie)
        {
            _ = petContainer_grid.Children.Add(uie);
        }

        public void DelControl(UIElement uie)
        {
            petContainer_grid.Children.Remove(uie);
        }
        #endregion

        private void e_Window_MouseLeave(object sender, MouseEventArgs e)
        {
            if (WindowPlaces == WinApi.Class1.Places.Bottom) _ = IWindow_Places_Bottom();
        }
    }
}
