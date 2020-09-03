using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ZLMediaKit.Sdk
{
    internal class ZLMediaKitOptions : IOptions<ZLMediaKitOptions>
    {
        public ZLMediaKitOptions Value => this;

        /// <summary>
        /// 
        /// </summary>
        public ApiConfig Api { get; set; } =  new ApiConfig();
        /// <summary>
        /// 
        /// </summary>
        public FfmpegConfig Ffmpeg { get; set; } = new FfmpegConfig();
        /// <summary>
        /// 
        /// </summary>
        public GeneralConfig General { get; set; } = new GeneralConfig();
        /// <summary>
        /// 
        /// </summary>
        public HlsConfig Hls { get; set; } = new HlsConfig();
        /// <summary>
        /// 
        /// </summary>
        public HookConfig Hook { get; set; } = new HookConfig();
        /// <summary>
        /// 
        /// </summary>
        public HttpConfig Http { get; set; } = new HttpConfig();
        /// <summary>
        /// 
        /// </summary>
        public MulticastConfig Multicast { get; set; } = new MulticastConfig();
        /// <summary>
        /// 
        /// </summary>
        public RecordConfig Record { get; set; } = new RecordConfig();
        /// <summary>
        /// 
        /// </summary>
        public RtmpConfig Rtmp { get; set; } = new RtmpConfig();
        /// <summary>
        /// 
        /// </summary>
        public RtpConfig Rtp { get; set; } = new RtpConfig();
        /// <summary>
        /// 
        /// </summary>
        public RtpProxyConfig RtpProxy { get; set; } = new RtpProxyConfig();
        /// <summary>
        /// 
        /// </summary>
        public RtspConfig Rtsp { get; set; } = new RtspConfig();
        /// <summary>
        /// 
        /// </summary>
        public ShellConfig Shell { get; set; } = new ShellConfig();

        public string GetConfig() =>
            string.Join(System.Environment.NewLine,
            this.Api.GetConfig()
                .Concat(this.Ffmpeg.GetConfig())
                .Concat(this.General.GetConfig())
                .Concat(this.Hls.GetConfig())
                .Concat(this.Hook.GetConfig())
                .Concat(this.Http.GetConfig())
                .Concat(this.Multicast.GetConfig())
                .Concat(this.Record.GetConfig())
                .Concat(this.Rtmp.GetConfig())
                .Concat(this.Rtp.GetConfig())
                .Concat(this.RtpProxy.GetConfig())
                .Concat(this.Rtsp.GetConfig())
                .Concat(this.Shell.GetConfig())
                .Select(s => $"{s.Key}={s.Value}"));


        public class ApiConfig
        {
            internal static string PrefixName = "api.";
            /// <summary>
            /// 是否调试http api,启用调试后，会打印每次http请求的内容和回复
            /// </summary>
            public bool ApiDebug { get; set; } = true;

            /// <summary>
            /// 一些比较敏感的http api在访问时需要提供secret，否则无权限调用
            /// </summary>
            /// <remarks>如果是通过127.0.0.1访问,那么可以不提供secret</remarks>
            public string Secret { get; set; } = @"035c73f7-bb6b-4889-a715-d9eb2d1925cc";

            /// <summary>
            /// 默认截图图片，在启动FFmpeg截图后但是截图还未生成时，可以返回默认的预设图片
            /// </summary>
            public string SnapRoot { get; set; } = @"./www/snap/";

            /// <summary>
            /// 默认截图图片，在启动FFmpeg截图后但是截图还未生成时，可以返回默认的预设图片
            /// </summary>
            public string DefaultSnap { get; set; } = @"./www/logo.png";

            internal Dictionary<string, object> GetConfig() =>
                new Dictionary<string, object>()
                {
                    { $"{PrefixName}apiDebug",this.ApiDebug ? 1: 0 },
                    { $"{PrefixName}secret",this.Secret },
                    { $"{PrefixName}snapRoot",this.SnapRoot },
                    { $"{PrefixName}defaultSnap",this.DefaultSnap },
                };
        }

        /// <summary>
        /// 
        /// </summary>
        public class FfmpegConfig
        {
            internal static string PrefixName = "ffmpeg.";
            /// <summary>
            /// FFmpeg可执行程序绝对路径
            /// </summary>
            public string Bin { get; set; } = @"/usr/local/bin/ffmpeg";

            /// <summary>
            /// FFmpeg拉流再推流的命令模板，通过该模板可以设置再编码的一些参数
            /// </summary>
            public string Cmd { get; set; } = @"%s -re -i %s -c:a aac -strict -2 -ar 44100 -ab 48k -c:v libx264 -f flv %s";

            /// <summary>
            /// FFmpeg生成截图的命令，可以通过修改该配置改变截图分辨率或质量
            /// </summary>
            public string Snap { get; set; } = @"%s -i %s -y -f mjpeg -t 0.001 %s";

            /// <summary>
            /// FFmpeg日志的路径，如果置空则不生成FFmpeg日志
            /// </summary>
            /// <remarks>可以为相对(相对于本可执行程序目录)或绝对路径</remarks>
            public string Log { get; set; } = @"./ffmpeg/ffmpeg.log";

            internal Dictionary<string, object> GetConfig() =>
                new Dictionary<string, object>()
                {
                    { $"{PrefixName}bin",this.Bin },
                    { $"{PrefixName}cmd",this.Cmd },
                    { $"{PrefixName}snap",this.Snap },
                    { $"{PrefixName}log",this.Log },
                };
           
        }
        /// <summary>
        /// 
        /// </summary>
        public class GeneralConfig
        {
            internal static string PrefixName = "general.";

            /// <summary>
            /// 是否启用虚拟主机
            /// </summary>
            public bool EnableVhost { get; set; } = false;

            /// <summary>
            /// 播放器或推流器在断开后会触发hook.on_flow_report事件(使用多少流量事件),
            /// </summary>
            /// <remarks>flowThreshold参数控制触发hook.on_flow_report事件阈值，使用流量超过该阈值后才触发，单位KB</remarks>
            public int FlowThreshold { get; set; } = 1024;

            /// <summary>
            /// 播放最多等待时间，单位毫秒
            /// </summary>
            /// <remarks>
            /// 播放在播放某个流时，如果该流不存在,ZLMediaKit会最多让播放器等待maxStreamWaitMS毫秒；
            /// 如果在这个时间内，该流注册成功，那么会立即返回播放器播放成功；
            /// 否则返回播放器未找到该流，该机制的目的是可以先播放再推流
            /// </remarks>
            public int MaxStreamWaitMS { get; set; } = 15000;

            /// <summary>
            /// 个流无人观看时，触发hook.on_stream_none_reader事件的最大等待时间，单位毫秒
            /// </summary>
            /// <remarks>在配合hook.on_stream_none_reader事件时，可以做到无人观看自动停止拉流或停止接收推流</remarks>
            public int StreamNoneReaderDelayMS { get; set; } = 20000;

            /// <summary>
            /// 拉流代理是否添加静音音频(直接拉流模式本协议无效)
            /// </summary>
            public bool AddMuteAudio { get; set; } = true;

            /// <summary>
            /// 拉流代理时如果断流再重连成功是否删除前一次的媒体流数据
            /// </summary>
            /// <remarks>如果删除将重新开始 ；如果不删除将会接着上一次的数据继续写(录制hls/mp4时会继续在前一个文件后面写)</remarks>
            public bool ResetWhenRePlay { get; set; } = true;

            /// <summary>
            /// 是否默认推流时转换成rtsp或rtmp，hook接口(on_publish)中可以覆盖该设置
            /// </summary>
            public bool PublishToRtxp { get; set; } = true;

            /// <summary>
            /// 是否默认推流时转换成hls，hook接口(on_publish)中可以覆盖该设置
            /// </summary>
            public bool PublishToHls { get; set; } = true;

            /// <summary>
            /// 是否默认推流时mp4录像，hook接口(on_publish)中可以覆盖该设置
            /// </summary>
            public bool PublishToMP4 { get; set; } = false;

            /// <summary>
            /// 合并写缓存大小(单位毫秒)
            /// </summary>
            /// <remarks>合并写指服务器缓存一定的数据后才会一次性写入socket，这样能提高性能，但是会提高延时,开启后会同时关闭TCP_NODELAY并开启MSG_MORE</remarks>
            public bool MergeWriteMS { get; set; } = false;

            /// <summary>
            /// 全局的时间戳覆盖开关，在转协议时，对frame进行时间戳覆盖
            /// </summary>
            /// <remarks>该开关对rtsp/rtmp/rtp推流、rtsp/rtmp/hls拉流代理转协议时生效；会直接影响rtsp/rtmp/hls/mp4/flv等协议的时间戳；同协议情况下不影响(例如rtsp/rtmp推流，那么播放rtsp/rtmp时不会影响时间戳)</remarks>
            public bool ModifyStamp { get; set; } = false;

            internal Dictionary<string, object> GetConfig() =>
                new Dictionary<string, object>()
                {
                    { $"{GeneralConfig.PrefixName}enableVhost", EnableVhost ? 1 : 0},
                    { $"{GeneralConfig.PrefixName}flowThreshold", FlowThreshold},
                    { $"{GeneralConfig.PrefixName}maxStreamWaitMS", MaxStreamWaitMS },
                    { $"{GeneralConfig.PrefixName}streamNoneReaderDelayMS", StreamNoneReaderDelayMS },
                    { $"{GeneralConfig.PrefixName}addMuteAudio", AddMuteAudio ? 1 : 0 },
                    { $"{GeneralConfig.PrefixName}resetWhenRePlay", ResetWhenRePlay ? 1 : 0 },
                    { $"{GeneralConfig.PrefixName}publishToRtxp", PublishToRtxp ? 1 : 0 },
                    { $"{GeneralConfig.PrefixName}publishToHls", PublishToHls ? 1 : 0 },
                    { $"{GeneralConfig.PrefixName}publishToMP4", PublishToMP4 ? 1 : 0 },
                    { $"{GeneralConfig.PrefixName}mergeWriteMS", MergeWriteMS ? 1 : 0 },
                    { $"{GeneralConfig.PrefixName}modifyStamp", ModifyStamp ? 1 : 0 }
                };

        }
        /// <summary>
        /// 
        /// </summary>
        public class HlsConfig
        {
            internal static string PrefixName = "hls.";

            /// <summary>
            /// hls写文件的buf大小，调整参数可以提高文件io性能
            /// </summary>
            public int FileBufSize { get; set; } = 65536;

            /// <summary>
            /// hls保存文件路径
            /// </summary>
            /// <remarks>可以为相对(相对于本可执行程序目录)或绝对路径</remarks>
            public string FilePath { get; set; } = @"./www";

            /// <summary>
            /// hls最大切片时间
            /// </summary>
            public int SegDur { get; set; } = 2;

            /// <summary>
            /// m3u8索引中,hls保留切片个数(实际保留切片个数大2~3个)
            /// </summary>
            /// <remarks>如果设置为0，则不删除切片，而是保存为点播</remarks>
            public int SegNum { get; set; } = 3;

            /// <summary>
            /// HLS切片从m3u8文件中移除后，继续保留在磁盘上的个数
            /// </summary>
            public int SegRetain { get; set; } = 5;

            internal Dictionary<string, object> GetConfig() =>
                new Dictionary<string, object>
                {
                    { $"{HlsConfig.PrefixName}fileBufSize", FileBufSize },
                    { $"{HlsConfig.PrefixName}filePath", FilePath },
                    { $"{HlsConfig.PrefixName}segDur", SegDur },
                    { $"{HlsConfig.PrefixName}segNum", SegNum },
                    { $"{HlsConfig.PrefixName}segRetain", SegRetain }
                };
        }
        /// <summary>
        /// 
        /// </summary>
        public class HookConfig
        {
            internal static string PrefixName = "hook.";
            /// <summary>
            /// 在推流时，如果url参数匹对admin_params，那么可以不经过hook鉴权直接推流成功，播放时亦然
            /// </summary>
            /// <remarks>该配置项的目的是为了开发者自己调试测试，该参数暴露后会有泄露隐私的安全隐患</remarks>
            public string Admin_params { get; set; } = @"035c73f7-bb6b-4889-a715-d9eb2d1925cc";

            /// <summary>
            /// 是否启用hook事件，启用后，推拉流都将进行鉴权
            /// </summary>
            public bool Enable { get; set; } = false;

            /// <summary>
            /// 播放器或推流器使用流量事件，置空则关闭
            /// </summary>
            public string On_flow_report { get; set; } = @"https://127.0.0.1/index/hook/on_flow_report";

            /// <summary>
            /// 访问http文件鉴权事件，置空则关闭鉴权 
            /// </summary>
            public string On_http_access { get; set; } = @"https://127.0.0.1/index/hook/on_http_access";

            /// <summary>
            /// 播放鉴权事件，置空则关闭鉴权
            /// </summary>
            public string On_play { get; set; } = @"https://127.0.0.1/index/hook/on_play";

            /// <summary>
            /// 推流鉴权事件，置空则关闭鉴权
            /// </summary>
            public string On_publish { get; set; } = @"https://127.0.0.1/index/hook/on_publish";

            /// <summary>
            /// 录制mp4切片完成事件
            /// </summary>
            public string On_record_mp4 { get; set; } = @"https://127.0.0.1/index/hook/on_record_mp4";

            /// <summary>
            /// rtsp播放鉴权事件，此事件中比对rtsp的用户名密码
            /// </summary>
            public string On_rtsp_auth { get; set; } = @"https://127.0.0.1/index/hook/on_rtsp_auth";
            /// <summary>
            /// rtsp播放是否开启专属鉴权事件，置空则关闭rtsp鉴权。rtsp播放鉴权还支持url方式鉴权
            /// </summary>
            /// <remarks>建议开发者统一采用url参数方式鉴权，rtsp用户名密码鉴权一般在设备上用的比较多</remarks>
            /// <remarks>开启rtsp专属鉴权后，将不再触发on_play鉴权事件</remarks>
            public string On_rtsp_realm { get; set; } = @"https://127.0.0.1/index/hook/on_rtsp_realm";

            /// <summary>
            /// 远程telnet调试鉴权事件
            /// </summary>
            public string On_shell_login { get; set; } = @"https://127.0.0.1/index/hook/on_shell_login";

            /// <summary>
            /// 直播流注册或注销事件
            /// </summary>
            public string On_stream_changed { get; set; } = @"https://127.0.0.1/index/hook/on_stream_changed";

            /// <summary>
            /// 无人观看流事件，通过该事件，可以选择是否关闭无人观看的流。配合general.streamNoneReaderDelayMS选项一起使用
            /// </summary>
            public string On_stream_none_reader { get; set; } = @"https://127.0.0.1/index/hook/on_stream_none_reader";

            /// <summary>
            /// 播放时，未找到流事件，通过配合hook.on_stream_none_reader事件可以完成按需拉流
            /// </summary>
            public string On_stream_not_found { get; set; } = @"https://127.0.0.1/index/hook/on_stream_not_found";

            /// <summary>
            /// 服务器启动报告，可以用于服务器的崩溃重启事件监听
            /// </summary>
            public string On_server_started { get; set; } = @"https://127.0.0.1/index/hook/on_server_started";

            /// <summary>
            /// hook api最大等待回复时间，单位秒
            /// </summary>
            public int TimeoutSec { get; set; } = 10;

            internal Dictionary<string, object> GetConfig() =>
                new Dictionary<string, object>
                {
                    { $"{HookConfig.PrefixName}admin_params", Admin_params },
                    { $"{HookConfig.PrefixName}enable", Enable ? 1 : 0 },
                    { $"{HookConfig.PrefixName}on_flow_report", On_flow_report },
                    { $"{HookConfig.PrefixName}on_http_access", On_http_access },
                    { $"{HookConfig.PrefixName}on_play", On_play },
                    { $"{HookConfig.PrefixName}on_publish", On_publish },
                    { $"{HookConfig.PrefixName}on_record_mp4", On_record_mp4 },
                    { $"{HookConfig.PrefixName}on_rtsp_auth", On_rtsp_auth },
                    { $"{HookConfig.PrefixName}on_rtsp_realm", On_rtsp_realm },
                    { $"{HookConfig.PrefixName}on_shell_login", On_shell_login },
                    { $"{HookConfig.PrefixName}on_stream_changed", On_stream_changed },
                    { $"{HookConfig.PrefixName}on_stream_none_reader", On_stream_none_reader },
                    { $"{HookConfig.PrefixName}on_stream_not_found", On_stream_not_found },
                    { $"{HookConfig.PrefixName}on_server_started", On_server_started },
                    { $"{HookConfig.PrefixName}yimeoutSec", TimeoutSec }
                };
        }
        /// <summary>
        /// 
        /// </summary>
        public class HttpConfig
        {
            internal static string PrefixName = "http.";

            /// <summary>
            /// http服务器字符编码，windows上默认gb2312
            /// </summary>
            public string CharSet { get; set; } = @"utf-8";

            /// <summary>
            /// http链接超时时间
            /// </summary>
            public int KeepAliveSecond { get; set; } = 30;

            /// <summary>
            /// http请求体最大字节数，如果post的body太大，则不适合缓存body在内存
            /// </summary>
            public int MaxReqSize { get; set; } = 4096;


            private string _notFound = "<html><head><title>404 Not Found</title></head><body bgcolor=\"white\"><center><h1>您访问的资源不存在！</h1></center><hr><center>ZLMediaKit-4.0</center></body></html>";
            /// <summary>
            /// 404网页内容，用户可以自定义404网页
            /// 也可以是一个本地文件
            /// </summary>
            public string NotFound { get=> _notFound; 
                set {
                    //是文件
                    if (File.Exists(value))
                        _notFound = File.ReadAllText(value, Encoding.UTF8);
                    else
                        _notFound = value;
                } }

            /// <summary>
            /// http服务器监听端口
            /// </summary>
            public int Port { get; set; } = 80;

            /// <summary>
            /// http文件服务器根目录
            /// </summary>
            /// <remarks>可以为相对(相对于本可执行程序目录)或绝对路径</remarks>
            public string RootPath { get; set; } = @"./www";
            /// <summary>
            /// http文件服务器读文件缓存大小，单位BYTE，调整该参数可以优化文件io性能
            /// </summary>
            public int SendBufSize { get; set; } = 65536;

            /// <summary>
            /// https服务器监听端口
            /// </summary>
            public int Sslport { get; set; } = 443;

            /// <summary>
            /// 是否显示文件夹菜单，开启后可以浏览文件夹
            /// </summary>
            public bool DirMenu { get; set; } = true;

            internal Dictionary<string, object> GetConfig() =>
                new Dictionary<string, object>
                {
                    { $"{HttpConfig.PrefixName}charSet", CharSet},
                    { $"{HttpConfig.PrefixName}keepAliveSecond", KeepAliveSecond },
                    { $"{HttpConfig.PrefixName}maxReqSize", MaxReqSize },
                    { $"{HttpConfig.PrefixName}notFound", NotFound },
                    { $"{HttpConfig.PrefixName}on_play", Port },
                    { $"{HttpConfig.PrefixName}rootPath", RootPath },
                    { $"{HttpConfig.PrefixName}sendBufSize", SendBufSize },
                    { $"{HttpConfig.PrefixName}sslport", Sslport },
                    { $"{HttpConfig.PrefixName}dirMenu", DirMenu ? 1 : 0 }
                };
        }
        /// <summary>
        /// 
        /// </summary>
        public class MulticastConfig
        {
            internal static string PrefixName = "multicast.";

            /// <summary>
            /// rtp组播截止组播ip地址
            /// </summary>
            public string AddrMax { get; set; } = @"239.255.255.255";

            /// <summary>
            /// rtp组播起始组播ip地址
            /// </summary>
            public string AddrMin { get; set; } = @"239.0.0.0";

            /// <summary>
            /// 组播udp ttl
            /// </summary>
            public int UdpTTL { get; set; } = 64;


            internal Dictionary<string, object> GetConfig() =>
                new Dictionary<string, object>
                {
                    { $"{MulticastConfig.PrefixName}addrMax", AddrMax },
                    { $"{MulticastConfig.PrefixName}addrMin", AddrMin },
                    { $"{MulticastConfig.PrefixName}udpTTL", UdpTTL }
                };
        }
        /// <summary>
        /// 
        /// </summary>
        public class RecordConfig
        {
            internal static string PrefixName = "record.";

            /// <summary>
            /// mp4录制或mp4点播的应用名，通过限制应用名，可以防止随意点播
            /// </summary>
            /// <remarks>点播的文件必须放置在此文件夹下</remarks>
            public string AppName { get; set; } = "record";

            /// <summary>
            /// mp4录制写文件缓存，单位BYTE,调整参数可以提高文件io性能
            /// </summary>
            public int FileBufSize { get; set; } = 65536;

            /// <summary>
            /// mp4录制保存、mp4点播根路径
            /// </summary>
            /// <remarks>可以为相对(相对于本可执行程序目录)或绝对路径</remarks>
            public string FilePath { get; set; } = @"./www";

            /// <summary>
            /// mp4录制切片时间，单位秒
            /// </summary>
            public int FileSecond { get; set; } = 3600;
            /// <summary>
            /// mp4点播每次流化数据量，单位毫秒
            /// 减少该值可以让点播数据发送量更平滑，增大该值则更节省cpu资源
            /// </summary>
            public int SampleMS { get; set; } = 500;

            /// <summary>
            /// mp4录制完成后是否进行二次关键帧索引写入头部
            /// </summary>
            public int FastStart { get; set; } = 0;

            /// <summary>
            /// MP4点播(rtsp/rtmp/http-flv/ws-flv)是否循环播放文件
            /// </summary>
            public int FileRepeat { get; set; } = 0;

            internal Dictionary<string, object> GetConfig() =>
                new Dictionary<string, object>
                {
                    { $"{RecordConfig.PrefixName}appName", AppName },
                    { $"{RecordConfig.PrefixName}fileBufSize", FileBufSize },
                    { $"{RecordConfig.PrefixName}filePath", FilePath },
                    { $"{RecordConfig.PrefixName}fileSecond", FileSecond },
                    { $"{RecordConfig.PrefixName}sampleMS", SampleMS },
                    { $"{RecordConfig.PrefixName}fastStart", FastStart },
                    { $"{RecordConfig.PrefixName}fileRepeat", FileRepeat }
                };
        }
        /// <summary>
        /// 
        /// </summary>
        public class RtmpConfig
        {
            internal static string PrefixName = "rtmp.";

            /// <summary>
            /// rtmp必须在此时间内完成握手，否则服务器会断开链接，单位秒
            /// </summary>
            public int HandshakeSecond { get; set; } = 15;
            /// <summary>
            /// rtmp超时时间，如果该时间内未收到客户端的数据，
            /// </summary>
            /// <remarks>或者tcp发送缓存超过这个时间，则会断开连接，单位秒</remarks>
            public int KeepAliveSecond { get; set; } = 15;
            /// <summary>
            /// 在接收rtmp推流时，是否重新生成时间戳(很多推流器的时间戳着实很烂)
            /// </summary>
            public int ModifyStamp { get; set; } = 0;
            /// <summary>
            /// rtmp服务器监听端口
            /// </summary>
            public int Port { get; set; } = 1935;
            /// <summary>
            /// rtmps服务器监听地址
            /// </summary>
            public int Sslport { get; set; } = 19350;

            internal Dictionary<string, object> GetConfig() =>
                new Dictionary<string, object>
                {
                    { $"{RtmpConfig.PrefixName}handshakeSecond", HandshakeSecond },
                    { $"{RtmpConfig.PrefixName}keepAliveSecond", KeepAliveSecond },
                    { $"{RtmpConfig.PrefixName}modifyStamp", ModifyStamp },
                    { $"{RtmpConfig.PrefixName}port", Port },
                    { $"{RtmpConfig.PrefixName}sslport", Sslport }
                };
        }
        /// <summary>
        /// 
        /// </summary>
        public class RtpConfig
        {
            internal static string PrefixName = "rtp.";

            /// <summary>
            /// 音频mtu大小，该参数限制rtp最大字节数，推荐不要超过1400,
            /// 加大该值会明显增加直播延时
            /// </summary>
            public int AudioMtuSize { get; set; } = 600;
            /// <summary>
            /// 如果rtp的序列号连续clearCount次有序，那么rtp将不再排序(目的减少rtp排序导致的延时)
            /// </summary>
            public int ClearCount { get; set; } = 10;
            /// <summary>
            /// rtp时间戳回环时间，单位毫秒
            /// </summary>
            public int CycleMS { get; set; } = 46800000;
            /// <summary>
            /// rtp排序map缓存大小，加大该值可能会增大延时，但是rtp乱序问题会减小
            /// </summary>
            public int MaxRtpCount { get; set; } = 50;
            /// <summary>
            /// 视频mtu大小，该参数限制rtp最大字节数，推荐不要超过1400
            /// </summary>
            public int VideoMtuSize { get; set; } = 1400;


            internal Dictionary<string, object> GetConfig() =>
                new Dictionary<string, object>
                {
                    { $"{RtpConfig.PrefixName}audioMtuSize", AudioMtuSize},
                    { $"{RtpConfig.PrefixName}clearCount", ClearCount },
                    { $"{RtpConfig.PrefixName}cycleMS", CycleMS },
                    { $"{RtpConfig.PrefixName}maxRtpCount", MaxRtpCount },
                    { $"{RtpConfig.PrefixName}videoMtuSize", VideoMtuSize }
                };
        }
        /// <summary>
        /// 
        /// </summary>
        public class RtpProxyConfig
        {
            internal static string PrefixName = "rtp_proxy.";

            /// <summary>
            /// udp类型的代理服务器是否检查rtp源地址，地址不配备将丢弃数据
            /// </summary>
            public int CheckSource { get; set; } = 1;
            /// <summary>
            /// 导出调试数据(包括rtp/ps/h264)至该目录,置空则关闭数据导出
            /// </summary>
            public string DumpDir { get; set; }
            /// <summary>
            /// udp和tcp代理服务器，支持rtp(必须是ts或ps类型)代理
            /// </summary>
            public int Port { get; set; } = 10000;
            /// <summary>
            /// rtp超时时间，单位秒
            /// </summary>
            public int TimeoutSec { get; set; } = 15;
           
            internal Dictionary<string, object> GetConfig() =>
                new Dictionary<string, object>
                {
                    { $"{RtpProxyConfig.PrefixName}checkSource", CheckSource },
                    { $"{RtpProxyConfig.PrefixName}dumpDir", DumpDir },
                    { $"{RtpProxyConfig.PrefixName}port", Port },
                    { $"{RtpProxyConfig.PrefixName}timeoutSec", TimeoutSec }
                };
        }
        /// <summary>
        /// 
        /// </summary>
        public class RtspConfig
        {
            internal static string PrefixName = "rtsp.";

            /// <summary>
            /// rtsp专有鉴权方式是采用base64还是md5方式
            /// </summary>
            public bool AuthBasic { get; set; }
            /// <summary>
            /// rtsp拉流代理是否是直接代理模式
            /// </summary>
            /// <remarks>
            /// 直接代理后支持任意编码格式，但是会导致GOP缓存无法定位到I帧，可能会导致开播花屏;
            /// 并且如果是tcp方式拉流，如果rtp大于mtu会导致无法使用udp方式代理;
            /// 假定您的拉流源地址不是264或265或AAC，那么你可以使用直接代理的方式来支持rtsp代理;
            /// 默认开启rtsp直接代理，rtmp由于没有这些问题，是强制开启直接代理的
            /// </remarks>
            public bool DirectProxy { get; set; }
            /// <summary>
            /// rtsp必须在此时间内完成握手，否则服务器会断开链接，单位秒
            /// </summary>
            public int HandshakeSecond { get; set; } = 15;
            /// <summary>
            /// rtsp超时时间，如果该时间内未收到客户端的数据,或者tcp发送缓存超过这个时间，则会断开连接，单位秒
            /// </summary>
            public int KeepAliveSecond { get; set; } = 15;
            /// <summary>
            /// rtsp服务器监听地址
            /// </summary>
            public int Port { get; set; } = 554;
            /// <summary>
            /// rtsps服务器监听地址
            /// </summary>
            public int Sslport { get; set; } = 322;

            internal Dictionary<string, object> GetConfig() =>
                new Dictionary<string, object>
                {
                    { $"{RtspConfig.PrefixName}authBasic", AuthBasic ? 1 : 0 },
                    { $"{RtspConfig.PrefixName}directProxy", DirectProxy ? 1 : 0 },
                    { $"{RtspConfig.PrefixName}handshakeSecond", HandshakeSecond },
                    { $"{RtspConfig.PrefixName}keepAliveSecond", KeepAliveSecond },
                    { $"{RtspConfig.PrefixName}port", Port },
                    { $"{RtspConfig.PrefixName}sslport", Sslport }
                };
        }
        /// <summary>
        /// 
        /// </summary>
        public class ShellConfig
        {
            internal static string PrefixName = "shell.";
            /// <summary>
            /// 调试telnet服务器接受最大bufffer大小
            /// </summary>
            public int MaxReqSize { get; set; } = 1024;
            /// <summary>
            /// 调试telnet服务器监听端口
            /// </summary>
            public int Port { get; set; } = 9000;

            internal Dictionary<string, object> GetConfig() =>
                new Dictionary<string, object>
                {
                    { $"{ShellConfig.PrefixName}maxReqSize", MaxReqSize },
                    { $"{ShellConfig.PrefixName}port", Port }
                };
        }
    }
}
