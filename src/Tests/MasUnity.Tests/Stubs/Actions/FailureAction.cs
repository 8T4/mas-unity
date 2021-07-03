using System;
using System.Threading;
using System.Threading.Tasks;
using MasUnity.Decision;
using MasUnity.Decision.Abstractions;
using MasUnity.Decision.Actions;

namespace MasUnity.Tests.Stubs.Actions
{
    public class FailureAction: IAction
    {
        public Task<Perception> Realize(CancellationToken cancellation)
        {
            return Perception.Assertion(
                ("Can say Goodby?", true)
            );
        }

        public Task<AgentResult> Execute(AgentContext context, CancellationToken cancellation)
        {
            return Task.FromResult(AgentResult.Fail("Error"));
        }
    }
    
    public class SkypAction: IAction
    {
        public Task<Perception> Realize(CancellationToken cancellation)
        {
            return Perception.Assertion(
                ("Can say Goodby?", false)
            );
        }

        public Task<AgentResult> Execute(AgentContext context, CancellationToken cancellation)
        {
            return Task.FromResult(AgentResult.Fail("Error"));
        }
    }    
    
    public class CancellationTokenAction: IAction
    {
        public Task<Perception> Realize(CancellationToken cancellation)
        {
            return Perception.Assertion(
                ("Can say Goodby?", true)
            );
        }

        public Task<AgentResult> Execute(AgentContext context, CancellationToken cancellation)
        {
            throw new OperationCanceledException();
        }
    }    
}