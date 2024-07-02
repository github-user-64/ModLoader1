using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Backpacks
{
    public partial class Backpacks1
    {
        public void Open()
        {
            Visibility = Visibility.Visible;

            isOpen = true;
        }

        public void Close()
        {
            Visibility = Visibility.Collapsed;

            isOpen = false;
        }

        public void SwitchOpenOrClose()
        {
            if (isOpen)
            {
                Close();
                return;
            }
            Open();
        }

        public void Select(int index)
        {
            if (0 > index || index > 3) return;
            if (index == select_index) return;

            select_index = index;

            switch (select_index)
            {
                case 0: Backpacks_RadioButton1.IsChecked = true; break;
                case 1: Backpacks_RadioButton2.IsChecked = true; break;
                case 2: Backpacks_RadioButton3.IsChecked = true; break;
                case 3: Backpacks_RadioButton4.IsChecked = true; break;
                default: break;
            }

            Title_TextBox1.Text = data_titles?.Length == 4 ? data_titles[select_index] : null;

            Backpacks_RadioButtons_Checked?.Invoke(select_index);
        }
    }
}
