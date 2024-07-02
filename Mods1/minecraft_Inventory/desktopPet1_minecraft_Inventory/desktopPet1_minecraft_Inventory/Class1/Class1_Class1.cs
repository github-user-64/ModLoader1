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
        private void Refresh_Data_InventorysItems(int[] indexs)
        {
            if (0 > data_inventory_index || data_inventory_index > data_inventory_count - 1) return;

            for (int i = 0; i < indexs?.Length; ++i)
            {
                List<PublicClass.Datas.Data_InventoryItem> data = data_inventorys[data_inventory_index].datas;

                if (0 > indexs[i] || indexs[i] > data.Count - 1) continue;

                data[indexs[i]] = inventory.Inventory_getItem(indexs[i])?.IDataAndObject_GetData();
            }
        }

        private void SwitchInventorysData(int index)
        {
            if (0 > index || index > data_inventory_count - 1) return;

            data_inventory_index = index;

            inventory.SwitchData(data_inventorys[data_inventory_index].datas, data_inventorys[data_inventory_index].path);
        }
    }
}
