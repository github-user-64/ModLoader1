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

namespace desktopPet1_expansion_ldnn.PublicClass1.PetObjects.ldnn
{
    public partial class message : desktopPet1_Front.Pet.PetObject
    {
        public message()
        {
            InitializeComponent();
        }

        public desktopPet1_Front.Pet.PetObject PlacementTarget = null;
        public double HorizontalOffset = 0;
        public double VerticalOffset = 0;
        public event Action Opening = null;

        public bool isFlip { get; private set; } = false;

        public async Task Open(string message, int displayTime)
        {
            bubble_message_TextBlock.Text = message;

            UpdateLayout();//让ActualWidth更新

            Opening?.Invoke();

            Visibility = Visibility.Visible;

            await Task.Delay(displayTime);

            Visibility = Visibility.Hidden;
        }

        public void Reset()
        {
            if (PlacementTarget == null) return;

            SetX(PlacementTarget.GetX() + HorizontalOffset);
            SetY(PlacementTarget.GetY() + VerticalOffset);
        }

        public void Flip(bool isFlip)
        {
            this.isFlip = isFlip;

            if (isFlip) bubble_background_grid_ScaleTransform.ScaleX = -1;
            else bubble_background_grid_ScaleTransform.ScaleX = 1;
        }
    }
}
