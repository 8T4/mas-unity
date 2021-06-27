using System;
using System.Threading.Tasks;
using FluentAssertions;
using MasUnity.Cluster;
using MasUnity.Tests.Stubs;
using Xunit;

namespace MasUnity.Tests.Cluster
{
    public class AgentStorageTestes
    {
        private readonly AgentInMemoryStorage _inMemoryStorage;
        private readonly SynchronousReactiveAgentStub _stub;
        
        public AgentStorageTestes()
        {
            _inMemoryStorage = new AgentInMemoryStorage();
            _stub = new SynchronousReactiveAgentStub();

            _inMemoryStorage.Add(Guid.NewGuid().ToString(), _stub);
            _inMemoryStorage.Add(Guid.NewGuid().ToString(), _stub);
        }

        [Fact]
        public async Task Test_get_all()
        {
            var agents = await _inMemoryStorage.GetAll();
            agents.Should().HaveCount(2);
        }
        
        [Fact]
        public void Test_count()
        {
            var agents = _inMemoryStorage.Count();
            agents.Should().Be(2);
        }   
        
        [Fact]
        public void Test_any()
        {
            var agents = _inMemoryStorage.Any();
            agents.Should().BeTrue();
        }         
    }
}