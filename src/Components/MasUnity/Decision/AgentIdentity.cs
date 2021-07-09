using System;
using MasUnity.Decision.Abstractions;

namespace MasUnity.Decision
{
    public sealed class AgentIdentity
    {
        public string Uri { get; }
        public int Partition { get; }
        public string InstanceId { get; }
        public DateTime? CreatedOn { get; }

        private AgentIdentity(string uri, int partition)
        {
            Uri = uri;
            InstanceId = Guid.NewGuid().ToString("N");
            Partition = partition;
            CreatedOn = DateTime.Now;
        }
        
        public static string GetFullName(IAgent agent) => agent.GetType().FullName;        

        public static AgentIdentity GetIdentity(IAgent agent, int partition)
        {
            var uri = $"{GetFullName(agent)}.AGENT-{partition.ToString().PadLeft(4, '0')}";
            return new AgentIdentity(uri, partition);
        }

        public static AgentIdentity GetIdentity<T>(int partition) where T: IAgent
        {
            var uri = $"{typeof(T).FullName}.AGENT-{partition.ToString().PadLeft(4, '0')}";
            return new AgentIdentity(uri, partition);
        }
    }
}