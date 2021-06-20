using System.Collections.Generic;
using MasUnity.Agents;
using MasUnity.Commons.Scheduling;
using MasUnity.Decision.Abstractions;
using MasUnity.Decision.Actions;
using MasUnity.Tests.Stubs.Actions;

namespace MasUnity.Tests.Stubs
{
    public class SynchronousProactiveAgentStub: ProactiveAgent
    {
        protected override IEnumerable<IAction> RegisterActions()
        {
            yield return new SayGoodByAction();
            yield return new SayHelloAction();
        }

        public SynchronousProactiveAgentStub() : base(new ScheduleStub())
        {
        }
    }
    
    public class AsynchronousProactiveAgentStub: ProactiveAgent
    {
        public AsynchronousProactiveAgentStub():base(new ScheduleStub())
        {
            Concurrency = ConcurrencyMode.Asynchronous;
        }
        
        protected override IEnumerable<IAction> RegisterActions()
        {
            yield return new SayGoodByAction();
            yield return new SayHelloAction();
        }
    }        
}