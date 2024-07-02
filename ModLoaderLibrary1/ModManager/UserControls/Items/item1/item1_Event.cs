using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ModLoaderLibrary1.ModManager.UserControls.items
{
    public partial class item1
    {
        public event Action<item1> Button_openModFolder_Click;
        public event Action<item1> Button_settings_Click;
        public event Action<item1> Button_disableMod_Click;
        public event Action<item1> Button_enableMod_Click;
        public event Action<item1> Button_deleteMod_Click;
    }
}
