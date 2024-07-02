using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModLoaderLibrary1.Mod
{
    public class LoadAssembly
    {
        private static List<data1> datas = new List<data1>();//已添加的dll路径, 真是不靠谱的方式

        /// <summary>
        /// 添加程序集并返回该程序集
        /// </summary>
        /// <param name="dllPath"></param>
        /// <returns></returns>
        public static Assembly AddAssembly(string dllPath)
        {
            IEnumerable<data1> ds = datas.Where(d => d.dp == dllPath);
            if (ds.Any()) return ds.First().a;

            if (!File.Exists(dllPath)) throw new Exception($"文件[{dllPath}]不存在");

            Assembly assembly = Assembly.Load(File.ReadAllBytes(dllPath));

            datas.Add(new data1(dllPath, assembly));

            AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
            {
                try
                {
                    if (new AssemblyName(e.Name).Name == assembly.GetName()?.Name) return assembly;
                    return null;
                }
                catch
                {
                    return null;
                }
            };

            return assembly;
        }

        private class data1
        {
            public data1(string dp, Assembly a)
            {
                this.dp = dp;
                this.a = a;
            }

            public string dp = null;
            public Assembly a = null;
        }
    }
}
