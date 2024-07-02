using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ModLoader1
{
    public partial class MainWindow
    {
        private PublicLibrary1.TS.ITS1 tsWindow = null;
        private ModLoaderLibrary1.ModManager.Apis.IModManager modManagerWindow = null;

        private ModLoaderLibrary1.TaskbarIconSet taskbarIcon = null;
        private System.Windows.Controls.StackPanel taskbarIcon_Container_Mod = null;//mod的任务栏右键菜单项都放这里

        public PublicLibrary1.Program.Apis.IProgram1 api_Program1 = null;

        private ModLoaderLibrary1.Mod.ModLoader modLoader = null;

        private static Random random = null;
    }
}
