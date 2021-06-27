using System;
using System.Threading;
using System.Threading.Tasks;
using MasUnity.Decision;
using MasUnity.Decision.Abstractions;
using MasUnity.Decision.Actions;
using MasUnity.Sample.Agents.EvenOdd.Knowledges;

namespace MasUnity.Sample.Agents.EvenOdd.Actions
{
    public class SayNumberIsOdd: IAction
    {
        private readonly OddOrEvenRecognition _recognition;

        public SayNumberIsOdd(OddOrEvenRecognition recognition) =>
            _recognition = recognition;
        
        public Task<Perception> Realize(CancellationToken cancellation)
        {
            var number = NaturalNumbers.Current.Number;

            var perception = Perception.Assertion(
                ("Number is greater than 0", _recognition.IsPositiveNumber(number)),
                ("Number is Even", _recognition.IsOdd(number))
            );

            return Task.FromResult(perception);
        }
        
        public Task<AgentResult> Execute(AgentContext context, CancellationToken cancellation)
        {
            Console.WriteLine($"[{context.Identity.Uri}]({DateTime.Now:G}) Number is odd");
            NaturalNumbers.Current.GenerateNumber();
            return Task.FromResult(AgentResult.Ok("Number is odd"));
        }        
    }
}