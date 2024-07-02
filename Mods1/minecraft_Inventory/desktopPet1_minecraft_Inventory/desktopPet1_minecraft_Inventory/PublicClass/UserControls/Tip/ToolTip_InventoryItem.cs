using desktopPet1_minecraft_Inventory.PublicClass.InventoryItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Tip
{
    /// <summary>
    /// mc样式的物品提示
    /// </summary>
    public class ToolTip_InventoryItem : ToolTip1
    {
        public void SetData(InventoryItemObject iio)
        {
            try
            {
                string path = iio?.IDataAndObject_GetData()?.path;

                if (path == null)
                {
                    toolTip_Content.SetText(path);
                    return;
                }

                //如果path是"C:\\"这样的根目录, 那在获取目录的名称时会变成空字符串
                //所以如果是根目录就不变, 如果不是那就获取目录的名称
                if (System.IO.Path.GetFullPath(path) != System.IO.Path.GetPathRoot(path)) path = System.IO.Path.GetFileName(path);

                SetText(path);
            }
            catch
            {
                SetText(null);
            }
        }
    }
}
