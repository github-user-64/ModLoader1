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
    public partial class ModManagerWindow :Apis.ModManagerTS
    {
        public void ModManagerTS(string message)
        {
            TS(message);
        }
    }
}
