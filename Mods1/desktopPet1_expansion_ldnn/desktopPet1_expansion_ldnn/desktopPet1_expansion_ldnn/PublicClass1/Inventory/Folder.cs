using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_expansion_ldnn.PublicClass1.Inventory
{
    /// <summary>
    /// 从mod文件的根目录开始, 开头结尾不为'\'
    /// </summary>
    public class Folder
    {
        /// <summary>
        /// 扩展宠物的资源文件夹
        /// </summary>
        public class ExpansionPets
        {
            /// <summary>
            /// 扩展宠物ldnn的右键菜单
            /// </summary>
            public const string Pet_ldnn_RightMenu = @"Resources\ExpansionPets\ldnn\rightMenu";
            public const string Pet_ldnn_Click = @"Resources\ExpansionPets\ldnn\click";
        }
    }
}
