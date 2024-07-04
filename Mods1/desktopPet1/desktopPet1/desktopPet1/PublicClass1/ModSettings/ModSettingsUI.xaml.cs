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

namespace desktopPet1.PublicClass1.ModSettings
{
    public partial class ModSettingsUI : UserControl
    {
        public ModSettingsUI()
        {
            InitializeComponent();

            //不要直接绑定Class1里的静态数据
            data = Class1.modSettings?.GetNewData() ?? new modSettingsData();

            DataContext = data;
        }

        private modSettingsData data = null;
        public event Action Custom_Refresh = null;
        public event Action Custom_OpenFolder = null;
        public event Action Custom_Enabled = null;

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

        private void Custom_Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            Custom_Refresh?.Invoke();
        }

        private void Custom_OpenFolder_Button_Click(object sender, RoutedEventArgs e)
        {
            Custom_OpenFolder?.Invoke();
        }

        private void Custom_CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (data?.ManagerWindow_isEnabledCustomUI != true) return;

            Custom_Enabled?.Invoke();
        }
    }
}
