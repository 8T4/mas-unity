using System;
using MasUnity.Cluster;
using MasUnity.Decision.Abstractions;

namespace MasUnity.Decision
{
    public sealed class AgentIdentity
    {
        public string Uri { get; }
        public string InstanceId { get; }
        public DateTime? CreatedOn { get; }

        private AgentIdentity(string uri)
        {
            Uri = uri;
            InstanceId = Guid.NewGuid().ToString("N");
            CreatedOn = DateTime.Now;
        }
        
        public static string GetFullName(IAgent agent) => agent.GetType().FullName;        

        public static AgentIdentity GetIdentity(IAgent agent, int instanceNumber)
        {
            var uri = $"{GetFullName(agent)}.AGENT-{instanceNumber.ToString().PadLeft(4, '0')}";
            return new AgentIdentity(uri);
        }

        public static AgentIdentity GetIdentity<T>(int instanceNumber) where T: IAgent
        {
            var uri = $"{typeof(T).FullName}.AGENT-{instanceNumber.ToString().PadLeft(4, '0')}";
            return new AgentIdentity(uri);
        }
    }
}