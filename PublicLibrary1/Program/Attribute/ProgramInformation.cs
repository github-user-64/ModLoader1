using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicLibrary1.Program
{
    /// <summary>
    /// 程序信息
    /// </summary>
    public class ProgramInformation
    {
        static ProgramInformation()
        {
            ProgramPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (ProgramPath?.Length < 1) throw new Exception($"{nameof(ProgramInformation)}:初始化[{nameof(ProgramPath)}]失败");
            if (ProgramPath[ProgramPath.Length - 1].Equals('\\')) ProgramPath = ProgramPath.Remove(ProgramPath.Length - 1, 1);
        }


        /// <summary>
        /// 程序文件路径, 不包括程序名称, 结尾不为'\'
        /// </summary>
        public static string ProgramPath { get; private set; } = null;
    }
}
