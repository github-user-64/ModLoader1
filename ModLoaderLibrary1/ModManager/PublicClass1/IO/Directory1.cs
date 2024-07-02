using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ModLoaderLibrary1.ModManager.PublicClass1.IO
{
    public partial class Directory1
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]
        public struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;

            [MarshalAs(UnmanagedType.U4)]

            public int wFunc;

            public string pFrom;

            public string pTo;

            public short fFlags;

            [MarshalAs(UnmanagedType.Bool)]

            public bool fAnyOperationsAborted;

            public IntPtr hNameMappings;

            public string lpszProgressTitle;
        }


        #region Dllimport
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern int SHFileOperation(ref SHFILEOPSTRUCT FileOp);
        #endregion

        #region Const
        public const int FO_DELETE = 3;
        public const int FOF_ALLOWUNDO = 0x40;
        public const int FOF_NOCONFIRMATION = 0x10;
        #endregion


        #region Public Static Method
        public static int DeleteFileToRecyclebin(string file, bool showConfirmDialog = false)
        {
            SHFILEOPSTRUCT shf = new SHFILEOPSTRUCT();

            shf.wFunc = FO_DELETE;
            shf.fFlags = FOF_ALLOWUNDO;

            if (!showConfirmDialog)
            {
                shf.fFlags |= FOF_NOCONFIRMATION;
            }

            shf.pFrom = file + '\0' + '\0';

            return SHFileOperation(ref shf);
        }
        #endregion
    }
}