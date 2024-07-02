using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ModLoaderLibrary1
{
    public partial class TSWindow
    {
        #region 吐司
        /// <summary>
        /// 吐司, Button的Tag被占用
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        public void TS(string title, string message, params Button[] buttons)
        {
            if (TS_father == null)
            {
                System.Media.SystemSounds.Beep.Play();
                _ = MessageBox.Show(message, title, MessageBoxButton.OK);
                return;
            }

            ContentControl cc = new ContentControl();
            cc.Style = TSStyle;
            cc.DataContext = new TS_data1() { title = title, message = message, buttons = buttons };
            cc.AddHandler(System.Windows.Controls.Primitives.Thumb.DragDeltaEvent, new System.Windows.Controls.Primitives.DragDeltaEventHandler(Thumb_DragDelta));
            cc.HorizontalAlignment = HorizontalAlignment.Center;
            cc.VerticalAlignment = VerticalAlignment.Center;

            for (int i = 0; i < buttons?.Length; ++i)
            {
                if (buttons[i] == null) continue;

                buttons[i].Click += (s, e) => TSClose(cc);

                //按钮类型是警告的改成红色
                if (buttons[i].Tag != null &&
                    buttons[i].Tag.GetType() == typeof(PublicLibrary1.TS.TSButton) &&
                    (PublicLibrary1.TS.TSButton)buttons[i].Tag == PublicLibrary1.TS.TSButton.Warning)
                {
                    buttons[i].Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
                    buttons[i].Foreground = buttons[i].Background;
                }
            }

            cc.MaxWidth = TS_father.ActualWidth / 2;

            _ = Activate();
            _ = TS_father.Children.Add(cc);
        }

        private void TSClose(UIElement uie)
        {
            TS_father.Children.Remove(uie);
        }

        public class TS_data1
        {
            public string title { get; set; } = null;
            public string message { get; set; } = null;
            public Button[] buttons { get; set; } = null;
        }
        #endregion

        /// <summary>
        /// 获取Url类获取程序集内的资源时的绝对路径参数中的开头部分, 结尾为/
        /// </summary>
        /// <returns></returns>
        public static string GetUrlAbsoluteAssemblyRootPath()
        {
            return $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/";
        }
    }
}
