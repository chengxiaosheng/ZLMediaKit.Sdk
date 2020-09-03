using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using ZLMediaKit.Sdk.Original;

namespace ZLMediaKit.Sdk.Services
{
    /// <summary>
    /// 原始事件处理
    /// </summary>
    /// <remarks>非公开类；对ZLMeidaKit原始事件进行绑定与转换；对外提供符合NET 快速处理的事件类</remarks>
    internal class ZLMediaKitEventBindService
    {
        private readonly ILogger<ZLMediaKitEventBindService> _logger;
        private  mk_events _mk_Events = default;
        public ZLMediaKitEventBindService(ILogger<ZLMediaKitEventBindService> logger)
        {
            this._logger = logger;
        }

        internal  void BindEvents()
        {
            _mk_Events = new mk_events
            {
                on_mk_flow_report = new _on_mk_flow_report(OnFlowReport),
                on_mk_http_access = new _on_mk_http_access(OnHttpAccess),
                on_mk_http_before_access = new _on_mk_http_before_access(OnHttpBeforeAccess),
                on_mk_http_request = new _on_mk_http_request(OnHttpRequest),
                on_mk_media_changed = new _on_mk_media_changed(OnMediaChange),
                on_mk_media_not_found = new _on_mk_media_not_found(OnMediNotFound),
                on_mk_media_no_reader = new _on_mk_media_no_reader(OnMediaNoReader),
                on_mk_media_play = new _on_mk_media_play(OnMediaPlay),
                on_mk_media_publish = new _on_mk_media_publish(OnMediaPublish),
                on_mk_record_mp4 = new _on_mk_record_mp4(OnRecordMp4),
                on_mk_rtsp_auth = new _on_mk_rtsp_auth(OnRtspAuth),
                on_mk_rtsp_get_realm = new _on_mk_rtsp_get_realm(OnRtspGetRealm),
                on_mk_shell_login = new _on_mk_shell_login(OnShellLogin)
            };
            mk_event.mk_events_listen(ref _mk_Events);
        }

        internal  void UnBindEvents()
        {
            _mk_Events.on_mk_flow_report = null;
            _mk_Events.on_mk_http_access = null;
            _mk_Events.on_mk_http_before_access = null;
            _mk_Events.on_mk_http_request = null;
            _mk_Events.on_mk_media_changed = null;
            _mk_Events.on_mk_media_not_found = null;
            _mk_Events.on_mk_media_no_reader = null;
            _mk_Events.on_mk_media_play = null;
            _mk_Events.on_mk_media_publish = null;
            _mk_Events.on_mk_record_mp4 = null;
            _mk_Events.on_mk_rtsp_auth = null;
            _mk_Events.on_mk_rtsp_get_realm = null;
            _mk_Events.on_mk_shell_login = null;
        }

        internal  void OnFlowReport(System.IntPtr url_info, uint total_bytes, uint total_seconds, int is_player, System.IntPtr sender)
        {
            _logger.LogDebug("收到on_mk_flow_report事件");
        }
        internal  void OnHttpAccess(System.IntPtr parser,  string path, int is_dir, System.IntPtr invoker, System.IntPtr sender)
        {
            _logger.LogDebug("on_mk_http_access");

        }
        internal  void OnHttpBeforeAccess(System.IntPtr parser, System.IntPtr path, System.IntPtr sender)
        {
            _logger.LogDebug("on_mk_http_before_access");

        }
        internal  void OnHttpRequest(System.IntPtr parser, System.IntPtr invoker, ref int consumed, System.IntPtr sender)
        {
            //接管请求
            consumed = 1;
            var para = mk_events_objects.mk_parser_get_url_params(parser);
            var method = mk_events_objects.mk_parser_get_method(parser);
            var url = mk_events_objects.mk_parser_get_url(parser);
            IntPtr ipintptr = Marshal.AllocHGlobal(15);
            var resIntptr = mk_tcp.mk_sock_info_peer_ip(sender, ipintptr);
            var peerIp = Marshal.PtrToStringAnsi(ipintptr);
            var peerPort = mk_tcp.mk_sock_info_peer_port(sender);
            int contentLen = 0;
            IntPtr header = Marshal.StringToHGlobalAnsi("{\"key\",\"12121222222222222\",NULL}");
            var content = mk_events_objects.mk_parser_get_content(parser,ref contentLen);
            mk_events_objects.mk_http_response_invoker_do_string(invoker, "200 OK", ref header, "wo me dou shi zhong guo ren");
            var paraString = Marshal.PtrToStringAnsi(para);
            var methodStr = Marshal.PtrToStringAnsi(method);
            var urlStr = Marshal.PtrToStringAnsi(url);
            var contentString = Marshal.PtrToStringAnsi(content);
            
            _logger.LogInformation($"{paraString}\r\n{methodStr}\r\n{urlStr}\r\n{contentString}");
            _logger.LogDebug("on_mk_http_request");

        }
        internal  void OnMediaChange(int regist, System.IntPtr sender)
        {
            _logger.LogDebug("on_mk_media_changed");

        }

        internal  void OnMediNotFound(System.IntPtr url_info, System.IntPtr sender)
        {
            _logger.LogDebug("on_mk_media_not_found");

        }
        internal  void OnMediaNoReader(System.IntPtr sender)
        {
            _logger.LogDebug("on_mk_media_no_reader");

        }
        internal  void OnMediaPlay(System.IntPtr url_info, System.IntPtr invoker, System.IntPtr sender)
        {
            _logger.LogDebug("on_mk_media_play");

        }

        internal  void OnMediaPublish(System.IntPtr url_info, System.IntPtr invoker, System.IntPtr sender)
        {
            _logger.LogDebug("on_mk_media_publish");

        }
        internal  void OnRecordMp4(System.IntPtr mp4)
        {

            _logger.LogDebug("on_mk_record_mp4");
        }
        internal  void OnRtspAuth(System.IntPtr url_info, string realm, string user_name, int must_no_encrypt, System.IntPtr invoker, System.IntPtr sender)
        {
            _logger.LogDebug("on_mk_rtsp_auth");

        }

        internal  void OnRtspGetRealm(System.IntPtr url_info, System.IntPtr invoker, System.IntPtr sender)
        {
            _logger.LogDebug("on_mk_rtsp_get_realm");

        }

        internal  void OnShellLogin(string user_name, string passwd, System.IntPtr invoker, System.IntPtr sender)
        {
            _logger.LogDebug("on_mk_shell_login");

        }
    }
}
