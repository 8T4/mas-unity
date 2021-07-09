using System.Diagnostics.CodeAnalysis;
using MasUnity.Decision;
using MasUnity.Decision.Abstractions;
using MasUnity.HealthCheck.Contracts;
using MasUnity.HostedService.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: ExcludeFromCodeCoverage]
namespace MasUnity.HealthCheck.Configuration
{
    public static class DependencyInjection
    {
        public static AgentOption<T> WithHealtCheck<T>(this AgentOption<T> agent) 
            where T : class, IAgent
        {
            for (var partition = 0; partition < agent.Partitions; partition++)
            {
                var identity = AgentIdentity.GetIdentity<T>(partition);
                agent.Services.AddHealthChecks().AddCheck<AgentHealthCheck<T>>(identity.Uri);
            }

            return agent;
        }
    }
}