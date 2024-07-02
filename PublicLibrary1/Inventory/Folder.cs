using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicLibrary1.Inventory
{
    /// <summary>
    /// 路径清单, 开头结尾不为'\'
    /// </summary>
    public partial class Folder
    {
        /// <summary>
        /// 程序的外部文件夹1
        /// </summary>
        public const string file = @"File1";
        /// <summary>
        /// 程序的配置信息
        /// </summary>
        public const string config = @"File1\config";
        /// <summary>
        /// 模组文件夹
        /// </summary>
        public const string mods = @"File1\mods";
    }
}
