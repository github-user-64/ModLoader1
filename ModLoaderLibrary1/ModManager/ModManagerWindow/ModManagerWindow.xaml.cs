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
using System.Windows.Shapes;

namespace ModLoaderLibrary1.ModManager
{
    /// <summary>
    /// ModManagerWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ModManagerWindow : Window
    {
        public ModManagerWindow(PublicLibrary1.Program.Apis.IProgram1 program1)
        {
            this.program1 = program1;
            if (program1 == null) throw new Exception($"{nameof(ModManagerWindow)}:传入参数[{nameof(program1)}]为null");

            InitializeComponent();

            PublicClass1.Resource.Get.SetSource(Resources);

            JumpPage_ModList();
        }


        private PublicLibrary1.Program.Apis.IProgram1 program1 = null;
    }
}
