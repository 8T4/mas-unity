using FluentAssertions;
using MasUnity.Cluster;
using MasUnity.Decision;
using MasUnity.Tests.Stubs;
using Xunit;

namespace MasUnity.Tests.Decision
{
    public class AgentIdentityTests
    {
        [Fact]
        public void Test_get_identity_by_type()
        {
            var type = typeof(SynchronousReactiveAgentStub);
            var uri = $"{type.FullName}.AGENT-{0.ToString().PadLeft(4, '0')}";
            var identity = AgentIdentity.GetIdentity<SynchronousReactiveAgentStub>(0);
            
            identity.CreatedOn.Should().NotBeNull();
            identity.Uri.Should().Be(uri);
        }
        
        [Fact]
        public void Test_get_identity_by_instance()
        {
            var agent = new SynchronousReactiveAgentStub();
            var uri = $"{AgentIdentity.GetFullName(agent)}.AGENT-{0.ToString().PadLeft(4, '0')}";
            var identity = AgentIdentity.GetIdentity(agent, 0);
            
            identity.CreatedOn.Should().NotBeNull();
            identity.Uri.Should().Be(uri);
        }        
    }
}