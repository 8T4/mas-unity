using System;
using FluentAssertions;
using MasUnity.Tests.Stubs;
using Xunit;

namespace MasUnity.Tests.Commons
{
    public class CustomScheduleTests
    {
        private readonly ScheduleStub _schedule;
        
        public CustomScheduleTests()
        {
            _schedule = new ScheduleStub();
        }

        [Fact]
        public void Test_get_next_occurrence()
        {
            var date = _schedule.NextOccurrence();

            if (date == null) return;
            DateTimeOffset.Now.AddSeconds(1).Should().BeBefore(date.Value);
            DateTimeOffset.Now.AddSeconds(3).Should().BeAfter(date.Value);
        }
    }
}