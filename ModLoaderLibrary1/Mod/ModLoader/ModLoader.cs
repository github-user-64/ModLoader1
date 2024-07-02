using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoaderLibrary1.Mod
{
    /// <summary>
    /// mod加载器
    /// </summary>
    public partial class ModLoader
    {
        public ModLoader(PublicLibrary1.Program.Apis.IProgram1 api_Program1)
        {
            this.api_Program1 = api_Program1;

            if (this.api_Program1 == null) throw new Exception($"{nameof(ModLoader)}:参数[{nameof(api_Program1)}]为null");
        }


        public List<PublicLibrary1.Mod.ModObject> GetModObjs()
        {
            return modObjects == null ? null : new List<PublicLibrary1.Mod.ModObject>(modObjects);
        }
    }
}
