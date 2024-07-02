using PublicLibrary1.Mod;
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
        #region
        /// <summary>
        /// 安装mod
        /// </summary>
        /// <param name="path"></param>
        public void ModOperation_Mod_Install(string path)
        {
            //PublicClass1.Mod.ModFile.ModInstall(path);
        }

        /// <summary>
        /// 卸载mod
        /// </summary>
        /// <param name="path"></param>
        public void ModOperation_Mod_Uninstall(string path)
        {
            //PublicClass1.Mod.ModFile.ModUninstall(path);
        }
        #endregion
    }
}
