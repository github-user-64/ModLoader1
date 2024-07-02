using desktopPet1_Front.Pet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace desktopPet1_minecraft_Inventory
{
    public partial class Class1 : desktopPet1_Front.Expansion.ExpansionPet
    {
        //Inventory直接记录全部的物品数据
        //用物品栏展示第一行物品
        //用背包展示全部物品

        public override void PetManagerLoaded(desktopPet1_Front.PetManager.Apis.IPetManager petManager)
        {
            this.petManager = petManager;

            Title = "物品栏";

            petManager.AddControl(petUI);
        }

        public override void AddPat()
        {
            petUI.Visibility = Visibility.Visible;
        }

        public override void DelPat(PetObject po)
        {
            petUI.Visibility = Visibility.Collapsed;
        }

        public override void ClearPet()
        {
            petUI.Visibility = Visibility.Collapsed;
        }
    }
}
