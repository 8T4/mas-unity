using System.Collections.Generic;
using MasUnity.Agents;
using MasUnity.Decision.Abstractions;
using MasUnity.Sample.Agents.EvenOdd.Actions;

namespace MasUnity.Sample.Agents.EvenOdd
{
    public class EvenAgent: ProactiveAgent
    {
        private readonly SayNumberIsEven _sayNumberIsEven;

        public EvenAgent(
            SayNumberIsEven sayNumberIsEven) : base(new EvenOrOddAgentSchedule())
        {
            _sayNumberIsEven = sayNumberIsEven;
        }

        protected override IEnumerable<IAction> RegisterActions()
        {
            yield return _sayNumberIsEven;
        }
    }
}