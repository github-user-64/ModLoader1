using desktopPet1_Front.Expansion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace desktopPet1_expansion_ldnn.PublicClass1.ExpansionPets
{
    public partial class ldnn
    {
        private void Pet_DelPet()
        {
            DelPat(OpenRightMenu_OpenedBy);

            OpenRightMenu_OpenedBy = null;
        }

        private async Task Pet_message(PetObjects.ldnn.body b, data1 data)
        {
            if (b?.message == null || data == null) return;

            string message = data.message?.Length < 1 ? null : data.message?[random.Next(0, data.message.Length)];
            if (message == null) return;

            b.data = data;

            b.SetImg(data?.img);
            await b.message.Open(message, 1000 + message.Length * Class1.modSettings?.thisModSettingsData?.messageDelay ?? 200);
        }

        private void Refresh_message_Point(PetObjects.ldnn.body b)
        {
            if (b?.message == null || b?.data == null) return;

            b.message.HorizontalOffset = b.message.isFlip ? -(b.message.ActualWidth + 1) : b.data.imgActual_Width + 1;
            b.message.VerticalOffset = -b.message.ActualHeight;
            b.message.HorizontalOffset += b.data.imgActual_StartX;
            b.message.VerticalOffset += b.data.imgActual_StartY;

            b.message.Reset();
        }
    }
}
