using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PublicLibrary1.Mod
{
    /// <summary>
    /// mod对象
    /// </summary>
    public partial class ModObject
    {
        /// <summary>
        /// mod配置
        /// </summary>
        public ModConfig modConfig = null;
        /// <summary>
        /// mod用于对接的类的类型
        /// </summary>
        public Type type = null;
        /// <summary>
        /// mod的程序集
        /// </summary>
        public Assembly assembly = null;
        /// <summary>
        /// mod用于对接的类的对象
        /// </summary>
        public object mod = null;
        /// <summary>
        /// 是否继承了api
        /// </summary>
        public bool isInheritApi = false;
    }
}
