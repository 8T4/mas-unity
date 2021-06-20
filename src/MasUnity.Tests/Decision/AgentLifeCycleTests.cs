using System;
using FluentAssertions;
using MasUnity.Decision;
using MasUnity.Tests.Stubs;
using Xunit;

namespace MasUnity.Tests.Decision
{
    public class AgentLifeCycleTests
    {
        private readonly SynchronousReactiveAgentStub _stub;

        public AgentLifeCycleTests()
        {
            _stub = new SynchronousReactiveAgentStub();
        }
        
        [Fact]
        public void Test_agent_lifecycle()
        {
            _stub.State.Value.Should().Be(AgentStates.Initiated);
            _stub.Invoke();
            _stub.State.Value.Should().Be(AgentStates.Active);
            _stub.Suspend();
            _stub.State.Value.Should().Be(AgentStates.Suspended);
            _stub.Resume();
            _stub.State.Value.Should().Be(AgentStates.Active);
            _stub.Wait();
            _stub.State.Value.Should().Be(AgentStates.Waiting); 
            _stub.WakeUp();
            _stub.State.Value.Should().Be(AgentStates.Active);
            _stub.Move();
            _stub.State.Value.Should().Be(AgentStates.Transit); 
            _stub.Execute();
            _stub.State.Value.Should().Be(AgentStates.Active);
            _stub.Quit();
            _stub.State.Value.Should().Be(AgentStates.Deleted);
        }
        
        [Fact]
        public void Test_agent_lifecycle_move_next()
        {
            _stub.State.Value.Should().Be(AgentStates.Initiated);
            _stub.Suspend();
            _stub.State.Value.Should().Be(AgentStates.Initiated);
            _stub.Suspend(new Exception());
            _stub.State.Value.Should().Be(AgentStates.Initiated);            
            _stub.Resume();
            _stub.State.Value.Should().Be(AgentStates.Initiated);
            _stub.Wait();
            _stub.State.Value.Should().Be(AgentStates.Initiated); 
            _stub.WakeUp();
            _stub.State.Value.Should().Be(AgentStates.Initiated);
            _stub.Move();
            _stub.State.Value.Should().Be(AgentStates.Initiated); 
            _stub.Execute();
            _stub.State.Value.Should().Be(AgentStates.Initiated);
            _stub.Quit();
            _stub.State.Value.Should().Be(AgentStates.Deleted);
            _stub.Invoke();
            _stub.State.Value.Should().Be(AgentStates.Deleted);            
        }        
    }
}