using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_minecraft_Inventory.PublicClass.IO.File
{
    public class Choice
    {
        public static string Get()
        {
            try
            {
                OpenFileDialog a1 = new OpenFileDialog();
                a1.Title = "选择文件";
                a1.InitialDirectory = "c:\\";
                a1.Multiselect = false;
                _ = a1.ShowDialog();

                if (!System.IO.File.Exists(a1.FileName)) return null;

                return a1.FileName;
            }
            catch
            {
                return null;
            }
        }
    }
}
