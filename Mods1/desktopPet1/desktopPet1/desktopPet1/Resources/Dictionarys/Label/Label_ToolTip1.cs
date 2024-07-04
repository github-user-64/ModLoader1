using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace desktopPet1.Resources.Dictionarys
{
    public class Label_ToolTip1 : ToolTip
    {
        public Label_ToolTip1()
        {
            Opened += Label_ToolTip1_Opened;
        }

        private void Label_ToolTip1_Opened(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBlock t = PlacementTarget as TextBlock;
            TextBlock t2 = t?.DataContext as TextBlock;
            if (t == null || t2 == null) return;

            if (t.ActualWidth >= t2.ActualWidth) IsOpen = false;
        }
    }
}
