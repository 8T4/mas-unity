using System.Collections.Generic;
using MasUnity.Agents;
using MasUnity.Decision.Abstractions;
using MasUnity.HostedService.Contracts;
using MasUnity.Sample.Agents.EvenOdd.Actions;

namespace MasUnity.Sample.Agents.EvenOdd
{
    public class OddAgent: ProactiveAgent
    {
        private IAgentServiceScope Scope { get; }

        public OddAgent(IAgentServiceScope scope, EvenOrOddAgentSchedule schedule) : base(schedule)
        {
            Scope = scope;
        }

        protected override IEnumerable<IAction> RegisterActions()
        {
            yield return Scope.GetService<SayNumberIsOdd>();
        }
    }
}