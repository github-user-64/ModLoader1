using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoader1.PublicClass1.Inventory1
{
    /// <summary>
    /// 文件夹清单的相关操作, 路径从该程序的运行路径开始, 路径开头结尾不为\, 通过KeyVal记录清单
    /// </summary>
    public partial class Folder1
    {
        private static data1 data1 = null;


        static Folder1()
        {
            //加载清单数据
            data1 = new data1(Properties.Resources.FolderInventory1);
        }


        public static string GetVal(string key)
        {
            return data1.GetVal(key);
        }

        //获取string[]类型的文件夹清单
        public static string[] GetStrings()
        {
            return data1.GetStrings();
        }
    }


    /// <summary>
    /// 文件清单的相关操作, 通过KeyVal记录清单
    /// </summary>
    public partial class File1
    {
        private static data1 data1 = null;


        static File1()
        {
            //加载清单数据
            data1 = new data1(Properties.Resources.FileInventory1);
        }


        public static string GetVal(string key)
        {
            return data1.GetVal(key);
        }

        //获取string[]类型的文件夹清单
        public static string[] GetStrings()
        {
            return data1.GetStrings();
        }
    }


    /// <summary>
    /// mod文件清单的相关操作, 路径从该mod的根文件夹开始, 路径开头不为\, 通过KeyVal记录清单
    /// </summary>
    public partial class ModFile1
    {
        private static data1 data1 = null;


        static ModFile1()
        {
            //加载清单数据
            data1 = new data1(Properties.Resources.FileInventory_Mod1);
        }


        public static string GetVal(string key)
        {
            return data1.GetVal(key);
        }

        //获取string[]类型的文件夹清单
        public static string[] GetStrings()
        {
            return data1.GetStrings();
        }
    }
}
