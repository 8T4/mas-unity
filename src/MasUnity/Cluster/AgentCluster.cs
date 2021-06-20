using System;
using System.Threading.Tasks;
using MasUnity.Decision.Abstractions;

namespace MasUnity.Cluster
{
    /// <summary>
    /// Clusters of agents work closely together to solve larger problems
    /// <see href="https://www.sciencedirect.com/science/article/abs/pii/S0167923604002155?via%3Dihub"/>
    /// </summary>
    public sealed class AgentCluster: IAgentCluster
    {
        public string Id { get; }
        private IAgentStorage Storage { get; }

        public AgentCluster(IAgentStorage storage)
        {
            Id = Guid.NewGuid().ToString("N");
            Storage = storage;
        }

        public void Register(IAgent agent)
        {
            var sequence = Storage.GetNextSequence(agent);
            agent.Assign(sequence);
            Storage.Add(sequence.Uri, agent);
        }

        public async Task<IAgent> Get(string uri) => await Storage.Get(uri);
    }
}