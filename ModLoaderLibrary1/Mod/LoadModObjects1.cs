using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PublicLibrary1.Mod;
using System.Windows.Controls;

namespace ModLoaderLibrary1.Mod
{
    //加载mod列表, 加载mod对象, 不加载mod.
    //不做修复.
    public class LoadModObjects1
    {
        private List<ModConfig> modConfigs = null;
        private List<ModObject> modObjects = null;

        /// <summary>
        /// 获取所有启用的模组对象
        /// </summary>
        /// <returns></returns>
        public List<ModObject> GetModObjs()
        {
            try
            {
                LoadModList();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(GetModObjs)}:{ex.Message}");
            }

            return modObjects;
        }

        private void LoadModList()
        {
            Load_ModConfigs();

            //判断mod的前置mod是否启用
            for (int i = 0; i < modConfigs.Count; ++i)
            {
                ModConfig mc = modConfigs[i];

                for (int i2 = 0; i2 < mc.frontModKeys?.Length; ++i2)
                {
                    string fKey = mc.frontModKeys[i2];

                    if (modConfigs.Any(v => v.key == fKey)) continue;

                    throw new Exception($"mod[{mc.key}]的前置mod[{fKey}]未加载");
                }
            }

            Load_ModObjects();
        }

        //获取mods文件夹下所有mod的配置数据
        private void Load_ModConfigs()
        {
            modConfigs = PublicLibrary1.Program.Mod.ModConfigAction.GetModsConfig();

            _ = modConfigs.RemoveAll(v => v == null);
            _ = modConfigs.RemoveAll(v => !v.isEnable);
        }

        #region Load_ModObjects
        private void Load_ModObjects()
        {
            modObjects = new List<ModObject>();

            for (int i = 0; i < modConfigs.Count; ++i)
            {
                modObjects.Add(new ModObject() { modConfig = modConfigs[i] });
            }

            Load_ModObjects_Assembly();
            Load_ModObjects_Object();
        }

        private void Load_ModObjects_Assembly()
        {
            for (int i = 0; i < modObjects.Count; ++i)
            {
                try
                {
                    ModObject mo = modObjects[i];

                    if (mo.modConfig.mainDll == null) continue;
                    mo.modConfig.mainDll = mo.modConfig.mainDll.Trim();
                    if (mo.modConfig.mainDll == "") continue;

                    List<string> dlls = mo.modConfig.dlls?.ToList() ?? new List<string>();
                    dlls.Add(mo.modConfig.mainDll);

                    for (int i2 = 0; i2 < dlls.Count; ++i2)
                    {
                        string path = $"{mo.modConfig.fullPath}\\{dlls[i2]}";

                        if (!File.Exists(path)) throw new Exception($"文件[{path}]不存在");
                        
                        Assembly assembly = LoadAssembly.AddAssembly(path);

                        if (dlls[i2] == mo.modConfig.mainDll) mo.assembly = assembly;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"加载[{modObjects?[i]?.modConfig?.key}]的程序集时出现异常:{ex.Message}");
                }
            }
        }

        private void Load_ModObjects_Object()
        {
            for (int i = 0; i < modConfigs.Count; ++i)
            {
                try
                {
                    ModObject mo = modObjects[i];

                    if (mo.assembly == null) continue;

                    if (mo.modConfig.mainClass == null) continue;
                    mo.modConfig.mainClass = mo.modConfig.mainClass.Trim();
                    if (mo.modConfig.mainClass == "") continue;

                    mo.type = mo.assembly.GetType(mo.modConfig.mainClass);//获取class类型
                    if (mo.type == null) throw new Exception($"获取[{mo.modConfig.mainClass}]的类型失败");
                    mo.mod = Activator.CreateInstance(mo.type);//创建对象

                    //mo.isInheritApi = typeof(PublicLibrary1.Mod.Apis.IMod1).IsAssignableFrom(mo.mod?.GetType());
                    mo.isInheritApi = (mo.mod as PublicLibrary1.Mod.Apis.IMod1) != null;
                }
                catch (Exception ex)
                {
                    throw new Exception($"加载[{modObjects?[i]?.modConfig?.key}]时出现异常:{ex.Message}");
                }
            }
        }
        #endregion
    }
}
