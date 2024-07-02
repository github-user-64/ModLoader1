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

namespace desktopPet1.PublicClass1.UserControls
{
    public partial class Button1 : Button
    {
        public Button1(Datas.ExpansionObject eo)
        {
            InitializeComponent();

            Initialize(eo);
        }
        public Button1()
        {
            InitializeComponent();
        }


        public Datas.ExpansionObject eo = null;

        public string ep_Title { get; set; } = null;


        private void Initialize(Datas.ExpansionObject eo)
        {
            this.eo = eo;
            ep_Title = eo?.expansionPet?.Title;

            Initialize_Ico(this.eo);
        }

        private void Initialize_Ico(Datas.ExpansionObject eo)
        {
            if (eo?.mo?.modConfig?.fullPath == null) return;

            Background = null;//必须先设为null, 这样绑定的[TargetNullValue]才会生效

            try
            {
                string path = $"{eo.mo.modConfig.fullPath}\\{PublicLibrary1.Inventory.FolderRelative.Mod.resources}\\modIco.png";

                if (!System.IO.File.Exists(path)) return;

                Background = new ImageBrush() { ImageSource = desktopPet1_Front.PublicClass1.IO.Get1.GetBitmapImage(path) };
            }
            catch
            {

            }
        }
    }
}
