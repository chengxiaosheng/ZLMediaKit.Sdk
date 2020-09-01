namespace ZLMediaKit.Sdk.Original
{

    public class  mk_unit
    {
        /// <summary>
        /// 获取本程序可执行文件路径
        /// </summary>
        /// <returns>文件路径，使用完后需要自己free</returns>
        public static System.IntPtr mk_util_get_exe_path()
            => LibraryConst.IsWindows ? mk_unit_windows.mk_util_get_exe_path() : mk_unit_unix.mk_util_get_exe_path();

        /// <summary>
        /// 获取本程序可执行文件相同目录下文件的绝对路径
        /// </summary>
        /// <param name="relative_path">同目录下文件的路径相对,可以为null</param>
        /// <returns>文件路径，使用完后需要自己free</returns>
        public static  System.IntPtr mk_util_get_exe_dir(string relative_path)
            => LibraryConst.IsWindows? mk_unit_windows.mk_util_get_exe_dir(relative_path) : mk_unit_unix.mk_util_get_exe_dir(relative_path);

        /// <summary>
        /// 获取unix标准的系统时间戳
        /// </summary>
        /// <returns>当前系统时间戳</returns>
        public static  uint mk_util_get_current_millisecond()
            => LibraryConst.IsWindows ? mk_unit_windows.mk_util_get_current_millisecond() : mk_unit_unix.mk_util_get_current_millisecond();

        /// <summary>
        /// 获取时间字符串
        /// </summary>
        /// <param name="fmt">时间格式，譬如%Y-%m-%d %H:%M:%S</param>
        /// <returns>时间字符串，使用完后需要自己free</returns>
        public static  System.IntPtr mk_util_get_current_time_string(string fmt)
            => LibraryConst.IsWindows ? mk_unit_windows.mk_util_get_current_time_string(fmt) : mk_unit_unix.mk_util_get_current_time_string(fmt);

        /// <summary>
        /// 打印二进制为字符串
        /// </summary>
        /// <param name="buf">二进制数据</param>
        /// <param name="len">数据长度</param>
        /// <returns>可打印的调试信息，使用完后需要自己free</returns>
        public static  System.IntPtr mk_util_hex_dump(System.IntPtr buf, int len)
            => LibraryConst.IsWindows ? mk_unit_windows.mk_util_hex_dump(buf,len) : mk_unit_unix.mk_util_hex_dump(buf, len);

    }

    internal class mk_unit_unix
    {
        /// Return Type: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_util_get_exe_path", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern System.IntPtr mk_util_get_exe_path();
        /// Return Type: char*
        ///relative_path: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_util_get_exe_dir", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_util_get_exe_dir([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string relative_path);


        /// Return Type: uint64_t->unsigned int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_util_get_current_millisecond", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern uint mk_util_get_current_millisecond();


        /// Return Type: char*
        ///fmt: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_util_get_current_time_string", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_util_get_current_time_string([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string fmt);


        /// Return Type: char*
        ///buf: void*
        ///len: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_util_hex_dump", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_util_hex_dump(System.IntPtr buf, int len);

    }

    internal class mk_unit_windows
    {
        /// Return Type: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_util_get_exe_path", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern System.IntPtr mk_util_get_exe_path();
        /// Return Type: char*
        ///relative_path: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_util_get_exe_dir", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_util_get_exe_dir([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string relative_path);


        /// Return Type: uint64_t->unsigned int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_util_get_current_millisecond", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern uint mk_util_get_current_millisecond();


        /// Return Type: char*
        ///fmt: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_util_get_current_time_string", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_util_get_current_time_string([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string fmt);


        /// Return Type: char*
        ///buf: void*
        ///len: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_util_hex_dump", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_util_hex_dump(System.IntPtr buf, int len);

    }
}
