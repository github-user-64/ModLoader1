using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoaderLibrary1.ModManager.PublicClass1.Mod
{
    public class ModInfor
    {
        /// <summary>
        /// mod标题
        /// </summary>
        public string Title = null;
        /// <summary>
        /// mod信息
        /// </summary>
        public string Information = null;
    }

    /// <summary>
    /// mod配置和mod信息
    /// </summary>
    public class Data_ModConfigAModInfor
    {
        public Data_ModConfigAModInfor(PublicLibrary1.Mod.ModConfig mc, ModInfor mi)
        {
            this.mc = mc;
            this.mi = mi;
        }


        public PublicLibrary1.Mod.ModConfig mc = null;
        public ModInfor mi = null;
    }
}
