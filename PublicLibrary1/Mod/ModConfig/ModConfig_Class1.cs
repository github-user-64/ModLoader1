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
        /// 从指定路径读取(完整的文件路径)//返回的对象的属性path不会赋值, 请手动赋值
        /// </summary>
        /// <param name="path">完整的文件路径</param>
        /// <returns>null:读取失败</returns>
        public static ModConfig Read(string path)
        {
            try
            {
                ModConfig mc = new MyJson1(path).Get2<ModConfig>();
                return mc;
            }
            catch (Exception ex)
            {
                MethodBase mb = MethodBase.GetCurrentMethod();
                throw new Exception($"{mb?.DeclaringType.Name}.{mb?.Name}:{ex.Message}");
            }
        }

        /// <summary>
        /// 保存到指定路径(完整的文件路径)
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="path">完整的文件路径</param>
        public static void Save(ModConfig mc, string path)
        {
            try
            {
                new MyJson1(path).Save(mc);
            }
            catch (Exception ex)
            {
                MethodBase mb = MethodBase.GetCurrentMethod();
                throw new Exception($"{mb?.DeclaringType.Name}.{mb?.Name}:{ex.Message}");
            }
        }
    }
}
