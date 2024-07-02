using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PublicLibrary1.JsonDispose1;

namespace PublicLibrary1.Mod
{
    /// <summary>
    /// mod配置
    /// </summary>
    public partial class ModConfig
    {
        /// <summary>
        /// 用于识别mod的id
        /// </summary>
        public string key { get; set; } = null;
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool isEnable { get; set; } = false;
        /// <summary>
        /// 版本
        /// </summary>
        public string version { get; set; } = null;
        /// <summary>
        /// 模组文件夹的完整路径. mod的配置文件中此项不写, 请在创建该对象时赋值
        /// </summary>
        public string fullPath { get; set; } = null;
        /// <summary>
        /// mod的用于对接的dll, 要包含文件名和文件后缀名, 文件要放在该mod的根目录的文件夹
        /// </summary>
        public string mainDll { get; set; } = null;
        /// <summary>
        /// 加载mainDll需要的其它dll, 只包括该mod的dll
        /// </summary>
        public string[] dlls { get; set; } = null;
        /// <summary>
        /// mod的用于对接的类, 要包含命名空间和类名
        /// </summary>
        public string mainClass { get; set; } = null;
        /// <summary>
        /// 该mod必须的前置mod的key
        /// </summary>
        public string[] frontModKeys { get; set; } = null;
    }
}
