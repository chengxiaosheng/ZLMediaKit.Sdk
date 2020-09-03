using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZLMediaKit.Sdk.Demo
{
    public static class StartUp
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddZLMediaKitSDK(configuration);
            return services;
        }
    }
}
