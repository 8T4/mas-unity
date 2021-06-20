using System.Threading.Tasks;
using MasUnity.Decision.Abstractions;

namespace MasUnity.Cluster
{
    /// <summary>
    /// Clusters of agents work closely together to solve larger problems
    /// <see href="https://www.sciencedirect.com/science/article/abs/pii/S0167923604002155?via%3Dihub"/>
    /// </summary>
    public interface IAgentCluster
    {
        public string Id { get; }
        public void Register(IAgent agent);
        public Task<IAgent> Get(string uri);
    }
}