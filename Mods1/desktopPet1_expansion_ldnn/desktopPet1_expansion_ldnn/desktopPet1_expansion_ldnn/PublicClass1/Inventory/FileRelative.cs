using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_expansion_ldnn.PublicClass1.Inventory
{
    /// <summary>
    /// 相对路径的文件清单
    /// </summary>
    public class FileRelative
    {
        /// <summary>
        /// 从mod文件的根目录开始, 开头结尾不为'\'
        /// </summary>
        public class ExpansionPets
        {
            /// <summary>
            /// 从右键菜单目录下的子文件夹下开始, 开头结尾不为'\'
            /// </summary>
            public class ldnn
            {
                /// <summary>
                /// 右键菜单的数据
                /// </summary>
                public const string rightMenu_data = @"data1.json";
                /// <summary>
                /// 右键菜单的相关文件
                /// </summary>
                public const string rightMenu_img = @"data1.png";

                /// <summary>
                /// 点击的行为数据
                /// </summary>
                public const string click_data = @"data1.json";
                /// <summary>
                /// 点击的相关文件
                /// </summary>
                public const string click_img = @"data1.png";
            }
        }
    }
}
