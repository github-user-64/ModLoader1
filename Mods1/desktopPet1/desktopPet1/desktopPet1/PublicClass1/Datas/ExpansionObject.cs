using desktopPet1_Front.Expansion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1.PublicClass1.Datas
{
    public class ExpansionObject
    {
        public ExpansionObject(ExpansionPet expansionPet, PublicLibrary1.Mod.ModObject mo)
        {
            this.expansionPet = expansionPet;
            this.mo = mo;
        }

        public ExpansionPet expansionPet { get; } = null;
        public PublicLibrary1.Mod.ModObject mo { get; } = null;
    }
}
