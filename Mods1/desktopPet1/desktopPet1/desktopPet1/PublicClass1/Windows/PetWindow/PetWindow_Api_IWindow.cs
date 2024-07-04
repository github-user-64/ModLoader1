using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1.PublicClass1.Windows
{
    public partial class PetWindow : Apis.IWindow1
    {
        public bool IWindow_Window_Activate()
        {
            return Activate();
        }

        public bool IWindow_Places_Bottom()
        {
            WindowPlaces = WinApi.Class1.Places.Bottom;

            windowTop_timer.Stop();

            return WinApi.Class1.WindowPlaces.Bottom(this);
        }

        public bool IWindow_Places_Normal()
        {
            WindowPlaces = WinApi.Class1.Places.Normal;

            windowTop_timer.Stop();

            return WinApi.Class1.WindowPlaces.Normal(this);
        }

        public bool IWindow_Places_Top()
        {
            WindowPlaces = WinApi.Class1.Places.Top;

            if (Class1.modSettings?.thisModSettingsData?.ManagerWindow_isRepeatWindowTop ?? false) windowTop_timer.Start();
            else windowTop_timer.Stop();

            return WinApi.Class1.WindowPlaces.Top(this);
        }

        public bool IWindow_WindowPenetration(bool isPenetration)
        {
            return WinApi.Class1.WindowPenetration.Set(this, isPenetration);
        }
    }
}
