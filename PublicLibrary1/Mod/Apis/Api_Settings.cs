using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PublicLibrary1.Mod.Apis
{
    /// <summary>
    /// mod设置的api
    /// </summary>
    public interface IModSettings
    {
        FrameworkElement SettingsGetUI();
        void SettingsSave();
    }
}
