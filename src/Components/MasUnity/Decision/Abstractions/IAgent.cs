using System;
using System.Threading.Tasks;
using MasUnity.Decision.Actions;

namespace MasUnity.Decision.Abstractions
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
    ///</summary>    
    public interface IAgent
    {
        public AgentIdentity Identity { get; }
        public AgentState State { get; }
        public ConcurrencyMode Concurrency { get; }
        public AgentReport Report { get; }

        public Task Invoke();
        public Task Suspend();
        public Task Suspend(Exception e);
        public Task Resume();
        public Task Wait();
        public Task WakeUp();
        public Task Move();
        public Task Execute();
        public Task Quit();

        public void Assign(AgentIdentity identity);
    }
}