using System;
using System.Runtime.InteropServices;

namespace ZLMediaKit.Sdk.Original
{
    internal class LibraryConst
    {
        internal const string LibraryNameForWindows = "mk_api.dll";
        internal const string LibraryNameForLinux = "libmk_api.so";
        /// <summary>
        /// 是否为Windows平台
        /// </summary>
        /// <remarks>如果不是则认为是linux，不考虑macos</remarks>
        internal static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        /// <summary>
        /// 是否为32位系统
        /// </summary>
        internal static bool Isx86 => IntPtr.Size == 4; 

    }
}
