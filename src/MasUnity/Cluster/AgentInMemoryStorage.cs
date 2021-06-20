using System.Collections.Generic;
using MasUnity.Commons.Storages;
using MasUnity.Decision;
using MasUnity.Decision.Abstractions;

namespace MasUnity.Cluster
{
    /// <summary>
    /// Store agent metadatas
    /// </summary>
    public sealed class AgentInMemoryStorage: AbstractStorage<IAgent>, IAgentStorage
    {
        private Dictionary<string, int> Sequences { get; }

        public AgentInMemoryStorage():base()
        {
            Sequences = new Dictionary<string, int>();
        }

        public AgentIdentity GetNextSequence(IAgent agent)
        {
            var key = AgentIdentity.GetFullName(agent);
            
            if (Sequences.ContainsKey(key))
            {
                var sequence = Sequences[key] + 1;
                Sequences[key] = sequence;
                return AgentIdentity.GetIdentity(agent, sequence);
            }
            
            Sequences[key] = 0;
            return AgentIdentity.GetIdentity(agent, 0);            
        }
    }
}