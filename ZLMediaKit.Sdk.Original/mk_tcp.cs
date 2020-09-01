using System.ComponentModel;

namespace ZLMediaKit.Sdk.Original
{

    /// <summary>
    /// 收到mk_tcp_session创建对象
    /// </summary>
    /// <param name="server_port">服务器端口号</param>
    /// <param name="session">会话处理对象</param>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_tcp_session_create(ushort server_port, System.IntPtr session);

    /// <summary>
    /// 收到客户端发过来的数据
    /// </summary>
    /// <param name="server_port">服务器端口号</param>
    /// <param name="session">会话处理对象</param>
    /// <param name="data">数据指针</param>
    /// <param name="len">数据长度</param>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_tcp_session_data(ushort server_port, System.IntPtr session, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string data, int len);

    /// <summary>
    /// 每隔2秒的定时器，用于管理超时等任务
    /// </summary>
    /// <param name="server_port">服务器端口号</param>
    /// <param name="session">会话处理对象</param>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_tcp_session_manager(ushort server_port, System.IntPtr session);

    /// <summary>
    /// 一般由于客户端断开tcp触发
    /// </summary>
    /// <param name="server_port">服务器端口号</param>
    /// <param name="session">会话处理对象</param>
    /// <param name="code">错误代码</param>
    /// <param name="msg">错误提示</param>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_tcp_session_disconnect(ushort server_port, System.IntPtr session, int code, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string msg);

    /// <summary>
    /// tcp客户端连接服务器成功或失败回调
    /// </summary>
    /// <param name="client">tcp客户端</param>
    /// <param name="code">0为连接成功，否则为失败原因</param>
    /// <param name="msg">连接失败错误提示</param>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_tcp_client_connect(System.IntPtr client, int code, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string msg);

    /// <summary>
    /// tcp客户端与tcp服务器之间断开回调
    /// </summary>
    /// <param name="client">tcp客户端</param>
    /// <param name="code">错误代码</param>
    /// <param name="msg">错误提示</param>
    /// <remarks>一般是eof事件导致</remarks>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_tcp_client_disconnect(System.IntPtr client, int code, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string msg);

    /// <summary>
    /// 收到tcp服务器发来的数据
    /// </summary>
    /// <param name="client">tcp客户端</param>
    /// <param name="data">数据指针</param>
    /// <param name="len">数据长度</param>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_tcp_client_data(System.IntPtr client, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string data, int len);

    /// <summary>
    /// 每隔2秒的定时器，用于管理超时等任务
    /// </summary>
    /// <param name="client">tcp客户端</param>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_tcp_client_manager(System.IntPtr client);

    public enum mk_tcp_type
    {

        /// <summary>
        /// 普通的tcp
        /// </summary>
        [Description("普通的tcp")]
        mk_type_tcp = 0,
        /// <summary>
        /// ssl类型的tcp
        /// </summary>
        [Description("ssl类型的tcp")]
        mk_type_ssl = 1,

        /// <summary>
        /// 基于websocket的连接
        /// </summary>
        [Description("基于websocket的连接")]
        mk_type_ws = 2,

        /// <summary>
        /// 基于ssl websocket的连接
        /// </summary>
        [Description("基于ssl websocket的连接")]
        mk_type_wss = 3,
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct mk_tcp_session_events
    {
        /// <summary>
        /// <inheritdoc cref="_on_mk_tcp_session_create"/>
        /// <seealso cref="_on_mk_tcp_session_create"/> 
        /// </summary>
        public _on_mk_tcp_session_create on_mk_tcp_session_create;

        /// <summary>
        /// <inheritdoc cref="_on_mk_tcp_session_data"/>
        /// <seealso cref="_on_mk_tcp_session_data"/>
        /// </summary>
        public _on_mk_tcp_session_data on_mk_tcp_session_data;

        /// <summary>
        /// <inheritdoc cref="_on_mk_tcp_session_manager"/>
        /// <seealso cref="_on_mk_tcp_session_manager"/>
        /// </summary>
        public _on_mk_tcp_session_manager on_mk_tcp_session_manager;

        /// <summary>
        /// <inheritdoc cref="_on_mk_tcp_session_disconnect"/>
        /// <seealso cref="_on_mk_tcp_session_disconnect"/>
        /// </summary>
        public _on_mk_tcp_session_disconnect on_mk_tcp_session_disconnect;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct mk_tcp_client_events
    {

        /// <summary>
        /// <inheritdoc cref="_on_mk_tcp_client_connect"/>
        /// <seealso cref="_on_mk_tcp_client_connect"/>
        /// </summary>
        public _on_mk_tcp_client_connect AnonymousMember1;

        /// <summary>
        /// <inheritdoc cref="_on_mk_tcp_client_disconnect"/>
        /// <seealso cref="_on_mk_tcp_client_disconnect"/>
        /// </summary>
        public _on_mk_tcp_client_disconnect AnonymousMember2;

        /// <summary>
        /// <inheritdoc cref="_on_mk_tcp_client_data"/>
        /// <seealso cref="_on_mk_tcp_client_data"/>
        /// </summary>
        public _on_mk_tcp_client_data AnonymousMember3;

        /// <summary>
        /// <inheritdoc cref="_on_mk_tcp_client_manager"/>
        /// <seealso cref="_on_mk_tcp_client_manager"/>
        /// </summary>
        public _on_mk_tcp_client_manager AnonymousMember4;
    }



    public class mk_tcp
    {

        public static System.IntPtr mk_sock_info_peer_ip(System.IntPtr ctx, System.IntPtr buf)
            => LibraryConst.IsWindows ? mk_tcp_windows.mk_sock_info_peer_ip(ctx, buf) : mk_tcp_unix.mk_sock_info_peer_ip(ctx, buf);


        public static System.IntPtr mk_sock_info_local_ip(System.IntPtr ctx, System.IntPtr buf)
            => LibraryConst.IsWindows ? mk_tcp_windows.mk_sock_info_local_ip(ctx, buf) : mk_tcp_unix.mk_sock_info_local_ip(ctx, buf);


        public static ushort mk_sock_info_peer_port(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_tcp_windows.mk_sock_info_peer_port(ctx) : mk_tcp_unix.mk_sock_info_peer_port(ctx);



        public static ushort mk_sock_info_local_port(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_tcp_windows.mk_sock_info_local_port(ctx) : mk_tcp_unix.mk_sock_info_local_port(ctx);

        //mk_tcp_session对象转换成mk_sock_info对象后再获取网络相关信息
        // mk_tcp_session_peer_ip(x,buf) mk_sock_info_peer_ip(mk_tcp_session_get_sock_info(x),buf)
        // mk_tcp_session_local_ip(x,buf) mk_sock_info_local_ip(mk_tcp_session_get_sock_info(x),buf)
        // mk_tcp_session_peer_port(x) mk_sock_info_peer_port(mk_tcp_session_get_sock_info(x))
        // mk_tcp_session_local_port(x) mk_sock_info_local_port(mk_tcp_session_get_sock_info(x))

        public static System.IntPtr mk_tcp_session_peer_ip(System.IntPtr ctx, System.IntPtr buf) => mk_sock_info_peer_ip(mk_tcp_session_get_sock_info(ctx), buf);
        public static System.IntPtr mk_tcp_session_local_ip(System.IntPtr ctx, System.IntPtr buf) => mk_sock_info_local_ip(mk_tcp_session_get_sock_info(ctx), buf);
        public static ushort mk_tcp_session_peer_port(System.IntPtr ctx) => mk_sock_info_peer_port(mk_tcp_session_get_sock_info(ctx));
        public static ushort mk_tcp_session_local_port(System.IntPtr ctx) => mk_sock_info_local_port(mk_tcp_session_get_sock_info(ctx));

        //mk_tcp_client对象转换成mk_sock_info对象后再获取网络相关信息
        //mk_tcp_client_peer_ip(x,buf) mk_sock_info_peer_ip(mk_tcp_client_get_sock_info(x),buf)
        //mk_tcp_client_local_ip(x,buf) mk_sock_info_local_ip(mk_tcp_client_get_sock_info(x),buf)
        //mk_tcp_client_peer_port(x) mk_sock_info_peer_port(mk_tcp_client_get_sock_info(x))
        //mk_tcp_client_local_port(x) mk_sock_info_local_port(mk_tcp_client_get_sock_info(x))

        public static System.IntPtr mk_tcp_client_peer_ip(System.IntPtr ctx, System.IntPtr buf) => mk_sock_info_peer_ip(mk_tcp_client_get_sock_info(ctx), buf);
        public static System.IntPtr mk_tcp_client_local_ip(System.IntPtr ctx, System.IntPtr buf) => mk_sock_info_local_ip(mk_tcp_client_get_sock_info(ctx), buf);
        public static ushort mk_tcp_client_peer_port(System.IntPtr ctx) => mk_sock_info_peer_port(mk_tcp_client_get_sock_info(ctx));
        public static ushort mk_tcp_client_local_port(System.IntPtr ctx) => mk_sock_info_local_port(mk_tcp_client_get_sock_info(ctx));

        public static System.IntPtr mk_tcp_session_get_sock_info(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_tcp_windows.mk_tcp_session_get_sock_info(ctx) : mk_tcp_unix.mk_tcp_session_get_sock_info(ctx);



        public static void mk_tcp_session_shutdown(System.IntPtr ctx, int err, string err_msg)
        {
            if (LibraryConst.IsWindows) mk_tcp_windows.mk_tcp_session_shutdown(ctx, err, err_msg);
            else mk_tcp_unix.mk_tcp_session_shutdown(ctx, err, err_msg);
        }


        public static void mk_tcp_session_send(System.IntPtr ctx, string data, int len)
        {
            if (LibraryConst.IsWindows) mk_tcp_windows.mk_tcp_session_send(ctx, data, len);
            else mk_tcp_unix.mk_tcp_session_send(ctx, data, len);
        }

        public static void mk_tcp_session_send_safe(System.IntPtr ctx, string data, int len)
        {
            if (LibraryConst.IsWindows) mk_tcp_windows.mk_tcp_session_send_safe(ctx, data, len);
            else mk_tcp_unix.mk_tcp_session_send_safe(ctx, data, len);
        }

        /// <summary>
        /// tcp会话对象附着用户数据
        /// </summary>
        /// <param name="session">会话对象</param>
        /// <param name="user_data">用户数据指针</param>
        /// <remarks>该函数只对mk_tcp_server_server_start启动的服务类型有效</remarks>
        public static void mk_tcp_session_set_user_data(System.IntPtr session, System.IntPtr user_data)
        {
            if (LibraryConst.IsWindows) mk_tcp_windows.mk_tcp_session_set_user_data(session, user_data);
            else mk_tcp_unix.mk_tcp_session_set_user_data(session, user_data);
        }

        /// <summary>
        /// 获取tcp会话对象上附着的用户数据
        /// </summary>
        /// <param name="session">tcp会话对象</param>
        /// <returns>用户数据指针</returns>
        /// <remarks>该函数只对mk_tcp_server_server_start启动的服务类型有效</remarks>
        public static System.IntPtr mk_tcp_session_get_user_data(System.IntPtr session)
             => LibraryConst.IsWindows ? mk_tcp_windows.mk_tcp_session_get_user_data(session) : mk_tcp_unix.mk_tcp_session_get_user_data(session);

        /// <summary>
        /// 开启tcp服务器
        /// </summary>
        /// <param name="port">监听端口号，0则为随机</param>
        /// <param name="type">服务器类型</param>
        /// <returns></returns>
        public static ushort mk_tcp_server_start(ushort port, mk_tcp_type type)
             => LibraryConst.IsWindows ? mk_tcp_windows.mk_tcp_server_start(port, type) : mk_tcp_unix.mk_tcp_server_start(port, type);


        /// <summary>
        /// 监听tcp服务器事件
        /// </summary>
        /// <param name="events"></param>
        public static void mk_tcp_server_events_listen(ref mk_tcp_session_events events)
        {
            if (LibraryConst.IsWindows) mk_tcp_windows.mk_tcp_server_events_listen(ref events);
            else mk_tcp_unix.mk_tcp_server_events_listen(ref events);

        }

        /// <summary>
        /// 获取基类指针以便获取其网络相关信息
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static System.IntPtr mk_tcp_client_get_sock_info(System.IntPtr ctx)
             => LibraryConst.IsWindows ? mk_tcp_windows.mk_tcp_client_get_sock_info(ctx) : mk_tcp_unix.mk_tcp_client_get_sock_info(ctx);

        /// <summary>
        /// 创建tcp客户端
        /// </summary>
        /// <param name="events">回调函数结构体</param>
        /// <param name="type">客户端类型</param>
        /// <returns>客户端对象</returns>
        public static System.IntPtr mk_tcp_client_create(ref mk_tcp_client_events events, mk_tcp_type type)
             => LibraryConst.IsWindows ? mk_tcp_windows.mk_tcp_client_create(ref events, type) : mk_tcp_unix.mk_tcp_client_create(ref events, type);


        /// <summary>
        /// 释放tcp客户端
        /// </summary>
        /// <param name="ctx">客户端对象</param>
        public static void mk_tcp_client_release(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_tcp_windows.mk_tcp_client_release(ctx);
            else mk_tcp_unix.mk_tcp_client_release(ctx);
        }

        /// <summary>
        /// 发起连接
        /// </summary>
        /// <param name="ctx">客户端对象</param>
        /// <param name="host">服务器ip或域名</param>
        /// <param name="port">服务器端口号</param>
        /// <param name="time_out_sec">超时时间</param>
        public static void mk_tcp_client_connect(System.IntPtr ctx,string host, ushort port, float time_out_sec)
        {
            if (LibraryConst.IsWindows) mk_tcp_windows.mk_tcp_client_connect(ctx,host, port, time_out_sec);
            else mk_tcp_unix.mk_tcp_client_connect(ctx, host, port, time_out_sec);
        }

        /// <summary>
        /// 非线程安全的发送数据
        /// </summary>
        /// <param name="ctx">客户端对象</param>
        /// <param name="data">数据指针</param>
        /// <param name="len">数据长度，等于0时，内部通过strlen获取</param>
        /// <remarks>开发者如果能确保在本对象网络线程内，可以调用此此函数</remarks>
        public static void mk_tcp_client_send(System.IntPtr ctx,string data, int len)
        {
            if (LibraryConst.IsWindows) mk_tcp_windows.mk_tcp_client_send(ctx, data, len);
            else mk_tcp_unix.mk_tcp_client_send(ctx, data, len);
        }

        /// <summary>
        /// 切换到本对象的网络线程后再发送数据
        /// </summary>
        /// <param name="ctx">客户端对象</param>
        /// <param name="data">数据指针</param>
        /// <param name="len">数据长度，等于0时，内部通过strlen获取</param>
        public static void mk_tcp_client_send_safe(System.IntPtr ctx, string data, int len)
        {
            if (LibraryConst.IsWindows) mk_tcp_windows.mk_tcp_client_send_safe(ctx, data, len);
            else mk_tcp_unix.mk_tcp_client_send_safe(ctx, data, len);
        }

        /// <summary>
        /// 客户端附着用户数据
        /// </summary>
        /// <param name="ctx">客户端对象</param>
        /// <param name="user_data">用户数据指针</param>
        public static void mk_tcp_client_set_user_data(System.IntPtr ctx, System.IntPtr user_data)
        {
            if (LibraryConst.IsWindows) mk_tcp_windows.mk_tcp_client_set_user_data(ctx, user_data);
            else mk_tcp_unix.mk_tcp_client_set_user_data(ctx, user_data);
        }

        /// <summary>
        /// 获取客户端对象上附着的用户数据
        /// </summary>
        /// <param name="ctx">客户端对象</param>
        /// <returns>用户数据指针</returns>
        public static System.IntPtr mk_tcp_client_get_user_data(System.IntPtr ctx)
             => LibraryConst.IsWindows? mk_tcp_windows.mk_tcp_client_get_user_data(ctx) : mk_tcp_unix.mk_tcp_client_get_user_data(ctx);


    }

    internal class mk_tcp_windows
    {


        /// Return Type: char*
        ///ctx: mk_sock_info->void*
        ///buf: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_sock_info_peer_ip", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_sock_info_peer_ip(System.IntPtr ctx, System.IntPtr buf);


        /// Return Type: char*
        ///ctx: mk_sock_info->void*
        ///buf: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_sock_info_local_ip", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_sock_info_local_ip(System.IntPtr ctx, System.IntPtr buf);


        /// Return Type: uint16_t->unsigned short
        ///ctx: mk_sock_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_sock_info_peer_port", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_sock_info_peer_port(System.IntPtr ctx);


        /// Return Type: uint16_t->unsigned short
        ///ctx: mk_sock_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_sock_info_local_port", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_sock_info_local_port(System.IntPtr ctx);


        /// Return Type: mk_sock_info->void*
        ///ctx: mk_tcp_session->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_tcp_session_get_sock_info", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_tcp_session_get_sock_info(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_tcp_session->void*
        ///err: int
        ///err_msg: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_tcp_session_shutdown", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_session_shutdown(System.IntPtr ctx, int err, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string err_msg);


        /// Return Type: void
        ///ctx: mk_tcp_session->void*
        ///data: char*
        ///len: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_tcp_session_send", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_session_send(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string data, int len);


        /// Return Type: void
        ///ctx: mk_tcp_session->void*
        ///data: char*
        ///len: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_tcp_session_send_safe", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_session_send_safe(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string data, int len);


        /// Return Type: void
        ///session: mk_tcp_session->void*
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_tcp_session_set_user_data", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_session_set_user_data(System.IntPtr session, System.IntPtr user_data);


        /// Return Type: void*
        ///session: mk_tcp_session->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_tcp_session_get_user_data", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_tcp_session_get_user_data(System.IntPtr session);


        /// Return Type: uint16_t->unsigned short
        ///port: uint16_t->unsigned short
        ///type: mk_tcp_type->Anonymous_8dcde228_a997_414b_995c_158d28816974
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_tcp_server_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_tcp_server_start(ushort port, mk_tcp_type type);


        /// Return Type: void
        ///events: mk_tcp_session_events*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_tcp_server_events_listen", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_server_events_listen(ref mk_tcp_session_events events);


        /// Return Type: mk_sock_info->void*
        ///ctx: mk_tcp_client->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_tcp_client_get_sock_info", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_tcp_client_get_sock_info(System.IntPtr ctx);


        /// Return Type: mk_tcp_client->void*
        ///events: mk_tcp_client_events*
        ///type: mk_tcp_type->Anonymous_8dcde228_a997_414b_995c_158d28816974
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_tcp_client_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_tcp_client_create(ref mk_tcp_client_events events, mk_tcp_type type);


        /// Return Type: void
        ///ctx: mk_tcp_client->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_tcp_client_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_client_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_tcp_client->void*
        ///host: char*
        ///port: uint16_t->unsigned short
        ///time_out_sec: float
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_tcp_client_connect", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_client_connect(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string host, ushort port, float time_out_sec);


        /// Return Type: void
        ///ctx: mk_tcp_client->void*
        ///data: char*
        ///len: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_tcp_client_send", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_client_send(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string data, int len);


        /// Return Type: void
        ///ctx: mk_tcp_client->void*
        ///data: char*
        ///len: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_tcp_client_send_safe", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_client_send_safe(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string data, int len);


        /// Return Type: void
        ///ctx: mk_tcp_client->void*
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_tcp_client_set_user_data", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_client_set_user_data(System.IntPtr ctx, System.IntPtr user_data);


        /// Return Type: void*
        ///ctx: mk_tcp_client->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_tcp_client_get_user_data", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_tcp_client_get_user_data(System.IntPtr ctx);


    }


    internal class mk_tcp_unix
    {


        /// Return Type: char*
        ///ctx: mk_sock_info->void*
        ///buf: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_sock_info_peer_ip", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_sock_info_peer_ip(System.IntPtr ctx, System.IntPtr buf);


        /// Return Type: char*
        ///ctx: mk_sock_info->void*
        ///buf: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_sock_info_local_ip", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_sock_info_local_ip(System.IntPtr ctx, System.IntPtr buf);


        /// Return Type: uint16_t->unsigned short
        ///ctx: mk_sock_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_sock_info_peer_port", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_sock_info_peer_port(System.IntPtr ctx);


        /// Return Type: uint16_t->unsigned short
        ///ctx: mk_sock_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_sock_info_local_port", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_sock_info_local_port(System.IntPtr ctx);


        /// Return Type: mk_sock_info->void*
        ///ctx: mk_tcp_session->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_tcp_session_get_sock_info", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_tcp_session_get_sock_info(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_tcp_session->void*
        ///err: int
        ///err_msg: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_tcp_session_shutdown", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_session_shutdown(System.IntPtr ctx, int err, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string err_msg);


        /// Return Type: void
        ///ctx: mk_tcp_session->void*
        ///data: char*
        ///len: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_tcp_session_send", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_session_send(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string data, int len);


        /// Return Type: void
        ///ctx: mk_tcp_session->void*
        ///data: char*
        ///len: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_tcp_session_send_safe", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_session_send_safe(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string data, int len);


        /// Return Type: void
        ///session: mk_tcp_session->void*
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_tcp_session_set_user_data", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_session_set_user_data(System.IntPtr session, System.IntPtr user_data);


        /// Return Type: void*
        ///session: mk_tcp_session->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_tcp_session_get_user_data", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_tcp_session_get_user_data(System.IntPtr session);


        /// Return Type: uint16_t->unsigned short
        ///port: uint16_t->unsigned short
        ///type: mk_tcp_type->Anonymous_8dcde228_a997_414b_995c_158d28816974
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_tcp_server_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_tcp_server_start(ushort port, mk_tcp_type type);


        /// Return Type: void
        ///events: mk_tcp_session_events*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_tcp_server_events_listen", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_server_events_listen(ref mk_tcp_session_events events);


        /// Return Type: mk_sock_info->void*
        ///ctx: mk_tcp_client->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_tcp_client_get_sock_info", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_tcp_client_get_sock_info(System.IntPtr ctx);


        /// Return Type: mk_tcp_client->void*
        ///events: mk_tcp_client_events*
        ///type: mk_tcp_type->Anonymous_8dcde228_a997_414b_995c_158d28816974
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_tcp_client_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_tcp_client_create(ref mk_tcp_client_events events, mk_tcp_type type);


        /// Return Type: void
        ///ctx: mk_tcp_client->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_tcp_client_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_client_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_tcp_client->void*
        ///host: char*
        ///port: uint16_t->unsigned short
        ///time_out_sec: float
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_tcp_client_connect", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_client_connect(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string host, ushort port, float time_out_sec);


        /// Return Type: void
        ///ctx: mk_tcp_client->void*
        ///data: char*
        ///len: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_tcp_client_send", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_client_send(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string data, int len);


        /// Return Type: void
        ///ctx: mk_tcp_client->void*
        ///data: char*
        ///len: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_tcp_client_send_safe", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_client_send_safe(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string data, int len);


        /// Return Type: void
        ///ctx: mk_tcp_client->void*
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_tcp_client_set_user_data", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_tcp_client_set_user_data(System.IntPtr ctx, System.IntPtr user_data);


        /// Return Type: void*
        ///ctx: mk_tcp_client->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_tcp_client_get_user_data", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_tcp_client_get_user_data(System.IntPtr ctx);


    }
}
