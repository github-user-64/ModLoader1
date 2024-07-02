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
        private class RegistrationClick
        {
            public RegistrationClick(UIElement uie)
            {
                this.uie = uie;
            }


            private UIElement uie = null;
            private bool isRightDown = false;
            private bool isMove = false;
            private Point? DownPoint = null;
            public event Action Click = null;


            public void down(MouseButtonEventArgs e)
            {
                isRightDown = true;
                isMove = false;

                DownPoint = e.GetPosition(uie);
            }

            public void up()
            {
                if (!isRightDown) return;
                if (isMove) return;

                Click?.Invoke();
            }

            public void move(MouseEventArgs e)
            {
                if (DownPoint == null) return;
                if (Math.Abs(DownPoint.Value.X - e.GetPosition(uie).X) + Math.Abs(DownPoint.Value.Y - e.GetPosition(uie).Y) < 6) return;

                isMove = true;
            }
        }
    }
}
