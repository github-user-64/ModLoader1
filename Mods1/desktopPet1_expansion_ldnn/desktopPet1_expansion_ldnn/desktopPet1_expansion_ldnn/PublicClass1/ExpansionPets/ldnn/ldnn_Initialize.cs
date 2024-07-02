using desktopPet1_Front.Expansion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;
using System.Windows;

namespace desktopPet1_expansion_ldnn.PublicClass1.ExpansionPets
{
    public partial class ldnn : ExpansionPet
    {
        private void Initialize()
        {
            Title = "绫地宁宁";

            Initialize_Attribute();
            Initialize_Res();
            Initialize_RightMenu();
        }

        private void Initialize_Attribute()
        {
            random = new Random();

            bs = new List<PetObjects.ldnn.body>();

            rightMenu = new desktopPet1_Front.PublicClass1.PerRightMenu();
            rightMenu_random = new List<MenuItem>();

            PetAction_rightMenu_datas = new List<data1>();
            PetAction_click_datas = new List<data1>();
        }

        private void Initialize_Res()
        {
            #region PetAction
            try
            {
                string default_data = $"{Class1.thisPath}\\{Inventory.File.petAction_default_data1}";
                string default_img = $"{Class1.thisPath}\\{Inventory.File.petAction_default_data1_img1}";
                string blink_img = $"{Class1.thisPath}\\{Inventory.File.petAction_default_blink_data1_img1}";
                string clickDefault_data = $"{Class1.thisPath}\\{Inventory.File.petAction_click_default_data1}";
                string clickDefault_img = $"{Class1.thisPath}\\{Inventory.File.petAction_click_default_data1_img1}";

                if (!File.Exists(default_data)) return;
                PetAction_default_data = new PublicLibrary1.JsonDispose1.MyJson1(default_data).Get2<data1>();

                if (!File.Exists(default_img)) return;
                PetAction_default_data.img = desktopPet1_Front.PublicClass1.IO.Get1.GetBitmapImage(default_img);

                //

                PetAction_default_blink_data = new data1();

                if (!File.Exists(blink_img)) return;
                PetAction_default_blink_data.img = desktopPet1_Front.PublicClass1.IO.Get1.GetBitmapImage(blink_img);

                //

                if (!File.Exists(clickDefault_data)) return;
                PetAction_click_default_data = new PublicLibrary1.JsonDispose1.MyJson1(clickDefault_data).Get2<data1>();

                if (!File.Exists(clickDefault_img)) return;
                PetAction_click_default_data.img = desktopPet1_Front.PublicClass1.IO.Get1.GetBitmapImage(clickDefault_img);
            }
            catch
            {

            }
            #endregion

            #region RightMenu
            try
            {
                string rightMenuPath = $"{Class1.thisPath}\\{Inventory.Folder.ExpansionPets.Pet_ldnn_RightMenu}";

                DirectoryInfo di = new DirectoryInfo(rightMenuPath);

                for (int i = 0; i < di.GetDirectories().Length; ++i)
                {
                    DirectoryInfo di_ = di.GetDirectories()[i];
                    string dataPath = $"{di_.FullName}\\{Inventory.FileRelative.ExpansionPets.ldnn.rightMenu_data}";
                    string dataPath_img = $"{di_.FullName}\\{Inventory.FileRelative.ExpansionPets.ldnn.rightMenu_img}";
                    data1 data = null;

                    if (!File.Exists(dataPath)) continue;

                    data = new PublicLibrary1.JsonDispose1.MyJson1(dataPath).Get2<data1>();
                    if (data == null) continue;

                    if (!File.Exists(dataPath_img)) continue;

                    data.img = desktopPet1_Front.PublicClass1.IO.Get1.GetBitmapImage(dataPath_img);

                    PetAction_rightMenu_datas.Add(data);
                }
            }
            catch
            {

            }
            #endregion

            #region Click
            try
            {
                string clickPath = $"{Class1.thisPath}\\{Inventory.Folder.ExpansionPets.Pet_ldnn_Click}";

                DirectoryInfo di = new DirectoryInfo(clickPath);

                for (int i = 0; i < di.GetDirectories().Length; ++i)
                {
                    DirectoryInfo di_ = di.GetDirectories()[i];
                    string dataPath = $"{di_.FullName}\\{Inventory.FileRelative.ExpansionPets.ldnn.click_data}";
                    string dataPath_img = $"{di_.FullName}\\{Inventory.FileRelative.ExpansionPets.ldnn.click_img}";
                    data1 data = null;

                    if (!File.Exists(dataPath)) continue;

                    data = new PublicLibrary1.JsonDispose1.MyJson1(dataPath).Get2<data1>();
                    if (data == null) continue;

                    if (!File.Exists(dataPath_img)) continue;

                    data.img = desktopPet1_Front.PublicClass1.IO.Get1.GetBitmapImage(dataPath_img);

                    PetAction_click_datas.Add(data);
                }
            }
            catch
            {

            }
            #endregion
        }

        private void Initialize_RightMenu()
        {
            try
            {
                for (int i = 0; i < PetAction_rightMenu_datas.Count; ++i)
                {
                    data1 data = PetAction_rightMenu_datas[i];
                    MenuItem mi = rightMenu.GetMenuItem();

                    mi.Header = data.text;
                    mi.Click += (s, e) => { PetAction_a1(data); };
                    mi.Visibility = data.isRandom ? Visibility.Collapsed : Visibility.Visible;

                    if (data.isRandom)
                    {
                        rightMenu_random.Add(mi);
                        continue;
                    }

                    rightMenu.AddMenuItem(mi);
                }

                for (int i = 0; i < rightMenu_random.Count; ++i)
                {
                    rightMenu.AddMenuItem(rightMenu_random[i]);//放到后面再加, 让要随机的都在下面
                }
            }
            catch
            {

            }

            MenuItem mi_del = rightMenu.GetMenuItem();
            mi_del.Header = "删除";
            mi_del.Click += (s, e) => { Pet_DelPet(); };
            rightMenu.AddMenuItem(mi_del);
        }
    }
}
