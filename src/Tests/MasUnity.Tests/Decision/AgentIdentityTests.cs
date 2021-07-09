using FluentAssertions;
using MasUnity.Decision;
using MasUnity.Tests.Stubs;
using Xunit;

namespace MasUnity.Tests.Decision
{
    public class AgentIdentityTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_get_identity_by_type(int partition)
        {
            var type = typeof(SynchronousReactiveAgentStub);
            var uri = $"{type.FullName}.AGENT-{partition.ToString().PadLeft(4, '0')}";
            var identity = AgentIdentity.GetIdentity<SynchronousReactiveAgentStub>(partition);
            
            identity.Uri.Should().Be(uri);
            identity.Partition.Should().Be(partition);
            identity.CreatedOn.Should().NotBeNull();
            identity.InstanceId.Should().NotBeNullOrEmpty();
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_get_identity_by_instance(int partition)
        {
            var agent = new SynchronousReactiveAgentStub();
            var uri = $"{AgentIdentity.GetFullName(agent)}.AGENT-{partition.ToString().PadLeft(4, '0')}";
            var identity = AgentIdentity.GetIdentity(agent, partition);

            identity.Uri.Should().Be(uri);
            identity.Partition.Should().Be(partition);
            identity.CreatedOn.Should().NotBeNull();
            identity.InstanceId.Should().NotBeNullOrEmpty();
        }        
    }
}