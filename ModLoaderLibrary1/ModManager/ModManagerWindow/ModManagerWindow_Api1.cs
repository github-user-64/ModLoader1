using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ModLoaderLibrary1.ModManager
{
    public partial class ModManagerWindow : Apis.IModManager
    {
        public void api_IModManager_Close()
        {
            Close_();
        }

        public void api_IModManager_Open()
        {
            Open_();
        }

        public void api_IModManager_SwitchOpenOrClose()
        {
            SwitchOpenOrClose();
        }
    }
}
