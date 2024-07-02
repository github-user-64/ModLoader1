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

namespace desktopPet1_expansion_ldnn.PublicClass1.ModSettings
{
    public partial class ModSettingsUI : UserControl
    {
        public ModSettingsUI()
        {
            InitializeComponent();

            //不要直接绑定Class1里的静态数据
            data = Class1.modSettings?.GetNewData() ?? new modSettingsData();

            if (data.scaleTransform < i1_slider1.Minimum) data.scaleTransform = i1_slider1.Minimum;
            if (data.scaleTransform > i1_slider1.Maximum) data.scaleTransform = i1_slider1.Maximum;

            if (data.messageDelay < i2_slider1.Minimum) data.messageDelay = (int)i2_slider1.Minimum;
            if (data.messageDelay > i2_slider1.Maximum) data.messageDelay = (int)i2_slider1.Maximum;

            DataContext = data;
        }

        private modSettingsData data = null;

        public void SettingsSave()
        {
            try
            {
                new PublicLibrary1.JsonDispose1.MyJson1(Class1.modSettings?.path).Save(data);
            }
            catch
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = data = new modSettingsData();
        }
    }
}
