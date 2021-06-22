using System.Diagnostics.CodeAnalysis;
using MasUnity.Decision.Abstractions;
using MasUnity.HostedService.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MasUnity.HostedService.Configuration
{
    /// <summary>
    /// To Configure the Agents
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class AgentOption<T> where T : class, IAgent
    {
        public IServiceCollection ServiceCollection { get; }
        public int Instances { get; }

        /// <summary>
        /// Add a Transient Agent and Singleton instances of Hosted services
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="instances">number of instances</param>
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
        
        /// <summary>
        /// Add Singleton instance of Action
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        public AgentOption<T> WithAction<TService, TImplementation>() 
            where TService: class, IAction
            where TImplementation : class, TService
        {
            ServiceCollection.AddSingleton<TService, TImplementation>();
            return this;
        }

        /// <summary>
        /// Add Singleton instance of Knowledge
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        public AgentOption<T> WithKnowledge<TService, TImplementation>()
            where TService: class, IKnowledge
            where TImplementation : class, TService
        {
            ServiceCollection.AddSingleton<TService, TImplementation>();
            return this;
        }        
    }
}