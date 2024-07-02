using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoaderLibrary1.ModManager.PublicClass1.Sys.WindowApis.Encapsulation
{
    public class Window
    {
        public static bool GetWindowRect(IntPtr hWnd, out Call.Window.RECT lpRect)
        {
            return Call.Window.GetWindowRect(hWnd, out lpRect);
        }

        public static int SetWindowPos(IntPtr wh, int hwndInsertAfter, int x, int y, int cx, int cy, int wFlags)
        {
            return Call.Window.SetWindowPos(wh, hwndInsertAfter, x, y, cx, cy, wFlags);
        }
    }
}
