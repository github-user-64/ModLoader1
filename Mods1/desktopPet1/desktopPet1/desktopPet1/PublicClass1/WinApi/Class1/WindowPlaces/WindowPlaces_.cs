using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace desktopPet1.PublicClass1.WinApi.Class1
{
    //https://www.cnblogs.com/choumengqizhigou/p/15702980.html
    //https://blog.csdn.net/qq_40036189/article/details/108210747

    /// <summary>
    /// 设置窗体的位置是[置顶,置底,正常]的其中之一, 废弃
    /// </summary>
    public class WindowPlaces_
    {
        static WindowPlaces_()
        {
            isOk = false;

            programHandle = Apis.api1.FindWindow("Progman", null);

            if (programHandle == IntPtr.Zero) return;

            isOk = true;
            //SendMsgToProgman();
        }


        private static bool isOk = false;
        private static IntPtr programHandle = IntPtr.Zero;


        private static void SendMsgToProgman()
        {
            //Spy++(看窗口用的)
            //SHELLDLL_DefView, 桌面图标
            //SysListView32, 桌面图标排序

            try
            {
                //TM不知道为啥能执行, 返回值也不是0, 但就是不能分层, 但是点电脑的任务视图按钮又能分层.
                //就不搞啥在桌面图标下了, 还是弄个简单的窗体置底就好了.
                //搞了还得考虑win7的适配, 而且在桌面图标下的话窗体就点不了了.
                //向Program Manager窗口发送消息0x52c(让桌面从Program脱离到WorkerW),超时设置为2秒
                if (Apis.api1.SendMessageTimeout(programHandle, 0x52c, IntPtr.Zero, IntPtr.Zero, 0, 2, IntPtr.Zero) == IntPtr.Zero) return;

                //遍历第一层的窗口
                _ = Apis.api1.EnumWindows((hwnd, lParam) =>
                {
                    //找到包含SHELLDLL_DefView的窗口
                    if (Apis.api1.FindWindowEx(hwnd, IntPtr.Zero, "SHELLDLL_DefView", null) == IntPtr.Zero) return true;

                    //找到当前第一个WorkerW窗口的后一个WorkerW窗口
                    IntPtr tempHwnd = Apis.api1.FindWindowEx(IntPtr.Zero, hwnd, "WorkerW", null);
                    if (tempHwnd == IntPtr.Zero) return true;

                    //隐藏第二个WorkerW窗口
                    _ = Apis.api1.ShowWindow(tempHwnd, 0);

                    isOk = true;
                    return true;
                }, IntPtr.Zero);
            }
            catch
            {
                isOk = false;
            }
        }

        public static bool Bottom(Window window)
        {
            if (!isOk) return false;
            if (programHandle == IntPtr.Zero) return false;

            IntPtr wh = Class1.GetWindowIntptr(window);
            if (wh == IntPtr.Zero) return false;

            WindowState ws = window.WindowState;

            if (Dependency1.GetWindowPlaces1(window) == Places.Top) _ = Normal(window);

            bool a = Class1.InvokeApi(() =>
            {
                return Apis.api1.SetParent(wh, programHandle) != IntPtr.Zero;//设置窗口到桌面窗口
            }, false);

            //WindowState属性为Normal的窗口在设置到桌面窗口后窗口会消失, 这时把WindowState属性设置为Maximized后窗口就会显示
            window.WindowState = WindowState.Maximized;
            window.WindowState = ws;

            Dependency1.SetWindowPlaces1(window, Places.Bottom);

            return a;
        }

        public static bool Top(Window window)
        {
            IntPtr wh = Class1.GetWindowIntptr(window);
            if (wh == IntPtr.Zero) return false;

            if (Dependency1.GetWindowPlaces1(window) == Places.Bottom) _ = Normal(window);

            bool a = Class1.InvokeApi(() =>
            {
                return Apis.api1.SetWindowPos(wh, Apis.api1.SetWindowPos_hWndInsertAfter_HWND_TOPMOST, 0, 0, 0, 0, Apis.api1.SetWindowPos_uFlags_SWP_NOMOVE | Apis.api1.SetWindowPos_uFlags_SWP_NOSIZE);
            }, false);

            Dependency1.SetWindowPlaces1(window, Places.Top);

            return a;
        }

        public static bool Normal(Window window)
        {
            IntPtr wh = Class1.GetWindowIntptr(window);
            if (wh == IntPtr.Zero) return false;

            WindowState ws = window.WindowState;

            bool a = Class1.InvokeApi(() =>
            {
                bool returnBool = true;

                if (Dependency1.GetWindowPlaces1(window) == Places.Top)
                {
                    returnBool &= Apis.api1.SetWindowPos(wh, Apis.api1.SetWindowPos_hWndInsertAfter_HWND_NOTOPMOST, 0, 0, 0, 0, Apis.api1.SetWindowPos_uFlags_SWP_NOMOVE | Apis.api1.SetWindowPos_uFlags_SWP_NOSIZE);
                }

                if (Dependency1.GetWindowPlaces1(window) == Places.Bottom)
                {
                    returnBool &= Apis.api1.SetParent(wh, IntPtr.Zero) != IntPtr.Zero;//设置窗口的父级从桌面窗口到正常窗口
                }

                return returnBool;
            }, false);

            window.WindowState = ws;//WindowState属性为Maximized的窗口从桌面窗口设置到正常窗口后, WindowState属性会变成Normal

            if (a) Dependency1.SetWindowPlaces1(window, Places.Normal);

            return a;
        }
    }
}
