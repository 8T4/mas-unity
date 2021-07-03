using System;
using System.Threading;
using System.Threading.Tasks;
using MasUnity.Decision.Abstractions;

namespace MasUnity.Sample.Agents.EvenOdd.Environments
{
    public class ClockSecondsIndicator: IEnvironment
    {
        private static ClockSecondsIndicator _current;
        public static ClockSecondsIndicator Current => _current ??= new ClockSecondsIndicator();
        public int Second => DateTime.Now.Second;
    }
}