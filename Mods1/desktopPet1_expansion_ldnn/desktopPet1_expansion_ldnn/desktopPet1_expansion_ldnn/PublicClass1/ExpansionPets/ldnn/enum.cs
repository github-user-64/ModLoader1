using desktopPet1_Front.Expansion;
using desktopPet1_Front.Pet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace desktopPet1_expansion_ldnn.PublicClass1.ExpansionPets
{
    public enum petState
    {
        /// <summary>
        /// 没任何状态, 可以随时覆盖该状态
        /// </summary>
        not,
        /// <summary>
        /// 正在进行活动, 在状态存在时不能进行其它活动
        /// </summary>
        actionIng
    }
}
