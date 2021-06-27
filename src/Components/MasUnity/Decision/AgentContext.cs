namespace MasUnity.Decision
{
    public struct AgentContext
    {
        public AgentIdentity Identity { get; private set; }
        public AgentState State { get; private set; }
        
        public AgentContext(AgentIdentity identity, AgentState state)
        {
            Identity = identity;
            State = state;
        }
    }
}