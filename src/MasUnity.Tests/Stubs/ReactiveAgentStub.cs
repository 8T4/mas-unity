using System.Collections.Generic;
using MasUnity.Agents;
using MasUnity.Decision.Abstractions;
using MasUnity.Decision.Actions;
using MasUnity.Tests.Stubs.Actions;

namespace MasUnity.Tests.Stubs
{
    public class SynchronousReactiveAgentStub: ReactiveAgent
    {
        protected override IEnumerable<IAction> RegisterActions()
        {
            yield return new SayGoodByAction();
            yield return new SayHelloAction();
        }
    }
    
    public class AsynchronousReactiveAgentStub: ReactiveAgent
    {
        public AsynchronousReactiveAgentStub()
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