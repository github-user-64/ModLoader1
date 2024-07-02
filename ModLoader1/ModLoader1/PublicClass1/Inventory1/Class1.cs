using PublicLibrary1.JsonDispose1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ModLoader1.PublicClass1.Inventory1
{
    /// <summary>
    /// 文件清单的相关操作
    /// </summary>
    public class Class1
    {
        //从资源转Dictionary<string, string>
        public static Dictionary<string, string> BytesToStringToDictionary(byte[] bs)
        {
            try
            {
                string s = Encoding.UTF8.GetString(bs);

                return new MyJson1().StringToObject<Dictionary<string, string>>(s);
            }
            catch (Exception ex)
            {
                MethodBase mb = MethodBase.GetCurrentMethod();
                throw new Exception($"{mb?.DeclaringType.Name}.{mb?.Name}:{ex.Message}");
            }
        }

        //从资源转string[]
        public static string[] BytesToStrings(byte[] bs)
        {
            Dictionary<string, string> d = BytesToStringToDictionary(bs);

            if (d.Count < 0) return new string[0];

            string[] ss = new string[d.Count];

            for (int i = 0; i < d.Count; ++i)
            {
                ss[i] = d.ElementAt(i).Value;
            }

            return ss;
        }
    }

    public class data1
    {
        private Dictionary<string, string> Paths1 { get; set; } = null;
        private string[] Paths1_string = null;


        public data1(byte[] bs)
        {
            Paths1 = Class1.BytesToStringToDictionary(bs);
            Paths1_string = Class1.BytesToStrings(bs);
        }


        public string GetVal(string key)
        {
            return Paths1[key];
        }

        public string[] GetStrings()
        {
            return Paths1_string;
        }
    }
}
