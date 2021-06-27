using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasUnity.Decision;
using MasUnity.Decision.Actions;

namespace MasUnity.Agents
{
    /// <summary>
    /// : agents perceive their environment (which may be the physical world, a user via a
    /// graphical user interface, a collection of other agents, the Internet, or perhaps all of these combined),
    /// and respond in a timely fashion to changes that occur in it;
    /// <see href="https://eprints.soton.ac.uk/252102/"/>
    /// </summary>
    public abstract class ReactiveAgent : Agent
    {
        protected override Task Run()
        {
            Task.Run(DoWork);
            Report.UpdateLastExecution();
            return Task.CompletedTask;
        }

        private async Task DoWork()
        {
            var source = new CancellationTokenSource();
            var token = source.Token;

            try
            {
                Actions = RegisterActions().ToArray();
                Report.SetResultOk();
                
                if (Concurrency == ConcurrencyMode.Synchronous)
                {
                    await ExecuteActionsSynchronously(token).ConfigureAwait(false);
                }
                else
                {
                    await ExecuteActionsAsynchronously(token).ConfigureAwait(false);
                }                
            }
            catch (OperationCanceledException e)
            {
                await Suspend(e).ConfigureAwait(false);
                Report.Result.Merge(AgentResult.Fail($"[{GetType().Name}] Operation Canceled Exception", e.Message, e.StackTrace));
            }
            catch (Exception e)
            {
                await Suspend(e).ConfigureAwait(false);
                Report.Result.Merge(AgentResult.Fail($"[{GetType().Name}] Operation Canceled Exception", e.Message, e.StackTrace));
            }               
            finally
            {
                Report.UpdateLastExecution();
                await Suspend().ConfigureAwait(false);
                source.Dispose();
            }
        }
    }
}