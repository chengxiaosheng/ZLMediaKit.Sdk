namespace ZLMediaKit.Sdk.Original
{
    public class mk_recorder
    {
        /// <summary>
        /// 创建flv录制器
        /// </summary>
        /// <returns></returns>
        public static System.IntPtr mk_flv_recorder_create()
            => LibraryConst.IsWindows ? mk_recorder_windows.mk_flv_recorder_create() : mk_recorder_unix.mk_flv_recorder_create();

        /// <summary>
        /// 释放flv录制器
        /// </summary>
        /// <param name="ctx"></param>
        public static  void mk_flv_recorder_release(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_recorder_windows.mk_flv_recorder_release(ctx);
            else mk_recorder_unix.mk_flv_recorder_release(ctx);
        }
        /// <summary>
        /// 开始录制flv
        /// </summary>
        /// <param name="ctx">flv录制器</param>
        /// <param name="vhost">虚拟主机</param>
        /// <param name="app">绑定的RtmpMediaSource的 app名</param>
        /// <param name="stream">绑定的RtmpMediaSource的 stream名</param>
        /// <param name="file_path">文件存放地址</param>
        /// <returns>0:开始超过，-1:失败,打开文件失败或该RtmpMediaSource不存在</returns>
        public static int mk_flv_recorder_start(System.IntPtr ctx, string vhost, string app, string stream, string file_path)
            => LibraryConst.IsWindows ? mk_recorder_windows.mk_flv_recorder_start(ctx, vhost, app, stream, file_path) : mk_recorder_unix.mk_flv_recorder_start(ctx, vhost, app, stream, file_path);

        /// <summary>
        /// 获取录制状态
        /// </summary>
        /// <param name="type">0:hls,1:MP4</param>
        /// <param name="vhost">虚拟主机</param>
        /// <param name="app">应用名</param>
        /// <param name="stream">流id</param>
        /// <returns>录制状态,0:未录制, 1:正在录制</returns>
        public static  int mk_recorder_is_recording(int type,string vhost,string app, string stream)
            => LibraryConst.IsWindows ? mk_recorder_windows.mk_recorder_is_recording(type, vhost, app, stream) : mk_recorder_unix.mk_recorder_is_recording(type, vhost, app, stream);


        /// <summary>
        /// 开始录制
        /// </summary>
        /// <param name="type"> 0:hls,1:MP4</param>
        /// <param name="vhost">虚拟主机</param>
        /// <param name="app">应用名</param>
        /// <param name="stream">流id</param>
        /// <param name="customized_path">录像文件保存自定义目录，默认为空或null则自动生成</param>
        /// <returns>1代表成功，0代表失败</returns>
        public static int mk_recorder_start(int type, string vhost, string app, string stream, string customized_path)
            => LibraryConst.IsWindows ? mk_recorder_windows.mk_recorder_start(type, vhost, app, stream, customized_path) : mk_recorder_unix.mk_recorder_start(type, vhost, app, stream, customized_path);


        /// <summary>
        /// 停止录制
        /// </summary>
        /// <param name="type">0:hls,1:MP4</param>
        /// <param name="vhost">虚拟主机</param>
        /// <param name="app">应用名</param>
        /// <param name="stream">流id</param>
        /// <returns>1:成功，0：失败</returns>
        public static  int mk_recorder_stop(int type,  string vhost,string app, string stream)
            => LibraryConst.IsWindows ? mk_recorder_windows.mk_recorder_stop(type, vhost, app, stream) : mk_recorder_unix.mk_recorder_stop(type, vhost, app, stream);

    }

    internal class mk_recorder_windows
    {

        /// Return Type: mk_flv_recorder->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_flv_recorder_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_flv_recorder_create();


        /// Return Type: void
        ///ctx: mk_flv_recorder->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_flv_recorder_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_flv_recorder_release(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_flv_recorder->void*
        ///vhost: char*
        ///app: char*
        ///stream: char*
        ///file_path: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_flv_recorder_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_flv_recorder_start(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string vhost, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string app, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string file_path);


        /// Return Type: int
        ///type: int
        ///vhost: char*
        ///app: char*
        ///stream: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_recorder_is_recording", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_recorder_is_recording(int type, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string vhost, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string app, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream);


        /// Return Type: int
        ///type: int
        ///vhost: char*
        ///app: char*
        ///stream: char*
        ///customized_path: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_recorder_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_recorder_start(int type, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string vhost, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string app, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string customized_path);


        /// Return Type: int
        ///type: int
        ///vhost: char*
        ///app: char*
        ///stream: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_recorder_stop", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_recorder_stop(int type, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string vhost, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string app, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream);
    }

    internal class mk_recorder_unix
    {

        /// Return Type: mk_flv_recorder->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_flv_recorder_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_flv_recorder_create();


        /// Return Type: void
        ///ctx: mk_flv_recorder->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_flv_recorder_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_flv_recorder_release(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_flv_recorder->void*
        ///vhost: char*
        ///app: char*
        ///stream: char*
        ///file_path: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_flv_recorder_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_flv_recorder_start(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string vhost, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string app, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string file_path);


        /// Return Type: int
        ///type: int
        ///vhost: char*
        ///app: char*
        ///stream: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_recorder_is_recording", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_recorder_is_recording(int type, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string vhost, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string app, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream);


        /// Return Type: int
        ///type: int
        ///vhost: char*
        ///app: char*
        ///stream: char*
        ///customized_path: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_recorder_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_recorder_start(int type, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string vhost, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string app, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string customized_path);


        /// Return Type: int
        ///type: int
        ///vhost: char*
        ///app: char*
        ///stream: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_recorder_stop", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_recorder_stop(int type, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string vhost, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string app, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream);
    }
}
