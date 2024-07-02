using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Backpacks
{
    public partial class Backpacks1
    {
        private Backpack.Backpack1 backpack = null;

        private double scaleTransform = 1;//缩放

        private IO.File.Apis.IDataSaveAndRead<string[]> dataSaveRead_titles = null;
        private string[] data_titles = null;
        private int select_index = -1;

        public bool isOpen { get; private set; } = false;
    }
}
