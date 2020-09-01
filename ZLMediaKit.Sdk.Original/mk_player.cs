namespace ZLMediaKit.Sdk.Original
{
    /// <summary>
    /// 播放结果或播放中断事件的回调
    /// </summary>
    /// <param name="user_data">用户数据指针</param>
    /// <param name="err_code">错误代码，0为成功</param>
    /// <param name="err_msg">错误提示</param>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void on_mk_play_event(System.IntPtr user_data, int err_code, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string err_msg);


    /// <summary>
    /// 收到音视频数据回调
    /// </summary>
    /// <param name="user_data">用户数据指针</param>
    /// <param name="track_type">0：视频，1：音频</param>
    /// <param name="codec_id"> 0：H264，1：H265，2：AAC 3.G711A 4.G711U 5.OPUS</param>
    /// <param name="data">数据指针</param>
    /// <param name="len">数据长度</param>
    /// <param name="dts">解码时间戳，单位毫秒</param>
    /// <param name="pts">显示时间戳，单位毫秒</param>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void on_mk_play_data(System.IntPtr user_data, int track_type, int codec_id, System.IntPtr data, int len, uint dts, uint pts);
    public class mk_player
    {
        /// <summary>
        /// 创建一个播放器,支持rtmp[s]/rtsp[s]
        /// </summary>
        /// <returns>播放器指针</returns>
        public static System.IntPtr mk_player_create()
            => LibraryConst.IsWindows ? mk_player_windows.mk_player_create() : mk_player_unix.mk_player_create();

        /// <summary>
        /// 销毁播放器
        /// </summary>
        /// <param name="ctx">播放器指针</param>
        public static  void mk_player_release(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_player_windows.mk_player_release(ctx);
            else mk_player_unix.mk_player_release(ctx);
        }

        /// <summary>
        /// 设置播放器配置选项   
        /// </summary>
        /// <param name="ctx">播放器指针</param>
        /// <param name="key">配置项键,支持 net_adapter/rtp_type/rtsp_user/rtsp_pwd/protocol_timeout_ms/media_timeout_ms/beat_interval_ms/max_analysis_ms</param>
        /// <param name="val">配置项值,如果是整形，需要转换成统一转换成string</param>
        public static  void mk_player_set_option(System.IntPtr ctx,  string key,  string val)
        {
            if (LibraryConst.IsWindows) mk_player_windows.mk_player_set_option(ctx,key,val);
            else mk_player_unix.mk_player_set_option(ctx,key,val);
        }

        /// <summary>
        /// 开始播放url
        /// </summary>
        /// <param name="ctx">播放器指针</param>
        /// <param name="url">rtsp[s]/rtmp[s] url</param>
        public static  void mk_player_play(System.IntPtr ctx,  string url)
        {
            if (LibraryConst.IsWindows) mk_player_windows.mk_player_play(ctx, url);
            else mk_player_unix.mk_player_play(ctx, url);
        }

        /// <summary>
        /// 暂停或恢复播放，仅对点播有用
        /// </summary>
        /// <param name="ctx">播放器指针</param>
        /// <param name="pause">1:暂停播放，0：恢复播放</param>
        public static  void mk_player_pause(System.IntPtr ctx, int pause)
        {
            if (LibraryConst.IsWindows) mk_player_windows.mk_player_pause(ctx, pause);
            else mk_player_unix.mk_player_pause(ctx, pause);
        }

        /// <summary>
        /// 设置点播进度条
        /// </summary>
        /// <param name="ctx">对象指针  </param>
        /// <param name="progress">取值范围未 0.0～1.0</param>
        public static  void mk_player_seekto(System.IntPtr ctx, float progress)
        {
            if (LibraryConst.IsWindows) mk_player_windows.mk_player_seekto(ctx, progress);
            else mk_player_unix.mk_player_seekto(ctx, progress);
        }

        /// <summary>
        /// 设置播放器开启播放结果回调函数
        /// </summary>
        /// <param name="ctx">播放器指针</param>
        /// <param name="cb">回调函数指针,设置null立即取消回调</param>
        /// <param name="user_data">用户数据指针</param>
        public static  void mk_player_set_on_result(System.IntPtr ctx, on_mk_play_event cb, System.IntPtr user_data)
        {
            if (LibraryConst.IsWindows) mk_player_windows.mk_player_set_on_result(ctx, cb, user_data);
            else mk_player_unix.mk_player_set_on_result(ctx, cb, user_data);
        }

        /// <summary>
        /// 设置播放被异常中断的回调
        /// </summary>
        /// <param name="ctx">播放器指针</param>
        /// <param name="cb">回调函数指针,设置null立即取消回调</param>
        /// <param name="user_data">用户数据指针</param>
        public static  void mk_player_set_on_shutdown(System.IntPtr ctx, on_mk_play_event cb, System.IntPtr user_data)
        {
            if (LibraryConst.IsWindows) mk_player_windows.mk_player_set_on_shutdown(ctx, cb, user_data);
            else mk_player_unix.mk_player_set_on_shutdown(ctx, cb, user_data);
        }

        /// <summary>
        /// 设置音视频数据回调函数
        /// </summary>
        /// <param name="ctx">播放器指针</param>
        /// <param name="cb">回调函数指针,设置null立即取消回调</param>
        /// <param name="user_data">用户数据指针</param>
        public static  void mk_player_set_on_data(System.IntPtr ctx, on_mk_play_data cb, System.IntPtr user_data)
        {
            if (LibraryConst.IsWindows) mk_player_windows.mk_player_set_on_data(ctx, cb, user_data);
            else mk_player_unix.mk_player_set_on_data(ctx, cb, user_data);
        }

        /// <summary>
        /// 获取视频codec_id -1：不存在 0：H264，1：H265，2：AAC 3.G711A 4.G711U
        /// </summary>
        /// <param name="ctx">播放器指针</param>
        /// <returns></returns>
        public static  int mk_player_video_codecId(System.IntPtr ctx) 
            => LibraryConst.IsWindows ? mk_player_windows.mk_player_video_codecId(ctx) : mk_player_unix.mk_player_video_codecId(ctx);


        /// <summary>
        /// 获取视频宽度
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static  int mk_player_video_width(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_player_windows.mk_player_video_width(ctx) : mk_player_unix.mk_player_video_width(ctx);


        /// <summary>
        /// 获取视频高度
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static  int mk_player_video_height(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_player_windows.mk_player_video_height(ctx) : mk_player_unix.mk_player_video_height(ctx);


        /// <summary>
        /// 获取视频帧率
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static  int mk_player_video_fps(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_player_windows.mk_player_video_fps(ctx) : mk_player_unix.mk_player_video_fps(ctx);


        /// <summary>
        /// 获取音频codec_id -1：不存在 0：H264，1：H265，2：AAC 3.G711A 4.G711U
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static  int mk_player_audio_codecId(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_player_windows.mk_player_audio_codecId(ctx) : mk_player_unix.mk_player_audio_codecId(ctx);


        /// <summary>
        /// 获取音频采样率
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static  int mk_player_audio_samplerate(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_player_windows.mk_player_audio_samplerate(ctx) : mk_player_unix.mk_player_audio_samplerate(ctx);


        /// <summary>
        /// 获取音频采样位数，一般为16
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static  int mk_player_audio_bit(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_player_windows.mk_player_audio_bit(ctx) : mk_player_unix.mk_player_audio_bit(ctx);


        /// <summary>
        /// 获取音频通道数
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static  int mk_player_audio_channel(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_player_windows.mk_player_audio_channel(ctx) : mk_player_unix.mk_player_audio_channel(ctx);


        /// <summary>
        /// 获取点播节目时长，如果是直播返回0，否则返回秒数
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static  float mk_player_duration(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_player_windows.mk_player_duration(ctx) : mk_player_unix.mk_player_duration(ctx);

        /// <summary>
        /// 获取点播播放进度，取值范围未 0.0～1.0
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static  float mk_player_progress(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_player_windows.mk_player_progress(ctx) : mk_player_unix.mk_player_progress(ctx);

        /// <summary>
        /// 获取丢包率，rtsp时有效
        /// </summary>
        /// <param name="ctx">对象指针</param>
        /// <param name="track_type">0：视频，1：音频</param>
        /// <returns></returns>
        public static  float mk_player_loss_rate(System.IntPtr ctx, int track_type)
            => LibraryConst.IsWindows ? mk_player_windows.mk_player_loss_rate(ctx, track_type) : mk_player_unix.mk_player_loss_rate(ctx, track_type);

    }

    internal class mk_player_windows
    {
        /// Return Type: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_player_create();


        /// Return Type: void
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_player_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_player->void*
        ///key: char*
        ///val: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_set_option", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_player_set_option(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string val);


        /// Return Type: void
        ///ctx: mk_player->void*
        ///url: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_play", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_player_play(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string url);


        /// Return Type: void
        ///ctx: mk_player->void*
        ///pause: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_pause", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_player_pause(System.IntPtr ctx, int pause);


        /// Return Type: void
        ///ctx: mk_player->void*
        ///progress: float
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_seekto", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_player_seekto(System.IntPtr ctx, float progress);


        /// Return Type: void
        ///ctx: mk_player->void*
        ///cb: on_mk_play_event
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_set_on_result", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_player_set_on_result(System.IntPtr ctx, on_mk_play_event cb, System.IntPtr user_data);


        /// Return Type: void
        ///ctx: mk_player->void*
        ///cb: on_mk_play_event
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_set_on_shutdown", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_player_set_on_shutdown(System.IntPtr ctx, on_mk_play_event cb, System.IntPtr user_data);


        /// Return Type: void
        ///ctx: mk_player->void*
        ///cb: on_mk_play_data
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_set_on_data", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_player_set_on_data(System.IntPtr ctx, on_mk_play_data cb, System.IntPtr user_data);


        /// Return Type: int
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_video_codecId", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_player_video_codecId(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_video_width", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_player_video_width(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_video_height", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_player_video_height(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_video_fps", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_player_video_fps(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_audio_codecId", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_player_audio_codecId(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_audio_samplerate", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_player_audio_samplerate(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_audio_bit", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_player_audio_bit(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_audio_channel", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_player_audio_channel(System.IntPtr ctx);


        /// Return Type: float
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_duration", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern float mk_player_duration(System.IntPtr ctx);


        /// Return Type: float
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_progress", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern float mk_player_progress(System.IntPtr ctx);


        /// Return Type: float
        ///ctx: mk_player->void*
        ///track_type: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_player_loss_rate", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern float mk_player_loss_rate(System.IntPtr ctx, int track_type);
    }

    internal class mk_player_unix
    {
        /// Return Type: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_player_create();


        /// Return Type: void
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_player_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_player->void*
        ///key: char*
        ///val: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_set_option", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_player_set_option(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string val);


        /// Return Type: void
        ///ctx: mk_player->void*
        ///url: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_play", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_player_play(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string url);


        /// Return Type: void
        ///ctx: mk_player->void*
        ///pause: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_pause", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_player_pause(System.IntPtr ctx, int pause);


        /// Return Type: void
        ///ctx: mk_player->void*
        ///progress: float
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_seekto", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_player_seekto(System.IntPtr ctx, float progress);


        /// Return Type: void
        ///ctx: mk_player->void*
        ///cb: on_mk_play_event
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_set_on_result", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_player_set_on_result(System.IntPtr ctx, on_mk_play_event cb, System.IntPtr user_data);


        /// Return Type: void
        ///ctx: mk_player->void*
        ///cb: on_mk_play_event
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_set_on_shutdown", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_player_set_on_shutdown(System.IntPtr ctx, on_mk_play_event cb, System.IntPtr user_data);


        /// Return Type: void
        ///ctx: mk_player->void*
        ///cb: on_mk_play_data
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_set_on_data", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_player_set_on_data(System.IntPtr ctx, on_mk_play_data cb, System.IntPtr user_data);


        /// Return Type: int
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_video_codecId", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_player_video_codecId(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_video_width", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_player_video_width(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_video_height", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_player_video_height(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_video_fps", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_player_video_fps(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_audio_codecId", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_player_audio_codecId(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_audio_samplerate", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_player_audio_samplerate(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_audio_bit", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_player_audio_bit(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_audio_channel", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_player_audio_channel(System.IntPtr ctx);


        /// Return Type: float
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_duration", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern float mk_player_duration(System.IntPtr ctx);


        /// Return Type: float
        ///ctx: mk_player->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_progress", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern float mk_player_progress(System.IntPtr ctx);


        /// Return Type: float
        ///ctx: mk_player->void*
        ///track_type: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_player_loss_rate", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern float mk_player_loss_rate(System.IntPtr ctx, int track_type);
    }
}
