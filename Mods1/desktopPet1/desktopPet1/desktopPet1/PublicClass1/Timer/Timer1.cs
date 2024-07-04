using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1.PublicClass1.Timer
{
    public class Timer1
    {
        public event Func<Task> t = null;
        private bool isRun = false;

        public async void Start()
        {
            if (isRun) return;
            isRun = true;

            while (isRun)
            {
                await t?.Invoke();
            }
        }

        public void Stop()
        {
            isRun = false;
        }
    }
}
