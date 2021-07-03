using System.Collections.Generic;
using System.Threading.Tasks;
using MasUnity.Decision;
using MasUnity.Decision.Abstractions;

namespace MasUnity.Cluster
{
    /// <summary>
    /// Store agent metadatas
    /// </summary>    
    public interface IAgentStorage
    {
        Task Add(string uri, IAgent agent);
        Task Remove(string uri);
        Task<IAgent> Get(string uri);
        Task<IEnumerable<IAgent>> GetAll();
        int Count();
        bool Any();
        public AgentIdentity GetNextSequence(IAgent agent);
    }
}