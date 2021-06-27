using System.Diagnostics.CodeAnalysis;
using MasUnity.Cluster;
using MasUnity.Decision.Abstractions;
using Microsoft.Extensions.DependencyInjection;

[assembly: ExcludeFromCodeCoverage]
namespace MasUnity.HostedService.Configuration
{
    /// <summary>
    /// Options to configure agent cluster
    /// </summary>
    public sealed class AgentClusterOption
    {
        private IServiceCollection ServiceCollection { get; }

        public AgentClusterOption(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
            ServiceCollection.AddSingleton<IAgentStorage, AgentInMemoryStorage>();
            ServiceCollection.AddSingleton<IAgentCluster, AgentCluster>();            
        }
        
        public AgentOption<T> AddAgent<T>(int instances = 1) where T : class, IAgent
        {
            return new AgentOption<T>(ServiceCollection, instances);
        }        
    }
}