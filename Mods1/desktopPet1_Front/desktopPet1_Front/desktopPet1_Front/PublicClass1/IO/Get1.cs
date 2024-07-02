using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace desktopPet1_Front.PublicClass1.IO
{
    public class Get1
    {
        /// <summary>
        /// 获取图片文件的BitmapImage(文件的完整路径)
        /// </summary>
        /// <param name="path">文件的完整路径</param>
        /// <returns></returns>
        public static BitmapImage GetBitmapImage(string path)
        {
            return Stream.Conversion.BytesToBitmapImage(GetBit1.ReadBit(path));
        }
    }
}
