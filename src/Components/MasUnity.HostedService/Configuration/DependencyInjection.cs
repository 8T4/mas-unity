using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace MasUnity.HostedService.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureMasUnity(this IServiceCollection services, Action<AgentClusterOption> setupAction)
        {
            var option = new AgentClusterOption(services);
            setupAction.Invoke(option);
            
            return services;
        }
    }
}