using System.Diagnostics.CodeAnalysis;
using MasUnity.Cluster;
using MasUnity.Decision.Abstractions;
using MasUnity.HostedService.Contracts;
using Microsoft.Extensions.DependencyInjection;

[assembly: ExcludeFromCodeCoverage]
namespace MasUnity.HostedService.Configuration
{
    /// <summary>
    /// Options to configure agent cluster
    /// </summary>
    public sealed class AgentClusterOption
    {
        private IServiceCollection Services { get; }

        public AgentClusterOption(IServiceCollection services)
        {
            Services = services;
            Services.AddSingleton<IAgentStorage, AgentInMemoryStorage>();
            Services.AddSingleton<IAgentCluster, AgentCluster>();
            Services.AddSingleton<IAgentServiceScope, AgentServiceScope>();
        }
        
        public AgentOption<T> AddAgent<T>(int instances = 1) where T : class, IAgent
        {
            return new AgentOption<T>(Services, instances);
        }        
    }
}