using System;
using System.Threading.Tasks;

namespace MasUnity.Decision
{
    /// <summary>
    /// Life cycle
    /// </summary>
    public abstract partial class Agent
    {
        public async Task Invoke()
        {
            if (State.Value == AgentStates.Initiated)
            {
                await BeforeInvoke().ConfigureAwait(false);
                State.SetState(AgentStates.Active);
                await OnInvoke().ConfigureAwait(false);
                await Run().ConfigureAwait(false);
                await AfterInvoke().ConfigureAwait(false);
            }
        }

        public async Task Suspend()
        {
            if (State.Value == AgentStates.Active)
            {
                await BeforeSuspend().ConfigureAwait(false);
                State.SetState(AgentStates.Suspended);
                await OnSuspend().ConfigureAwait(false);
                await AfterSuspend().ConfigureAwait(false);
            }
        }

        public async Task Suspend(Exception e)
        {
            if (State.Value == AgentStates.Active)
            {
                await BeforeSuspend(e).ConfigureAwait(false);
                State.SetState(AgentStates.Suspended);
                await OnSuspend().ConfigureAwait(false);
                await AfterSuspend().ConfigureAwait(false);
            }
        }

        public async Task Resume()
        {
            if (State.Value == AgentStates.Suspended)
            {
                await BeforeResume().ConfigureAwait(false);
                State.SetState(AgentStates.Active);
                await OnResume().ConfigureAwait(false);
                await Run().ConfigureAwait(false);
                await AfterResume().ConfigureAwait(false);
            }
        }

        public async Task Wait()
        {
            if (State.Value == AgentStates.Active)
            {
                await BeforeWait().ConfigureAwait(false);
                State.SetState(AgentStates.Waiting);
                await OnWait().ConfigureAwait(false);
                await AfterWait().ConfigureAwait(false);
            }
        }

        public async Task WakeUp()
        {
            if (State.Value == AgentStates.Waiting)
            {
                await BeforeWakeUp().ConfigureAwait(false);
                State.SetState(AgentStates.Active);
                await OnWakeUp().ConfigureAwait(false);
                await Run().ConfigureAwait(false);
                await AfterWakeUp().ConfigureAwait(false);
            }
        }

        public async Task Move()
        {
            if (State.Value == AgentStates.Active)
            {
                await BeforeMove().ConfigureAwait(false);
                State.SetState(AgentStates.Transit);
                await OnMove().ConfigureAwait(false);
                await AfterMove().ConfigureAwait(false);
            }
        }

        public async Task Execute()
        {
            if (State.Value == AgentStates.Transit)
            {
                await BeforeExecute().ConfigureAwait(false);
                State.SetState(AgentStates.Active);
                await OnExecute().ConfigureAwait(false);
                await Run().ConfigureAwait(false);
                await AfterExecute().ConfigureAwait(false);
            }
        }

        public async Task Quit()
        {
            await BeforeQuit().ConfigureAwait(false);
            State.SetState(AgentStates.Deleted);
            await OnQuit().ConfigureAwait(false);
            await AfterQuit().ConfigureAwait(false);
        }
    }
}