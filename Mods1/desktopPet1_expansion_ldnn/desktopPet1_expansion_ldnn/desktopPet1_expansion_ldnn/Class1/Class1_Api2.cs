using desktopPet1_Front.Expansion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace desktopPet1_expansion_ldnn
{
    public partial class Class1 : desktopPet1_Front.Expansion.Apis.IExpansions
    {
        public List<ExpansionPet> GetExpansionPets()
        {
            return expansionPets;
        }
    }
}
