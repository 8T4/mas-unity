using System;
using MasUnity.Commons.Scheduling;

namespace MasUnity.Tests.Stubs
{
    public class ScheduleStub: CustomSchedule
    {
        protected override DateTimeOffset? SetNextOccurrence()
        {
            return DateTimeOffset.Now.AddSeconds(2);
        }
    }
}