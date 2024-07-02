using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Backpacks
{
    public partial class Backpacks1
    {
        private void Initialize(PublicClass.Inventory.InventoryObject<PublicClass.InventoryItem.InventoryItemObject> inventory,
            IO.File.Apis.IDataSaveAndRead<string[]> dataSaveRead_titles)
        {
            Initialize_Datas(dataSaveRead_titles);
            Initialize_Backpack(inventory);
            Initialize_Event();

            Close();

            Backpacks_RadioButton1.SetText(data_titles[0]);
            Backpacks_RadioButton2.SetText(data_titles[1]);
            Backpacks_RadioButton3.SetText(data_titles[2]);
            Backpacks_RadioButton4.SetText(data_titles[3]);
        }

        private void Initialize_Datas(IO.File.Apis.IDataSaveAndRead<string[]> dataSaveRead_titles)
        {
            this.dataSaveRead_titles = dataSaveRead_titles;
            
            try
            {
                data_titles = dataSaveRead_titles?.Read();
            }
            catch { }

            if (data_titles == null || data_titles.Length != 4)
            {
                data_titles = new string[] { "建筑方块", "装饰性方块", "红石", "交通运输" };
                try
                {
                    this.dataSaveRead_titles?.Save(data_titles);
                }
                catch { }
            }
        }

        private void Initialize_Backpack(PublicClass.Inventory.InventoryObject<PublicClass.InventoryItem.InventoryItemObject> inventory)
        {
            backpack = new Backpack.Backpack1(inventory);
            backpack.Open();

            Backpack_Container.Child = backpack;
        }

        private void Initialize_Event()
        {
            Inventory_KeyUp += e_UserControl_Inventory_KeyUp;
        }
    }
}
