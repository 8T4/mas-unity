using MasUnity.Cluster;
using MasUnity.Decision.Abstractions;
using MasUnity.HostedService.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace MasUnity.HostedService.Configuration
{
    /// <summary>
    /// To Configure the Agents
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed partial class AgentOption<T> where T : class, IAgent
    {
        public IServiceCollection Services { get; }
        public int Instances { get; }

        /// <summary>
        /// Add a Transient Agent and Singleton instances of Hosted services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="instances">number of instances</param>
        public AgentOption(IServiceCollection services, int instances = 1)
        {
            Services = services;
            Instances = instances;
            Services.AddTransient<T>();

            for (var instance = 0; instance < instances; instance++)
            {
                Services.AddSingleton<IHostedService, AgentHostedService<T>>();
            }
        }
    }

    /// <summary>
    /// Actions Injection Scopes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed partial class AgentOption<T> where T : class, IAgent
    {
        /// <summary>
        /// Add Singleton instance of Action
        /// </summary>
        /// <typeparam name="TS">Service</typeparam>
        /// <typeparam name="TI">Implementation</typeparam>
        /// <returns></returns>
        public AgentOption<T> WithAction<TS, TI>() where TS : class, IAction where TI : class, TS
        {
            Services.TryAddTransient<TS, TI>();
            return this;
        }

        /// <summary>
        /// Add Singleton instance of Action
        /// </summary>
        /// <typeparam name="TS">Service</typeparam>
        /// <returns></returns>        
        public AgentOption<T> WithAction<TS>() where TS : class, IAction
        {
            Services.TryAddTransient<TS>();
            return this;
        }
    }
    
    /// <summary>
    /// Knowledge Injection Scopes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed partial class AgentOption<T> where T : class, IAgent
    {
        /// <summary>
        /// Add Singleton instance of Knowledge
        /// </summary>
        /// <typeparam name="TS">Service</typeparam>
        /// <typeparam name="TI">Implementation</typeparam>
        /// <returns></returns>
        public AgentOption<T> WithKnowledge<TS, TI>() where TS : class, IKnowledge where TI : class, TS
        {
            Services.TryAddTransient<TS, TI>();
            return this;
        }
        
        /// <summary>
        /// Add Singleton instance of Knowledge
        /// </summary>
        /// <typeparam name="TS">Service</typeparam>
        /// <returns></returns>        
        public AgentOption<T> WithKnowledge<TS>() where TS : class, IKnowledge
        {
            Services.TryAddTransient<TS>();
            return this;
        }
    }    
}