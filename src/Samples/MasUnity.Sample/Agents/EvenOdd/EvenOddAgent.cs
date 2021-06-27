using System.Collections.Generic;
using MasUnity.Agents;
using MasUnity.Decision.Abstractions;
using MasUnity.Sample.Agents.EvenOdd.Actions;

namespace MasUnity.Sample.Agents.EvenOdd
{
    public class OddAgent: ProactiveAgent
    {
        private readonly SayNumberIsOdd _sayNumberIsOdd;

        public OddAgent(SayNumberIsOdd sayNumberIsOdd) : base(new EvenOrOddAgentSchedule())
        {
            _sayNumberIsOdd = sayNumberIsOdd;
        }

        protected override IEnumerable<IAction> RegisterActions()
        {
            yield return _sayNumberIsOdd;
        }
    }
}