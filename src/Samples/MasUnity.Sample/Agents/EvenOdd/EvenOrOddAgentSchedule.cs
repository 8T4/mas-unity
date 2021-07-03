using System;
using MasUnity.Commons.Scheduling;

namespace MasUnity.Sample.Agents.EvenOdd
{
    public class EvenOrOddAgentSchedule: ISchedule
    {
        public DateTimeOffset? NextOccurrence()
        {
            var random = new Random();
            random.Next(1, 10);
            return DateTimeOffset.Now.AddSeconds(random.Next(1, 10));
        }
    }
}