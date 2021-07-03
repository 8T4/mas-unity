using System;
using System.Collections.Generic;
using MasUnity.Agents;
using MasUnity.Decision.Abstractions;
using MasUnity.Decision.Actions;
using MasUnity.Tests.Stubs.Actions;

namespace MasUnity.Tests.Stubs
{
    public class FailureAgentStub: ReactiveAgent
    {
        protected override IEnumerable<IAction> RegisterActions()
        {
            yield return new FailureAction();
        }
    }
    
    public class SkypAsyncAgentStub: ReactiveAgent
    {
        public SkypAsyncAgentStub()
        {
            Concurrency = ConcurrencyMode.Asynchronous;
        }
        
        protected override IEnumerable<IAction> RegisterActions()
        {
            yield return new SkypAction();
        }
    }    
    
    public class SkypAgentStub: ReactiveAgent
    {
        protected override IEnumerable<IAction> RegisterActions()
        {
            yield return new SkypAction();
        }
    }   
    
    public class ExceptionAgentStub: ReactiveAgent
    {
        protected override IEnumerable<IAction> RegisterActions()
        {
            throw new NotImplementedException();
        }
    }  
    
    public class CancellationTokenAgentStub: ReactiveAgent
    {
        protected override IEnumerable<IAction> RegisterActions()
        {
            yield return new CancellationTokenAction();
        }
    }    
    
    //ProactiveAgent
    
    public class FailureProactiveAgentStub: ProactiveAgent
    {
        public FailureProactiveAgentStub():base(new ScheduleStub())
        {
            Concurrency = ConcurrencyMode.Asynchronous;
        }
        
        protected override IEnumerable<IAction> RegisterActions()
        {
            yield return new FailureAction();
        }
    }
    
    public class SkypAsyncProactiveAgentStub: ProactiveAgent
    {
        public SkypAsyncProactiveAgentStub():base(new ScheduleStub())
        {
            Concurrency = ConcurrencyMode.Asynchronous;
        }
        
        protected override IEnumerable<IAction> RegisterActions()
        {
            yield return new SkypAction();
        }
    }    
    
    public class SkypProactiveAgentStub: ProactiveAgent
    {
        protected override IEnumerable<IAction> RegisterActions()
        {
            yield return new SkypAction();
        }

        public SkypProactiveAgentStub() : base(new ScheduleStub())
        {
        }
    }   
    
    public class ExceptionProactiveAgentStub: ProactiveAgent
    {
        protected override IEnumerable<IAction> RegisterActions()
        {
            throw new NotImplementedException();
        }

        public ExceptionProactiveAgentStub() : base(new ScheduleStub())
        {
        }
    }  
    
    public class CancellationTokenProactiveAgentStub: ProactiveAgent
    {
        protected override IEnumerable<IAction> RegisterActions()
        {
            yield return new CancellationTokenAction();
        }

        public CancellationTokenProactiveAgentStub() : base(new ScheduleStub())
        {
        }
    }   
}