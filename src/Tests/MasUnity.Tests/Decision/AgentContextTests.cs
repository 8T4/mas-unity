using FluentAssertions;
using MasUnity.Decision;
using MasUnity.Tests.Stubs;
using Xunit;

namespace MasUnity.Tests.Decision
{
    public class AgentContextTests
    {
        [Fact]
        public void Test_Agent_Context()
        {
            var identity = AgentIdentity.GetIdentity<FailureAgentStub>(1);
            var state = new AgentState();

            var context = new AgentContext(identity, state);

            context.Identity.Should().NotBeNull();
            context.State.Should().NotBeNull();
            context.State.Value.Should().Be(AgentStates.Initiated);
        }
        
        [Fact]
        public void Test_Agents_Are_Equals()
        {
            var identity = AgentIdentity.GetIdentity<FailureAgentStub>(1);
            var state = new AgentState();

            var contextA = new AgentContext(identity, state);
            var contextB = new AgentContext(identity, state);

            contextA.Should().BeEquivalentTo(contextB);
        }       
        
        [Fact]
        public void Test_Agents_Get_Hashcode()
        {
            var identity = AgentIdentity.GetIdentity<FailureAgentStub>(1);
            var state = new AgentState();

            var contextA = new AgentContext(identity, state);

            contextA.GetHashCode().Should().NotBe(0);
        }        
    }
}