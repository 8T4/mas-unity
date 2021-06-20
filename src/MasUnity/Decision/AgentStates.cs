namespace MasUnity.Decision
{
    public enum AgentStates
    {
        /// <summary>
        /// the Agent object is built, but hasn't registered itself yet with the AMS,
        /// has neither a name nor an address and cannot communicate with other agents.
        /// </summary>
        Initiated,

        /// <summary>
        /// the Agent object is registered with the AMS
        /// </summary>
        Active,

        /// <summary>
        /// the Agent object is blocked, waiting for something. Its internal thread is sleeping on a Java monitor and
        /// will wake up when some condition is met (typically when a message arrives).
        /// </summary>
        Waiting,

        /// <summary>
        /// the Agent object is currently stopped. Its internal thread is suspended and no agent behaviour is being
        /// executed.
        /// </summary>
        Suspended,

        /// <summary>
        /// a mobile agent enters this state while it is migrating to the new location. The system continues to buffer
        /// messages that will then be sent to its new location.
        /// </summary>
        Transit,

        /// <summary>
        /// the Agent is definitely dead. The internal thread has terminated its execution and the Agent is no
        /// more registered with the AMS.
        /// </summary>
        Deleted,
    }
}