using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PublicLibrary1
{
    /// <summary>
    /// 消息弹窗
    /// </summary>
    public partial class TS
    {
        public interface ITS1
        {
            /// <summary>
            /// 消息弹窗
            /// </summary>
            /// <param name="title"></param>
            /// <param name="message"></param>
            /// <param name="buttons"></param>
            void TS(string title, string message, params Button[] buttons);
        }
    }
}
