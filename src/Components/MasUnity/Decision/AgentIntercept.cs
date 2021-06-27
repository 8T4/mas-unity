using System;
using System.Threading.Tasks;
using MasUnity.Decision.Abstractions;

namespace MasUnity.Decision
{
    /// <summary>
    /// Life cycle
    /// </summary>
    public abstract partial class Agent : IAgent
    {
        //Invoke
        protected virtual Task BeforeInvoke() => Task.CompletedTask;
        protected virtual Task OnInvoke() => Task.CompletedTask;
        protected virtual Task AfterInvoke() => Task.CompletedTask;

        //Suspend
        protected virtual Task BeforeSuspend() => Task.CompletedTask;
        protected virtual Task BeforeSuspend(Exception exception) => Task.CompletedTask;
        protected virtual Task OnSuspend() => Task.CompletedTask;
        protected virtual Task AfterSuspend() => Task.CompletedTask;
        
        //Resume
        protected virtual Task BeforeResume() => Task.CompletedTask;
        protected virtual Task OnResume() => Task.CompletedTask;
        protected virtual Task AfterResume() => Task.CompletedTask; 
        
        //Wait
        protected virtual Task BeforeWait() => Task.CompletedTask;
        protected virtual Task OnWait() => Task.CompletedTask;
        protected virtual Task AfterWait() => Task.CompletedTask;  
        
        //WakeUp
        protected virtual Task BeforeWakeUp() => Task.CompletedTask;
        protected virtual Task OnWakeUp() => Task.CompletedTask;
        protected virtual Task AfterWakeUp() => Task.CompletedTask;    
        
        //Move
        protected virtual Task BeforeMove() => Task.CompletedTask;
        protected virtual Task OnMove() => Task.CompletedTask;
        protected virtual Task AfterMove() => Task.CompletedTask;    
        
        //Execute
        protected virtual Task BeforeExecute() => Task.CompletedTask;
        protected virtual Task OnExecute() => Task.CompletedTask;
        protected virtual Task AfterExecute() => Task.CompletedTask;  
        
        //Quit
        protected virtual Task BeforeQuit() => Task.CompletedTask;
        protected virtual Task OnQuit() => Task.CompletedTask;
        protected virtual Task AfterQuit() => Task.CompletedTask;          
    }
}