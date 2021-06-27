using System;

namespace MasUnity.Commons.Scheduling
{
    /// <summary>
    /// Provides a custom schedule object
    /// </summary>
    public abstract class CustomSchedule: ISchedule
    {
        public DateTimeOffset? NextOccurrence() => SetNextOccurrence();

        protected abstract DateTimeOffset? SetNextOccurrence();
    }
}