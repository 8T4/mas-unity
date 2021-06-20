using MasUnity.Decision.Abstractions;
using Microsoft.Extensions.Hosting;

namespace MasUnity.HostedService.Contracts
{
    internal interface IAgentHostedService<T> : IHostedService where T : IAgent
    {
        public T Agent { get; }
    }
}