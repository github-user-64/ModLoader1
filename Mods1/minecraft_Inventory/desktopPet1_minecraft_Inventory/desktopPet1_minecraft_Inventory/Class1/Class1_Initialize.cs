using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_minecraft_Inventory
{
    public partial class Class1
    {
        private void Initialize()
        {
            Initialize_Attribute();
            Initialize_Datas();
            Initialize_Inventory();
            Initialize_Event();

            backpacks_ui.Select(0);//选择第一个物品栏
        }

        private void Initialize_Attribute()
        {
            if (!System.IO.Directory.Exists(thisMO?.modConfig?.fullPath)) throw new Exception($"{config_key}: 路径[{thisMO?.modConfig?.fullPath}]不存在");

            data_inventorys = new InventoryItemData_class1[data_inventory_count]
            {
                new InventoryItemData_class1($"{thisMO.modConfig.fullPath}\\InventoryData1.json"),
                new InventoryItemData_class1($"{thisMO.modConfig.fullPath}\\InventoryData2.json"),
                new InventoryItemData_class1($"{thisMO.modConfig.fullPath}\\InventoryData3.json"),
                new InventoryItemData_class1($"{thisMO.modConfig.fullPath}\\InventoryData4.json")
            };
            for (int i = 0; i < data_inventorys.Length; ++i)
            {
                data_inventorys[i].save = new PublicClass.ActionCD(500);
            };

            path_Backpacks_Titles = $"{thisMO.modConfig.fullPath}\\config\\Backpacks_titles.json";
        }

        private void Initialize_Datas()
        {
            modSettings = new PublicClass.Settings.Mod.class1();
            if (modSettings.GetNewData() == null)//文件读取错误的情况下数据会设为默认值. 所以直接读取文件数据判断文件读取是否出错
            {
                try
                {
                    new PublicLibrary1.JsonDispose1.MyJson1($"{thisMO?.modConfig?.fullPath}\\config\\modSettings.json").Save(new PublicClass.Settings.Mod.modSettingsData());
                }
                catch
                {

                }

                throw new Exception($"{config_key}: mod配置文件错误");
            }

            //

            int inventory_lenght = modSettings.thisModSettingsData.Inventory_Column * modSettings.thisModSettingsData.Inventory_Row;
            for (int i = 0; i < data_inventorys.Length; ++i)
            {
                data_inventorys[i].datas = Initialize_Datas_InventorysItems(data_inventorys[i].path, inventory_lenght);
            }
        }
        private List<PublicClass.Datas.Data_InventoryItem> Initialize_Datas_InventorysItems(string path, int item_lenght)
        {
            try
            {
                if (!System.IO.File.Exists(path))
                    return new List<PublicClass.Datas.Data_InventoryItem>(Enumerable.Repeat(default(PublicClass.Datas.Data_InventoryItem), item_lenght));
                
                return new PublicLibrary1.JsonDispose1.MyJson1(path).Get2<List<PublicClass.Datas.Data_InventoryItem>>();
            }
            catch
            {
                return new List<PublicClass.Datas.Data_InventoryItem>(Enumerable.Repeat(default(PublicClass.Datas.Data_InventoryItem), item_lenght));
            }
        }

        private void Initialize_Inventory()
        {
            try
            {
                int lenght = modSettings.thisModSettingsData.Inventory_Column * modSettings.thisModSettingsData.Inventory_Row;
                int min = PublicClass.Inventory.Inventory.MinLength;
                int max = PublicClass.Inventory.Inventory.MaxLength;

                if (min > lenght || lenght > max)
                {
                    throw new Exception($"物品栏长度不符合规范, 长度为{lenght}. 目标长度为{min}-{max}");
                }

                inventory = new PublicClass.Inventory.InventoryObjects<PublicClass.InventoryItem.InventoryItemObject>
                (lenght,
                () => new PublicClass.InventoryItem.InventoryItemObject()
                );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Initialize_Inventory_UI();
        }

        private void Initialize_Inventory_UI()
        {
            inventory_ui = new PublicClass.UserControls.Inventory.Inventory1(inventory);
            backpacks_ui = new PublicClass.UserControls.Backpacks.Backpacks1(inventory, new DataSaveAndReads_Backpacks_Titles(path_Backpacks_Titles));
            petUI = new PublicClass.PetObjects.container();

            inventory_ui.SetScaleTransform(modSettings?.thisModSettingsData?.inventory_ui_scaleTransform ?? new PublicClass.Settings.Mod.modSettingsData().inventory_ui_scaleTransform);
            backpacks_ui.SetScaleTransform(modSettings?.thisModSettingsData?.backpack_ui_scaleTransform ?? new PublicClass.Settings.Mod.modSettingsData().backpack_ui_scaleTransform);
            backpacks_ui.Close();

            //

            _ = petUI.Children.Add(inventory_ui);
            _ = petUI.Children.Add(backpacks_ui);
        }

        private void Initialize_Event()
        {
            apiProcedure1.api_Program1_ExitProgramIng += () =>
            {
                if (modSettings?.thisModSettingsData != null)
                {
                    try
                    {
                        //保存物品栏的坐标
                        new PublicLibrary1.JsonDispose1.MyJson1(modSettings.path).Save(modSettings.thisModSettingsData);
                    }
                    catch
                    {

                    }
                }
            };

            petUI.KeyUp += (s, e) =>
            {
                switch (e.Key)
                {
                    case System.Windows.Input.Key.E: backpacks_ui.SwitchOpenOrClose(); break;
                    default: break;
                }

                if (!backpacks_ui.isOpen) inventory_ui.OnInventory_KeyUp(s, e);
                if (backpacks_ui.isOpen) backpacks_ui.OnInventory_KeyUp(s, e);
            };

            backpacks_ui.Backpacks_RadioButtons_Checked += (index) =>
            {
                SwitchInventorysData(index);
            };

            inventory.InventoryItemChanged += (indexs) =>
            {
                Refresh_Data_InventorysItems(indexs);
            };

            inventory.savedata += (s) =>
            {
                //数据会等待一定时间后才会保存, 如果在这期间将物品栏的数据切换成其它数据, 那么到保存时获取的数据则是新的数据而不是需要保存的原数据.
                //所以需要把需要保存的数据暂时存下, 然后在开始保存的时候使用存下的数据.

                int index = data_inventory_index;
                if (0 > index || index > data_inventorys.Length - 1) return;

                List<PublicClass.Datas.Data_InventoryItem> data = inventory.IDataAndObject_GetData();

                data_inventorys[index].save.action(() =>
                {
                    new PublicLibrary1.JsonDispose1.MyJson1(s).Save(data);
                });
            };
        }
    }
}
