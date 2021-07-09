using System.Threading;
using System.Threading.Tasks;
using MasUnity.Decision.Actions;

namespace MasUnity.Decision.Abstractions
{
    /// <summary>
    /// Task is another fundamental concept in the MAS paradigm. Each agent is responsible for performing
    /// tasks to solve partial problems. MAS supports task synchronization, task allocation, task sharing,
    /// and result sharing.
    /// <see href="https://www.sciencedirect.com/science/article/abs/pii/S0167923604002155?via%3Dihub"/>
    /// <code>
    ///     Action is P* -> A
    ///     P*: is a sequence of perceptions
    ///     A: Actions    
    /// </code>
    /// </summary>
    public interface IAction
    {
        Task<Perception> Realize(AgentContext context, CancellationToken cancellation);
        
        Task<AgentResult> Execute(AgentContext context, CancellationToken cancellation);
    }
}