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
        private class InventoryItemData_class1
        {
            public InventoryItemData_class1(string path)
            {
                this.path = path;
            }

            public string path = null;
            public List<PublicClass.Datas.Data_InventoryItem> datas = null;
            public PublicClass.ActionCD save = null;//为了让每个有独立的cd
        }
    }
}
