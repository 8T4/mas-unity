using System.Diagnostics.CodeAnalysis;
using MasUnity.Decision.Abstractions;
using MasUnity.HostedService.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MasUnity.HostedService.Configuration
{
    public sealed class AgentOption<T> where T : class, IAgent
    {
        public IServiceCollection ServiceCollection { get; }
        public int Instances { get; }

        public AgentOption(IServiceCollection serviceCollection, int instances = 1)
        {
            ServiceCollection = serviceCollection;
            Instances = instances;
            ServiceCollection.AddTransient<T>();
            
            for (var instance = 0; instance < instances; instance++)
            {
                ServiceCollection.AddSingleton<IHostedService, AgentHostedService<T>>();
            }
        }
        
        public AgentOption<T> WithAction<TService, TImplementation>() 
            where TService: class, IAction
            where TImplementation : class, TService
        {
            ServiceCollection.AddSingleton<TService, TImplementation>();
            return this;
        }

        public AgentOption<T> WithKnowledge<TService, TImplementation>()
            where TService: class, IKnowledge
            where TImplementation : class, TService
        {
            ServiceCollection.AddSingleton<TService, TImplementation>();
            return this;
        }        
    }
}