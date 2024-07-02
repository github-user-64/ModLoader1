using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Hardcodet.Wpf.TaskbarNotification;

namespace ModLoaderLibrary1
{
    public partial class TaskbarIconSet
    {
        public TaskbarIconSet(System.Drawing.Icon ico, Style Style_ContextMenu)
        {
            this.ico = ico;
            this.Style_ContextMenu = Style_ContextMenu;
        }


        private TaskbarIcon taskbarIcon = null;
        private ContextMenu contextMenu = null;
        private System.Drawing.Icon ico = null;
        private Style Style_ContextMenu = null;

        public RoutedEventHandler TrayLeftMouseDown = null;


        public void Set(object[] menuItems)
        {
            Dispose();

            contextMenu = new ContextMenu() { Style = Style_ContextMenu };
            for (int i = 0; i < menuItems?.Length; ++i)
            {
                if (menuItems[i] == null) continue;
                _ = contextMenu.Items.Add(menuItems[i]);
            }

            taskbarIcon = new TaskbarIcon();
            taskbarIcon.Icon = ico;
            taskbarIcon.ToolTipText = "Ciallo~!";
            taskbarIcon.ContextMenu = contextMenu;
            taskbarIcon.TrayLeftMouseDown += TrayLeftMouseDown;
        }

        public void Add(params object[] menuItems)
        {
            if (contextMenu == null)
            {
                Set(menuItems);
                return;
            }

            for (int i = 0; i < menuItems?.Length; ++i)
            {
                if (menuItems[i] == null) continue;
                _ = contextMenu.Items.Add(menuItems[i]);
            }
        }

        public void Remove(UIElement menuItem)
        {
            if (contextMenu == null) return;

            contextMenu.Items.Remove(menuItem);
        }

        public void Dispose()
        {
            taskbarIcon?.Dispose();
            contextMenu?.Items?.Clear();
            contextMenu = null;
        }
    }
}
