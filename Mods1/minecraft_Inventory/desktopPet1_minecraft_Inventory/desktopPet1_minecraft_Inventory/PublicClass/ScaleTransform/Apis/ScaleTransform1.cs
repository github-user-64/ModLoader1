using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_minecraft_Inventory.PublicClass.ScaleTransform.Apis
{
    public interface IScaleTransform1
    {
        /// <summary>
        /// 缩放
        /// </summary>
        /// <param name="v"></param>
        void SetScaleTransform(double v);
        /// <summary>
        /// 跳过缩放, 将缩放向下传递. 用于防止缩放向下传递时子级再次设置缩放
        /// </summary>
        /// <param name="v"></param>
        void SetScaleTransform_transmit(double v);
    }
}
