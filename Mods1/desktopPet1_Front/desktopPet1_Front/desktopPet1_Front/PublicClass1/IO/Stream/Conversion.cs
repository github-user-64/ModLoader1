using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace desktopPet1_Front.PublicClass1.IO.Stream
{
    public class Conversion
    {
        public static BitmapImage BytesToBitmapImage(byte[] bs)
        {
            using (System.IO.Stream stream = new System.IO.MemoryStream(bs))
            {
                BitmapImage bi = new BitmapImage();
                stream.Position = 0;
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.StreamSource = stream;
                bi.EndInit();
                bi.Freeze();
                return bi;
            }
        }
    }
}
