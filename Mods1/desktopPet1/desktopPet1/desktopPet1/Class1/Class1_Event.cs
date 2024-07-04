using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1
{
    public partial class Class1
    {
        public event Action ModsInitialized;

        #region
        public event Action Timer = null;
        public event Action<System.Windows.Input.KeyEventArgs> KeyDown = null;
        public event Action<System.Windows.Input.KeyEventArgs> KeyUp = null;
        #endregion
    }
}
