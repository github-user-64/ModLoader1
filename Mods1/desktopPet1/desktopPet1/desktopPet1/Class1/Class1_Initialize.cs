using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1
{
    public partial class Class1
    {
        private void Initialize()
        {
            try
            {
                //获取mod对象列表
                modObjects = apiProcedure1.api_Program1_Mod_GetModList();
                if (modObjects == null) throw new Exception("获取的mod对象列表为null");

                ModsInitialized += () =>
                {
                    try
                    {
                        Initialize_Attribute();
                        Initialize_Timer();
                        Initialize_Event();
                        Initialize_ExpansionMod();
                        Initialize_Window();
                        Initialize_TaskbarIcon();
                        Initialize_CustomUI();
                    }
                    catch (Exception ex)
                    {
                        apiProcedure1.api_Program1_TS("mod加载出错", $"{PublicClass1.Mod.Config1.key}:{ex.Message}", PublicLibrary1.TS.GetBtn("确定", () => apiProcedure1.api_Program1_ExitProgram()));
                    }
                };
            }
            catch (Exception ex)
            {
                apiProcedure1.api_Program1_TS("mod加载出错", $"{PublicClass1.Mod.Config1.key}:{ex.Message}", PublicLibrary1.TS.GetBtn("确定", () => apiProcedure1.api_Program1_ExitProgram()));
                return;
            }
        }

        private void Initialize_Attribute()
        {
            modSettings = new PublicClass1.ModSettings.class1();

            expansionObjects = new List<PublicClass1.Datas.ExpansionObject>();

            petWindow = new PublicClass1.Windows.PetWindow();
            petWindow_Closing = (s, e) => apiProcedure1.api_Program1_ExitProgram();
            petWindow.Closing += petWindow_Closing;

            managerWindow = new PublicClass1.UserControls.ManagerWindow(expansionObjects, petWindow);
            managerWindow.PetAddClick += Class1_ManagerWindow_PetAddClick;
            managerWindow.PetClearClick += Class1_ManagerWindow_PetClearClick;

            //

            petWindow.ManagerWindow_UI.Child = managerWindow;
        }

        private void Initialize_Timer()
        {
            timer1 = new PublicClass1.Timer.Timer1();
            timer1.t += Class_Tick;
            timer1.Start();
        }

        private void Initialize_Event()
        {
            petWindow.KeyDown += (s, e) => KeyDown?.Invoke(e);
            petWindow.KeyUp += (s, e) => KeyUp?.Invoke(e);
        }

        #region 初始化扩展对象列表
        private void Initialize_ExpansionMod()
        {
            for (int i = 0; i < modObjects.Count; ++i)
            {
                PublicLibrary1.Mod.ModObject mo = modObjects[i];

                if (mo == null) continue;
                if (mo.modConfig.key == PublicClass1.Mod.Config1.key) continue;

                //添加对象
                Initialize_ExpansionMod_AddExpansionObjects_ExpansionPet(mo);
                Initialize_ExpansionMod_AddExpansionObjects_IExpansions(mo);
            }

            for (int i = 0; i < expansionObjects.Count; ++i)
            {
                try
                {
                    expansionObjects[i].expansionPet.PetManagerLoaded(this);
                }
                catch (Exception ex)
                {
                    apiProcedure1.api_Program1_TS("初始化扩展mod失败", $"{nameof(desktopPet1_Front.Expansion.ExpansionPet.PetManagerLoaded)}:{ex.Message}", PublicLibrary1.TS.GetBtn("确定", null));
                }
            }
        }

        private void Initialize_ExpansionMod_AddExpansionObjects_ExpansionPet(PublicLibrary1.Mod.ModObject mo)
        {
            desktopPet1_Front.Expansion.ExpansionPet ep = mo.mod as desktopPet1_Front.Expansion.ExpansionPet;

            if (ep == null) return;

            expansionObjects.Add(new PublicClass1.Datas.ExpansionObject(ep, mo));
        }

        private void Initialize_ExpansionMod_AddExpansionObjects_IExpansions(PublicLibrary1.Mod.ModObject mo)
        {
            desktopPet1_Front.Expansion.Apis.IExpansions ie = mo.mod as desktopPet1_Front.Expansion.Apis.IExpansions;

            if (ie == null) return;

            List<desktopPet1_Front.Expansion.ExpansionPet> eps = ie.GetExpansionPets();

            for (int i = 0; i < eps?.Count; ++i)
            {
                if (eps[i] == null) continue;

                expansionObjects.Add(new PublicClass1.Datas.ExpansionObject(eps[i], mo));
            }
        }
        #endregion

        #region 初始化窗口
        private void Initialize_Window()
        {
            Initialize_Window_PetWindow();
            Initialize_Window_ManagerWindow();
        }

        private void Initialize_Window_PetWindow()
        {
            petWindow.Loaded += (s, e) =>
            {
                if (modSettings?.thisModSettingsData?.ManagerWindow_isDefaultTop ?? false) _ = petWindow.IWindow_Places_Top();
                if (modSettings?.thisModSettingsData?.ManagerWindow_isDefaultBottom ?? false) _ = petWindow.IWindow_Places_Bottom();
                //当管理窗口默认打开和穿透都打开时, 默认穿透无效
                if (
                (modSettings?.thisModSettingsData?.ManagerWindow_isDefaultPenetration ?? false) &&
                modSettings?.thisModSettingsData?.ManagerWindow_isDefaultOpen == false)
                    _ = petWindow.IWindow_WindowPenetration(true);
            };
            petWindow.Show();
        }

        private void Initialize_Window_ManagerWindow()
        {
            if (modSettings?.thisModSettingsData?.ManagerWindow_isDefaultOpen != true) return;

            //初始化完扩展列表再打开窗口才有item
            managerWindow.Open();
        }
        #endregion

        private void Initialize_TaskbarIcon()
        {
            System.Windows.Controls.MenuItem menuItem = new System.Windows.Controls.MenuItem() { Header = "桌宠管理" };
            apiProcedure1.api_Program1_TaskbarIconAdd(menuItem);

            menuItem.Click += (s, e) => managerWindow?.SwitchOpenOrClose();
        }

        private void Initialize_CustomUI()
        {
            if (modSettings?.thisModSettingsData?.ManagerWindow_isEnabledCustomUI != true) return;

            CustomUI_Refresh();
        }
    }
}
