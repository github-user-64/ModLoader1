using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace desktopPet1.PublicClass1.WinApi.Class1
{
    public class Dependency1 : DependencyObject
    {
        public static Places GetWindowPlaces1(DependencyObject obj)
        {
            return (Places)obj.GetValue(WindowPlaces1Property);
        }
        public static void SetWindowPlaces1(DependencyObject obj, Places value)
        {
            obj.SetValue(WindowPlaces1Property, value);
        }
        public static readonly DependencyProperty WindowPlaces1Property = DependencyProperty.Register(
            "WindowPlaces1", typeof(Places), typeof(Dependency1), new PropertyMetadata(Places.Normal));
    }
}