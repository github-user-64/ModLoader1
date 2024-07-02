using desktopPet1_minecraft_Inventory.PublicClass.Datas.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace desktopPet1_minecraft_Inventory.PublicClass.InventoryItem
{
    /// <summary>
    /// 物品栏的item
    /// </summary>
    public class InventoryItem : IDataAndObject<Datas.Data_InventoryItem>
    {
        /// <summary>
        /// 获取物品在UI上显示的控件, 每次返回的对象不能是同一个
        /// </summary>
        /// <returns></returns>
        public virtual FrameworkElement InventoryItem_GetUI()
        {
            return null;
        }

        /// <summary>
        /// 使用
        /// </summary>
        public virtual void InventoryItem_Apply()
        {

        }

        public virtual Datas.Data_InventoryItem IDataAndObject_GetData()
        {
            return null;
        }

        public virtual void IDataAndObject_DataToObject(Datas.Data_InventoryItem data)
        {

        }
    }
}
