using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace desktopPet1_minecraft_Inventory.PublicClass.IO
{
    public class GetIco
    {
        public static BitmapImage Get(string path)
        {
            if (!System.IO.File.Exists(path)) return null;

            try
            {
                Bitmap b = Icon.ExtractAssociatedIcon(path).ToBitmap();
                byte[] bs = null;

                using (MemoryStream stream = new MemoryStream())
                {
                    b.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    bs = new byte[stream.Length];
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.Read(bs, 0, Convert.ToInt32(stream.Length));
                }

                using (Stream stream = new MemoryStream(bs))
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
            catch
            {
                return null;
            }
        }
    }
}
