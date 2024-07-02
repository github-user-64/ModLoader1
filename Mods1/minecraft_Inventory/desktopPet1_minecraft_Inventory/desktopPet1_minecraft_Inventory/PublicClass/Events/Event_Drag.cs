using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_minecraft_Inventory.PublicClass.Events
{
    /// <summary>
    /// 一般用于触发拖放操作
    /// </summary>
    public class Event_Drag
    {
        /// <summary>
        /// 发生拖动的那一刻触发
        /// </summary>
        public event Action Drag = null;
        private bool Drag_MousePressed_hold = false;//当鼠标在控件上方开始移动前, 鼠标是否按下. 当鼠标开始移动后该值为false


        public void MouseDown()
        {
            Drag_MousePressed_hold = true;
        }

        public void MouseUp()
        {
            Drag_MousePressed_hold = false;
        }

        public void MouseLeave()
        {
            Drag_MousePressed_hold = false;
        }

        public void MouseMove()
        {
            if (!Drag_MousePressed_hold) return;

            Drag_MousePressed_hold = false;

            Drag?.Invoke();
        }
    }
}
