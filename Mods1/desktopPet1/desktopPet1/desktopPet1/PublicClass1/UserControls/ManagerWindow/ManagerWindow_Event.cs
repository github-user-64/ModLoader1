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
        public event Action<Datas.ExpansionObject> PetAddClick = null;
        public event Action PetClearClick = null;
    }
}
