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

        /// <summary>
        /// Add new agent
        /// </summary>
        /// <typeparam name="T">IAgent</typeparam>
        /// <returns></returns>
        public AgentOption<T> AddAgent<T>() where T : class, IAgent
        {
            return new AgentOption<T>(Services, 1);
        }        
        
        /// <summary>
        /// Add new agent
        /// </summary>
        /// <param name="instances">number of instances</param>
        /// <typeparam name="T">IAgent</typeparam>
        /// <returns></returns>
        public AgentOption<T> AddAgent<T>(int instances) where T : class, IAgent
        {
            return new AgentOption<T>(Services, instances);
        }        
    }
}