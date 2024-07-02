using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
    public partial class MyButton1 : Button
    {
        public MyButton1()
        {
            try
            {
                Style = new ResourceDictionary()
                {
                    Source = new Uri($"pack://application:,,,/{nameof(desktopPet1)};component/Resources/Dictionarys/Button/MyButton1.xaml", UriKind.Absolute)
                }["MyButton1"] as Style;
            }
            catch
            {

            }

            Click += Button_Click;
        }


        public string ClickAction { get; set; } = null;
        private List<string> datas { get; set; } = new List<string>();
        public string Datas
        {
            set
            {
                datas.Clear();

                StringBuilder val = new StringBuilder();

                foreach (char i in value)
                {
                    if (i == '|')
                    {
                        datas.Add(val.ToString());
                        val = new StringBuilder();
                        continue;
                    }

                    _ = val.Append(i);
                }

                datas.Add(val.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (ClickAction.ToLower())
            {
                case "popup":
                    Class1.apiP?.api_Program1_TS(
                        datas?.Count > 0 ? datas[0] : "",
                        datas?.Count > 1 ? datas[1] : "",
                        PublicLibrary1.TS.GetBtn("确定", null));
                    return;

                case "open":
                    try
                    {
                        if (datas?.Count < 1) return;
                        if (datas[0] == null) return;
                        _ = Process.Start(datas[0]);
                    }
                    catch { return; }
                    return;

                default: return;
            }
        }
    }
}
