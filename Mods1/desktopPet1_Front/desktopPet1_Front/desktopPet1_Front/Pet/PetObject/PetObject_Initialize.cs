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

namespace desktopPet1_Front.Pet
{
    public partial class PetObject
    {
        private void Initialize()
        {
            Width = 50;
            Height = 50;
            Background = new SolidColorBrush(Colors.White);
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;

            Initialize_Event();
        }

        private void Initialize_Event()
        {
            RegistrationClick leftClick = new RegistrationClick(this);
            MouseLeftButtonDown += (s, e) => leftClick.down(e);
            MouseLeftButtonUp += (s, e) => leftClick.up();
            MouseMove += (s, e) => leftClick.move(e);
            leftClick.Click += () => OnLeftClick();

            //

            RegistrationClick rightClick = new RegistrationClick(this);
            MouseRightButtonDown += (s, e) => rightClick.down(e);
            MouseRightButtonUp += (s, e) => rightClick.up();
            MouseMove += (s, e) => rightClick.move(e);
            rightClick.Click += () => OnRightClick();
        }
    }
}
