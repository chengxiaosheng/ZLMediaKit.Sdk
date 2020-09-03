namespace ZLMediaKit.Sdk.Original
{


    /// Return Type: void
    ///regist: int
    ///sender: mk_media_source->void*
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_media_changed(int regist, System.IntPtr sender);

    /// Return Type: void
    ///url_info: mk_media_info->void*
    ///invoker: mk_publish_auth_invoker->void*
    ///sender: mk_sock_info->void*
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_media_publish(System.IntPtr url_info, System.IntPtr invoker, System.IntPtr sender);

    /// Return Type: void
    ///url_info: mk_media_info->void*
    ///invoker: mk_auth_invoker->void*
    ///sender: mk_sock_info->void*
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_media_play(System.IntPtr url_info, System.IntPtr invoker, System.IntPtr sender);

    /// Return Type: void
    ///url_info: mk_media_info->void*
    ///sender: mk_sock_info->void*
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_media_not_found(System.IntPtr url_info, System.IntPtr sender);

    /// Return Type: void
    ///sender: mk_media_source->void*
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_media_no_reader(System.IntPtr sender);

    /// Return Type: void
    ///parser: mk_parser->void*
    ///invoker: mk_http_response_invoker->void*
    ///consumed: int*
    ///sender: mk_sock_info->void*
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_http_request(System.IntPtr parser, System.IntPtr invoker, ref int consumed, System.IntPtr sender);

    /// Return Type: void
    ///parser: mk_parser->void*
    ///path: char*
    ///is_dir: int
    ///invoker: mk_http_access_path_invoker->void*
    ///sender: mk_sock_info->void*
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_http_access(System.IntPtr parser, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string path, int is_dir, System.IntPtr invoker, System.IntPtr sender);

    /// Return Type: void
    ///parser: mk_parser->void*
    ///path: char*
    ///sender: mk_sock_info->void*
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_http_before_access(System.IntPtr parser, System.IntPtr path, System.IntPtr sender);

    /// Return Type: void
    ///url_info: mk_media_info->void*
    ///invoker: mk_rtsp_get_realm_invoker->void*
    ///sender: mk_sock_info->void*
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_rtsp_get_realm(System.IntPtr url_info, System.IntPtr invoker, System.IntPtr sender);

    /// Return Type: void
    ///url_info: mk_media_info->void*
    ///realm: char*
    ///user_name: char*
    ///must_no_encrypt: int
    ///invoker: mk_rtsp_auth_invoker->void*
    ///sender: mk_sock_info->void*
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_rtsp_auth(System.IntPtr url_info, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string realm, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string user_name, int must_no_encrypt, System.IntPtr invoker, System.IntPtr sender);

    /// Return Type: void
    ///mp4: mk_mp4_info->void*
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_record_mp4(System.IntPtr mp4);

    /// Return Type: void
    ///user_name: char*
    ///passwd: char*
    ///invoker: mk_auth_invoker->void*
    ///sender: mk_sock_info->void*
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_shell_login([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string user_name, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string passwd, System.IntPtr invoker, System.IntPtr sender);

    /// Return Type: void
    ///url_info: mk_media_info->void*
    ///total_bytes: uint64_t->unsigned int
    ///total_seconds: uint64_t->unsigned int
    ///is_player: int
    ///sender: mk_sock_info->void*
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void _on_mk_flow_report(System.IntPtr url_info, uint total_bytes, uint total_seconds, int is_player, System.IntPtr sender);

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct mk_events
    {

        /// _on_mk_media_changed
        public _on_mk_media_changed on_mk_media_changed;

        /// _on_mk_media_publish
        public _on_mk_media_publish on_mk_media_publish;

        /// _on_mk_media_play
        public _on_mk_media_play on_mk_media_play;

        /// _on_mk_media_not_found
        public _on_mk_media_not_found on_mk_media_not_found;

        /// _on_mk_media_no_reader
        public _on_mk_media_no_reader on_mk_media_no_reader;

        /// _on_mk_http_request
        public _on_mk_http_request on_mk_http_request;

        /// _on_mk_http_access
        public _on_mk_http_access on_mk_http_access;

        /// _on_mk_http_before_access
        public _on_mk_http_before_access on_mk_http_before_access;

        /// _on_mk_rtsp_get_realm
        public _on_mk_rtsp_get_realm on_mk_rtsp_get_realm;

        /// _on_mk_rtsp_auth
        public _on_mk_rtsp_auth on_mk_rtsp_auth;

        /// _on_mk_record_mp4
        public _on_mk_record_mp4 on_mk_record_mp4;

        /// _on_mk_shell_login
        public _on_mk_shell_login on_mk_shell_login;

        /// _on_mk_flow_report
        public _on_mk_flow_report on_mk_flow_report;
    }

    public class mk_event
    {
        public static void mk_events_listen(ref mk_events events)
        {
            if (LibraryConst.IsWindows) mk_events_windows.mk_events_listen(ref events);
            else mk_events_unix.mk_events_listen(ref events);
        }
    }

    internal class mk_events_windows
    {
        /// Return Type: void
        ///events: mk_events*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_events_listen", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_events_listen(ref mk_events events);
    }

    internal class mk_events_unix
    {
        /// Return Type: void
        ///events: mk_events*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_events_listen", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_events_listen(ref mk_events events);
    }

}
