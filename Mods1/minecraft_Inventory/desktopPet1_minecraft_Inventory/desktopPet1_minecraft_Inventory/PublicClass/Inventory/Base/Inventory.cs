using desktopPet1_minecraft_Inventory.PublicClass.Datas.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_minecraft_Inventory.PublicClass.Inventory
{
    /// <summary>
    /// 物品栏
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Inventory<T> : IDataAndObject<List<Datas.Data_InventoryItem>> where T : InventoryItem.InventoryItem
    {
        public Inventory(int length)
        {
            if (Inventory.MinLength > length || length > Inventory.MaxLength) throw new Exception($"{nameof(Inventory<T>)}:参数不符合规范:{nameof(length)}={length}");

            Length = length;
            list = new List<T>(Enumerable.Repeat(default(T), Length));
        }


        public int Length { get; private set; } = 0;//只设置一次, readonly
        private List<T> list = null;
        public event Action<int[]> InventoryItemChanged = null;


        /// <summary>
        /// 交换
        /// </summary>
        /// <param name="io"></param>
        /// <param name="io2"></param>
        public virtual void InventoryAction_exchange(int index, int index2)
        {
            if (index == index2) return;
            if (0 > index || index > Length - 1) return;
            if (0 > index2 || index2 > Length - 1) return;

            T ii = list[index];
            list[index] = list[index2];
            list[index2] = ii;

            InventoryItemChanged?.Invoke(new int[] { index, index2 });
        }

        /// <summary>
        /// 覆盖
        /// </summary>
        /// <param name="io"></param>
        /// <param name="index"></param>
        public virtual void InventoryAction_cover(T ii, int index)
        {
            if (0 > index || index > Length - 1) return;

            list[index] = ii;

            InventoryItemChanged?.Invoke(new int[] { index });
        }

        /// <summary>
        /// 使用
        /// </summary>
        /// <param name="index"></param>
        public virtual void Inventory_apply(int index)
        {
            if (0 > index || index > Length - 1) return;

            list[index]?.InventoryItem_Apply();
        }

        public virtual T Inventory_getItem(int index)
        {
            if (0 > index || index > Length - 1) return null;

            return list[index];
        }

        /// <summary>
        /// 查找对象的索引, 如果对象不存在则返回-1
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual int Inventory_IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public virtual List<Datas.Data_InventoryItem> IDataAndObject_GetData()
        {
            List<Datas.Data_InventoryItem> os = new List<Datas.Data_InventoryItem>();

            for (int i = 0; i < list.Count; ++i)
            {
                os.Add(list[i]?.IDataAndObject_GetData());
            }

            return os;
        }

        public virtual void IDataAndObject_DataToObject(List<Datas.Data_InventoryItem> data)
        {
            List<Datas.Data_InventoryItem> s = data;

            if (s == null) return;

            for (int i = 0; i < s.Count && i < Length; ++i)
            {
                T t = s[i] == null ? null : GetInventoryItemDefault();
                t?.IDataAndObject_DataToObject(s[i]);

                list[i] = t;
            }

            //

            int[] indexs = new int[Length];

            for (int i = 0; i < indexs.Length; ++i) indexs[i] = i;
            InventoryItemChanged?.Invoke(indexs);
        }

        /// <summary>
        /// 获取item对象的默认值, 继承的类需重写
        /// </summary>
        /// <returns></returns>
        protected virtual T GetInventoryItemDefault()
        {
            //return new InventoryItem.InventoryItemObject() as T;
            return null;
        }
    }
}
