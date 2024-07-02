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
        public const string config_key = nameof(desktopPet1_minecraft_Inventory);
        public IProgram1 apiProcedure1 = null;
        public static ModObject thisMO = null;

        private string path_Backpacks_Titles = null;

        /// <summary>
        /// 物品栏数据列表
        /// </summary>
        private InventoryItemData_class1[] data_inventorys = null;
        public static PublicClass.Settings.Mod.class1 modSettings = null;

        #region
        private PublicClass.PetObjects.container petUI = null;//添加到桌宠管理器的容器UI, 东西都塞这

        /// <summary>
        /// 物品栏数量
        /// </summary>
        private const int data_inventory_count = 4;
        /// <summary>
        /// 当前选择的是第几个物品栏
        /// </summary>
        private int data_inventory_index = -1;
        private PublicClass.Inventory.InventoryObjects<PublicClass.InventoryItem.InventoryItemObject> inventory = null;//物品栏类
        private PublicClass.UserControls.Inventory.Inventory1 inventory_ui = null;//物品栏ui
        private PublicClass.UserControls.Backpacks.Backpacks1 backpacks_ui = null;//背包ui
        #endregion
    }
}
