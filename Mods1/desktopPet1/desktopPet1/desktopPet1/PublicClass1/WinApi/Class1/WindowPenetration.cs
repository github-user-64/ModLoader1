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
    /// 设置窗体是否鼠标穿透
    /// </summary>
    public class WindowPenetration
    {
        public static bool Set(Window window, bool isPenetration)
        {
            if (window == null) return false;

            IntPtr wh = new WindowInteropHelper(window).Handle;
            if (wh == IntPtr.Zero) return false;

            uint extendedStyle = Apis.api1.GetWindowLong(wh, Apis.api1.GetWindowLong_nIndex_GWL_EXSTYLE);

            if (isPenetration)
            {
                extendedStyle |= Apis.api1.SetWindowLong_dwNewLong_WS_EX_TRANSPARENT;
            }
            else
            {
                extendedStyle &= ~((uint)Apis.api1.SetWindowLong_dwNewLong_WS_EX_TRANSPARENT);
            }

            return Class1.InvokeApi(() =>
            {
                return Apis.api1.SetWindowLong(wh, Apis.api1.GetWindowLong_nIndex_GWL_EXSTYLE, extendedStyle) != 0;
            }, false);
        }
    }
}
