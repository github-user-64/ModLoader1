using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_expansion_ldnn.PublicClass1.ModSettings
{
    public class modSettingsData
    {
        public bool isDebug { get; set; } = false;
        public bool autoAdd { get; set; } = false;
        public double scaleTransform { get; set; } = 1;
        public int messageDelay { get; set; } = 200;

    }
}
