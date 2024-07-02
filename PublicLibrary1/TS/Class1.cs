using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PublicLibrary1
{
    public partial class TS
    {
        /// <summary>
        /// 获取一个新的按钮对象, 传入的方法将在按钮点击事件触发时调用, 传入的按钮类型将会赋值给按钮的Tag属性
        /// </summary>
        /// <param name="content"></param>
        /// <param name="action"></param>
        /// <param name="tSButton"></param>
        /// <returns></returns>
        public static Button GetBtn(string content, Action action, TSButton tSButton = TSButton.Normal)
        {
            Button button = new Button() { Content = content, Tag = tSButton };
            button.Click += (s, e) => { action?.Invoke(); };

            return button;
        }
    }
}
