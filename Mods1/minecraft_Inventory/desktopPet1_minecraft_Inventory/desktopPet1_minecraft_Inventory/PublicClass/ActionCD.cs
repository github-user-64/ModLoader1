using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_minecraft_Inventory.PublicClass
{
    public class ActionCD
    {
        public ActionCD(int delay)
        {
            this.delay = delay;
        }

        private int delay = 1000;
        private int Data_Save_t = 0;
        private object _lock = new object();

        /// <summary>
        /// 在该方法被调用的1秒内没有再次被调用时才会保存
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public async void action(Action action)
        {
            int t = 0;

            lock (_lock)
            {
                ++Data_Save_t;
                t = Data_Save_t;
            }

            await Task.Delay(delay);

            if (t != Data_Save_t) return;
            Data_Save_t = 0;

            action?.Invoke();
        }
    }
}
