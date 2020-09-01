namespace ZLMediaKit.Sdk.Original
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user_data">用户数据指针</param>
    /// <param name="code">错误代码，0代表成功</param>
    /// <param name="err_msg">错误提示</param>
    /// <param name="file_path">文件保存路径</param>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void on_mk_download_complete(System.IntPtr user_data, int code, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string err_msg, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string file_path);

    /// <summary>
    /// http请求结果回调
    /// </summary>
    /// <param name="user_data">用户数据指针</param>
    /// <param name="code">错误代码，0代表成功</param>
    /// <param name="err_msg">错误提示</param>
    /// <remarks>
    /// <list type="number">
    /// <item>在code == 0时代表本次http会话是完整的（收到了http回复）</item>
    /// <item>用户应该通过user_data获取到mk_http_requester对象</item>
    /// <item>然后通过mk_http_requester_get_response等函数获取相关回复数据</item>
    /// <item>在回调结束时，应该通过mk_http_requester_release函数销毁该对象</item>
    /// <item>或者调用mk_http_requester_clear函数后再复用该对象</item>
    /// </list>
    /// </remarks>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void on_mk_http_requester_complete(System.IntPtr user_data, int code, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string err_msg);

    public class mk_httpclient
    {
        /// <summary>
        /// 创建http[s]下载器
        /// </summary>
        /// <returns>下载器指针</returns>
        public static System.IntPtr mk_http_downloader_create()
            => LibraryConst.IsWindows ? mk_httpclient_windows.mk_http_downloader_create() : mk_httpclient_unix.mk_http_downloader_create();

        /// <summary>
        /// 销毁http[s]下载器
        /// </summary>
        /// <param name="ctx">下载器指针</param>
        public static void mk_http_downloader_release(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_httpclient_windows.mk_http_downloader_release(ctx);
            else mk_httpclient_unix.mk_http_downloader_release(ctx);
        }

        /// <summary>
        /// 开始http[s]下载
        /// </summary>
        /// <param name="ctx">下载器指针</param>
        /// <param name="url">http[s]下载url</param>
        /// <param name="file">文件保存路径</param>
        /// <param name="cb">回调函数</param>
        /// <param name="user_data">用户数据指针</param>
        public static void mk_http_downloader_start(System.IntPtr ctx,  string url,  string file, on_mk_download_complete cb, System.IntPtr user_data)
        {
            if (LibraryConst.IsWindows) mk_httpclient_windows.mk_http_downloader_start(ctx, url, file, cb, user_data);
            else mk_httpclient_unix.mk_http_downloader_start(ctx, url, file, cb, user_data);
        }

        /// <summary>
        /// 创建HttpRequester
        /// </summary>
        /// <returns></returns>
        public static System.IntPtr mk_http_requester_create()
            => LibraryConst.IsWindows ? mk_httpclient_windows.mk_http_requester_create() : mk_httpclient_unix.mk_http_requester_create();


        /// <summary>
        /// 在复用mk_http_requester对象时才需要用到此方法
        /// </summary>
        /// <param name="ctx"></param>
        public static void mk_http_requester_clear(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_httpclient_windows.mk_http_requester_clear(ctx);
            else mk_httpclient_unix.mk_http_requester_clear(ctx);
        }

        /// <summary>
        /// 销毁HttpRequester
        /// </summary>
        /// <remarks><list type="number"><item>如果调用了mk_http_requester_start函数且正在等待http回复，</item><item>也可以调用mk_http_requester_release方法取消本次http请求</item></list></remarks>
        /// <param name="ctx"></param>
        public static void mk_http_requester_release(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_httpclient_windows.mk_http_requester_release(ctx);
            else mk_httpclient_unix.mk_http_requester_release(ctx);
        }


        /// <summary>
        /// 设置HTTP方法，譬如GET/POST
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="method"></param>
        public static void mk_http_requester_set_method(System.IntPtr ctx,  string method)
        {
            if (LibraryConst.IsWindows) mk_httpclient_windows.mk_http_requester_set_method(ctx, method);
            else mk_httpclient_unix.mk_http_requester_set_method(ctx, method);
        }

        /// <summary>
        /// 批量设置设置HTTP头
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="header">譬如 {"Content-Type","text/html",NULL} 必须以NULL结尾</param>
        public static void mk_http_requester_set_header(System.IntPtr ctx, ref System.IntPtr header)
        {
            if (LibraryConst.IsWindows) mk_httpclient_windows.mk_http_requester_set_header(ctx,ref header);
            else mk_httpclient_unix.mk_http_requester_set_header(ctx,ref header);
        }

        /// <summary>
        /// 添加HTTP头
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="key">譬如Content-Type</param>
        /// <param name="value">譬如 text/html</param>
        /// <param name="force">如果已经存在该key，是否强制替换</param>
        public static void mk_http_requester_add_header(System.IntPtr ctx,  string key,  string value, int force)
        {
            if (LibraryConst.IsWindows) mk_httpclient_windows.mk_http_requester_add_header(ctx, key, value, force);
            else mk_httpclient_unix.mk_http_requester_add_header(ctx, key, value, force);
        }

        /// <summary>
        /// 设置消息体，
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="body">mk_http_body对象，通过mk_http_body_from_string等函数生成，使用完毕后请调用mk_http_body_release释放之</param>
        public static void mk_http_requester_set_body(System.IntPtr ctx, System.IntPtr body)
        {
            if (LibraryConst.IsWindows) mk_httpclient_windows.mk_http_requester_set_body(ctx, body);
            else mk_httpclient_unix.mk_http_requester_set_body(ctx, body);
        }

        /// <summary>
        /// 在收到HTTP回复后可调用该方法获取状态码
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns>譬如 200 OK</returns>
        public static System.IntPtr mk_http_requester_get_response_status(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_httpclient_windows.mk_http_requester_get_response_status(ctx) : mk_httpclient_unix.mk_http_requester_get_response_status(ctx);


        /// <summary>
        /// 在收到HTTP回复后可调用该方法获取响应HTTP头
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="key">HTTP头键名</param>
        /// <returns>HTTP头键值</returns>
        public static System.IntPtr mk_http_requester_get_response_header(System.IntPtr ctx,  string key)
            => LibraryConst.IsWindows ? mk_httpclient_windows.mk_http_requester_get_response_header(ctx, key) : mk_httpclient_unix.mk_http_requester_get_response_header(ctx, key);


        /// <summary>
        /// 在收到HTTP回复后可调用该方法获取响应HTTP body
        /// </summary>
        /// <param name="ctx">返回body长度,可以为null</param>
        /// <param name="length">body指针</param>
        /// <returns></returns>
        public static System.IntPtr mk_http_requester_get_response_body(System.IntPtr ctx, ref int length)
            => LibraryConst.IsWindows ? mk_httpclient_windows.mk_http_requester_get_response_body(ctx, ref length) : mk_httpclient_unix.mk_http_requester_get_response_body(ctx, ref length);


        /// <summary>
        /// 在收到HTTP回复后可调用该方法获取响应
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns>响应对象</returns>
        public static System.IntPtr mk_http_requester_get_response(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_httpclient_windows.mk_http_requester_get_response(ctx) : mk_httpclient_unix.mk_http_requester_get_response(ctx);

        /// <summary>
        /// 设置回调函数
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="cb">回调函数，不能为空</param>
        /// <param name="user_data">用户数据指针</param>
        public static void mk_http_requester_set_cb(System.IntPtr ctx, on_mk_http_requester_complete cb, System.IntPtr user_data)
        {
            if (LibraryConst.IsWindows) mk_httpclient_windows.mk_http_requester_set_cb(ctx, cb, user_data);
            else mk_httpclient_unix.mk_http_requester_set_cb(ctx, cb, user_data);
        }

        /// <summary>
        /// 开始url请求
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="url">请求url，支持http/https</param>
        /// <param name="timeout_second">最大超时时间</param>
        public static void mk_http_requester_start(System.IntPtr ctx,  string url, float timeout_second)
        {
            if (LibraryConst.IsWindows) mk_httpclient_windows.mk_http_requester_start(ctx, url, timeout_second);
            else mk_httpclient_unix.mk_http_requester_start(ctx, url, timeout_second);
        }
    }

    internal class mk_httpclient_windows
    {
        /// Return Type: mk_http_downloader->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_downloader_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_downloader_create();


        /// Return Type: void
        ///ctx: mk_http_downloader->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_downloader_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_downloader_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_http_downloader->void*
        ///url: char*
        ///file: char*
        ///cb: on_mk_download_complete
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_downloader_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_downloader_start(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string url, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string file, on_mk_download_complete cb, System.IntPtr user_data);


        /// Return Type: mk_http_requester->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_requester_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_requester_create();


        /// Return Type: void
        ///ctx: mk_http_requester->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_requester_clear", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_requester_clear(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_http_requester->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_requester_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_requester_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_http_requester->void*
        ///method: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_requester_set_method", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_requester_set_method(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string method);


        /// Return Type: void
        ///ctx: mk_http_requester->void*
        ///header: char**
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_requester_set_header", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_requester_set_header(System.IntPtr ctx, ref System.IntPtr header);


        /// Return Type: void
        ///ctx: mk_http_requester->void*
        ///key: char*
        ///value: char*
        ///force: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_requester_add_header", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_requester_add_header(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string value, int force);


        /// Return Type: void
        ///ctx: mk_http_requester->void*
        ///body: mk_http_body->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_requester_set_body", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_requester_set_body(System.IntPtr ctx, System.IntPtr body);


        /// Return Type: char*
        ///ctx: mk_http_requester->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_requester_get_response_status", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_requester_get_response_status(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_http_requester->void*
        ///key: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_requester_get_response_header", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_requester_get_response_header(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key);


        /// Return Type: char*
        ///ctx: mk_http_requester->void*
        ///length: int*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_requester_get_response_body", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_requester_get_response_body(System.IntPtr ctx, ref int length);


        /// Return Type: mk_parser->void*
        ///ctx: mk_http_requester->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_requester_get_response", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_requester_get_response(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_http_requester->void*
        ///cb: on_mk_http_requester_complete
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_requester_set_cb", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_requester_set_cb(System.IntPtr ctx, on_mk_http_requester_complete cb, System.IntPtr user_data);


        /// Return Type: void
        ///ctx: mk_http_requester->void*
        ///url: char*
        ///timeout_second: float
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_requester_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_requester_start(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string url, float timeout_second);
    }

    internal class mk_httpclient_unix
    {
        /// Return Type: mk_http_downloader->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_downloader_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_downloader_create();


        /// Return Type: void
        ///ctx: mk_http_downloader->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_downloader_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_downloader_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_http_downloader->void*
        ///url: char*
        ///file: char*
        ///cb: on_mk_download_complete
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_downloader_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_downloader_start(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string url, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string file, on_mk_download_complete cb, System.IntPtr user_data);


        /// Return Type: mk_http_requester->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_requester_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_requester_create();


        /// Return Type: void
        ///ctx: mk_http_requester->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_requester_clear", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_requester_clear(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_http_requester->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_requester_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_requester_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_http_requester->void*
        ///method: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_requester_set_method", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_requester_set_method(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string method);


        /// Return Type: void
        ///ctx: mk_http_requester->void*
        ///header: char**
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_requester_set_header", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_requester_set_header(System.IntPtr ctx, ref System.IntPtr header);


        /// Return Type: void
        ///ctx: mk_http_requester->void*
        ///key: char*
        ///value: char*
        ///force: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_requester_add_header", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_requester_add_header(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string value, int force);


        /// Return Type: void
        ///ctx: mk_http_requester->void*
        ///body: mk_http_body->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_requester_set_body", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_requester_set_body(System.IntPtr ctx, System.IntPtr body);


        /// Return Type: char*
        ///ctx: mk_http_requester->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_requester_get_response_status", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_requester_get_response_status(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_http_requester->void*
        ///key: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_requester_get_response_header", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_requester_get_response_header(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key);


        /// Return Type: char*
        ///ctx: mk_http_requester->void*
        ///length: int*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_requester_get_response_body", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_requester_get_response_body(System.IntPtr ctx, ref int length);


        /// Return Type: mk_parser->void*
        ///ctx: mk_http_requester->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_requester_get_response", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_requester_get_response(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_http_requester->void*
        ///cb: on_mk_http_requester_complete
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_requester_set_cb", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_requester_set_cb(System.IntPtr ctx, on_mk_http_requester_complete cb, System.IntPtr user_data);


        /// Return Type: void
        ///ctx: mk_http_requester->void*
        ///url: char*
        ///timeout_second: float
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_requester_start", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_requester_start(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string url, float timeout_second);
    }
}
