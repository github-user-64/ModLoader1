using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ldnn_expansion
{
    public partial class Class1
    {
        private void Initialize()
        {
            data_js_0 = new desktopPet1_expansion_ldnn.PublicClass1.ExpansionPets.data1();
            data_js_0.message = new string[] { "欸!" };
            data_js_0.imgActual_StartX = 40;
            data_js_0.imgActual_StartY = 10;
            data_js_0.imgActual_Width = 50;
            data_js_0.imgActual_Height = 333;
            data_js_0.img = new BitmapImage(new Uri($"pack://application:,,,/{nameof(ldnn_expansion)};component/Resources/Images/a1.png", UriKind.Absolute));

            data_js_1 = new desktopPet1_expansion_ldnn.PublicClass1.ExpansionPets.data1();
            data_js_1.message = new string[] { "衣服湿了..", "发生了什么!", "为什么会这样啊" };
            data_js_1.imgActual_StartX = 40;
            data_js_1.imgActual_StartY = 10;
            data_js_1.imgActual_Width = 50;
            data_js_1.imgActual_Height = 333;
            data_js_1.img = new BitmapImage(new Uri($"pack://application:,,,/{nameof(ldnn_expansion)};component/Resources/Images/a2.png", UriKind.Absolute));

            ModsInitialized += () =>
            {
                for (int i = 0; i < mos.Count; ++i)
                {
                    desktopPet1_Front.Expansion.Apis.IExpansions e_ldnn = mos[i].mod as desktopPet1_Front.Expansion.Apis.IExpansions;
                    if (e_ldnn == null) continue;

                    //

                    List<desktopPet1_Front.Expansion.ExpansionPet> eps = e_ldnn.GetExpansionPets();
                    if (eps == null) return;

                    //

                    desktopPet1_expansion_ldnn.PublicClass1.ExpansionPets.ldnn ldnn = null;

                    for (int i2 = 0; i2 < eps.Count; ++i2)
                    {
                        ldnn = eps[i2] as desktopPet1_expansion_ldnn.PublicClass1.ExpansionPets.ldnn;
                    }

                    if (ldnn == null) return;

                    //

                    System.Windows.Controls.MenuItem mi = ldnn.rightMenu.GetMenuItem();
                    mi.Header = "浇水";
                    mi.Click += (s, e) => ldll_MenuItem_js_Click(ldnn);

                    object[] os = new object[ldnn.rightMenu.Menu.Items.Count];

                    ldnn.rightMenu.Menu.Items.CopyTo(os, 0);
                    ldnn.rightMenu.Menu.Items.Clear();
                    ldnn.rightMenu.Menu.Items.Add(mi);
                    for (int i2 = 0; i2 < os.Length; ++i2) ldnn.rightMenu.Menu.Items.Add(os[i2]);
                }
            };
        }
    }
}
