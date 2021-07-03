using System;
using System.Threading;
using System.Threading.Tasks;
using MasUnity.Decision;
using MasUnity.Decision.Abstractions;
using MasUnity.Decision.Actions;
using MasUnity.Sample.Agents.EvenOdd.Environments;
using MasUnity.Sample.Agents.EvenOdd.Knowledges;

namespace MasUnity.Sample.Agents.EvenOdd.Actions
{
    public class SayNumberIsOdd: IAction
    {
        private readonly EvenOrOddRecognition _recognition;

        public SayNumberIsOdd(EvenOrOddRecognition recognition) =>
            _recognition = recognition;
        
        public Task<Perception> Realize(CancellationToken cancellation)
        {
            var number = ClockSecondsIndicator.Current.Second;

            return Perception.Assertion(
                ("Number is greater than 0", _recognition.IsPositiveNumber(number)),
                ("Number is Even", _recognition.IsOdd(number))
            );
        }
        
        public Task<AgentResult> Execute(AgentContext context, CancellationToken cancellation)
        {
            Console.WriteLine($"[{context.Identity.Uri}]({DateTime.Now:G}) Number is odd");
            return Task.FromResult(AgentResult.Ok("Number is odd"));
        }        
    }
}