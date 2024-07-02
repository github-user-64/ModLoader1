using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicLibrary1.Inventory
{
    /// <summary>
    /// 相对路径的文件清单
    /// </summary>
    public class FileRelative
    {
        /// <summary>
        /// 从mod文件的根目录开始, 开头结尾不为'\'
        /// </summary>
        public class Mod
        {
            /// <summary>
            /// 配置文件
            /// </summary>
            public const string config = @"config\config.json";
        }
    }
}
