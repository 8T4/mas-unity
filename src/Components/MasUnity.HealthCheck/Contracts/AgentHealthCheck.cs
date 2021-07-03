using System.Threading;
using System.Threading.Tasks;
using MasUnity.Cluster;
using MasUnity.Decision.Abstractions;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MasUnity.HealthCheck.Contracts
{
    internal sealed class AgentHealthCheck<T>: IHealthCheck where T: IAgent
    {
        private IAgentCluster Cluster { get; }
        
        public AgentHealthCheck(IAgentCluster cluster)
        {
            Cluster = cluster;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            var agent = await Cluster.Get(context.Registration.Name).ConfigureAwait(false);

            if (agent == null)
            {
                return new HealthCheckResult(HealthStatus.Degraded, "service was removed");
            }

            return agent.Report.Result.IsSuccess
                ? HealthCheckResult.Healthy($"service is ready")
                : new HealthCheckResult(context.Registration.FailureStatus, "service is unhealthy or removed");
        }
    }
}