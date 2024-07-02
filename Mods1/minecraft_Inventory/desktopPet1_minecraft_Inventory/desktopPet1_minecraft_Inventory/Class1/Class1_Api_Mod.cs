using PublicLibrary1.Mod;
using PublicLibrary1.Program.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_minecraft_Inventory
{
    public partial class Class1 : PublicLibrary1.Mod.Apis.IMod1
    {
        public event Action ModsInitialized;

        public void Dispose()
        {
            
        }

        public void ModInitialize(IProgram1 api_Program1, ModObject mo)
        {
            apiProcedure1 = api_Program1;
            if (apiProcedure1 == null) throw new Exception($"{config_key}: 获取的程序api为null");

            thisMO = mo;
            if (thisMO == null) throw new Exception($"{config_key}: 获取的mod自身对象为null");

            Initialize();
        }
    }
}
