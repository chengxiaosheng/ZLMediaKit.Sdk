namespace ZLMediaKit.Sdk.Original
{

    /// <summary>
    /// ZLM配置
    /// </summary>
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct mk_config
    {
        /// <summary>
        /// 线程数
        /// </summary>
        internal int thread_num;

        /// <summary>
        /// 日志级别,支持0~4
        /// </summary>
        internal int log_level;

        /// <summary>
        /// 文件日志保存路径,路径可以不存在(内部可以创建文件夹)，设置为NULL关闭日志输出至文件
        /// </summary>
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        internal string log_file_path;

        /// <summary>
        /// 文件日志保存天数,设置为0关闭日志文件
        /// </summary>
        internal int log_file_days;

        /// <summary>
        /// 配置文件是内容还是路径
        /// </summary>
        internal int ini_is_path;

        /// <summary>
        /// 配置文件内容或路径，可以为NULL,如果该文件不存在，那么将导出默认配置至该文件
        /// </summary>
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        internal string ini;

        /// <summary>
        /// ssl证书是内容还是路径
        /// </summary>
        internal int ssl_is_path;

        /// <summary>
        /// ssl证书内容或路径，可以为NULL
        /// </summary>
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        internal string ssl;

        /// <summary>
        /// 证书密码，可以为NULL
        /// </summary>
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        internal string ssl_pwd;
    }

    public class mk_common
    {

        public static  void mk_env_init(ref mk_config cfg)
        {
            if (LibraryConst.IsWindows) mk_common_windows.mk_env_init(ref cfg);
            else mk_common_unix.mk_env_init(ref cfg);
        }


        public static  void mk_stop_all_server()
        {
            if (LibraryConst.IsWindows) mk_common_windows.mk_stop_all_server();
            else mk_common_unix.mk_stop_all_server();
        }

        /// <summary>
        /// 基础类型参数版本的mk_env_init，为了方便其他语言调用
        /// </summary>
        /// <param name="thread_num"><inheritdoc cref="mk_config.thread_num"/></param>
        /// <param name="log_level"><inheritdoc cref="mk_config.log_level"/></param>
        /// <param name="log_file_path"><inheritdoc cref="mk_config.log_file_path"/></param>
        /// <param name="log_file_days"><inheritdoc cref="mk_config.log_file_days"/></param>
        /// <param name="ini_is_path"><inheritdoc cref="mk_config.ini_is_path"/></param>
        /// <param name="ini"><inheritdoc cref="mk_config.ini"/></param>
        /// <param name="ssl_is_path"><inheritdoc cref="mk_config.ssl_is_path"/></param>
        /// <param name="ssl"><inheritdoc cref="mk_config.ssl"/></param>
        /// <param name="ssl_pwd"><inheritdoc cref="mk_config.ssl_pwd"/></param>
        public static  void mk_env_init1(int thread_num, int log_level,  string log_file_path, int log_file_days, int ini_is_path, string ini, int ssl_is_path, string ssl, string ssl_pwd)
        {
            if (LibraryConst.IsWindows) mk_common_windows.mk_env_init1(thread_num,log_level,log_file_path,log_file_days,ini_is_path,ini,ssl_is_path,ssl,ssl_pwd);
            else mk_common_unix.mk_env_init1(thread_num, log_level, log_file_path, log_file_days, ini_is_path, ini, ssl_is_path, ssl,ssl_pwd);
        }

        /// <summary>
        /// 设置配置项
        /// </summary>
        /// <param name="key">配置项名</param>
        /// <param name="val">配置项值</param>
        public static  void mk_set_option(string key, string val)
        {
            if (LibraryConst.IsWindows) mk_common_windows.mk_set_option(key,val);
            else mk_common_unix.mk_set_option(key, val);
        }

        /// <summary>
        /// 获取配置项的值
        /// </summary>
        /// <param name="key">配置项名</param>
        /// <returns></returns>
        public static System.IntPtr mk_get_option(string key)
            => LibraryConst.IsWindows ? mk_common_windows.mk_get_option(key) : mk_common_unix.mk_get_option(key);

        /// <summary>
        /// 创建http[s]服务器
        /// </summary>
        /// <param name="port">http监听端口，推荐80，传入0则随机分配</param>
        /// <param name="ssl">是否为ssl类型服务器</param>
        /// <returns></returns>
        public static  ushort mk_http_server_start(ushort port, int ssl)
            => LibraryConst.IsWindows ? mk_common_windows.mk_http_server_start(port, ssl) : mk_common_unix.mk_http_server_start(port, ssl);


        /// <summary>
        /// 创建rtsp[s]服务器
        /// </summary>
        /// <param name="port">rtsp监听端口，推荐554，传入0则随机分配</param>
        /// <param name="ssl">是否为ssl类型服务器</param>
        /// <returns></returns>
        public static  ushort mk_rtsp_server_start(ushort port, int ssl)
            => LibraryConst.IsWindows ? mk_common_windows.mk_rtsp_server_start(port, ssl) : mk_common_unix.mk_rtsp_server_start(port, ssl);

        /// <summary>
        /// 创建rtmp[s]服务器
        /// </summary>
        /// <param name="port">rtmp监听端口，推荐1935，传入0则随机分配</param>
        /// <param name="ssl">是否为ssl类型服务器</param>
        /// <returns>0:失败,非0:端口号</returns>
        public static  ushort mk_rtmp_server_start(ushort port, int ssl)
            => LibraryConst.IsWindows ? mk_common_windows.mk_rtmp_server_start(port, ssl) : mk_common_unix.mk_rtmp_server_start(port, ssl);


        /// <summary>
        /// 创建rtp服务器
        /// </summary>
        /// <param name="port">rtp监听端口(包括udp/tcp)</param>
        /// <returns>0:失败,非0:端口号</returns>
        public static  ushort mk_rtp_server_start(ushort port)
            => LibraryConst.IsWindows ? mk_common_windows.mk_rtp_server_start(port) : mk_common_unix.mk_rtp_server_start(port);


        /// <summary>
        /// 创建shell服务器
        /// </summary>
        /// <param name="port">shell监听端口</param>
        /// <returns>0:失败,非0:端口号</returns>
        public static  ushort mk_shell_server_start(ushort port)
            => LibraryConst.IsWindows ? mk_common_windows.mk_shell_server_start(port) : mk_common_unix.mk_shell_server_start(port);

    }

    internal class mk_common_windows
    {


        /// Return Type: void
        ///cfg: mk_config*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_env_init", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_env_init(ref mk_config cfg);


        /// Return Type: void
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_stop_all_server", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_stop_all_server();


        /// Return Type: void
        ///thread_num: int
        ///log_level: int
        ///log_file_path: char*
        ///log_file_days: int
        ///ini_is_path: int
        ///ini: char*
        ///ssl_is_path: int
        ///ssl: char*
        ///ssl_pwd: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_env_init1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_env_init1(int thread_num, int log_level, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string log_file_path, int log_file_days, int ini_is_path, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string ini, int ssl_is_path, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string ssl, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string ssl_pwd);


        /// Return Type: void
        ///key: char*
        ///val: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_set_option", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_set_option([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string val);


        /// Return Type: char*
        ///key: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_get_option", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_get_option([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key);


        /// Return Type: uint16_t->unsigned short
        ///port: uint16_t->unsigned short
        ///ssl: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_server_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_http_server_start(ushort port, int ssl);


        /// Return Type: uint16_t->unsigned short
        ///port: uint16_t->unsigned short
        ///ssl: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_rtsp_server_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_rtsp_server_start(ushort port, int ssl);


        /// Return Type: uint16_t->unsigned short
        ///port: uint16_t->unsigned short
        ///ssl: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_rtmp_server_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_rtmp_server_start(ushort port, int ssl);


        /// Return Type: uint16_t->unsigned short
        ///port: uint16_t->unsigned short
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_rtp_server_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_rtp_server_start(ushort port);


        /// Return Type: uint16_t->unsigned short
        ///port: uint16_t->unsigned short
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_shell_server_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_shell_server_start(ushort port);

    }

    internal class mk_common_unix
    {


        /// Return Type: void
        ///cfg: mk_config*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_env_init", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_env_init(ref mk_config cfg);


        /// Return Type: void
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_stop_all_server", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_stop_all_server();


        /// Return Type: void
        ///thread_num: int
        ///log_level: int
        ///log_file_path: char*
        ///log_file_days: int
        ///ini_is_path: int
        ///ini: char*
        ///ssl_is_path: int
        ///ssl: char*
        ///ssl_pwd: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_env_init1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_env_init1(int thread_num, int log_level, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string log_file_path, int log_file_days, int ini_is_path, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string ini, int ssl_is_path, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string ssl, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string ssl_pwd);


        /// Return Type: void
        ///key: char*
        ///val: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_set_option", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_set_option([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string val);


        /// Return Type: char*
        ///key: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_get_option", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_get_option([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key);


        /// Return Type: uint16_t->unsigned short
        ///port: uint16_t->unsigned short
        ///ssl: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_server_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_http_server_start(ushort port, int ssl);


        /// Return Type: uint16_t->unsigned short
        ///port: uint16_t->unsigned short
        ///ssl: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_rtsp_server_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_rtsp_server_start(ushort port, int ssl);


        /// Return Type: uint16_t->unsigned short
        ///port: uint16_t->unsigned short
        ///ssl: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_rtmp_server_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_rtmp_server_start(ushort port, int ssl);


        /// Return Type: uint16_t->unsigned short
        ///port: uint16_t->unsigned short
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_rtp_server_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_rtp_server_start(ushort port);


        /// Return Type: uint16_t->unsigned short
        ///port: uint16_t->unsigned short
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_shell_server_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_shell_server_start(ushort port);

    }
}
