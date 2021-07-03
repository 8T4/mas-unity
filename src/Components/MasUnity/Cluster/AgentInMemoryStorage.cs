using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task Remove(string uri)
        {
            var agent = await Get(uri);
            if ((agent != null) && (agent.State.Value != AgentStates.Active))
            {
                await agent.Quit();
                await Delete(uri);
            }
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