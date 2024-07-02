using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoaderLibrary1.IO
{
    public class Directory
    {
        /// <summary>
        /// 复制源路径的目录到目标路径(被复制的目录, 复制到此目录(结尾为被复制目录名, 如果和源目录名不同那复制后的目录将改为新的目录名))
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        public static void Copy(string sourcePath, string targetPath)
        {
            if (sourcePath == null || targetPath == null) throw new Exception("参数为null");

            sourcePath = sourcePath.Trim();
            targetPath = targetPath.Trim();

            if (sourcePath.Equals(targetPath)) return;

            if (sourcePath.Length < 1) throw new Exception($"路径长度过短:{sourcePath}");
            if (targetPath.Length < 1) throw new Exception($"路径长度过短:{targetPath}");

            sourcePath += sourcePath.Substring(sourcePath.Length - 1, 1) == @"\" ? "" : @"\";
            targetPath += targetPath.Substring(targetPath.Length - 1, 1) == @"\" ? "" : @"\";

            if (!System.IO.Directory.Exists(sourcePath)) throw new Exception($"源目录不存在:{sourcePath}");
            if (System.IO.Directory.Exists(targetPath)) throw new Exception($"目录已存在:{targetPath}");

            try
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(sourcePath);

                _ = System.IO.Directory.CreateDirectory($"{targetPath}");

                foreach (System.IO.FileInfo fi_ in di.GetFiles())
                {
                    string newpath = $"{targetPath}{fi_.Name}";

                    _ = fi_.CopyTo(newpath, false);
                }

                foreach (System.IO.DirectoryInfo di_ in di.GetDirectories())
                {
                    Copy(di_.FullName, $"{targetPath}{di_.Name}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteToRecyclebin_Folder(string path)
        {
            if (path == null) throw new Exception("参数为null");

            path = path.Trim();

            if (path.Length < 1) throw new Exception($"路径长度过短:{path}");

            if (!System.IO.Directory.Exists(path)) throw new Exception($"目录不存在:{path}");

            try
            {
                int v = WindowApi1.Directory1.DeleteToRecyclebin(path);

                if (v == 0) return;

                throw new Exception($"移动文件或文件夹到回收站失败. 返回值为:{v}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
