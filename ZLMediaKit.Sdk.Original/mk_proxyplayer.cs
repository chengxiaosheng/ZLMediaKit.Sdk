namespace ZLMediaKit.Sdk.Original
{
    /// <summary>
    /// MediaSource.close()回调事件
    /// </summary>
    /// <remarks>在选择关闭一个关联的MediaSource时，将会最终触发到该回调
    /// <para>你应该通过该事件调用mk_proxy_player_release函数并且释放其他资源</para>
    /// <para>如果你不调用mk_proxy_player_release函数，那么MediaSource.close()操作将无效</para></remarks>
    /// <param name="user_data">用户数据指针，通过mk_proxy_player_set_on_close函数设置</param>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void on_mk_proxy_player_close(System.IntPtr user_data);

    public class mk_proxyplayer
    {
        /// <summary>
        /// 创建一个代理播放器
        /// </summary>
        /// <param name="vhost">虚拟主机名，一般为__defaultVhost__</param>
        /// <param name="app">应用名</param>
        /// <param name="stream">流名</param>
        /// <param name="hls_enabled">是否生成hls</param>
        /// <param name="mp4_enabled">是否生成mp4</param>
        /// <returns>对象指针</returns>
        public static System.IntPtr mk_proxy_player_create(string vhost, string app, string stream, int hls_enabled, int mp4_enabled)
            => LibraryConst.IsWindows ? mk_proxyplayer_windows.mk_proxy_player_create(vhost, app, stream, hls_enabled, mp4_enabled) : mk_proxyplayer_unix.mk_proxy_player_create(vhost, app, stream, hls_enabled, mp4_enabled);

        /// <summary>
        /// 销毁代理播放器
        /// </summary>
        /// <param name="ctx">对象指针</param>
        public static  void mk_proxy_player_release(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_proxyplayer_windows.mk_proxy_player_release(ctx);
            else mk_proxyplayer_unix.mk_proxy_player_release(ctx);
        }

        /// <summary>
        /// 设置代理播放器配置选项
        /// </summary>
        /// <param name="ctx">代理播放器指针</param>
        /// <param name="key">配置项键,支持 net_adapter/rtp_type/rtsp_user/rtsp_pwd/protocol_timeout_ms/media_timeout_ms/beat_interval_ms/max_analysis_ms</param>
        /// <param name="val">配置项值,如果是整形，需要转换成统一转换成string</param>
        public static  void mk_proxy_player_set_option(System.IntPtr ctx,  string key,  string val)
        {
            if (LibraryConst.IsWindows) mk_proxyplayer_windows.mk_proxy_player_set_option(ctx,key,val);
            else mk_proxyplayer_unix.mk_proxy_player_set_option(ctx,key,val);
        }

        /// <summary>
        /// 开始播放
        /// </summary>
        /// <param name="ctx">对象指针</param>
        /// <param name="url">播放url,支持rtsp/rtmp</param>
        public static  void mk_proxy_player_play(System.IntPtr ctx,  string url)
        {
            if(LibraryConst.IsWindows) mk_proxyplayer_windows.mk_proxy_player_play(ctx, url);
            else mk_proxyplayer_unix.mk_proxy_player_play(ctx, url);
        }

        /// <summary>
        /// 监听MediaSource.close()事件
        /// </summary>
        /// <remarks>在选择关闭一个关联的MediaSource时，将会最终触发到该回调；你应该通过该事件调用mk_proxy_player_release函数并且释放其他资源</remarks>
        /// <param name="ctx">对象指针</param>
        /// <param name="cb">回调指针</param>
        /// <param name="user_data">用户数据指针</param>
        public static  void mk_proxy_player_set_on_close(System.IntPtr ctx, on_mk_proxy_player_close cb, System.IntPtr user_data)
        {
            if (LibraryConst.IsWindows) mk_proxyplayer_windows.mk_proxy_player_set_on_close(ctx, cb, user_data);
            else mk_proxyplayer_unix.mk_proxy_player_set_on_close(ctx, cb, user_data);
        }

        /// <summary>
        /// 获取总的观看人数
        /// </summary>
        /// <param name="ctx">对象指针</param>
        /// <returns>观看人数</returns>
        public static  int mk_proxy_player_total_reader_count(System.IntPtr ctx)
            => LibraryConst.IsWindows? mk_proxyplayer_windows.mk_proxy_player_total_reader_count(ctx) : mk_proxyplayer_unix.mk_proxy_player_total_reader_count(ctx);
        
    }

    internal class mk_proxyplayer_windows
    {
        /// Return Type: mk_proxy_player->void*
        ///vhost: char*
        ///app: char*
        ///stream: char*
        ///hls_enabled: int
        ///mp4_enabled: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_proxy_player_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_proxy_player_create([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string vhost, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string app, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream, int hls_enabled, int mp4_enabled);


        /// Return Type: void
        ///ctx: mk_proxy_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_proxy_player_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_proxy_player_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_proxy_player->void*
        ///key: char*
        ///val: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_proxy_player_set_option", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_proxy_player_set_option(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string val);


        /// Return Type: void
        ///ctx: mk_proxy_player->void*
        ///url: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_proxy_player_play", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_proxy_player_play(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string url);


        /// Return Type: void
        ///ctx: mk_proxy_player->void*
        ///cb: on_mk_proxy_player_close
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_proxy_player_set_on_close", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_proxy_player_set_on_close(System.IntPtr ctx, on_mk_proxy_player_close cb, System.IntPtr user_data);


        /// Return Type: int
        ///ctx: mk_proxy_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_proxy_player_total_reader_count", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_proxy_player_total_reader_count(System.IntPtr ctx);
    }

    internal class mk_proxyplayer_unix
    {
        /// Return Type: mk_proxy_player->void*
        ///vhost: char*
        ///app: char*
        ///stream: char*
        ///hls_enabled: int
        ///mp4_enabled: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_proxy_player_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_proxy_player_create([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string vhost, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string app, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream, int hls_enabled, int mp4_enabled);


        /// Return Type: void
        ///ctx: mk_proxy_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_proxy_player_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_proxy_player_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_proxy_player->void*
        ///key: char*
        ///val: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_proxy_player_set_option", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_proxy_player_set_option(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string val);


        /// Return Type: void
        ///ctx: mk_proxy_player->void*
        ///url: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_proxy_player_play", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_proxy_player_play(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string url);


        /// Return Type: void
        ///ctx: mk_proxy_player->void*
        ///cb: on_mk_proxy_player_close
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_proxy_player_set_on_close", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_proxy_player_set_on_close(System.IntPtr ctx, on_mk_proxy_player_close cb, System.IntPtr user_data);


        /// Return Type: int
        ///ctx: mk_proxy_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_proxy_player_total_reader_count", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_proxy_player_total_reader_count(System.IntPtr ctx);
    }
}
