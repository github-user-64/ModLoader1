using PublicLibrary1.Mod.Apis;
using PublicLibrary1.Program.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Markup;

namespace desktopPet1
{
    public partial class Class1 : IMod1
    {
        public void CustomUI_Clear()
        {
            petWindow.Custom_Top_Grid.Children.Clear();
            petWindow.Custom_Bottom_Grid.Children.Clear();
        }

        public void CustomUI_Refresh()
        {
            CustomUI_Clear();

            if (!Directory.Exists(thisMO?.modConfig?.fullPath)) return;

            try
            {
                List<System.Windows.Controls.Grid> gs_top = CustomUI_Refresh_a1((i) => $"{thisMO.modConfig.fullPath}\\Custom_Top{i + 1}.xaml");
                List<System.Windows.Controls.Grid> gs_bottom = CustomUI_Refresh_a1((i) => $"{thisMO.modConfig.fullPath}\\Custom_Bottom{i + 1}.xaml");

                for (int i = 0; i < gs_top?.Count; ++i)
                {
                    _ = petWindow.Custom_Top_Grid.Children.Add(gs_top[i]);
                }
                for (int i = 0; i < gs_bottom?.Count; ++i)
                {
                    _ = petWindow.Custom_Bottom_Grid.Children.Add(gs_bottom[i]);
                }
            }
            catch (Exception ex)
            {
                apiProcedure1?.api_Program1_TS($"刷新自定义界面失败", $"desktopPet1: {ex.Message})", PublicLibrary1.TS.GetBtn("确定", null));
            }
        }

        public List<System.Windows.Controls.Grid> CustomUI_Refresh_a1(Func<int, string> f)
        {
            if (f == null) return null;
            string path = null;
            List<System.Windows.Controls.Grid> gs = new List<System.Windows.Controls.Grid>();

            try
            {
                for (int i = 0; i < 16; ++i)
                {
                    path = f.Invoke(i);

                    if (!File.Exists(path)) return gs;
                    
                    string custom = File.ReadAllText(path, Encoding.UTF8);

                    gs.Add(XamlToGrid(custom));
                }

                return gs;
            }
            catch (Exception ex)
            {
                throw new Exception($"加载自定义文件[{path}]时出错: {ex.Message}");
            }
        }


        private System.Windows.Controls.Grid XamlToGrid(string content1)
        {
            StringReader stringReader = new StringReader($"<Grid>{content1}</Grid>");
            XmlReaderSettings settings = new XmlReaderSettings { NameTable = new NameTable() };
            XmlNamespaceManager xmlns = new XmlNamespaceManager(settings.NameTable);

            xmlns.AddNamespace("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            xmlns.AddNamespace("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            //xmlns.AddNamespace("d", "http://schemas.microsoft.com/expression/blend/2008");
            //xmlns.AddNamespace("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");

            xmlns.AddNamespace("my", GetClassNamespace(typeof(PublicClass1.UserControls.MyButton1)));

            XmlParserContext context = new XmlParserContext(null, xmlns, "", XmlSpace.Default);
            XmlReader xmlReader = XmlReader.Create(stringReader, settings, context);

            return XamlReader.Load(xmlReader) as System.Windows.Controls.Grid;
        }

        private string GetClassNamespace(Type type)
        {
            //不在同一程序集加assembly来表示在哪个程序集里
            return $"clr-namespace:{type.Namespace};assembly={nameof(desktopPet1)}";
        }
    }
}
