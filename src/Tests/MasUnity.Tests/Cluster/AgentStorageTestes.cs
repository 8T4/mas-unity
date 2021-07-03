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
            
            

            _inMemoryStorage.Add("C445CE09-DDBA-48A0-AB0A-1DC5BB3B7161", _stub);
            _inMemoryStorage.Add("3689C2A1-38BC-4614-A1A4-7F8550B51E84", _stub);
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
        
        [Fact]
        public async Task Test_remove()
        {
            _inMemoryStorage.Count().Should().Be(2);
            await _inMemoryStorage.Remove("3689C2A1-38BC-4614-A1A4-7F8550B51E84").ConfigureAwait(false);
            _inMemoryStorage.Count().Should().Be(1);
        }        
    }
}