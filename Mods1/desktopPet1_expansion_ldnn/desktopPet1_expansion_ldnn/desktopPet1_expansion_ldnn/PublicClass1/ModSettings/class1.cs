using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_expansion_ldnn.PublicClass1.ModSettings
{
    public class class1
    {
        public class1()
        {
            path = $"{Class1.thisPath}\\config\\modSettings.json";

            SetData(GetNewData() ?? new modSettingsData());
        }

        public string path { get; } = null;
        public modSettingsData thisModSettingsData { get; private set; } = null;
        /// <summary>
        /// 参数可能为null
        /// </summary>
        public event Action<modSettingsData> ModSettingsChanged = null;

        public modSettingsData GetNewData()
        {
            try
            {
                return new PublicLibrary1.JsonDispose1.MyJson1(path).Get2<modSettingsData>();
            }
            catch
            {

            }

            return null;
        }

        public void SetData(modSettingsData modSettingsData)
        {
            thisModSettingsData = modSettingsData;
            try
            {
                ModSettingsChanged?.Invoke(thisModSettingsData);
            }
            catch
            {

            }
        }
    }
}
