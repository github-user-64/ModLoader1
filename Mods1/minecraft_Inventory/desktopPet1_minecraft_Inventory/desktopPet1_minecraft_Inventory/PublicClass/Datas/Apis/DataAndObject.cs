using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_minecraft_Inventory.PublicClass.Datas.Apis
{
    /// <summary>
    /// 获取可保存的数据
    /// </summary>
    public interface IDataAndObject<T>
    {
        /// <summary>
        /// 获取可保存的数据
        /// </summary>
        /// <returns></returns>
        T IDataAndObject_GetData();
        /// <summary>
        /// 将数据转为对象
        /// </summary>
        /// <param name="data"></param>
        void IDataAndObject_DataToObject(T data);
    }
}
