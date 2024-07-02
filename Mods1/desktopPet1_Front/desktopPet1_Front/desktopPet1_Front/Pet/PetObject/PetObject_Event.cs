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
    public partial class PetObject : UserControl
    {
        public event Action<PetObject> Move = null;
        public event Action<PetObject> RightClick = null;
        public event Action<PetObject> LeftClick = null;


        protected virtual void OnMove()
        {
            Move?.Invoke(this);
        }
        protected virtual void OnRightClick()
        {
            RightClick?.Invoke(this);
        }
        protected virtual void OnLeftClick()
        {
            LeftClick?.Invoke(this);
        }
    }
}
