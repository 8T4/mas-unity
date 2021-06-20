using System;

namespace MasUnity.Commons.Scheduling
{
    public interface ISchedule
    {
        public DateTimeOffset? NextOccurrence();
    }
}