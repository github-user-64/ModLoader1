using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace desktopPet1.PublicClass1.WinApi.Class1
{
    public class Class1
    {
        public static IntPtr GetWindowIntptr(Window window)
        {
            if (window == null) return IntPtr.Zero;

            return new WindowInteropHelper(window).Handle;
        }

        public static T InvokeApi<T>(Func<T> func, T fail)
        {
            try
            {
                if (func == null) return fail;

                return func.Invoke();
            }
            catch
            {
                return fail;
            }
        }
    }
}
