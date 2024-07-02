using PublicLibrary1.Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ModLoader1
{
    public partial class MainWindow : PublicLibrary1.Program.Apis.IProgram1
    {
        public void api_Program1_ExitProgram()
        {
            ExitProgram();
        }

        public void api_Program1_TaskbarIconAdd(UIElement menuItem)
        {
            MenuItem mi = menuItem as MenuItem;
            if (mi != null && mi.Style == null)
            {
                mi.Style = Application.Current.Resources["MenuItem1"] as Style;
            }

            _ = taskbarIcon_Container_Mod.Children.Add(menuItem);
        }

        public void api_Program1_TaskbarIconDel(UIElement menuItem)
        {
            taskbarIcon_Container_Mod.Children.Remove(menuItem);
        }

        public void api_Program1_TS(string title, string message, params Button[] buttons)
        {
            TS(title, message, buttons);
        }

        public void api_Program1_ModLoad()
        {
            modLoader.LoadMod();
        }

        public List<ModObject> api_Program1_Mod_GetModList()
        {
            return modLoader.GetModObjs();
        }

        public Random api_Program1_GetRandom()
        {
            return random;
        }
    }
}
