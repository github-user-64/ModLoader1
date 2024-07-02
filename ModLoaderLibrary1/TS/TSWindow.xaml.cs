using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModLoaderLibrary1
{
    public partial class TSWindow : Window, PublicLibrary1.TS.ITS1
    {
        public TSWindow()
        {
            InitializeComponent();


            try
            {
                string path = $"{GetUrlAbsoluteAssemblyRootPath()}TS/TS1.xaml";

                Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(path, UriKind.Absolute) });

                TSStyle = Resources["TS1"] as Style;

                if (TSStyle == null) throw new Exception("获取的资源为null");
            }
            catch (Exception ex)
            {
                System.Media.SystemSounds.Beep.Play();
                _ = MessageBox.Show($"消息弹窗的样式资源获取失败, 消息弹窗的内容将会不完整.\n详细信息:{ex.Message}", "资源获取失败", MessageBoxButton.OK);
            }

            Show();
        }
    }
}
