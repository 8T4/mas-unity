using System;

namespace MasUnity.Decision
{
    public sealed class AgentReport
    {
        public DateTimeOffset? NextExecution { get; private set; }        
        public AgentResult Result { get; private set; }
        public DateTime? LastExecution { get; private set; }

        public AgentReport()
        {
            LastExecution = default;
            NextExecution = default;
            Result = AgentResult.Ok();            
        }

        public void UpdateNextExecution(DateTimeOffset? nextExecution)
        {
            if (nextExecution == null)
                throw new ArgumentNullException($"{nameof(nextExecution)} value is required");
            
            if (NextExecution != null && nextExecution.Value < NextExecution.Value)
                throw new ArgumentException($"Then {nameof(nextExecution)} should be great the current next execution");

            NextExecution = nextExecution;
        }

        public void UpdateLastExecution() => LastExecution = DateTime.Now;
        public void SetResultOk() => Result = AgentResult.Ok();
    }
}