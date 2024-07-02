using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoaderLibrary1.ModManager.Apis
{
    public interface IModManager
    {
        /// <summary>
        /// 显示
        /// </summary>
        void api_IModManager_Open();
        /// <summary>
        /// 隐藏
        /// </summary>
        void api_IModManager_Close();
        /// <summary>
        /// 切换显示隐藏
        /// </summary>
        void api_IModManager_SwitchOpenOrClose();
    }
}
