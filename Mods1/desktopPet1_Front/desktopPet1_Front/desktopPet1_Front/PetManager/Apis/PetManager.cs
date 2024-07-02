using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_Front.PetManager.Apis
{
    public interface IPetManager
    {
        /// <summary>
        /// 计时器, 等待指定时间后调用. 这是公用的计时器请不要在里面进行等待或阻塞操作
        /// </summary>
        event Action Timer;
        /// <summary>
        /// 在窗口上按下按键时触发
        /// </summary>
        event Action<System.Windows.Input.KeyEventArgs> KeyDown;
        /// <summary>
        /// 在窗口上松开按键时触发
        /// </summary>
        event Action<System.Windows.Input.KeyEventArgs> KeyUp;

        /// <summary>
        /// 添加控件到ui
        /// </summary>
        /// <param name="po"></param>
        void AddControl(Pet.PetObject po);
        /// <summary>
        /// 从ui删除控件
        /// </summary>
        /// <param name="po"></param>
        void DelControl(Pet.PetObject po);
    }
}
