using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using MasUnity.Decision.Abstractions;

namespace MasUnity.Commons.Scheduling
{
    /// <summary>
    /// Provides Methods to support Schedule Object
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal static class ScheduleHelper
    {
        internal static Task Execute(this ISchedule schedule, IAgent agent, Action action)
        {
            if (schedule.CanExecute(agent.Report.NextExecution))
            {
                action.Invoke();
            }
            
            return Task.CompletedTask;
        }

        private static bool CanExecute(this ISchedule schedule, DateTimeOffset? dateTimeOffset)
        {
            return dateTimeOffset != null && dateTimeOffset.Value < DateTime.Now;
        }        
    }
}