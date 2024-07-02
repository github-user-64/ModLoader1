using desktopPet1_minecraft_Inventory.PublicClass.InventoryItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace desktopPet1_minecraft_Inventory.PublicClass.Inventory
{
    public class InventoryObjects<T> : InventoryObject<T> where T : InventoryItem.InventoryItem
    {
        public InventoryObjects(int lenght, Func<T> get_itme_default) : base(lenght, get_itme_default)
        {

        }

        private string savedata_path = null;
        public event Action<string> savedata = null;

        /// <summary>
        /// 交换
        /// </summary>
        /// <param name="io"></param>
        /// <param name="io2"></param>
        public override void InventoryAction_exchange(int index, int index2)
        {
            base.InventoryAction_exchange(index, index2);

            savedata?.Invoke(savedata_path);
        }

        /// <summary>
        /// 覆盖
        /// </summary>
        /// <param name="io"></param>
        /// <param name="index"></param>
        public override void InventoryAction_cover(T ii, int index)
        {
            base.InventoryAction_cover(ii, index);

            savedata?.Invoke(savedata_path);
        }

        public void SwitchData(List<Datas.Data_InventoryItem> data, string path)
        {
            base.IDataAndObject_DataToObject(data);

            savedata_path = path;
        }
    }
}
