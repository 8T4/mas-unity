using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasUnity.Commons.Scheduling;
using MasUnity.Decision;
using MasUnity.Decision.Actions;

namespace MasUnity.Agents
{
    /// <summary>
    /// Agents do not simply act in response to their environment, they are able to exhibit goal-directed behaviour
    /// by taking the initiativ
    /// <see href="https://eprints.soton.ac.uk/252102/"/>
    /// </summary>
    public abstract class ProactiveAgent : Agent
    {
        private ISchedule Schedule { get; }

        protected ProactiveAgent(ISchedule schedule)
        {
            Schedule = schedule;
        }

        protected override Task Run()
        {
            Task.Run(DoWork);
            return Task.CompletedTask;
        }

        private async Task DoWork()
        {
            Report.UpdateNextExecution(Schedule.NextOccurrence());

            while (State.Value == AgentStates.Active)
            {
                await Schedule.Execute(this, async () => await ExecuteActions());
                var seconds = Report.NextExecution?.Subtract(DateTimeOffset.Now) ?? TimeSpan.FromSeconds(5);
                Thread.Sleep(seconds);
            }
        }

        private async Task ExecuteActions()
        {
            var source = new CancellationTokenSource();
            try
            {
                var token = source.Token;
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
                Report.UpdateNextExecution(Schedule.NextOccurrence());
                Report.UpdateLastExecution();
                source.Dispose();
            }
        }
    }
}