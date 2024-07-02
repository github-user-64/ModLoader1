using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModLoaderLibrary1.ModManager.PublicClass1.Resource
{
    public class Get
    {
        private static ResourceDictionary r = null;

        public static void SetSource(ResourceDictionary r)
        {
            Get.r = r;
        }

        public static string GetString(string key)
        {
            return r[key] as string;
        }
    }
}
