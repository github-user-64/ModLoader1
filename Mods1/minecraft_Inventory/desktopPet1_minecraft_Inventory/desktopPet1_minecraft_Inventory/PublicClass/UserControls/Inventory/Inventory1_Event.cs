using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Inventory
{
    public partial class Inventory1
    {
        #region
        /// <summary>
        /// 由外部调用以触发该事件
        /// </summary>
        public event Action<object, KeyEventArgs> Inventory_KeyUp = null;
        #endregion

        #region 用于外部调用以触发特定事件
        public void OnInventory_KeyUp(object o, KeyEventArgs e)
        {
            Inventory_KeyUp?.Invoke(o, e);
        }
        #endregion
    }
}
