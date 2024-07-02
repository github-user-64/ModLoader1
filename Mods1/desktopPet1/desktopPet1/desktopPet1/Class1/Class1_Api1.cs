using PublicLibrary1.Mod.Apis;
using PublicLibrary1.Program.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1
{
    public partial class Class1 : IMod1
    {
        public void ModInitialize(IProgram1 apiProcedure1, PublicLibrary1.Mod.ModObject mo)
        {
            this.apiProcedure1 = apiProcedure1;
            apiP = apiProcedure1;
            if (this.apiProcedure1 == null) throw new Exception($"{PublicClass1.Mod.Config1.key}: 获取的程序api为null");

            thisMO = mo;
            if (thisMO == null) throw new Exception($"{PublicClass1.Mod.Config1.key}: 获取的mod自身对象为null");

            Initialize();
        }

        public void Dispose()
        {
            timer1?.Stop();
            timer1 = null;

            if (petWindow != null)
            {
                petWindow.Closing -= petWindow_Closing;
                petWindow.Close();
                petWindow = null;
            }
            
            thisMO = null;
        }
    }
}
