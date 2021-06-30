namespace MasUnity.Decision
{
    public struct AgentContext
    {
        public AgentIdentity Identity { get; }
        public AgentState State { get; }
        
        public AgentContext(AgentIdentity identity, AgentState state)
        {
            Identity = identity;
            State = state;
        }
    }
}