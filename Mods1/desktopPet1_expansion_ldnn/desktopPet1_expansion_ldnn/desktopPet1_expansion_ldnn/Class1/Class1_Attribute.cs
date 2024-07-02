using desktopPet1_Front.Expansion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace desktopPet1_expansion_ldnn
{
    public partial class Class1
    {
        public const string config_modkey = "desktopPet1_expansion_ldnn";

        public PublicLibrary1.Program.Apis.IProgram1 program = null;

        public List<ExpansionPet> expansionPets = null;

        /// <summary>
        /// 当前模组的根目录
        /// </summary>
        public static string thisPath = null;

        public static PublicClass1.ModSettings.class1 modSettings = null;
    }
}
