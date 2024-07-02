using PublicLibrary1.Program.Apis;
using PublicLibrary1.Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace desktopPet1_minecraft_Inventory
{
    public partial class Class1
    {
        public class DataSaveAndReads_Backpacks_Titles : PublicClass.IO.File.Apis.IDataSaveAndRead<string[]>
        {
            public DataSaveAndReads_Backpacks_Titles(string path)
            {
                this.path = path;
                acd = new PublicClass.ActionCD(500);
            }

            private string path = null;
            private PublicClass.ActionCD acd = null;

            public string[] Read()
            {
                try
                {
                    return new PublicLibrary1.JsonDispose1.MyJson1(path).Get2<string[]>();
                }
                catch
                {
                    return null;
                }
            }

            public void Save(string[] data)
            {
                try
                {
                    acd.action(() =>
                    {
                        new PublicLibrary1.JsonDispose1.MyJson1(path).Save(data);
                    });
                }
                catch
                {

                }
            }
        }
    }
}
