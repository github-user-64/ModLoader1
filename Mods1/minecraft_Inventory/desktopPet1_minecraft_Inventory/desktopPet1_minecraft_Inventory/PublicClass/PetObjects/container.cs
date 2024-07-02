using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_minecraft_Inventory.PublicClass.PetObjects
{
    public class container : desktopPet1_Front.Pet.PetObject
    {
        public container()
        {
            grid = new System.Windows.Controls.Grid();
            Content = grid;
            Children = grid.Children;

            Width = double.NaN;
            Height = double.NaN;
            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            //必须设为null不能只设为透明色
            //因为这是铺满父容器的控件, 如果只设为透明色会导致鼠标无法交互图层下方的其它控件(设为透明色的控件虽然看不见, 但是能被鼠标点击)
            Background = null;
            Focusable = true;
            FocusVisualStyle = null;

            MouseEnter += (s, e) =>
            {
                _ = Focus();
            };
        }


        public System.Windows.Controls.UIElementCollection Children = null;
        private System.Windows.Controls.Grid grid = null;
    }
}
