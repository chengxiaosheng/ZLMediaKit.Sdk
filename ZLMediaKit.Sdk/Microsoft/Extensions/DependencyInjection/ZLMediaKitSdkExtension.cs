using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using ZLMediaKit.Sdk;
using ZLMediaKit.Sdk.HostedServices;
using ZLMediaKit.Sdk.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 服务注册类
    /// </summary>
    public static class ZLMediaKitSdkExtension
    {
        //注册SDK服务，通过配置文件启动服务进程
        public static IServiceCollection AddZLMediaKitSDK(this IServiceCollection service, IConfiguration configuration)
        {
            //注入配置文件
            service.AddOptions().Configure<ZLMediaKitOptions>("ZLMediaKit",configuration);

            return service.AddHostedService<InitService>().AddSingleton<ZLMediaKitEventBindService>();

        }

        /// <summary>
        /// 注册SDK服务，通过config.ini 文件启动SDK进程
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddZLMediaKitSDK(this IServiceCollection service)
        {
            return service.AddSingleton<ZLMediaKitEventBindService>().AddHostedService<InitService>();
        }
    }
}
