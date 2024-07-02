using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PublicLibrary1.Mod;

namespace PublicLibrary1.Program.Mod
{
    public class ModConfigAction
    {
        /// <summary>
        /// 获取mods文件夹下所有模组的配置文件<para></para>
        /// 若获取成功则返回数据, 否则报错<para></para>
        /// 即使某个模组配置为null也会添加到返回的列表中
        /// </summary>
        /// <returns></returns>
        public static List<ModConfig> GetModsConfig()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo($@"{ProgramInformation.ProgramPath}\{Inventory.Folder.mods}");
                DirectoryInfo[] dis = di.GetDirectories();
                List<ModConfig> mcs = new List<ModConfig>();

                for (int i = 0; i < dis.Length; ++i)
                {
                    ModConfig mc = ModConfig.Read($@"{dis[i].FullName}\{Inventory.FileRelative.Mod.config}");

                    mcs.Add(mc);

                    if (mc == null) continue;

                    mc.fullPath = dis[i].FullName;
                }

                return mcs;
            }
            catch (Exception ex)
            {
                MethodBase mb = MethodBase.GetCurrentMethod();
                throw new Exception($"{mb?.DeclaringType.Name}.{mb?.Name}:获取mods下的mod配置文件失败:{ex.Message}");
            }
        }

        /// <summary>
        /// 保存模组配置. 根据模组的key保存在mods下有对应key的模组内
        /// </summary>
        /// <param name="mc"></param>
        public static void SaveModConfig_key(ModConfig mc)
        {
            try
            {
                if (mc == null) throw new Exception("参数为null");
                if (mc.key == null) throw new Exception($"参数字段[{nameof(ModConfig.key)}]为null");

                ModConfig mc_copy = CopyClassAttribute(mc);
                List<ModConfig> mcs = GetModsConfig();
                bool isSave = false;

                mc_copy.fullPath = null;

                for (int i = 0; i < mcs.Count; ++i)
                {
                    if (mcs[i]?.key != mc.key) continue;

                    _ = Directory.CreateDirectory($@"{mcs[i].fullPath}\{Inventory.FolderRelative.Mod.config}");

                    new JsonDispose1.MyJson1($@"{mcs[i].fullPath}\{Inventory.FileRelative.Mod.config}").Save(mc_copy);

                    isSave = true;
                }

                if (!isSave) throw new Exception($"找不到key为[{mc.key}]的mod文件夹");
            }
            catch (Exception ex)
            {
                MethodBase mb = MethodBase.GetCurrentMethod();
                throw new Exception($"{mb?.DeclaringType.Name}.{mb?.Name}:保存mod配置文件失败:{ex.Message}");
            }
        }

        /// <summary>
        /// 保存模组配置. 根据模组配置的模组路径属性保存
        /// </summary>
        /// <param name="mc"></param>
        public static void SaveModConfig_path(ModConfig mc)
        {
            try
            {
                if (mc?.fullPath == null) throw new Exception("获取目录失败");

                if (!Directory.Exists(mc.fullPath)) throw new Exception($"目录不存在:{mc.fullPath}");

                _ = Directory.CreateDirectory($@"{mc.fullPath}\{Inventory.FolderRelative.Mod.config}");

                ModConfig mc_copy = CopyClassAttribute(mc);
                mc_copy.fullPath = null;

                new JsonDispose1.MyJson1($@"{mc.fullPath}\{Inventory.FileRelative.Mod.config}").Save(mc_copy);
            }
            catch (Exception ex)
            {
                MethodBase mb = MethodBase.GetCurrentMethod();
                throw new Exception($"{mb?.DeclaringType.Name}.{mb?.Name}:保存mod配置文件失败:{ex.Message}");
            }
        }

        //

        private static T CopyClassAttribute<T>(T tIn)
        {
            if (tIn == null) return Activator.CreateInstance<T>();

            T tOut = Activator.CreateInstance<T>();
            Type tInType = tIn.GetType();

            foreach (PropertyInfo itemOut in tOut.GetType().GetProperties())
            {
                PropertyInfo itemIn = tInType.GetProperty(itemOut.Name);
                
                if (itemIn == null) continue;

                itemOut.SetValue(tOut, itemIn.GetValue(tIn));
            }

            return tOut;
        }
    }
}
