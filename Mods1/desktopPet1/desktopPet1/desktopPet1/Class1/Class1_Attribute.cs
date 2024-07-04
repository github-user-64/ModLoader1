using PublicLibrary1.Program.Apis;
using PublicLibrary1.Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace desktopPet1
{
    public partial class Class1
    {
        public IProgram1 apiProcedure1 = null;
        public static IProgram1 apiP { get; private set; } = null;

        private List<ModObject> modObjects = null;

        private PublicClass1.Timer.Timer1 timer1 = null;
        private List<PublicClass1.Datas.ExpansionObject> expansionObjects = null;

        private PublicClass1.Windows.PetWindow petWindow = null;
        private System.ComponentModel.CancelEventHandler petWindow_Closing = null;//记录petWindow的Closing事件. 用在窗体关闭前删除事件
        private PublicClass1.UserControls.ManagerWindow managerWindow = null;

        /// <summary>
        /// 当前模组对象
        /// </summary>
        public static ModObject thisMO = null;

        public static PublicClass1.ModSettings.class1 modSettings = null;
    }
}
