using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace desktopPet1.PublicClass1.WinApi.Class1
{
    /// <summary>
    /// 设置窗体的位置是[置顶,置底,正常]的其中之一
    /// </summary>
    public class WindowPlaces
    {
        /// <summary>
        /// 当窗口重新获取焦点时会失去置底
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        public static bool Bottom(Window window)
        {
            IntPtr wh = Class1.GetWindowIntptr(window);
            if (wh == IntPtr.Zero) return false;

            bool a = Class1.InvokeApi(() =>
            {
                return Apis.api1.SetWindowPos(wh, Apis.api1.SetWindowPos_hWndInsertAfter_HWND_BOTTOM, 0, 0, 0, 0, Apis.api1.SetWindowPos_uFlags_SWP_NOMOVE | Apis.api1.SetWindowPos_uFlags_SWP_NOSIZE);
            }, false);

            Dependency1.SetWindowPlaces1(window, Places.Bottom);

            return a;
        }

        /// <summary>
        /// 会被其它置顶窗口遮住
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        public static bool Top(Window window)
        {
            IntPtr wh = Class1.GetWindowIntptr(window);
            if (wh == IntPtr.Zero) return false;

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

            bool a = Class1.InvokeApi(() =>
            {
                return Apis.api1.SetWindowPos(wh, Apis.api1.SetWindowPos_hWndInsertAfter_HWND_NOTOPMOST, 0, 0, 0, 0, Apis.api1.SetWindowPos_uFlags_SWP_NOMOVE | Apis.api1.SetWindowPos_uFlags_SWP_NOSIZE); ;
            }, false);

            if (a) Dependency1.SetWindowPlaces1(window, Places.Normal);

            return a;
        }
    }
}
