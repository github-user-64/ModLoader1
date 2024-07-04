using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1.PublicClass1.Apis
{
    public interface IWindow1
    {
        bool IWindow_Window_Activate();
        bool IWindow_Places_Top();
        bool IWindow_Places_Bottom();
        bool IWindow_Places_Normal();
        bool IWindow_WindowPenetration(bool isPenetration);
    }
}
