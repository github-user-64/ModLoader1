using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace desktopPet1_minecraft_Inventory.PublicClass.InventoryItem
{
    public class InventoryItemObject : InventoryItem
    {
        public InventoryItemObject()
        {

        }
        /// <summary>
        /// 路径必须存在或者为null
        /// </summary>
        /// <param name="path"></param>
        public InventoryItemObject(string path)
        {
            IDataAndObject_DataToObject(new Datas.Data_InventoryItem() { path = path });
        }


        public string path { get; private set; } = null;
        public bool pathIsFile { get; private set; } = false;
        public bool pathIsFolder { get; private set; } = false;
        private BitmapImage img = null;


        public override FrameworkElement InventoryItem_GetUI()
        {
            return new Image() { Source = img };
        }

        public override void InventoryItem_Apply()
        {
            if (path == null) return;

            try
            {
                System.Diagnostics.ProcessStartInfo p = new System.Diagnostics.ProcessStartInfo();
                p.FileName = path;
                if (pathIsFile) p.WorkingDirectory = System.IO.Path.GetDirectoryName(path);//设置文件的工作目录

                _ = System.Diagnostics.Process.Start(p);
            }
            catch
            {

            }
        }

        public override Datas.Data_InventoryItem IDataAndObject_GetData()
        {
            return new Datas.Data_InventoryItem() { path = path };
        }

        public override void IDataAndObject_DataToObject(Datas.Data_InventoryItem data)
        {
            path = data.path;

            if (path != null)
            {
                pathIsFile = System.IO.File.Exists(path);
                pathIsFolder = System.IO.Directory.Exists(path);

                //if (!pathIsFile && !pathIsFolder) throw new Exception($"路径不存在:{path}");
            }

            if (pathIsFile) img = IO.GetIco.Get(path);
            if (pathIsFolder) img = new BitmapImage(new Uri($"pack://application:,,,/{nameof(desktopPet1_minecraft_Inventory)};component/Resources/Images/Inventory/item_ico_folder.png", UriKind.Absolute));
            if (img == null) img = new BitmapImage(new Uri($"pack://application:,,,/{nameof(desktopPet1_minecraft_Inventory)};component/Resources/Images/ValueIsNull/a1.png", UriKind.Absolute));
        }
    }
}
