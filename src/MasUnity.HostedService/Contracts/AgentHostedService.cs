using System.Threading;
using System.Threading.Tasks;
using MasUnity.Cluster;
using MasUnity.Decision.Abstractions;

namespace MasUnity.HostedService.Contracts
{
    internal sealed class AgentHostedService<T>: IAgentHostedService<T> where T : IAgent
    {
        public T Agent { get; }

        public AgentHostedService(T agent, IAgentCluster cluster)
        {
            Agent = agent;
            cluster.Register(agent);
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(Agent.Invoke, cancellationToken);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Task.Run(Agent.Suspend, cancellationToken);
            return Task.CompletedTask;
        }
    }
}