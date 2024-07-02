using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Backpacks
{
    public partial class Backpacks1
    {
        private void e_UserControl_Inventory_KeyUp(object sender, KeyEventArgs e)
        {
            backpack?.OnInventory_KeyUp(sender, e);
        }

        private void e_Backpacks_RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            Select(0);
        }
        private void e_Backpacks_RadioButton2_Checked(object sender, RoutedEventArgs e)
        {
            Select(1);
        }
        private void e_Backpacks_RadioButton3_Checked(object sender, RoutedEventArgs e)
        {
            Select(2);
        }
        private void e_Backpacks_RadioButton4_Checked(object sender, RoutedEventArgs e)
        {
            Select(3);
        }

        private void e_Title_TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (0 > select_index || select_index > 3) return;
            if (data_titles?.Length != 4) return;

            data_titles[select_index] = Title_TextBox1.Text;

            switch (select_index)
            {
                case 0: Backpacks_RadioButton1.SetText(data_titles[0]); break;
                case 1: Backpacks_RadioButton2.SetText(data_titles[1]); break;
                case 2: Backpacks_RadioButton3.SetText(data_titles[2]); break;
                case 3: Backpacks_RadioButton4.SetText(data_titles[3]); break;
                default: break;
            }
        }

        private void e_Title_TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if (e.Key != Key.Enter) return;

            dataSaveRead_titles?.Save(data_titles);

            _ = Focus();//让TextBox失去焦点
        }
    }
}
