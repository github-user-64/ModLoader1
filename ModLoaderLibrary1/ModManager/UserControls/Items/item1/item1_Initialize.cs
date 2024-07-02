using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ModLoaderLibrary1.ModManager.UserControls.items
{
    public partial class item1
    {
        private void Initialize(PublicClass1.Mod.Data_ModConfigAModInfor d_mm, Apis.ModManagerTS ts)
        {
            this.d_mm = d_mm;
            this.ts = ts;

            if (this.d_mm?.mc == null) throw new Exception($"{nameof(item1)}.{nameof(Initialize)}: 初始化参数为null");

            mod_Title = d_mm.mi == null ? d_mm.mc.key : d_mm.mi.Title;
            mod_Version = d_mm.mc?.version;
            mod_Information = d_mm.mi?.Information;

            RefreshUi();
        }
    }
}
