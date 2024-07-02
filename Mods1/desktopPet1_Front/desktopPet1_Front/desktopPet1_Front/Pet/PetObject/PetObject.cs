using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace desktopPet1_Front.Pet
{
    public partial class PetObject : UserControl
    {
        public PetObject()
        {
            Initialize();
        }
        /// <summary>
        /// 创建一个子对象(主对象)
        /// </summary>
        /// <param name="mainpo">主对象</param>
        public PetObject(PetObject mainpo) : this()
        {
            MainPetObject = mainpo;
        }

        /// <summary>
        /// 该对象的主对象
        /// </summary>
        public PetObject MainPetObject = null;
        /// <summary>
        /// 该对象的子对象, 由主对象使用
        /// </summary>
        public List<PetObject> ChildrenPetObject = null;


        public virtual void SetImg(ImageSource img) { }

        public virtual void SetX(double v)
        {
            if (v == GetX()) return;

            Margin = new Thickness(v, Margin.Top, 0, 0);

            OnMove();
        }
        public virtual void SetY(double v)
        {
            if (v == GetY()) return;

            Margin = new Thickness(Margin.Left, v, 0, 0);

            OnMove();
        }
        public virtual double GetX()
        {
            return Margin.Left;
        }
        public virtual double GetY()
        {
            return Margin.Top;
        }
    }
}
