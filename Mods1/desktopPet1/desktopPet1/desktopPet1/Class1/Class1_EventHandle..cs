using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1
{
    public partial class Class1
    {
        private Stopwatch Class_Tick_stopwatch = new Stopwatch();
        private int Class_Tick_sleep = 1000 / 30;
        public async Task Class_Tick()
        {
            Class_Tick_stopwatch.Start();

            Timer?.Invoke();

            Class_Tick_stopwatch.Stop();

            int interval = (int)Class_Tick_stopwatch.ElapsedMilliseconds;

            if (interval > Class_Tick_sleep) return;

            await Task.Delay(Class_Tick_sleep - interval);
        }

        #region ManagerWindow
        private void Class1_ManagerWindow_PetAddClick(PublicClass1.Datas.ExpansionObject eo)
        {
            if (!expansionObjects.Contains(eo)) return;

            eo?.expansionPet?.AddPat();
        }

        private void Class1_ManagerWindow_PetClearClick()
        {
            for (int i = 0; i < expansionObjects.Count; ++i)
            {
                expansionObjects[i]?.expansionPet?.ClearPet();
            }
        }
        #endregion
    }
}
