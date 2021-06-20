using System.Threading;
using System.Threading.Tasks;
using MasUnity.Decision;
using MasUnity.Decision.Abstractions;
using MasUnity.Decision.Actions;

namespace MasUnity.Tests.Stubs.Actions
{
    public class SayGoodByAction : IAction
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
            return Task.FromResult(AgentResult.Ok("Goodby"));
        }
    }
}