using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ModLoader1
{
    public partial class MainWindow
    {
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dispose();

            Environment.Exit(0);
        }

        private void ModLoader_ClearModIng()
        {
            taskbarIcon_Container_Mod.Children.Clear();

            api_Program1_ExitProgramIng = null;
            api_Program1_TS_Action = tsWindow;
        }
    }
}
