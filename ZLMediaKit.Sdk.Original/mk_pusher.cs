namespace ZLMediaKit.Sdk.Original
{
    /// <summary>
    /// 推流结果或推流中断事件的回调
    /// </summary>
    /// <param name="user_data">用户数据指针</param>
    /// <param name="err_code">错误代码，0为成功</param>
    /// <param name="err_msg">错误提示</param>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void on_mk_push_event(System.IntPtr user_data, int err_code, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string err_msg);

    public class mk_pusher
    {

        /// <summary>
        /// 绑定的MediaSource对象并创建rtmp[s]/rtsp[s]推流器;
        /// </summary>
        /// <param name="schema">绑定的MediaSource对象所属协议，支持rtsp/rtmp</param>
        /// <param name="vhost">绑定的MediaSource对象的虚拟主机，一般为__defaultVhost__</param>
        /// <param name="app">绑定的MediaSource对象的应用名，一般为live</param>
        /// <param name="stream">绑定的MediaSource对象的流id</param>
        /// <returns></returns>
        /// <remarks>MediaSource通过mk_media_create或mk_proxy_player_create生成 ;
        /// 该MediaSource对象必须已注册
        /// </remarks>
        public static System.IntPtr mk_pusher_create(string schema, string vhost, string app, string stream)
            => LibraryConst.IsWindows ? mk_pusher_windows.mk_pusher_create(schema, vhost, app, stream) : mk_pusher_unix.mk_pusher_create(schema, vhost, app, stream);

        /// <summary>
        /// 释放推流器
        /// </summary>
        /// <param name="ctx">推流器指针</param>
        public static  void mk_pusher_release(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_pusher_windows.mk_pusher_release(ctx);
            else mk_pusher_unix.mk_pusher_release(ctx);
        }

        /// <summary>
        /// 设置推流器配置选项
        /// </summary>
        /// <param name="ctx">推流器指针</param>
        /// <param name="key">
        /// 配置项键,支持 net_adapter/rtp_type/rtsp_user/rtsp_pwd/protocol_timeout_ms/media_timeout_ms/beat_interval_ms/max_analysis_ms
        /// <list type="number">
        /// <item>net_adapter</item>
        /// <item>rtp_type</item>
        /// <item>rtsp_user</item>
        /// <item>rtsp_pwd</item>
        /// <item>protocol_timeout_ms</item>
        /// <item>media_timeout_ms</item>
        /// <item>beat_interval_ms</item>
        /// <item>max_analysis_ms</item></list></param>
        /// <param name="val">配置项值,如果是整形，需要转换成统一转换成string</param>
        public static  void mk_pusher_set_option(System.IntPtr ctx,  string key,  string val)
        {
            if (LibraryConst.IsWindows) mk_pusher_windows.mk_pusher_set_option(ctx, key,val);
            else mk_pusher_unix.mk_pusher_set_option(ctx, key, val);
        }

        /// <summary>
        /// 开始推流
        /// </summary>
        /// <param name="ctx">推流器指针</param>
        /// <param name="url">推流地址，支持rtsp[s]/rtmp[s]</param>
        public static  void mk_pusher_publish(System.IntPtr ctx,  string url)
        {
            if (LibraryConst.IsWindows) mk_pusher_windows.mk_pusher_publish(ctx, url);
            else mk_pusher_unix.mk_pusher_publish(ctx, url);
        }

        /// <summary>
        /// 设置推流器推流结果回调函数
        /// </summary>
        /// <param name="ctx">推流器指针</param>
        /// <param name="cb">回调函数指针,不得为null</param>
        /// <param name="user_data">用户数据指针</param>
        public static  void mk_pusher_set_on_result(System.IntPtr ctx, on_mk_push_event cb, System.IntPtr user_data)
        {
            if (LibraryConst.IsWindows) mk_pusher_windows.mk_pusher_set_on_result(ctx, cb,user_data);
            else mk_pusher_unix.mk_pusher_set_on_result(ctx, cb, user_data);
        }

        /// <summary>
        /// 设置推流被异常中断的回调
        /// </summary>
        /// <param name="ctx">推流器指针</param>
        /// <param name="cb">回调函数指针,不得为null</param>
        /// <param name="user_data">用户数据指针</param>
        public static  void mk_pusher_set_on_shutdown(System.IntPtr ctx, on_mk_push_event cb, System.IntPtr user_data)
        {
            if (LibraryConst.IsWindows) mk_pusher_windows.mk_pusher_set_on_shutdown(ctx, cb, user_data);
            else mk_pusher_unix.mk_pusher_set_on_shutdown(ctx, cb, user_data);
        }
    }

    internal class mk_pusher_windows
    {

        /// Return Type: mk_pusher->void*
        ///schema: char*
        ///vhost: char*
        ///app: char*
        ///stream: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_pusher_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_pusher_create([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string schema, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string vhost, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string app, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream);


        /// Return Type: void
        ///ctx: mk_pusher->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_pusher_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_pusher_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_pusher->void*
        ///key: char*
        ///val: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_pusher_set_option", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_pusher_set_option(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string val);


        /// Return Type: void
        ///ctx: mk_pusher->void*
        ///url: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_pusher_publish", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_pusher_publish(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string url);


        /// Return Type: void
        ///ctx: mk_pusher->void*
        ///cb: on_mk_push_event
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_pusher_set_on_result", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_pusher_set_on_result(System.IntPtr ctx, on_mk_push_event cb, System.IntPtr user_data);


        /// Return Type: void
        ///ctx: mk_pusher->void*
        ///cb: on_mk_push_event
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_pusher_set_on_shutdown", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_pusher_set_on_shutdown(System.IntPtr ctx, on_mk_push_event cb, System.IntPtr user_data);
    }

    internal class mk_pusher_unix
    {

        /// Return Type: mk_pusher->void*
        ///schema: char*
        ///vhost: char*
        ///app: char*
        ///stream: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_pusher_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_pusher_create([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string schema, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string vhost, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string app, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream);


        /// Return Type: void
        ///ctx: mk_pusher->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_pusher_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_pusher_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_pusher->void*
        ///key: char*
        ///val: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_pusher_set_option", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_pusher_set_option(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string val);


        /// Return Type: void
        ///ctx: mk_pusher->void*
        ///url: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_pusher_publish", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_pusher_publish(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string url);


        /// Return Type: void
        ///ctx: mk_pusher->void*
        ///cb: on_mk_push_event
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_pusher_set_on_result", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_pusher_set_on_result(System.IntPtr ctx, on_mk_push_event cb, System.IntPtr user_data);


        /// Return Type: void
        ///ctx: mk_pusher->void*
        ///cb: on_mk_push_event
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_pusher_set_on_shutdown", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_pusher_set_on_shutdown(System.IntPtr ctx, on_mk_push_event cb, System.IntPtr user_data);
    }
}
