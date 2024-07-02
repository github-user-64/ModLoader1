using PublicLibrary1.Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ModLoaderLibrary1.Mod
{
    public partial class ModLoader
    {
        #region
        /// <summary>
        /// 重新加载mod
        /// </summary>
        public void LoadMod()
        {
            try
            {
                ClearMod();//清理
                LoadModObjs();//加载对象
                Initialize();//初始化
            }
            catch (Exception ex)
            {
                try
                {
                    ClearMod();
                }
                catch
                {

                }
                throw new Exception($"加载mod失败:{ex.Message}");
            }
        }

        /// <summary>
        /// 清理mod
        /// </summary>
        public void ClearMod()
        {
            try
            {
                ModOperation_Invoke(false, nameof(PublicLibrary1.Mod.Apis.IMod1.Dispose));

                ClearModIng?.Invoke();

                modObjects?.Clear();
                modObjects = null;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ClearMod)}:mod清理失败:{ex.Message}");
            }
        }

        /// <summary>
        /// 加载mod对象
        /// </summary>
        private void LoadModObjs()
        {
            try
            {
                List<ModObject> mos = new LoadModObjects1().GetModObjs();
                if (mos == null) throw new Exception("mod对象列表为null");

                modObjects = mos;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(LoadModObjs)}:mod加载失败:{ex.Message}");
            }
        }

        /// <summary>
        /// 初始化mod
        /// </summary>
        private void Initialize()
        {
            for (int i = 0; i < modObjects?.Count; ++i)
            {
                ModObject mo = modObjects[i];

                if (!mo.isInheritApi) continue;

                try
                {
                    _ = mo.Invoke(nameof(PublicLibrary1.Mod.Apis.IMod1.ModInitialize), api_Program1, mo);
                }
                catch (Exception ex)
                {
                    throw new Exception($"{nameof(Initialize)}:初始化mod失败:{mo?.modConfig?.key}:{ex.Message}:{ex.InnerException?.Message}");
                }
            }

            try
            {
                ModOperation_EventInvoke(true, nameof(PublicLibrary1.Mod.Apis.IMod1.ModsInitialized));
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(Initialize)}:初始化mod失败:调用[{nameof(PublicLibrary1.Mod.Apis.IMod1.ModsInitialized)}]时出现异常:{ex.Message}:{ex.InnerException?.Message}");
            }
        }
        #endregion

        #region
        public void ModOperation_EventInvoke(bool isCatch, string eventName, params object[] os)
        {
            for (int i = 0; i < modObjects?.Count; ++i)
            {
                try
                {
                    _ = modObjects[i]?.InvokeEvent(eventName, os);
                }
                catch (Exception ex)
                {
                    if (!isCatch) continue;

                    throw new Exception(ex.Message, ex.InnerException);
                }
            }
        }

        public void ModOperation_Invoke(bool isCatch, string ActionName, params object[] os)
        {
            for (int i = 0; i < modObjects?.Count; ++i)
            {
                try
                {
                    _ = modObjects[i]?.Invoke(ActionName, os);
                }
                catch (Exception ex)
                {
                    if (!isCatch) continue;

                    throw new Exception(ex.Message, ex.InnerException);
                }
            }
        }
        #endregion
    }
}
