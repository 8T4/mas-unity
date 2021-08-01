using System;
using System.Threading.Tasks;
using FluentAssertions;
using MasUnity.Tests.Stubs;
using Xunit;
using static MasUnity.Decision.AgentStates;

namespace MasUnity.Tests.Decision
{
    public class AgentLifeCycleTests
    {
        [Fact]
        public async Task Test_lifecycle_when_invoke_an_agent()
        {
            var stub = new SynchronousReactiveAgentStub();
            stub.State.Value.Should().Be(Initiated);
            
            await stub.Invoke();
            (stub.State.Value is Active or Suspended).Should().BeTrue();
        }

        [Fact]
        public async Task Test_lifecycle_when_suspend_and_resume_an_angent()
        {
            var stub = new SynchronousReactiveAgentStub();
            stub.State.SetState(Active);

            await stub.Suspend();
            stub.State.Value.Should().Be(Suspended);

            await stub.Resume();
            (stub.State.Value is Active or Suspended).Should().BeTrue();
        }
        
        [Fact]
        public async Task Test_lifecycle_when_wait_and_wakeup_an_angent()
        {
            var stub = new SynchronousReactiveAgentStub();
            stub.State.SetState(Active);
            
            await stub.Wait();
            stub.State.Value.Should().Be(Waiting); 

            await stub.WakeUp();
            (stub.State.Value is Active or Suspended).Should().BeTrue();
        }     
        
        [Fact]
        public async Task Test_lifecycle_when_move_and_execute_an_angent()
        {
            var stub = new SynchronousReactiveAgentStub();
            stub.State.SetState(Active);
            
            await stub.Move();
            stub.State.Value.Should().Be(Transit); 
            
            await stub.Execute();
            (stub.State.Value is Active or Suspended).Should().BeTrue();
        }   
        
        [Fact]
        public async Task Test_lifecycle_when_quit_angent()
        {
            var stub = new SynchronousReactiveAgentStub();
            stub.State.SetState(Active);
            
            await stub.Quit();
            stub.State.Value.Should().Be(Deleted); 
        }        
        
        [Fact]
        public async Task Test_agent_lifecycle_move_next()
        {
            var stub = new SynchronousReactiveAgentStub();
            stub.State.Value.Should().Be(Initiated);

            await stub.Suspend();
            stub.State.Value.Should().Be(Initiated);
            
            await stub.Suspend(new Exception());
            stub.State.Value.Should().Be(Initiated);            
            
            await stub.Resume();
            stub.State.Value.Should().Be(Initiated);
            
            await stub.Wait();
            stub.State.Value.Should().Be(Initiated); 
            
            await stub.WakeUp();
            stub.State.Value.Should().Be(Initiated);
            
            await stub.Move();
            stub.State.Value.Should().Be(Initiated); 
            
            await stub.Execute();
            stub.State.Value.Should().Be(Initiated);
            
            await stub.Quit();
            stub.State.Value.Should().Be(Deleted);
            
            await stub.Invoke();
            stub.State.Value.Should().Be(Deleted);            
        }        
    }
}