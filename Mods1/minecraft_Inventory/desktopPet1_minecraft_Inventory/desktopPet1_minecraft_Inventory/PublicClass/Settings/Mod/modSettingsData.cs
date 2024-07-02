using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_minecraft_Inventory.PublicClass.Settings.Mod
{
    public class modSettingsData
    {
        public double backpack_ui_scaleTransform { get; set; } = 1;
        public double inventory_ui_scaleTransform { get; set; } = 1;
        public double horizontalOffset { get; set; } = 0;
        public double verticalOffset { get; set; } = -64;
        public int Inventory_Column { get; set; } = 9;
        public int Inventory_Row { get; set; } = 4;
    }
}
