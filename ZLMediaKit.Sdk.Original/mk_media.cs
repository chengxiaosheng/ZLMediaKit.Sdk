namespace ZLMediaKit.Sdk.Original
{
    /// <summary>
    /// MediaSource.close()回调事件
    /// </summary>
    /// <param name="user_data">用户数据指针，通过mk_media_set_on_close函数设置</param>
    /// <remarks>在选择关闭一个关联的MediaSource时，将会最终触发到该回调<para>你应该通过该事件调用mk_media_release函数并且释放其他资源</para><para>如果你不调用mk_media_release函数，那么MediaSource.close()操作将无效</para></remarks>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void on_mk_media_close(System.IntPtr user_data);

    /// <summary>
    /// 收到客户端的seek请求时触发该回调
    /// </summary>
    /// <param name="user_data">用户数据指针,通过mk_media_set_on_seek设置</param>
    /// <param name="stamp_ms">seek至的时间轴位置，单位毫秒</param>
    /// <returns>1代表将处理seek请求，0代表忽略该请求</returns>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate int on_mk_media_seek(System.IntPtr user_data, uint stamp_ms);

    /// <summary>
    /// 生成的MediaSource注册或注销事件
    /// </summary>
    /// <param name="user_data">设置回调时的用户数据指针</param>
    /// <param name="sender">生成的MediaSource对象</param>
    /// <param name="regist">1为注册事件，0为注销事件</param>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void on_mk_media_source_regist(System.IntPtr user_data, System.IntPtr sender, int regist);

    public class mk_media
    {
        /// <summary>
        /// 创建一个媒体源
        /// </summary>
        /// <param name="vhost">虚拟主机名，一般为__defaultVhost__</param>
        /// <param name="app">应用名，推荐为live</param>
        /// <param name="stream">流id，例如camera</param>
        /// <param name="duration">时长(单位秒)，直播则为0</param>
        /// <param name="rtsp_enabled">是否启用rtsp协议</param>
        /// <param name="rtmp_enabled">是否启用rtmp协议</param>
        /// <param name="hls_enabled">是否生成hls</param>
        /// <param name="mp4_enabled">是否生成mp4</param>
        /// <returns>对象指针</returns>
        public static System.IntPtr mk_media_create(string vhost, string app, string stream, float duration, int rtsp_enabled, int rtmp_enabled, int hls_enabled, int mp4_enabled)
            => LibraryConst.IsWindows ? mk_media_windows.mk_media_create(vhost, app, stream, duration, rtsp_enabled, rtmp_enabled, hls_enabled, mp4_enabled)
            : mk_media_unix.mk_media_create(vhost, app, stream, duration, rtsp_enabled, rtmp_enabled, hls_enabled, mp4_enabled);

        /// <summary>
        /// 销毁媒体源
        /// </summary>
        /// <param name="ctx">对象指针</param>
        public static void mk_media_release(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_media_windows.mk_media_release(ctx);
            else mk_media_unix.mk_media_release(ctx);
        }

        /// <summary>
        /// 添加视频轨道  
        /// </summary>
        /// <param name="ctx">对象指针</param>
        /// <param name="track_id">0:CodecH264/1:CodecH265</param>
        /// <param name="width">视频宽度</param>
        /// <param name="height">视频高度</param>
        /// <param name="fps">视频fps</param>
        public static void mk_media_init_video(System.IntPtr ctx, int track_id, int width, int height, int fps)
        {
            if (LibraryConst.IsWindows) mk_media_windows.mk_media_init_video(ctx, track_id, width, height, fps);
            else mk_media_unix.mk_media_init_video(ctx, track_id, width, height, fps);
        }

        /// <summary>
        /// 添加音频轨道
        /// </summary>
        /// <param name="ctx">对象指针</param>
        /// <param name="track_id">2:CodecAAC/3:CodecG711A/4:CodecG711U/5:OPUS</param>
        /// <param name="sample_rate">通道数</param>
        /// <param name="channels">采样位数，只支持16</param>
        /// <param name="sample_bit">采样率</param>
        public static void mk_media_init_audio(System.IntPtr ctx, int track_id, int sample_rate, int channels, int sample_bit)
        {
            if (LibraryConst.IsWindows) mk_media_windows.mk_media_init_audio(ctx, track_id, sample_rate, channels, sample_bit);
            else mk_media_unix.mk_media_init_audio(ctx, track_id, sample_rate, channels, sample_bit);
        }

        /// <summary>
        /// 初始化h264/h265/aac完毕后调用此函数
        /// </summary>
        /// <param name="ctx"></param>
        /// <remarks>在单track(只有音频或视频)时，因为ZLMediaKit不知道后续是否还要添加track，所以会多等待3秒钟<para>如果产生的流是单Track类型，请调用此函数以便加快流生成速度，当然不调用该函数，影响也不大(会多等待3秒)</para></remarks>
        public static void mk_media_init_complete(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_media_windows.mk_media_init_complete(ctx);
            else mk_media_unix.mk_media_init_complete(ctx);
        }

        /// <summary>
        /// 输入单帧H264视频，帧起始字节00 00 01,00 00 00 01均可
        /// </summary>
        /// <param name="ctx">对象指针</param>
        /// <param name="data">单帧H264数据</param>
        /// <param name="len">单帧H264数据字节数</param>
        /// <param name="dts">解码时间戳，单位毫秒</param>
        /// <param name="pts">播放时间戳，单位毫秒</param>
        public static void mk_media_input_h264(System.IntPtr ctx, System.IntPtr data, int len, uint dts, uint pts)
        {
            if (LibraryConst.IsWindows) mk_media_windows.mk_media_input_h264(ctx, data, len, dts, pts);
            else mk_media_unix.mk_media_input_h264(ctx, data, len, dts, pts);
        }

        /// <summary>
        /// 输入单帧H265视频，帧起始字节00 00 01,00 00 00 01均可
        /// </summary>
        /// <param name="ctx">对象指针</param>
        /// <param name="data">单帧H265数据</param>
        /// <param name="len">单帧H265数据字节数</param>
        /// <param name="dts">解码时间戳，单位毫秒</param>
        /// <param name="pts">播放时间戳，单位毫秒</param>
        public static void mk_media_input_h265(System.IntPtr ctx, System.IntPtr data, int len, uint dts, uint pts)
        {
            if (LibraryConst.IsWindows) mk_media_windows.mk_media_input_h265(ctx, data, len, dts, pts);
            else mk_media_unix.mk_media_input_h265(ctx, data, len, dts, pts);
        }

        /// <summary>
        /// 输入单帧AAC音频(单独指定adts头)
        /// </summary>
        /// <param name="ctx">对象指针</param>
        /// <param name="data">不包含adts头的单帧AAC数据</param>
        /// <param name="len">单帧AAC数据字节数</param>
        /// <param name="dts">时间戳，毫秒</param>
        /// <param name="adts">adts头，可以为null</param>
        public static void mk_media_input_aac(System.IntPtr ctx, System.IntPtr data, int len, uint dts, System.IntPtr adts)
        {
            if (LibraryConst.IsWindows) mk_media_windows.mk_media_input_aac(ctx, data, len, dts, adts);
            else mk_media_unix.mk_media_input_aac(ctx, data, len, dts, adts);
        }

        /// <summary>
        /// 输入单帧PCM音频,启用ENABLE_FAAC编译时，该函数才有效
        /// </summary>
        /// <param name="ctx">对象指针</param>
        /// <param name="data">单帧PCM数据</param>
        /// <param name="len">单帧PCM数据字节数</param>
        /// <param name="pts">时间戳，毫秒</param>
        public static void mk_media_input_pcm(System.IntPtr ctx, System.IntPtr data, int len, uint pts)
        {
            if (LibraryConst.IsWindows) mk_media_windows.mk_media_input_pcm(ctx, data, len, pts);
            else mk_media_unix.mk_media_input_pcm(ctx, data, len, pts);
        }

        /// <summary>
        /// 输入单帧OPUS/G711音频帧
        /// </summary>
        /// <param name="ctx">对象指针</param>
        /// <param name="data">单帧音频数据</param>
        /// <param name="len">单帧音频数据字节数</param>
        /// <param name="dts">时间戳，毫秒</param>
        public static void mk_media_input_audio(System.IntPtr ctx, System.IntPtr data, int len, uint dts)
        {
            if (LibraryConst.IsWindows) mk_media_windows.mk_media_input_audio(ctx, data, len, dts);
            else mk_media_unix.mk_media_input_audio(ctx, data, len, dts);
        }

        /// <summary>
        /// 监听MediaSource.close()事件
        /// </summary>
        /// <param name="ctx">对象指针</param>
        /// <param name="cb">回调指针</param>
        /// <param name="user_data">用户数据指针</param>
        /// <remarks>在选择关闭一个关联的MediaSource时，将会最终触发到该回调<para>你应该通过该事件调用mk_media_release函数并且释放其他资源</para></remarks>
        public static void mk_media_set_on_close(System.IntPtr ctx, on_mk_media_close cb, System.IntPtr user_data)
        {
            if (LibraryConst.IsWindows) mk_media_windows.mk_media_set_on_close(ctx, cb, user_data);
            else mk_media_unix.mk_media_set_on_close(ctx, cb, user_data);
        }

        /// <summary>
        /// 监听播放器seek请求事件
        /// </summary>
        /// <param name="ctx">对象指针</param>
        /// <param name="cb">回调指针</param>
        /// <param name="user_data">用户数据指针</param>
        public static void mk_media_set_on_seek(System.IntPtr ctx, on_mk_media_seek cb, System.IntPtr user_data)
        {
            if (LibraryConst.IsWindows) mk_media_windows.mk_media_set_on_seek(ctx, cb, user_data);
            else mk_media_unix.mk_media_set_on_seek(ctx, cb, user_data);
        }

        /// <summary>
        /// 获取总的观看人数
        /// </summary>
        /// <param name="ctx">对象指针</param>
        /// <returns>观看人数</returns>
        public static int mk_media_total_reader_count(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_media_windows.mk_media_total_reader_count(ctx) : mk_media_unix.mk_media_total_reader_count(ctx);


        /// <summary>
        /// 设置MediaSource注册或注销事件回调函数
        /// </summary>
        /// <param name="ctx">对象指针</param>
        /// <param name="cb">回调指针</param>
        /// <param name="user_data">用户数据指针</param>
        public static void mk_media_set_on_regist(System.IntPtr ctx, on_mk_media_source_regist cb, System.IntPtr user_data)
        {
            if (LibraryConst.IsWindows) mk_media_windows.mk_media_set_on_regist(ctx, cb, user_data);
            else mk_media_unix.mk_media_set_on_regist(ctx, cb, user_data);
        }

    }
    internal class mk_media_windows
    {
        /// Return Type: mk_media->void*
        ///vhost: char*
        ///app: char*
        ///stream: char*
        ///duration: float
        ///rtsp_enabled: int
        ///rtmp_enabled: int
        ///hls_enabled: int
        ///mp4_enabled: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_create([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string vhost, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string app, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream, float duration, int rtsp_enabled, int rtmp_enabled, int hls_enabled, int mp4_enabled);


        /// Return Type: void
        ///ctx: mk_media->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///track_id: int
        ///width: int
        ///height: int
        ///fps: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_init_video", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_init_video(System.IntPtr ctx, int track_id, int width, int height, int fps);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///track_id: int
        ///sample_rate: int
        ///channels: int
        ///sample_bit: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_init_audio", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_init_audio(System.IntPtr ctx, int track_id, int sample_rate, int channels, int sample_bit);


        /// Return Type: void
        ///ctx: mk_media->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_init_complete", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_init_complete(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///data: void*
        ///len: int
        ///dts: uint32_t->unsigned int
        ///pts: uint32_t->unsigned int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_input_h264", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_input_h264(System.IntPtr ctx, System.IntPtr data, int len, uint dts, uint pts);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///data: void*
        ///len: int
        ///dts: uint32_t->unsigned int
        ///pts: uint32_t->unsigned int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_input_h265", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_input_h265(System.IntPtr ctx, System.IntPtr data, int len, uint dts, uint pts);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///data: void*
        ///len: int
        ///dts: uint32_t->unsigned int
        ///adts: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_input_aac", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_input_aac(System.IntPtr ctx, System.IntPtr data, int len, uint dts, System.IntPtr adts);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///data: void*
        ///len: int
        ///pts: uint32_t->unsigned int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_input_pcm", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_input_pcm(System.IntPtr ctx, System.IntPtr data, int len, uint pts);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///data: void*
        ///len: int
        ///dts: uint32_t->unsigned int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_input_audio", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_input_audio(System.IntPtr ctx, System.IntPtr data, int len, uint dts);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///cb: on_mk_media_close
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_set_on_close", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_set_on_close(System.IntPtr ctx, on_mk_media_close cb, System.IntPtr user_data);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///cb: on_mk_media_seek
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_set_on_seek", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_set_on_seek(System.IntPtr ctx, on_mk_media_seek cb, System.IntPtr user_data);


        /// Return Type: int
        ///ctx: mk_media->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_total_reader_count", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_media_total_reader_count(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///cb: on_mk_media_source_regist
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_set_on_regist", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_set_on_regist(System.IntPtr ctx, on_mk_media_source_regist cb, System.IntPtr user_data);

    }
    internal class mk_media_unix
    {
        /// Return Type: mk_media->void*
        ///vhost: char*
        ///app: char*
        ///stream: char*
        ///duration: float
        ///rtsp_enabled: int
        ///rtmp_enabled: int
        ///hls_enabled: int
        ///mp4_enabled: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_create([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string vhost, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string app, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream, float duration, int rtsp_enabled, int rtmp_enabled, int hls_enabled, int mp4_enabled);


        /// Return Type: void
        ///ctx: mk_media->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///track_id: int
        ///width: int
        ///height: int
        ///fps: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_init_video", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_init_video(System.IntPtr ctx, int track_id, int width, int height, int fps);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///track_id: int
        ///sample_rate: int
        ///channels: int
        ///sample_bit: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_init_audio", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_init_audio(System.IntPtr ctx, int track_id, int sample_rate, int channels, int sample_bit);


        /// Return Type: void
        ///ctx: mk_media->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_init_complete", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_init_complete(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///data: void*
        ///len: int
        ///dts: uint32_t->unsigned int
        ///pts: uint32_t->unsigned int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_input_h264", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_input_h264(System.IntPtr ctx, System.IntPtr data, int len, uint dts, uint pts);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///data: void*
        ///len: int
        ///dts: uint32_t->unsigned int
        ///pts: uint32_t->unsigned int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_input_h265", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_input_h265(System.IntPtr ctx, System.IntPtr data, int len, uint dts, uint pts);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///data: void*
        ///len: int
        ///dts: uint32_t->unsigned int
        ///adts: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_input_aac", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_input_aac(System.IntPtr ctx, System.IntPtr data, int len, uint dts, System.IntPtr adts);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///data: void*
        ///len: int
        ///pts: uint32_t->unsigned int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_input_pcm", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_input_pcm(System.IntPtr ctx, System.IntPtr data, int len, uint pts);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///data: void*
        ///len: int
        ///dts: uint32_t->unsigned int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_input_audio", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_input_audio(System.IntPtr ctx, System.IntPtr data, int len, uint dts);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///cb: on_mk_media_close
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_set_on_close", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_set_on_close(System.IntPtr ctx, on_mk_media_close cb, System.IntPtr user_data);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///cb: on_mk_media_seek
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_set_on_seek", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_set_on_seek(System.IntPtr ctx, on_mk_media_seek cb, System.IntPtr user_data);


        /// Return Type: int
        ///ctx: mk_media->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_total_reader_count", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_media_total_reader_count(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_media->void*
        ///cb: on_mk_media_source_regist
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_set_on_regist", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_set_on_regist(System.IntPtr ctx, on_mk_media_source_regist cb, System.IntPtr user_data);

    }
}
