using System.Threading;
using System.Threading.Tasks;
using MasUnity.Cluster;
using MasUnity.Decision.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MasUnity.HostedService.Contracts
{
    internal sealed class AgentHostedService<T> : BackgroundService where T : IAgent
    {
        private IServiceScopeFactory Scope { get; }

        public AgentHostedService(IServiceScopeFactory scope)
        {
            Scope = scope;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = Scope.CreateScope();
            var provider = scope.ServiceProvider;

            var agent = provider.GetService<T>();
            if (agent == null)
            {
                return Task.CompletedTask;
            }

            var cluster = provider.GetService<IAgentCluster>();
            if (cluster == null)
            {
                return Task.CompletedTask;
            }

            cluster.Register(agent);
            Task.Run(agent.Invoke, stoppingToken);

            return Task.CompletedTask;
        }
    }
}