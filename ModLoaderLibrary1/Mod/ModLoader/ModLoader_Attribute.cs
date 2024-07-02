using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoaderLibrary1.Mod
{
    public partial class ModLoader
    {
        private PublicLibrary1.Program.Apis.IProgram1 api_Program1 = null;

        private List<PublicLibrary1.Mod.ModObject> modObjects = null;

        public event Action ClearModIng = null;
    }
}
