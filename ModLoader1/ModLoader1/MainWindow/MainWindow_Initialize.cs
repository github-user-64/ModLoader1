using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using System.Windows.Markup;
using System.Windows.Controls;
using System.Windows.Media;

namespace ModLoader1
{
    public partial class MainWindow
    {
        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()
        {
            Initialize_Attribute();
            Initialize_TaskbarIcon();
            Initialize_Folder();
            Initialize_api_Program1();
            Initialize_ModLoader();
            Initialize_Mod();
        }

        //初始化属性
        private void Initialize_Attribute()
        {
            if (random == null) random = new Random();

            tsWindow = new ModLoaderLibrary1.TSWindow();
            modManagerWindow = new ModLoaderLibrary1.ModManager.ModManagerWindow(this);
            taskbarIcon_Container_Mod = new StackPanel();
        }

        //初始化任务栏图标
        private void Initialize_TaskbarIcon()
        {
            taskbarIcon = new ModLoaderLibrary1.TaskbarIconSet(Properties.Resources.ico1, Application.Current.Resources["ContextMenu1"] as Style);
            taskbarIcon.TrayLeftMouseDown += (s, e) => modManagerWindow?.api_IModManager_SwitchOpenOrClose();

            MenuItem mi = new MenuItem() { Header = "退出" };
            mi.Click += (s, e) => ExitProgram();

            MenuItem mi2 = new MenuItem() { Header = "mod管理器" };
            mi2.Click += (s, e) => modManagerWindow?.api_IModManager_SwitchOpenOrClose();

            MenuItem mi_mod = new MenuItem() { Header = taskbarIcon_Container_Mod };
            mi_mod.Style = Application.Current.Resources["MenuItem_Null"] as Style;

            taskbarIcon.Add(mi_mod);
            taskbarIcon.Add(mi2);
            taskbarIcon.Add(mi);
        }

        //初始化清单文件夹, 用于补全文件夹
        private void Initialize_Folder()
        {
            try
            {
                foreach (string s in PublicClass1.Inventory1.Folder1.GetStrings())
                {
                    _ = Directory.CreateDirectory($"{PublicLibrary1.Program.ProgramInformation.ProgramPath}\\{s}");
                }
            }
            catch (Exception ex)
            {
                TS("初始化清单文件夹失败", ex.Message, PublicLibrary1.TS.GetBtn("确定", () => { ExitProgram(); }));
            }
        }

        //初始化清单文件, 用于补全文件
        private void Initialize_File()
        {

        }

        private void Initialize_api_Program1()
        {
            PublicLibrary1.Program.Apis.IProgram1 program1 = this;

            program1.api_Program1_TS_Action = tsWindow;
        }

        private void Initialize_ModLoader()
        {
            modLoader = new ModLoaderLibrary1.Mod.ModLoader(this);
            modLoader.ClearModIng += ModLoader_ClearModIng;
        }

        private void Initialize_Mod()
        {
            try
            {
                api_Program1_ModLoad();
            }
            catch (Exception ex)
            {
                //重试除了调用自己暂时想不到好方法
                TS("mod加载失败", ex.Message,
                    PublicLibrary1.TS.GetBtn("继续", null, PublicLibrary1.TS.TSButton.Warning),
                    PublicLibrary1.TS.GetBtn("重试", () => { Initialize_Mod(); }),
                    PublicLibrary1.TS.GetBtn("退出", () => { ExitProgram(); }));
            }
        }
    }
}
