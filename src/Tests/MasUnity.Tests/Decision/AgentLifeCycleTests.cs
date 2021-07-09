using System;
using System.Threading.Tasks;
using FluentAssertions;
using MasUnity.Decision;
using MasUnity.Tests.Stubs;
using Xunit;

namespace MasUnity.Tests.Decision
{
    public class AgentLifeCycleTests
    {
        [Fact]
        public async Task Test_agent_lifecycle()
        {
            var stub = new SynchronousReactiveAgentStub();

            stub.State.Value.Should().Be(AgentStates.Initiated);
            await stub.Invoke();
            stub.State.Value.Should().Be(AgentStates.Active);
            await stub.Suspend();
            stub.State.Value.Should().Be(AgentStates.Suspended);
            await stub.Resume();
            stub.State.Value.Should().Be(AgentStates.Active);
            await stub.Wait();
            stub.State.Value.Should().Be(AgentStates.Waiting); 
            await stub.WakeUp();
            stub.State.Value.Should().Be(AgentStates.Active);
            await stub.Move();
            stub.State.Value.Should().Be(AgentStates.Transit); 
            await stub.Execute();
            stub.State.Value.Should().Be(AgentStates.Active);
            await stub.Quit();
            stub.State.Value.Should().Be(AgentStates.Deleted);
        }
        
        [Fact]
        public async Task Test_agent_lifecycle_move_next()
        {
            var stub = new SynchronousReactiveAgentStub();
            
            stub.State.Value.Should().Be(AgentStates.Initiated);
            await stub.Suspend();
            stub.State.Value.Should().Be(AgentStates.Initiated);
            await stub.Suspend(new Exception());
            stub.State.Value.Should().Be(AgentStates.Initiated);            
            await stub.Resume();
            stub.State.Value.Should().Be(AgentStates.Initiated);
            await stub.Wait();
            stub.State.Value.Should().Be(AgentStates.Initiated); 
            await stub.WakeUp();
            stub.State.Value.Should().Be(AgentStates.Initiated);
            await stub.Move();
            stub.State.Value.Should().Be(AgentStates.Initiated); 
            await stub.Execute();
            stub.State.Value.Should().Be(AgentStates.Initiated);
            await stub.Quit();
            stub.State.Value.Should().Be(AgentStates.Deleted);
            await stub.Invoke();
            stub.State.Value.Should().Be(AgentStates.Deleted);            
        }        
    }
}