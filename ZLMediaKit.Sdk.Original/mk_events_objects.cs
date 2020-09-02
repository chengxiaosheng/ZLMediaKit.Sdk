namespace ZLMediaKit.Sdk.Original
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user_data"></param>
    /// <param name="ctx"></param>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void on_mk_media_source_find_cb(System.IntPtr user_data, System.IntPtr ctx);

    public class mk_events_objects
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static uint mk_mp4_info_get_start_time(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_mp4_info_get_start_time(ctx) : mk_events_objects_unix.mk_mp4_info_get_start_time(ctx);


        public static uint mk_mp4_info_get_time_len(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_mp4_info_get_time_len(ctx) : mk_events_objects_unix.mk_mp4_info_get_time_len(ctx);



        public static uint mk_mp4_info_get_file_size(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_mp4_info_get_file_size(ctx) : mk_events_objects_unix.mk_mp4_info_get_file_size(ctx);



        public static System.IntPtr mk_mp4_info_get_file_path(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_mp4_info_get_file_path(ctx) : mk_events_objects_unix.mk_mp4_info_get_file_path(ctx);



        public static System.IntPtr mk_mp4_info_get_file_name(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_mp4_info_get_file_name(ctx) : mk_events_objects_unix.mk_mp4_info_get_file_name(ctx);



        public static System.IntPtr mk_mp4_info_get_folder(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_mp4_info_get_folder(ctx) : mk_events_objects_unix.mk_mp4_info_get_folder(ctx);



        public static System.IntPtr mk_mp4_info_get_url(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_mp4_info_get_url(ctx) : mk_events_objects_unix.mk_mp4_info_get_url(ctx);



        public static System.IntPtr mk_mp4_info_get_vhost(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_mp4_info_get_vhost(ctx) : mk_events_objects_unix.mk_mp4_info_get_vhost(ctx);



        public static System.IntPtr mk_mp4_info_get_app(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_mp4_info_get_app(ctx) : mk_events_objects_unix.mk_mp4_info_get_app(ctx);



        public static System.IntPtr mk_mp4_info_get_stream(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_mp4_info_get_stream(ctx) : mk_events_objects_unix.mk_mp4_info_get_stream(ctx);


        /// <summary>
        /// Parser::Method(),获取命令字，譬如GET/POST
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static System.IntPtr mk_parser_get_method(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_parser_get_method(ctx) : mk_events_objects_unix.mk_parser_get_method(ctx);


        /// <summary>
        /// 获取HTTP的访问url(不包括?后面的参数)
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static System.IntPtr mk_parser_get_url(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_parser_get_url(ctx) : mk_events_objects_unix.mk_parser_get_url(ctx);


        /// <summary>
        /// FullUrl(),包括?后面的参数
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static System.IntPtr mk_parser_get_full_url(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_parser_get_full_url(ctx) : mk_events_objects_unix.mk_parser_get_full_url(ctx);

        /// <summary>
        /// Params(),?后面的参数字符串
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static System.IntPtr mk_parser_get_url_params(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_parser_get_url_params(ctx) : mk_events_objects_unix.mk_parser_get_url_params(ctx);

        /// <summary>
        /// getUrlArgs()["key"],获取?后面的参数中的特定参数
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static System.IntPtr mk_parser_get_url_param(System.IntPtr ctx,  string key)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_parser_get_url_param(ctx, key) : mk_events_objects_unix.mk_parser_get_url_param(ctx, key);


        /// <summary>
        /// ，获取协议相关信息，譬如 HTTP/1.1
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static System.IntPtr mk_parser_get_tail(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_parser_get_tail(ctx) : mk_events_objects_unix.mk_parser_get_tail(ctx);


        /// <summary>
        /// getValues()["key"],获取HTTP头中特定字段
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static System.IntPtr mk_parser_get_header(System.IntPtr ctx,  string key)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_parser_get_header(ctx, key) : mk_events_objects_unix.mk_parser_get_header(ctx, key);


        /// <summary>
        /// Content(),获取HTTP body
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static System.IntPtr mk_parser_get_content(System.IntPtr ctx, ref int length)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_parser_get_content(ctx, ref length) : mk_events_objects_unix.mk_parser_get_content(ctx, ref length);



        public static System.IntPtr mk_media_info_get_params(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_media_info_get_params(ctx) : mk_events_objects_unix.mk_media_info_get_params(ctx);



        public static System.IntPtr mk_media_info_get_schema(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_media_info_get_schema(ctx) : mk_events_objects_unix.mk_media_info_get_schema(ctx);



        public static System.IntPtr mk_media_info_get_vhost(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_media_info_get_vhost(ctx) : mk_events_objects_unix.mk_media_info_get_vhost(ctx);



        public static System.IntPtr mk_media_info_get_app(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_media_info_get_app(ctx) : mk_events_objects_unix.mk_media_info_get_app(ctx);



        public static System.IntPtr mk_media_info_get_stream(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_media_info_get_stream(ctx) : mk_events_objects_unix.mk_media_info_get_stream(ctx);



        public static System.IntPtr mk_media_info_get_host(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_media_info_get_host(ctx) : mk_events_objects_unix.mk_media_info_get_host(ctx);



        public static ushort mk_media_info_get_port(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_media_info_get_port(ctx) : mk_events_objects_unix.mk_media_info_get_port(ctx);



        public static System.IntPtr mk_media_source_get_schema(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_media_source_get_schema(ctx) : mk_events_objects_unix.mk_media_source_get_schema(ctx);



        public static System.IntPtr mk_media_source_get_vhost(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_media_source_get_vhost(ctx) : mk_events_objects_unix.mk_media_source_get_vhost(ctx);



        public static System.IntPtr mk_media_source_get_app(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_media_source_get_app(ctx) : mk_events_objects_unix.mk_media_source_get_app(ctx);



        public static System.IntPtr mk_media_source_get_stream(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_media_source_get_stream(ctx) : mk_events_objects_unix.mk_media_source_get_stream(ctx);



        public static int mk_media_source_get_reader_count(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_media_source_get_reader_count(ctx) : mk_events_objects_unix.mk_media_source_get_reader_count(ctx);



        public static int mk_media_source_get_total_reader_count(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_media_source_get_total_reader_count(ctx) : mk_events_objects_unix.mk_media_source_get_total_reader_count(ctx);


        /// <summary>
        /// 直播源在ZLMediaKit中被称作为MediaSource，
        /// 目前支持3种，分别是RtmpMediaSource、RtspMediaSource、HlsMediaSource
        /// </summary>
        /// <param name="ctx">对象</param>
        /// <param name="force">是否强制关闭，如果强制关闭，在有人观看的情况下也会关闭</param>
        /// <returns></returns>
        /// <remarks><list type="number">
        /// <item>源的产生有被动和主动方式</item>
        /// <item>被动方式分别是rtsp/rtmp/rtp推流、mp4点播</item>
        /// <item>主动方式包括mk_media_create创建的对象(DevChannel)、mk_proxy_player_create创建的对象(PlayerProxy)</item>
        /// <item>被动方式你不用做任何处理，ZLMediaKit已经默认适配了MediaSource::close()事件，都会关闭直播流</item>
        /// <item>主动方式你要设置这个事件的回调，你要自己选择删除对象</item>
        /// <item>通过mk_proxy_player_set_on_close、mk_media_set_on_close函数可以设置回调</item>
        /// <item>请在回调中删除对象来完成媒体的关闭，否则又为什么要调用mk_media_source_close函数？</item>
        /// </list>0代表失败，1代表成功</remarks>
        public static int mk_media_source_close(System.IntPtr ctx, int force)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_media_source_close(ctx, force) : mk_events_objects_unix.mk_media_source_close(ctx, force);



        public static int mk_media_source_seek_to(System.IntPtr ctx, uint stamp)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_media_source_seek_to(ctx, stamp) : mk_events_objects_unix.mk_media_source_seek_to(ctx, stamp);



        public static void mk_media_source_find( string schema,  string vhost,  string app,  string stream, System.IntPtr user_data, on_mk_media_source_find_cb cb)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_media_source_find(schema, vhost, app, stream, user_data, cb);
            else mk_events_objects_unix.mk_media_source_find(schema, vhost, app, stream, user_data, cb);
        }



        public static void mk_media_source_for_each(System.IntPtr user_data, on_mk_media_source_find_cb cb)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_media_source_for_each(user_data, cb);
            else mk_events_objects_unix.mk_media_source_for_each(user_data, cb);
        }

        /// <summary>
        /// 生成HttpStringBody
        /// </summary>
        /// <param name="str">字符串指针</param>
        /// <param name="len">字符串长度，为0则用strlen获取</param>
        /// <returns></returns>
        public static System.IntPtr mk_http_body_from_string( string str, int len)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_http_body_from_string(str, len) : mk_events_objects_unix.mk_http_body_from_string(str, len);


        /// <summary>
        /// 生成HttpFileBody
        /// </summary>
        /// <param name="file_path">文件完整路径</param>
        /// <returns></returns>
        public static System.IntPtr mk_http_body_from_file( string file_path)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_http_body_from_file(file_path) : mk_events_objects_unix.mk_http_body_from_file(file_path);


        /// <summary>
        /// 生成HttpMultiFormBody
        /// </summary>
        /// <param name="key_val">参数key-value</param>
        /// <param name="file_path">文件完整路径</param>
        /// <returns></returns>
        public static System.IntPtr mk_http_body_from_multi_form(ref System.IntPtr key_val,  string file_path)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_http_body_from_multi_form(ref key_val, file_path) : mk_events_objects_unix.mk_http_body_from_multi_form(ref key_val, file_path);


        /// <summary>
        /// 销毁HttpBody
        /// </summary>
        /// <param name="ctx"></param>
        public static void mk_http_body_release(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_http_body_release(ctx);
            else mk_events_objects_unix.mk_http_body_release(ctx);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx">HttpSession::HttpResponseInvoker(const string &codeOut, const StrCaseMap &headerOut, const HttpBody::Ptr &body);</param>
        /// <param name="response_code">譬如200 OK</param>
        /// <param name="response_header">返回的http头，譬如 {"Content-Type","text/html",NULL} 必须以NULL结尾</param>
        /// <param name="response_body">body对象</param>
        public static void mk_http_response_invoker_do(System.IntPtr ctx,  string response_code, ref System.IntPtr response_header, System.IntPtr response_body)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_http_response_invoker_do(ctx, response_code,ref response_header,response_body);
            else mk_events_objects_unix.mk_http_response_invoker_do(ctx, response_code, ref response_header, response_body);
        }

        /// <summary>
        /// HttpSession::HttpResponseInvoker(const string &codeOut, const StrCaseMap &headerOut, const string &body);
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="response_code">譬如200 OK</param>
        /// <param name="response_header">返回的http头，譬如 {"Content-Type","text/html",NULL} 必须以NULL结尾</param>
        /// <param name="response_content">返回的content部分，譬如一个网页内容</param>
        public static void mk_http_response_invoker_do_string(System.IntPtr ctx,  string response_code, ref System.IntPtr response_header,  string response_content)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_http_response_invoker_do_string(ctx, response_code, ref response_header, response_content);
            else mk_events_objects_unix.mk_http_response_invoker_do_string(ctx, response_code, ref response_header, response_content);
        }

        /// <summary>
        /// HttpSession::HttpResponseInvoker(const StrCaseMap &requestHeader,const StrCaseMap &responseHeader,const string &filePath);
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="request_parser">请求事件中的mk_parser对象，用于提取其中http头中的Range字段，通过该字段先fseek然后再发送文件部分片段</param>
        /// <param name="response_header">返回的http头，譬如 {"Content-Type","text/html",NULL} 必须以NULL结尾</param>
        /// <param name="response_file_path">返回的content部分，譬如/path/to/html/file</param>
        public static void mk_http_response_invoker_do_file(System.IntPtr ctx, System.IntPtr request_parser, ref System.IntPtr response_header,  string response_file_path)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_http_response_invoker_do_file(ctx, request_parser, ref response_header, response_file_path);
            else mk_events_objects_unix.mk_http_response_invoker_do_file(ctx, request_parser, ref response_header, response_file_path);
        }
        /// <summary>
        /// 克隆mk_http_response_invoker对象，通过克隆对象为堆对象，可以实现跨线程异步执行mk_http_response_invoker_do
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        /// <remarks>如果是同步执行mk_http_response_invoker_do，那么没必要克隆对象</remarks>
        public static System.IntPtr mk_http_response_invoker_clone(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_http_response_invoker_clone(ctx) : mk_events_objects_unix.mk_http_response_invoker_clone(ctx);


        /// <summary>
        /// 销毁堆上的克隆对象
        /// </summary>
        /// <param name="ctx"></param>
        public static void mk_http_response_invoker_clone_release(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_http_response_invoker_clone_release(ctx);
            else mk_events_objects_unix.mk_http_response_invoker_clone_release(ctx);
        }

        /// <summary>
        /// HttpSession::HttpAccessPathInvoker(const string &errMsg,const string &accessPath, int cookieLifeSecond);
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="err_msg">如果为空，则代表鉴权通过，否则为错误提示,可以为null</param>
        /// <param name="access_path">运行或禁止访问的根目录,可以为null</param>
        /// <param name="cookie_life_second">鉴权cookie有效期</param>
        public static void mk_http_access_path_invoker_do(System.IntPtr ctx,  string err_msg,  string access_path, int cookie_life_second)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_http_access_path_invoker_do(ctx, err_msg,access_path,cookie_life_second);
            else mk_events_objects_unix.mk_http_access_path_invoker_do(ctx, err_msg, access_path, cookie_life_second);
        }

        /// <summary>
        /// 克隆mk_http_access_path_invoker对象，通过克隆对象为堆对象，可以实现跨线程异步执行mk_http_access_path_invoker_do
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        /// <remarks>如果是同步执行mk_http_access_path_invoker_do，那么没必要克隆对象</remarks>
        public static System.IntPtr mk_http_access_path_invoker_clone(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_http_access_path_invoker_clone(ctx) : mk_events_objects_unix.mk_http_access_path_invoker_clone(ctx);


        /// <summary>
        /// 销毁堆上的克隆对象
        /// </summary>
        /// <param name="ctx"></param>
        public static void mk_http_access_path_invoker_clone_release(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_http_access_path_invoker_clone_release(ctx);
            else mk_events_objects_unix.mk_http_access_path_invoker_clone_release(ctx);
        }

        /// <summary>
        /// 执行RtspSession::onGetRealm
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="realm">该rtsp流是否需要开启rtsp专属鉴权，至null或空字符串则不鉴权</param>
        public static void mk_rtsp_get_realm_invoker_do(System.IntPtr ctx,  string realm)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_rtsp_get_realm_invoker_do(ctx, realm);
            else mk_events_objects_unix.mk_rtsp_get_realm_invoker_do(ctx, realm);
        }

        /// <summary>
        /// 克隆mk_rtsp_get_realm_invoker对象，通过克隆对象为堆对象，可以实现跨线程异步执行mk_rtsp_get_realm_invoker_do
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        ///<remarks>如果是同步执行mk_rtsp_get_realm_invoker_do，那么没必要克隆对象</remarks>
        public static System.IntPtr mk_rtsp_get_realm_invoker_clone(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_rtsp_get_realm_invoker_clone(ctx) : mk_events_objects_unix.mk_rtsp_get_realm_invoker_clone(ctx);


        /// <summary>
        /// 销毁堆上的克隆对象
        /// </summary>
        /// <param name="ctx"></param>
        public static void mk_rtsp_get_realm_invoker_clone_release(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_rtsp_get_realm_invoker_clone_release(ctx);
            else mk_events_objects_unix.mk_rtsp_get_realm_invoker_clone_release(ctx);
        }

        /// <summary>
        /// 执行RtspSession::onAuth
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="encrypted">为true是则表明是md5加密的密码，否则是明文密码, 在请求明文密码时如果提供md5密码者则会导致认证失败</param>
        /// <param name="pwd_or_md5">明文密码或者md5加密的密码</param>
        public static void mk_rtsp_auth_invoker_do(System.IntPtr ctx, int encrypted,  string pwd_or_md5)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_rtsp_auth_invoker_do(ctx, encrypted , pwd_or_md5);
            else mk_events_objects_unix.mk_rtsp_auth_invoker_do(ctx, encrypted, pwd_or_md5);
        }

        /// <summary>
        /// 克隆mk_rtsp_auth_invoker对象，通过克隆对象为堆对象，可以实现跨线程异步执行mk_rtsp_auth_invoker_do
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        /// <remarks>如果是同步执行mk_rtsp_auth_invoker_do，那么没必要克隆对象</remarks>
        public static System.IntPtr mk_rtsp_auth_invoker_clone(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_rtsp_auth_invoker_clone(ctx) : mk_events_objects_unix.mk_rtsp_auth_invoker_clone(ctx);


        /// <summary>
        /// 销毁堆上的克隆对象
        /// </summary>
        /// <param name="ctx"></param>
        public static void mk_rtsp_auth_invoker_clone_release(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_rtsp_auth_invoker_clone_release(ctx);
            else mk_events_objects_unix.mk_rtsp_auth_invoker_clone_release(ctx);
        }

        /// <summary>
        /// 执行Broadcast::PublishAuthInvoker
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="err_msg">为空或null则代表鉴权成功</param>
        /// <param name="enable_rtxp">rtmp推流时是否运行转rtsp；rtsp推流时，是否允许转rtmp</param>
        /// <param name="enable_hls">是否允许转换hls</param>
        /// <param name="enable_mp4">是否运行MP4录制</param>
        public static void mk_publish_auth_invoker_do(System.IntPtr ctx,  string err_msg, int enable_rtxp, int enable_hls, int enable_mp4)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_publish_auth_invoker_do(ctx, err_msg, enable_rtxp, enable_hls, enable_mp4);
            else mk_events_objects_unix.mk_publish_auth_invoker_do(ctx, err_msg, enable_rtxp, enable_hls, enable_mp4);
        }

        /// <summary>
        /// 克隆mk_publish_auth_invoker对象，通过克隆对象为堆对象，可以实现跨线程异步执行mk_publish_auth_invoker_do
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        /// <remarks>如果是同步执行mk_publish_auth_invoker_do，那么没必要克隆对象</remarks>
        public static System.IntPtr mk_publish_auth_invoker_clone(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_publish_auth_invoker_clone(ctx) : mk_events_objects_unix.mk_publish_auth_invoker_clone(ctx);


        /// <summary>
        /// 销毁堆上的克隆对象
        /// </summary>
        /// <param name="ctx"></param>
        public static void mk_publish_auth_invoker_clone_release(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_publish_auth_invoker_clone_release(ctx);
            else mk_events_objects_unix.mk_publish_auth_invoker_clone_release(ctx);
        }

        /// <summary>
        /// Broadcast::AuthInvoker对象的C映射
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="err_msg">为空或null则代表鉴权成功</param>
        public static void mk_auth_invoker_do(System.IntPtr ctx,  string err_msg)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_auth_invoker_do(ctx, err_msg);
            else mk_events_objects_unix.mk_auth_invoker_do(ctx, err_msg);
        }

        /// <summary>
        /// 克隆mk_auth_invoker对象，通过克隆对象为堆对象，可以实现跨线程异步执行mk_auth_invoker_do
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        /// <remarks>如果是同步执行mk_auth_invoker_do，那么没必要克隆对象</remarks>
        public static System.IntPtr mk_auth_invoker_clone(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_events_objects_windows.mk_auth_invoker_clone(ctx) : mk_events_objects_unix.mk_auth_invoker_clone(ctx);


        /// <summary>
        /// 销毁堆上的克隆对象
        /// </summary>
        /// <param name="ctx"></param>
        public static void mk_auth_invoker_clone_release(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_events_objects_windows.mk_auth_invoker_clone_release(ctx);
            else mk_events_objects_unix.mk_auth_invoker_clone_release(ctx);
        }
    }

    internal class mk_events_objects_windows
    {
        /// Return Type: uint64_t->unsigned int
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_mp4_info_get_start_time", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern uint mk_mp4_info_get_start_time(System.IntPtr ctx);


        /// Return Type: uint64_t->unsigned int
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_mp4_info_get_time_len", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern uint mk_mp4_info_get_time_len(System.IntPtr ctx);


        /// Return Type: uint64_t->unsigned int
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_mp4_info_get_file_size", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern uint mk_mp4_info_get_file_size(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_mp4_info_get_file_path", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_mp4_info_get_file_path(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_mp4_info_get_file_name", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_mp4_info_get_file_name(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_mp4_info_get_folder", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_mp4_info_get_folder(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_mp4_info_get_url", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_mp4_info_get_url(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_mp4_info_get_vhost", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_mp4_info_get_vhost(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_mp4_info_get_app", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_mp4_info_get_app(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_mp4_info_get_stream", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_mp4_info_get_stream(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_parser->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_parser_get_method", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_parser_get_method(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_parser->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_parser_get_url", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_parser_get_url(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_parser->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_parser_get_full_url", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_parser_get_full_url(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_parser->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_parser_get_url_params", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_parser_get_url_params(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_parser->void*
        ///key: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_parser_get_url_param", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_parser_get_url_param(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key);


        /// Return Type: char*
        ///ctx: mk_parser->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_parser_get_tail", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_parser_get_tail(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_parser->void*
        ///key: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_parser_get_header", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_parser_get_header(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key);


        /// Return Type: char*
        ///ctx: mk_parser->void*
        ///length: int*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_parser_get_content", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_parser_get_content(System.IntPtr ctx, ref int length);


        /// Return Type: char*
        ///ctx: mk_media_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_info_get_params", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_info_get_params(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_info_get_schema", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_info_get_schema(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_info_get_vhost", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_info_get_vhost(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_info_get_app", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_info_get_app(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_info_get_stream", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_info_get_stream(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_info_get_host", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_info_get_host(System.IntPtr ctx);


        /// Return Type: uint16_t->unsigned short
        ///ctx: mk_media_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_info_get_port", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_media_info_get_port(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_source->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_source_get_schema", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_source_get_schema(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_source->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_source_get_vhost", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_source_get_vhost(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_source->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_source_get_app", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_source_get_app(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_source->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_source_get_stream", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_source_get_stream(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_media_source->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_source_get_reader_count", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_media_source_get_reader_count(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_media_source->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_source_get_total_reader_count", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_media_source_get_total_reader_count(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_media_source->void*
        ///force: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_source_close", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_media_source_close(System.IntPtr ctx, int force);


        /// Return Type: int
        ///ctx: mk_media_source->void*
        ///stamp: uint32_t->unsigned int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_source_seek_to", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_media_source_seek_to(System.IntPtr ctx, uint stamp);


        /// Return Type: void
        ///schema: char*
        ///vhost: char*
        ///app: char*
        ///stream: char*
        ///user_data: void*
        ///cb: on_mk_media_source_find_cb
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_source_find", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_source_find([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string schema, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string vhost, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string app, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream, System.IntPtr user_data, on_mk_media_source_find_cb cb);


        /// Return Type: void
        ///user_data: void*
        ///cb: on_mk_media_source_find_cb
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_media_source_for_each", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_source_for_each(System.IntPtr user_data, on_mk_media_source_find_cb cb);


        /// Return Type: mk_http_body->void*
        ///str: char*
        ///len: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_body_from_string", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_body_from_string([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string str, int len);


        /// Return Type: mk_http_body->void*
        ///file_path: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_body_from_file", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_body_from_file([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string file_path);


        /// Return Type: mk_http_body->void*
        ///key_val: char**
        ///file_path: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_body_from_multi_form", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_body_from_multi_form(ref System.IntPtr key_val, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string file_path);


        /// Return Type: void
        ///ctx: mk_http_body->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_body_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_body_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_http_response_invoker->void*
        ///response_code: char*
        ///response_header: char**
        ///response_body: mk_http_body->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_response_invoker_do", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_response_invoker_do(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string response_code, ref System.IntPtr response_header, System.IntPtr response_body);


        /// Return Type: void
        ///ctx: mk_http_response_invoker->void*
        ///response_code: char*
        ///response_header: char**
        ///response_content: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_response_invoker_do_string", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_response_invoker_do_string(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string response_code, ref System.IntPtr response_header, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string response_content);


        /// Return Type: void
        ///ctx: mk_http_response_invoker->void*
        ///request_parser: mk_parser->void*
        ///response_header: char**
        ///response_file_path: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_response_invoker_do_file", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_response_invoker_do_file(System.IntPtr ctx, System.IntPtr request_parser, ref System.IntPtr response_header, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string response_file_path);


        /// Return Type: mk_http_response_invoker->void*
        ///ctx: mk_http_response_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_response_invoker_clone", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_response_invoker_clone(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_http_response_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_response_invoker_clone_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_response_invoker_clone_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_http_access_path_invoker->void*
        ///err_msg: char*
        ///access_path: char*
        ///cookie_life_second: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_access_path_invoker_do", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_access_path_invoker_do(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string err_msg, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string access_path, int cookie_life_second);


        /// Return Type: mk_http_access_path_invoker->void*
        ///ctx: mk_http_access_path_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_access_path_invoker_clone", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_access_path_invoker_clone(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_http_access_path_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_http_access_path_invoker_clone_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_access_path_invoker_clone_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_rtsp_get_realm_invoker->void*
        ///realm: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_rtsp_get_realm_invoker_do", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_rtsp_get_realm_invoker_do(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string realm);


        /// Return Type: mk_rtsp_get_realm_invoker->void*
        ///ctx: mk_rtsp_get_realm_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_rtsp_get_realm_invoker_clone", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_rtsp_get_realm_invoker_clone(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_rtsp_get_realm_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_rtsp_get_realm_invoker_clone_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_rtsp_get_realm_invoker_clone_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_rtsp_auth_invoker->void*
        ///encrypted: int
        ///pwd_or_md5: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_rtsp_auth_invoker_do", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_rtsp_auth_invoker_do(System.IntPtr ctx, int encrypted, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pwd_or_md5);


        /// Return Type: mk_rtsp_auth_invoker->void*
        ///ctx: mk_rtsp_auth_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_rtsp_auth_invoker_clone", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_rtsp_auth_invoker_clone(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_rtsp_auth_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_rtsp_auth_invoker_clone_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_rtsp_auth_invoker_clone_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_publish_auth_invoker->void*
        ///err_msg: char*
        ///enable_rtxp: int
        ///enable_hls: int
        ///enable_mp4: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_publish_auth_invoker_do", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_publish_auth_invoker_do(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string err_msg, int enable_rtxp, int enable_hls, int enable_mp4);


        /// Return Type: mk_publish_auth_invoker->void*
        ///ctx: mk_publish_auth_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_publish_auth_invoker_clone", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_publish_auth_invoker_clone(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_publish_auth_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_publish_auth_invoker_clone_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_publish_auth_invoker_clone_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_auth_invoker->void*
        ///err_msg: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_auth_invoker_do", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_auth_invoker_do(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string err_msg);


        /// Return Type: mk_auth_invoker->void*
        ///ctx: mk_auth_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_auth_invoker_clone", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_auth_invoker_clone(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_auth_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_auth_invoker_clone_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_auth_invoker_clone_release(System.IntPtr ctx);
    }

    internal class mk_events_objects_unix
    {
        /// Return Type: uint64_t->unsigned int
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_mp4_info_get_start_time", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern uint mk_mp4_info_get_start_time(System.IntPtr ctx);


        /// Return Type: uint64_t->unsigned int
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_mp4_info_get_time_len", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern uint mk_mp4_info_get_time_len(System.IntPtr ctx);


        /// Return Type: uint64_t->unsigned int
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_mp4_info_get_file_size", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern uint mk_mp4_info_get_file_size(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_mp4_info_get_file_path", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_mp4_info_get_file_path(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_mp4_info_get_file_name", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_mp4_info_get_file_name(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_mp4_info_get_folder", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_mp4_info_get_folder(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_mp4_info_get_url", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_mp4_info_get_url(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_mp4_info_get_vhost", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_mp4_info_get_vhost(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_mp4_info_get_app", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_mp4_info_get_app(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_mp4_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_mp4_info_get_stream", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_mp4_info_get_stream(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_parser->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_parser_get_method", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_parser_get_method(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_parser->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_parser_get_url", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_parser_get_url(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_parser->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_parser_get_full_url", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_parser_get_full_url(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_parser->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_parser_get_url_params", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_parser_get_url_params(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_parser->void*
        ///key: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_parser_get_url_param", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_parser_get_url_param(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key);


        /// Return Type: char*
        ///ctx: mk_parser->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_parser_get_tail", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_parser_get_tail(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_parser->void*
        ///key: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_parser_get_header", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_parser_get_header(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key);


        /// Return Type: char*
        ///ctx: mk_parser->void*
        ///length: int*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_parser_get_content", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_parser_get_content(System.IntPtr ctx, ref int length);


        /// Return Type: char*
        ///ctx: mk_media_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_info_get_params", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_info_get_params(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_info_get_schema", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_info_get_schema(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_info_get_vhost", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_info_get_vhost(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_info_get_app", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_info_get_app(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_info_get_stream", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_info_get_stream(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_info_get_host", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_info_get_host(System.IntPtr ctx);


        /// Return Type: uint16_t->unsigned short
        ///ctx: mk_media_info->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_info_get_port", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern ushort mk_media_info_get_port(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_source->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_source_get_schema", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_source_get_schema(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_source->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_source_get_vhost", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_source_get_vhost(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_source->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_source_get_app", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_source_get_app(System.IntPtr ctx);


        /// Return Type: char*
        ///ctx: mk_media_source->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_source_get_stream", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_media_source_get_stream(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_media_source->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_source_get_reader_count", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_media_source_get_reader_count(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_media_source->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_source_get_total_reader_count", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_media_source_get_total_reader_count(System.IntPtr ctx);


        /// Return Type: int
        ///ctx: mk_media_source->void*
        ///force: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_source_close", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_media_source_close(System.IntPtr ctx, int force);


        /// Return Type: int
        ///ctx: mk_media_source->void*
        ///stamp: uint32_t->unsigned int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_source_seek_to", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern int mk_media_source_seek_to(System.IntPtr ctx, uint stamp);


        /// Return Type: void
        ///schema: char*
        ///vhost: char*
        ///app: char*
        ///stream: char*
        ///user_data: void*
        ///cb: on_mk_media_source_find_cb
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_source_find", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_source_find([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string schema, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string vhost, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string app, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string stream, System.IntPtr user_data, on_mk_media_source_find_cb cb);


        /// Return Type: void
        ///user_data: void*
        ///cb: on_mk_media_source_find_cb
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_media_source_for_each", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_media_source_for_each(System.IntPtr user_data, on_mk_media_source_find_cb cb);


        /// Return Type: mk_http_body->void*
        ///str: char*
        ///len: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_body_from_string", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_body_from_string([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string str, int len);


        /// Return Type: mk_http_body->void*
        ///file_path: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_body_from_file", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_body_from_file([System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string file_path);


        /// Return Type: mk_http_body->void*
        ///key_val: char**
        ///file_path: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_body_from_multi_form", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_body_from_multi_form(ref System.IntPtr key_val, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string file_path);


        /// Return Type: void
        ///ctx: mk_http_body->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_body_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_body_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_http_response_invoker->void*
        ///response_code: char*
        ///response_header: char**
        ///response_body: mk_http_body->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_response_invoker_do", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_response_invoker_do(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string response_code, ref System.IntPtr response_header, System.IntPtr response_body);


        /// Return Type: void
        ///ctx: mk_http_response_invoker->void*
        ///response_code: char*
        ///response_header: char**
        ///response_content: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_response_invoker_do_string", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_response_invoker_do_string(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string response_code, ref System.IntPtr response_header, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string response_content);


        /// Return Type: void
        ///ctx: mk_http_response_invoker->void*
        ///request_parser: mk_parser->void*
        ///response_header: char**
        ///response_file_path: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_response_invoker_do_file", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_response_invoker_do_file(System.IntPtr ctx, System.IntPtr request_parser, ref System.IntPtr response_header, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string response_file_path);


        /// Return Type: mk_http_response_invoker->void*
        ///ctx: mk_http_response_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_response_invoker_clone", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_response_invoker_clone(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_http_response_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_response_invoker_clone_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_response_invoker_clone_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_http_access_path_invoker->void*
        ///err_msg: char*
        ///access_path: char*
        ///cookie_life_second: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_access_path_invoker_do", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_access_path_invoker_do(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string err_msg, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string access_path, int cookie_life_second);


        /// Return Type: mk_http_access_path_invoker->void*
        ///ctx: mk_http_access_path_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_access_path_invoker_clone", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_http_access_path_invoker_clone(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_http_access_path_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_http_access_path_invoker_clone_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_http_access_path_invoker_clone_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_rtsp_get_realm_invoker->void*
        ///realm: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_rtsp_get_realm_invoker_do", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_rtsp_get_realm_invoker_do(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string realm);


        /// Return Type: mk_rtsp_get_realm_invoker->void*
        ///ctx: mk_rtsp_get_realm_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_rtsp_get_realm_invoker_clone", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_rtsp_get_realm_invoker_clone(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_rtsp_get_realm_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_rtsp_get_realm_invoker_clone_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_rtsp_get_realm_invoker_clone_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_rtsp_auth_invoker->void*
        ///encrypted: int
        ///pwd_or_md5: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_rtsp_auth_invoker_do", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_rtsp_auth_invoker_do(System.IntPtr ctx, int encrypted, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pwd_or_md5);


        /// Return Type: mk_rtsp_auth_invoker->void*
        ///ctx: mk_rtsp_auth_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_rtsp_auth_invoker_clone", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_rtsp_auth_invoker_clone(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_rtsp_auth_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_rtsp_auth_invoker_clone_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_rtsp_auth_invoker_clone_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_publish_auth_invoker->void*
        ///err_msg: char*
        ///enable_rtxp: int
        ///enable_hls: int
        ///enable_mp4: int
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_publish_auth_invoker_do", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_publish_auth_invoker_do(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string err_msg, int enable_rtxp, int enable_hls, int enable_mp4);


        /// Return Type: mk_publish_auth_invoker->void*
        ///ctx: mk_publish_auth_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_publish_auth_invoker_clone", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_publish_auth_invoker_clone(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_publish_auth_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_publish_auth_invoker_clone_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_publish_auth_invoker_clone_release(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_auth_invoker->void*
        ///err_msg: char*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_auth_invoker_do", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_auth_invoker_do(System.IntPtr ctx, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string err_msg);


        /// Return Type: mk_auth_invoker->void*
        ///ctx: mk_auth_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_auth_invoker_clone", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_auth_invoker_clone(System.IntPtr ctx);


        /// Return Type: void
        ///ctx: mk_auth_invoker->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_auth_invoker_clone_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_auth_invoker_clone_release(System.IntPtr ctx);
    }
}
