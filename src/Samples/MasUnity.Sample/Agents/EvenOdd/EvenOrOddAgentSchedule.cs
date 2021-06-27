using System;
using MasUnity.Commons.Scheduling;

namespace MasUnity.Sample.Agents.EvenOdd
{
    public class EvenOrOddAgentSchedule: ISchedule
    {
        public DateTimeOffset? NextOccurrence()
        {
            return DateTimeOffset.Now.AddSeconds(10);
        }
    }
}