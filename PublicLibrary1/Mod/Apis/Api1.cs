using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicLibrary1.Mod.Apis
{
    /// <summary>
    /// mod的api
    /// </summary>
    public interface IMod1 : IDisposable
    {
        /// <summary>
        /// 全部mod初始化完成时触发
        /// </summary>
        event Action ModsInitialized;

        /// <summary>
        /// 初始化mod(程序的api, 当前模组对象)
        /// </summary>
        /// <param name="api_Program1"></param>
        /// <param name="mo">当前模组对象</param>
        void ModInitialize(Program.Apis.IProgram1 api_Program1, ModObject mo);
    }
}
