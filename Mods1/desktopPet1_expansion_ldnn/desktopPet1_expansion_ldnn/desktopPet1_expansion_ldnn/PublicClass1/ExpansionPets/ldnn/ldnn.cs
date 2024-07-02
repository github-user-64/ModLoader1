using desktopPet1_Front.Expansion;
using desktopPet1_Front.Pet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace desktopPet1_expansion_ldnn.PublicClass1.ExpansionPets
{
    public partial class ldnn : ExpansionPet
    {
        public ldnn()
        {
            Initialize();
        }

        public override void PetManagerLoaded(desktopPet1_Front.PetManager.Apis.IPetManager petManager)
        {
            this.petManager = petManager;

            if (Class1.modSettings?.thisModSettingsData?.autoAdd ?? false) AddPat();
        }

        public override void AddPat()
        {
            PetObjects.ldnn.body ldnn_body = new PetObjects.ldnn.body();
            PetObjects.ldnn.message ldnn_message = new PetObjects.ldnn.message();

            ldnn_body.SetImg(PetAction_default_data?.img);
            ldnn_body.LeftClick_new += (s) => { PetAction_Click(s); };
            ldnn_body.OpenRightMenu += (s) => { OpenRightMenu(s); };
            ldnn_body.ChildrenPetObject = new List<PetObject>();
            ldnn_body.ChildrenPetObject.Add(ldnn_message);
            ldnn_body.message = ldnn_message;
            ldnn_body.timer.Tick += (s, e) => { PetAction_blink(ldnn_body); };
            ldnn_body.Move += (s) =>
            {
                if ((ldnn_body.Parent as FrameworkElement) != null) ldnn_body.message.Flip(ldnn_body.GetX() > ((FrameworkElement)ldnn_body.Parent).ActualWidth / 2);//在屏幕右边就翻转
                Refresh_message_Point(ldnn_body);
            };
            ldnn_body.timer.Start();

            ldnn_message.MainPetObject = ldnn_body;
            ldnn_message.PlacementTarget = ldnn_body;
            ldnn_message.Opening += () => Refresh_message_Point(ldnn_body);

            petManager.AddControl(ldnn_body);
            petManager.AddControl(ldnn_message);

            //在设置XY后触发的移动事件
            //在事件的处理中会获取父控件
            //在添加到ui后才能获取父控件
            ldnn_body.SetX(SystemParameters.PrimaryScreenWidth - ldnn_body.Width - 64);
            ldnn_body.SetY(SystemParameters.PrimaryScreenHeight - ldnn_body.Height);

            bs.Add(ldnn_body);
        }

        public override void DelPat(PetObject po)
        {
            (po as PetObjects.ldnn.body)?.timer?.Stop();

            base.DelPat(po);

            bs.Remove(po as PetObjects.ldnn.body);
        }

        public override void ClearPet()
        {
            for (int i = 0; i < bs.Count; ++i)
            {
                DelPat(bs[i]);
            }

            bs.Clear();
        }

        public PetObjects.ldnn.body OpenRightMenu_OpenedBy { get; private set; } = null;
        private void OpenRightMenu(PetObjects.ldnn.body b)
        {
            OpenRightMenu_OpenedBy = b;

            if (rightMenu_random_This != null) rightMenu_random_This.Visibility = Visibility.Collapsed;

            if (rightMenu_random.Count > 0)
            {
                int index = random.Next(0, rightMenu_random.Count);

                rightMenu_random_This = rightMenu_random[index];

                rightMenu_random_This.Visibility = Visibility.Visible;
            }

            rightMenu.Open();
        }
    }
}
