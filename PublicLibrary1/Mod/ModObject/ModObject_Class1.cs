using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PublicLibrary1.Mod
{
    /// <summary>
    /// mod对象
    /// </summary>
    public partial class ModObject
    {
        /// <summary>
        /// 调用mod用于对接的类内的方法, 找不到方法时不会报错, 主要用于没继承api的mod
        /// </summary>
        /// <param name="ff"></param>
        /// <param name="os"></param>
        public object Invoke(string ff, params object[] os)
        {
            try
            {
                MethodInfo methodInfo1 = type?.GetMethod(ff);//创建方法

                return methodInfo1?.Invoke(mod, os == null ? new object[0] : os);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="ff"></param>
        /// <param name="os"></param>
        /// <returns></returns>
        public object InvokeEvent(string ff, params object[] os)
        {
            try
            {
                FieldInfo fieldInfo = type?.GetField(ff, BindingFlags.NonPublic | BindingFlags.Instance);
                object action = fieldInfo?.GetValue(mod);
                MethodInfo methodInfo1 = action?.GetType()?.GetMethod("Invoke");

                return methodInfo1?.Invoke(action, os == null ? new object[0] : os);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
