using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoaderLibrary1.ModManager.PublicClass1.IO
{
    public class GetBit1
    {
        public static byte[] ReadBit(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] bs = new byte[fs.Length];

                _ = fs.Read(bs, 0, bs.Length);

                fs.Close();

                return bs;
            }
        }
    }
}
