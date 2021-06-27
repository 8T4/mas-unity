using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasUnity.Decision.Abstractions;

namespace MasUnity.Decision
{
    /// <summary>
    /// Life cycle
    /// </summary>
    public abstract partial class Agent : IAgent
    {
        public async Task Invoke()
        {
            if (State.Value != AgentStates.Initiated) return;
            
            var tasks = new List<Task>
            {
                OnInvoke(),
                Run()
            };

            await BeforeInvoke().ConfigureAwait(false);
            State.SetState(AgentStates.Active);
            await Task.WhenAll(tasks).ConfigureAwait(false);
            await AfterInvoke().ConfigureAwait(false);
        }

        public async Task Suspend()
        {
            if (State.Value != AgentStates.Active) return;

            await BeforeSuspend().ConfigureAwait(false);
            State.SetState(AgentStates.Suspended);
            await OnSuspend().ConfigureAwait(false);
            await AfterSuspend().ConfigureAwait(false);
        }

        public async Task Suspend(Exception e)
        {
            if (State.Value != AgentStates.Active) return;

            await BeforeSuspend(e).ConfigureAwait(false);
            State.SetState(AgentStates.Suspended);
            await OnSuspend().ConfigureAwait(false);
            await AfterSuspend().ConfigureAwait(false);
        }

        public async Task Resume()
        {
            if (State.Value != AgentStates.Suspended) return;
            
            var tasks = new List<Task>
            {
                OnResume(),
                Run()
            };            

            await BeforeResume().ConfigureAwait(false);
            State.SetState(AgentStates.Active);
            await Task.WhenAll(tasks).ConfigureAwait(false);            
            await AfterResume().ConfigureAwait(false);
        }

        public async Task Wait()
        {
            if (State.Value != AgentStates.Active) return;

            await BeforeWait().ConfigureAwait(false);
            State.SetState(AgentStates.Waiting);
            await OnWait().ConfigureAwait(false);
            await AfterWait().ConfigureAwait(false);
        }

        public async Task WakeUp()
        {
            if (State.Value != AgentStates.Waiting) return;
            
            var tasks = new List<Task>
            {
                OnWakeUp(),
                Run()
            };  

            await BeforeWakeUp().ConfigureAwait(false);
            State.SetState(AgentStates.Active);
            await Task.WhenAll(tasks).ConfigureAwait(false);  
            await AfterWakeUp().ConfigureAwait(false);
        }

        public async Task Move()
        {
            if (State.Value != AgentStates.Active) return;

            await BeforeMove().ConfigureAwait(false);
            State.SetState(AgentStates.Transit);
            await OnMove().ConfigureAwait(false);
            await AfterMove().ConfigureAwait(false);
        }

        public async Task Execute()
        {
            if (State.Value != AgentStates.Transit) return;
            
            var tasks = new List<Task>
            {
                OnExecute(),
                Run()
            };              

            await BeforeExecute().ConfigureAwait(false);
            State.SetState(AgentStates.Active);
            await Task.WhenAll(tasks).ConfigureAwait(false);
            await AfterExecute().ConfigureAwait(false);
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