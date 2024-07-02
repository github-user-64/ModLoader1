using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoaderLibrary1.ModManager.PublicClass1.IO
{
    public partial class Directory1
    {
        /// <summary>
        /// 创建目标目录, 并将原目录下的全部文件和文件夹复制到目标目录下
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destPath"></param>
        public static void Copy(string sourcePath, string destPath)
        {
            if (!Directory.Exists(sourcePath)) throw new Exception("原目录不存在");
            if (sourcePath == destPath) throw new Exception("目标目录和原目录相同");
            if (Directory.Exists(destPath)) throw new Exception("目标目录已存在");

            //

            DirectoryInfo s_di = new DirectoryInfo(sourcePath);
            FileInfo[] s_fs = s_di.GetFiles();
            DirectoryInfo[] s_dis = s_di.GetDirectories();
            DirectoryInfo d_di = Directory.CreateDirectory(destPath);//创建目标目录

            for (int i = 0; i < s_fs.Length; ++i)
            {
                if (File.Exists($"{destPath}\\{s_fs[i].Name}")) continue;
                _ = s_fs[i].CopyTo($"{destPath}\\{s_fs[i].Name}");
            }

            for (int i = 0; i < s_dis.Length; ++i)
            {
                Copy(s_dis[i].FullName, $"{d_di.FullName}\\{s_dis[i].Name}");
            }
        }
    }
}
