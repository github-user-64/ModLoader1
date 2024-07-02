using desktopPet1_Front.Expansion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace desktopPet1_expansion_ldnn.PublicClass1.ExpansionPets
{
    public partial class ldnn : ExpansionPet
    {
        private Random random = null;

        private List<PetObjects.ldnn.body> bs = null;

        public desktopPet1_Front.PublicClass1.PerRightMenu rightMenu = null;
        public List<MenuItem> rightMenu_random = null;//随机互动项
        private MenuItem rightMenu_random_This = null;//当前显示的随机项

        private List<data1> PetAction_rightMenu_datas = null;
        private data1 PetAction_default_data = null;
        private data1 PetAction_default_blink_data = null;
        private data1 PetAction_click_default_data = null;
        private List<data1> PetAction_click_datas = null;
    }
}
