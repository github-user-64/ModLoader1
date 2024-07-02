using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicLibrary1.Mod.Apis;
using PublicLibrary1.Program.Apis;

namespace ldnn_expansion
{
    public partial class Class1 : IMod1
    {
        public event Action ModsInitialized;

        public void Dispose()
        {
            thisPath = null;
        }

        public void ModInitialize(IProgram1 api_Program1, PublicLibrary1.Mod.ModObject mo)
        {
            program = api_Program1;
            if (program == null) return;

            //获取mod对象列表
            mos = program.api_Program1_Mod_GetModList();
            if (mos == null) return;

            thisPath = mo?.modConfig?.fullPath;
            if (thisPath == null) return;

            Initialize();
        }
    }
}
