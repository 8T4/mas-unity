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
    }
}