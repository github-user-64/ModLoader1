using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace desktopPet1.PublicClass1.UserControls
{
    public partial class ManagerWindow
    {
        private void e_TitleRight_Buttons_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void e_TitleRight_Buttons_Clear_Click(object sender, RoutedEventArgs e)
        {
            PetClearClick?.Invoke();
        }

        #region
        private void e_TitleRight_Buttons_Window_Places_Normal_Click(object sender, RoutedEventArgs e)
        {
            _ = window?.IWindow_Places_Normal();
        }

        private void e_TitleRight_Buttons_Window_Places_Top_Click(object sender, RoutedEventArgs e)
        {
            _ = window?.IWindow_Places_Top();
        }

        private void e_TitleRight_Buttons_Window_Places_Bottom_Click(object sender, RoutedEventArgs e)
        {
            _ = window?.IWindow_Places_Bottom();
        }

        private void e_TitleRight_Buttons_Window_WindowPenetration_Click(object sender, RoutedEventArgs e)
        {
            Close();
            _ = window?.IWindow_WindowPenetration(window_isWindowPenetration = !window_isWindowPenetration);
        }
        #endregion

        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Margin = new Thickness(Margin.Left + e.HorizontalChange, Margin.Top + e.VerticalChange, 0, 0);
        }
    }
}
