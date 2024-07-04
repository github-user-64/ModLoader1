using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1.PublicClass1.WinApi.Apis
{
    public static class api1
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string className, string winName);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageTimeout(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam, uint fuFlage, uint timeout, IntPtr result);

        //查找窗口的委托 查找逻辑
        public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool EnumWindows(EnumWindowsProc proc, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string className, string winName);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hwnd, IntPtr parentHwnd);

        //

        public static IntPtr SetWindowPos_hWndInsertAfter_HWND_BOTTOM { get; } = new IntPtr(1);//将窗口的层级移到正常窗口, 层级在所有正常窗口的最下方
        public static IntPtr SetWindowPos_hWndInsertAfter_HWND_TOPMOST { get; } = new IntPtr(-1);//将窗口的层级移到置顶窗口, 层级在所有置顶窗口的最上方
        public static IntPtr SetWindowPos_hWndInsertAfter_HWND_NOTOPMOST { get; } = new IntPtr(-2);//将窗口的层级移到正常窗口, 层级在所有正常窗口的最上方
        public const uint SetWindowPos_uFlags_SWP_NOMOVE = 0x0002;//不调整窗体位置
        public const uint SetWindowPos_uFlags_SWP_NOSIZE = 0x0001;//不调整窗体大小
        public const uint SetWindowPos_uFlags_SWP_SWP_NOACTIVATE = 0x0010;//不更改所有者窗口在 Z 顺序中的位置
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        //

        public const int GetWindowLong_nIndex_GWL_EXSTYLE = -20;//检索 扩展窗口样式
        [DllImport("user32", EntryPoint = "GetWindowLong")]
        public static extern uint GetWindowLong(IntPtr hwnd, int nIndex);

        //

        public const int SetWindowLong_nIndex_GWL_EXSTYLE = -20;//设置新的 扩展窗口样式
        public const int SetWindowLong_dwNewLong_WS_EX_TRANSPARENT = 0x20;//可以事件穿透
        [DllImport("user32", EntryPoint = "SetWindowLong")]
        public static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);
    }
}
