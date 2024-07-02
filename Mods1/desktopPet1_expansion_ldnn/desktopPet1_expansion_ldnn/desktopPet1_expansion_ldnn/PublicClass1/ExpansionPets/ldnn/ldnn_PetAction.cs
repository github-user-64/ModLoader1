using desktopPet1_Front.Expansion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace desktopPet1_expansion_ldnn.PublicClass1.ExpansionPets
{
    public partial class ldnn
    {
        /// <summary>
        /// 直接恢复外观和状态, 不管处于什么状态
        /// </summary>
        /// <param name="po"></param>
        private void PetAction_Recovery(PetObjects.ldnn.body b)
        {
            if (b == null) return;

            b.petState = petState.not;
            b.SetImg(PetAction_default_data?.img);
        }

        public async Task PetAction_a1(data1 data, PetObjects.ldnn.body b)
        {
            if (b == null) return;
            if (b.petState == petState.actionIng) return;
            b.petState = petState.actionIng;

            await Pet_message(b, data);

            PetAction_Recovery(b);
        }

        private async Task PetAction_a1(data1 data)
        {
            await PetAction_a1(data, OpenRightMenu_OpenedBy);
        }

        private async void PetAction_Click(PetObjects.ldnn.body b)
        {
            if (b == null) return;
            if (b.petState == petState.actionIng) return;
            b.petState = petState.actionIng;

            data1 data = null;

            if (PetAction_click_datas.Count < 1)
            {
                data = PetAction_click_default_data;
            }
            else
            {
                int val = random.Next(0, 3);

                data = val == 0 ? PetAction_click_default_data : PetAction_click_datas[random.Next(0, PetAction_click_datas.Count)];
            }

            await Pet_message(b, data);

            PetAction_Recovery(b);
        }

        private async void PetAction_blink(PetObjects.ldnn.body b)
        {
            if (PetAction_default_blink_data == null) return;
            if (b == null) return;
            if (b.petState == petState.actionIng) return;

            b.SetImg(PetAction_default_blink_data?.img);

            await Task.Delay(64);

            if (b.petState == petState.actionIng) return;

            b.SetImg(PetAction_default_data?.img);
        }
    }
}
