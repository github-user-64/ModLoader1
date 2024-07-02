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
        public void Open()
        {
            Visibility = Visibility.Visible;

            RefreshExpansionPet();

            _ = window?.IWindow_WindowPenetration(false);
            window_isWindowPenetration = false;

            _ = window?.IWindow_Window_Activate();
        }

        public void Close()
        {
            Visibility = Visibility.Collapsed;
        }

        public void SwitchOpenOrClose()
        {
            if (Visibility == Visibility.Visible)
            {
                Close();
                return;
            }
            Open();
        }

        public void RefreshExpansionPet()
        {
            ExpansionPet_wrapPanel.Children.Clear();

            for (int i = 0; i < eos?.Count; ++i)
            {
                Datas.ExpansionObject eo = eos[i];
                Button1 b1 = new Button1(eo);

                b1.Margin = new Thickness(4);
                b1.Click += (s, e) =>
                {
                    PetAddClick?.Invoke(eo);
                };

                _ = ExpansionPet_wrapPanel.Children.Add(b1);
            }
        }
    }
}
