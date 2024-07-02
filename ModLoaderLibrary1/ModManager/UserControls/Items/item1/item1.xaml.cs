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

namespace ModLoaderLibrary1.ModManager.UserControls.items
{
    /// <summary>
    /// item1.xaml 的交互逻辑
    /// </summary>
    public partial class item1 : ListBoxItem
    {
        public item1()
        {
            InitializeComponent();

            Button_openModFolder_Click += Button_openModFolder_Click_Handle;
        }

        public item1(PublicClass1.Mod.Data_ModConfigAModInfor d_mm, Apis.ModManagerTS ts) : this()
        {
            Initialize(d_mm, ts);
        }
    }
}
