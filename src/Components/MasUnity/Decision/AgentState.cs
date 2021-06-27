namespace MasUnity.Decision
{
    public sealed class AgentState
    {
        public AgentStates Value { get; private set; }
        public string Description { get; private set; }

        public AgentState()
        {
            SetState(AgentStates.Initiated);
        }

        public void SetState(AgentStates state)
        {
            Value = state;
            Description = Value.ToString();            
        }
    }
}