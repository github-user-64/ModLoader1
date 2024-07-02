using desktopPet1_Front.Expansion;
using PublicLibrary1.Program.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace desktopPet1_expansion_ldnn
{
    public partial class Class1 : PublicLibrary1.Mod.Apis.IMod1
    {
        public void ModInitialize(IProgram1 api_Program1, PublicLibrary1.Mod.ModObject mo)
        {
            program = api_Program1;
            if (program == null) throw new Exception($"{config_modkey}: 获取的程序api为null");

            thisPath = mo?.modConfig?.fullPath;
            if (thisPath == null) throw new Exception($"{config_modkey}: 获取的mod文件路径为null");

            modSettings = new PublicClass1.ModSettings.class1();

            expansionPets = new List<ExpansionPet>() { new PublicClass1.ExpansionPets.ldnn() };
        }

        public void Dispose()
        {
            thisPath = null;
        }
    }
}
