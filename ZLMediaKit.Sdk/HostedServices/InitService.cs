using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZLMediaKit.Sdk.Original;
using ZLMediaKit.Sdk.Services;

namespace ZLMediaKit.Sdk.HostedServices
{
    //在程序启动时初始化SDK 
    internal class InitService : IHostedService
    {
        private readonly ILogger<InitService> _logger;
        private readonly IOptions<ZLMediaKitOptions> _options;
        private readonly ZLMediaKitEventBindService _zLMediaKitEventBindService;
        public InitService(ILogger<InitService> logger, IOptions<ZLMediaKitOptions> options , ZLMediaKitEventBindService zLMediaKitEventBindService)
        {
            _logger = logger;
            _options = options;
            _zLMediaKitEventBindService = zLMediaKitEventBindService;
        }
        //初始化SDK
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin Start ZLMediaKit SDK Service");
            var mk_config = new mk_config
            {
                log_level = 0,
                ini = _options.Value.GetConfig(),
                ini_is_path = 0,
                log_file_days = 7,
                log_file_path = Path.Combine("Logs","ZLMediaKit"),
            };
            mk_common.mk_env_init(ref mk_config);
            mk_common.mk_http_server_start((ushort)_options.Value.Http.Port, 0);
            mk_common.mk_rtsp_server_start((ushort)_options.Value.Rtsp.Port, 0);
            mk_common.mk_rtmp_server_start((ushort)_options.Value.Rtmp.Port, 0);
            mk_common.mk_rtp_server_start((ushort)_options.Value.RtpProxy.Port);
            _zLMediaKitEventBindService.BindEvents();
            return Task.CompletedTask;
        }

        //关闭SDK所有服务
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin Stop ZLMediaKit SDK Service");
            _zLMediaKitEventBindService.UnBindEvents();
            mk_common.mk_stop_all_server();
            return Task.CompletedTask;
        }
    }
}
