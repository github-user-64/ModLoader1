using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModLoaderLibrary1
{
    public partial class TSWindow
    {
        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            FrameworkElement f = sender as FrameworkElement;

            if (f == null) return;

            f.Margin = new Thickness(f.Margin.Left + e.HorizontalChange, f.Margin.Top + e.VerticalChange, 0, 0);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
