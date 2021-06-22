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
        private readonly SynchronousReactiveAgentStub _stub;

        public AgentLifeCycleTests()
        {
            _stub = new SynchronousReactiveAgentStub();
        }
        
        [Fact]
        public async Task Test_agent_lifecycle()
        {
            _stub.State.Value.Should().Be(AgentStates.Initiated);
            await _stub.Invoke();
            _stub.State.Value.Should().Be(AgentStates.Active);
            await _stub.Suspend();
            _stub.State.Value.Should().Be(AgentStates.Suspended);
            await _stub.Resume();
            _stub.State.Value.Should().Be(AgentStates.Active);
            await _stub.Wait();
            _stub.State.Value.Should().Be(AgentStates.Waiting); 
            await _stub.WakeUp();
            _stub.State.Value.Should().Be(AgentStates.Active);
            await _stub.Move();
            _stub.State.Value.Should().Be(AgentStates.Transit); 
            await _stub.Execute();
            _stub.State.Value.Should().Be(AgentStates.Active);
            await _stub.Quit();
            _stub.State.Value.Should().Be(AgentStates.Deleted);
        }
        
        [Fact]
        public async Task Test_agent_lifecycle_move_next()
        {
            _stub.State.Value.Should().Be(AgentStates.Initiated);
            await _stub.Suspend();
            _stub.State.Value.Should().Be(AgentStates.Initiated);
            await _stub.Suspend(new Exception());
            _stub.State.Value.Should().Be(AgentStates.Initiated);            
            await _stub.Resume();
            _stub.State.Value.Should().Be(AgentStates.Initiated);
            await _stub.Wait();
            _stub.State.Value.Should().Be(AgentStates.Initiated); 
            await _stub.WakeUp();
            _stub.State.Value.Should().Be(AgentStates.Initiated);
            await _stub.Move();
            _stub.State.Value.Should().Be(AgentStates.Initiated); 
            await _stub.Execute();
            _stub.State.Value.Should().Be(AgentStates.Initiated);
            await _stub.Quit();
            _stub.State.Value.Should().Be(AgentStates.Deleted);
            await _stub.Invoke();
            _stub.State.Value.Should().Be(AgentStates.Deleted);            
        }        
    }
}