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
            var result = Perception.Assertion(
                ("Can say Goodby?", true)
            );

            return Task.FromResult(result);
        }

        public Task<AgentResult> Execute(CancellationToken cancellation)
        {
            return Task.FromResult(AgentResult.Fail("Error"));
        }
    }
    
    public class SkypAction: IAction
    {
        public Task<Perception> Realize(CancellationToken cancellation)
        {
            var result = Perception.Assertion(
                ("Can say Goodby?", false)
            );

            return Task.FromResult(result);
        }

        public Task<AgentResult> Execute(CancellationToken cancellation)
        {
            return Task.FromResult(AgentResult.Fail("Error"));
        }
    }    
    
    public class CancellationTokenAction: IAction
    {
        public Task<Perception> Realize(CancellationToken cancellation)
        {
            var result = Perception.Assertion(
                ("Can say Goodby?", true)
            );

            return Task.FromResult(result);
        }

        public Task<AgentResult> Execute(CancellationToken cancellation)
        {
            throw new OperationCanceledException();
        }
        
    }    
}