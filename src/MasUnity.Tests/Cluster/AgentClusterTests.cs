using System.Threading.Tasks;
using FluentAssertions;
using MasUnity.Cluster;
using MasUnity.Tests.Stubs;
using Xunit;

namespace MasUnity.Tests.Cluster
{
    public class AgentClusterTests
    {
        private readonly AgentCluster _cluster;
        private readonly SynchronousReactiveAgentStub _stub;
        
        public AgentClusterTests()
        {
            _cluster = new AgentCluster(new AgentInMemoryStorage());
            _stub = new SynchronousReactiveAgentStub();
        }
        
        [Fact]
        public void Test_constructor()
        {
            _cluster.Id.Should().NotBeNullOrEmpty();
        }        

        [Fact]
        public void Test_cluster_register()
        {
            _stub.Identity.Should().BeNull();
            _cluster.Register(_stub);
            _stub.Identity.Should().NotBeNull();
        }
        
        [Fact]
        public void Test_cluster_register_twice()
        {
            _stub.Identity.Should().BeNull();
            _cluster.Register(_stub);
            _cluster.Register(_stub);
            _stub.Identity.Should().NotBeNull();
        }        
        
        [Fact]
        public void Test_cluster_get_agent()
        {
            _stub.Identity.Should().BeNull();
            _cluster.Register(_stub);
            
            var agent = _cluster.Get(_stub.Identity.Uri);
            agent.Should().NotBeNull();
        }   
        
        [Fact]
        public async Task Test_cluster_get_agent_return_null()
        {
            _stub.Identity.Should().BeNull();
            _cluster.Register(_stub);
            
            var agent = await _cluster.Get(string.Empty);
            agent.Should().BeNull();
        }          
    }
}