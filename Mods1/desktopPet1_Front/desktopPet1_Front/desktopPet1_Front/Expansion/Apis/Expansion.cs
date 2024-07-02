using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_Front.Expansion.Apis
{
    /// <summary>
    /// 扩展mod
    /// </summary>
    public interface IExpansions
    {
        /// <summary>
        /// 获取宠物扩展
        /// </summary>
        /// <returns></returns>
        List<ExpansionPet> GetExpansionPets();
    }
}
