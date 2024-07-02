using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace desktopPet1_Front.PublicClass1
{
    /// <summary>
    /// 右键菜单, 使用ModLoader自带样式
    /// </summary>
    public class PerRightMenu
    {
        public PerRightMenu()
        {
            Initialize();
        }


        public ContextMenu Menu { get; protected set; } = null;
        private ResourceDictionary rd = null;


        private void Initialize()
        {
            rd = new ResourceDictionary()
            {
                Source = new Uri($"pack://application:,,,/{nameof(desktopPet1_Front)};component/Resources/Dictionarys/ContextMenus/ContextMenu1.xaml", UriKind.Absolute)
            };

            Menu = new ContextMenu();
            Menu.Style = rd["ContextMenu1"] as Style;
        }

        public void Open()
        {
            Menu.IsOpen = true;
        }

        public void AddMenuItem(object o)
        {
            _ = Menu.Items.Add(o);
        }

        /// <summary>
        /// 获取有样式的菜单项
        /// </summary>
        /// <returns></returns>
        public MenuItem GetMenuItem()
        {
            return new MenuItem()
            {
                Style = rd["MenuItem1"] as Style
            };
        }
    }
}
