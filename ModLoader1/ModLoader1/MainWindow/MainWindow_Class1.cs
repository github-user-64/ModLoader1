using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ModLoader1
{
    public partial class MainWindow
    {
        /// <summary>
        /// 关闭程序
        /// </summary>
        public void ExitProgram()
        {
            api_Program1_ExitProgramIng?.Invoke();

            Close();//在窗体的Closing事件里会继续处理
        }

        /// <summary>
        /// 消息弹窗
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        private void TS(string title, string message, params Button[] buttons)
        {
            try
            {
                if (api_Program1_TS_Action == null) throw new Exception("弹窗接口为null");

                api_Program1_TS_Action.TS(title, message, buttons);
            }
            catch (Exception ex)
            {
                System.Media.SystemSounds.Beep.Play();
                _ = System.Windows.MessageBox.Show($"原弹窗消息[{message}]\n异常消息:{ex.Message}", "弹窗异常", System.Windows.MessageBoxButton.OK);

                ExitProgram();
            }
        }

        /// <summary>
        /// 用于窗体关闭前释放
        /// </summary>
        private void Dispose()
        {
            taskbarIcon?.Dispose();
        }
    }
}
