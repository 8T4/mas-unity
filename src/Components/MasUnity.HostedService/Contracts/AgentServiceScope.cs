using Microsoft.Extensions.DependencyInjection;

namespace MasUnity.HostedService.Contracts
{
    public class AgentServiceScope : IAgentServiceScope
    {
        private IServiceScopeFactory ScopeFactory { get; }
        
        public AgentServiceScope(IServiceScopeFactory scope)
        {
            ScopeFactory = scope;
        }

        public T GetService<T>()
        {
            using var scope = ScopeFactory.CreateScope();
            var provider = scope.ServiceProvider;
                
            return provider.GetService<T>();
        }        
    }
}