using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasUnity.Decision.Abstractions;
using MasUnity.Decision.Actions;

namespace MasUnity.Decision
{
    /// <summary>
    /// Agents are the fundamental concept in the MAS paradigm. There are multiple agents in a multi-agent system.
    /// However, no agent possesses the knowledge or the capabilities to understand and solve the entire problem.
    /// <see href="https://www.sciencedirect.com/science/article/abs/pii/S0167923604002155?via%3Dihub"/>
    /// <code>
    ///     Environment is T:Ra -> P(E)
    ///         P(E): is a set of parts of E.
    ///         E: is a sequence of (state-action)
    /// 
    ///     Action Execution is Env = (E, S0, t)
    ///         Env: is Environment
    ///         E: is a sequence of (state-action)
    ///         S0: initial state
    ///         t: is ((S0, a0, S1, a1, S2, a2 ... an-1))
    /// </code>
    /// </summary>    
    public abstract partial class Agent : IAgent
    {
        public AgentIdentity Identity { get; private set; }
        public AgentState State { get; private set; }
        public ConcurrencyMode Concurrency { get; protected set; }
        public AgentReport Report { get; private set; }
        protected IAction[] Actions { get; set; }

        protected Agent()
        {
            Identity = default;
            Actions = default;
            State = new AgentState();
            Report = new AgentReport();
            Concurrency = ConcurrencyMode.Synchronous;
        }

        public void Assign(AgentIdentity identity)
        {
            Identity = identity;
        }

        protected abstract Task Run();

        protected abstract IEnumerable<IAction> RegisterActions();
        
        protected async Task ExecuteActionsSynchronously(CancellationToken token)
        {
            foreach (var action in Actions)
            {
                await ExecuteAction(action, token).ConfigureAwait(false);
            }            
        }

        protected Task ExecuteActionsAsynchronously(CancellationToken token)
        {
            Task.WaitAll(Actions.Select(action => Task.Run(async () =>
            {
                await ExecuteAction(action, token).ConfigureAwait(false);
            }, token)).ToArray()); 
              
            return Task.CompletedTask;
        }

        private async Task ExecuteAction(IAction action, CancellationToken token)
        {
            var context = new AgentContext(Identity, State);
            var perception = await action.Realize(context, token).ConfigureAwait(false);
            
            if (perception.IsFalse)
            {
                perception.NotRealizeAction?.Invoke();
                return;
            }
            
            Report.Result.Merge(await action.Execute(context, token).ConfigureAwait(false));
        }
    }
}