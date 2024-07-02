using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktopPet1_minecraft_Inventory.PublicClass.IO.Folder
{
    public class Choice
    {
        public static string Get()
        {
            try
            {
                FolderSelectDialog fsd = new FolderSelectDialog();
                fsd.Title = "选择文件夹";
                fsd.InitialDirectory = "c:\\";
                _ = fsd.ShowDialog();

                if (!System.IO.Directory.Exists(fsd.FileName)) return null;

                return fsd.FileName;
            }
            catch
            {
                return null;
            }
        }
    }
}
