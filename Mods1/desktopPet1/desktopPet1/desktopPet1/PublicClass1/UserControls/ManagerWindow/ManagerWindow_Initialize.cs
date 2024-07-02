using desktopPet1.PublicClass1.Datas;
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
        private void Initialize(List<ExpansionObject> eos, Apis.IWindow1 window)
        {
            this.eos = eos;
            this.window = window;

            window_isWindowPenetration = Class1.modSettings?.thisModSettingsData?.ManagerWindow_isDefaultPenetration ?? false;
        }
    }
}
