using MasUnity.Commons.Scheduling;
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
        public int Partitions { get; }

        /// <summary>
        /// Add a Transient Agent and Singleton instances of Hosted services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="partitions">number of partition</param>
        public AgentOption(IServiceCollection services, int partitions)
        {
            Services = services;
            Partitions = partitions;
        }

        public void Build()
        {
            Services.AddTransient<T>();
            
            for (var partition = 0; partition < Partitions; partition++)
            {
                Services.AddSingleton<IHostedService, AgentHostedService<T>>();
            }            
        }
    }
    
    /// <summary>
    /// Schedule Injection Scopes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed partial class AgentOption<T> where T : class, IAgent
    {
        /// <summary>
        /// Add Transient instance of Action
        /// </summary>
        /// <typeparam name="TS">Service</typeparam>
        /// <returns></returns>        
        public AgentOption<T> WithSchedule<TS>() where TS : class, ISchedule
        {
            Services.TryAddTransient<TS>();
            return this;
        }
    }    

    /// <summary>
    /// Actions Injection Scopes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed partial class AgentOption<T> where T : class, IAgent
    {
        /// <summary>
        /// Add Transient instance of Action
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
        /// Add Transient instance of Action
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
        /// Add Transient instance of Knowledge
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
        /// Add Transient instance of Knowledge
        /// </summary>
        /// <typeparam name="TS">Service</typeparam>
        /// <returns></returns>        
        public AgentOption<T> WithKnowledge<TS>() where TS : class, IKnowledge
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
        /// Add Transient instance of Knowledge
        /// </summary>
        /// <typeparam name="TS">Service</typeparam>
        /// <typeparam name="TI">Implementation</typeparam>
        /// <returns></returns>
        public AgentOption<T> WithEnvironment<TS, TI>() where TS : class, IEnvironment where TI : class, TS
        {
            Services.TryAddTransient<TS, TI>();
            return this;
        }
        
        /// <summary>
        /// Add Transient instance of Knowledge
        /// </summary>
        /// <typeparam name="TS">Service</typeparam>
        /// <returns></returns>        
        public AgentOption<T> WithEnvironment<TS>() where TS : class, IEnvironment
        {
            Services.TryAddTransient<TS>();
            return this;
        }
    }        
}