using System;

namespace MasUnity.Decision
{
    public readonly struct AgentContext: IEquatable<AgentContext>
    {
        public AgentIdentity Identity { get; }
        public AgentState State { get; }
        
        public AgentContext(AgentIdentity identity, AgentState state)
        {
            Identity = identity;
            State = state;
        }

        public bool Equals(AgentContext other)
        {
            return Equals(Identity, other.Identity) && Equals(State, other.State);
        }

        public override bool Equals(object obj)
        {
            return obj is AgentContext other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Identity, State);
        }
    }
}