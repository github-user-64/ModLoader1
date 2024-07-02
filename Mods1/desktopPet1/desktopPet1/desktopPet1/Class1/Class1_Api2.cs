using desktopPet1_Front.Pet;
using PublicLibrary1.Mod.Apis;
using PublicLibrary1.Program.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1
{
    public partial class Class1 : desktopPet1_Front.PetManager.Apis.IPetManager
    {
        public void AddControl(PetObject po)
        {
            petWindow.AddControl(po);
        }

        public void DelControl(PetObject po)
        {
            petWindow.DelControl(po);
        }
    }
}
