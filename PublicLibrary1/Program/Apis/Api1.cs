using PublicLibrary1.Mod;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PublicLibrary1.Program.Apis
{
    /// <summary>
    /// 程序的api
    /// </summary>
    public interface IProgram1
    {
        TS.ITS1 api_Program1_TS_Action { get; set; }

        /// <summary>
        /// 退出程序中, 在[api_Program1_ExitProgram]调用时触发
        /// </summary>
        event Action api_Program1_ExitProgramIng;

        /// <summary>
        /// 退出程序
        /// </summary>
        void api_Program1_ExitProgram();

        /// <summary>
        /// 添加任务栏图标选项
        /// </summary>
        /// <param name="menuItem"></param>
        void api_Program1_TaskbarIconAdd(UIElement menuItem);
        /// <summary>
        /// 删除任务栏图标选项
        /// </summary>
        /// <param name="menuItem"></param>
        void api_Program1_TaskbarIconDel(UIElement menuItem);

        /// <summary>
        /// 弹出消息弹窗, 该方法调用api_Program1_TS_Action
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        void api_Program1_TS(string title, string message, params Button[] buttons);

        /// <summary>
        /// 重新加载mod
        /// </summary>
        void api_Program1_ModLoad();

        /// <summary>
        /// 获取已加载的mod对象列表
        /// </summary>
        /// <returns></returns>
        List<ModObject> api_Program1_Mod_GetModList();

        Random api_Program1_GetRandom();
    }
}
