using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace desktopPet1_minecraft_Inventory.PublicClass.UserControls.Backpacks
{
    public partial class Backpacks1 : UserControl
    {
        public Backpacks1(PublicClass.Inventory.InventoryObject<PublicClass.InventoryItem.InventoryItemObject> inventory,
            IO.File.Apis.IDataSaveAndRead<string[]> dataSaveRead_titles)
        {
            InitializeComponent();

            Initialize(inventory, dataSaveRead_titles);
        }
    }
}
