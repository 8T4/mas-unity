using MasUnity.Decision.Abstractions;

namespace MasUnity.Sample.Agents.EvenOdd.Knowledges
{
    public class OddOrEvenRecognition: IKnowledge
    {
        public bool IsEven(int number) => number % 2 == 0;
        public bool IsOdd(int number) => number % 2 != 0;
        public bool IsPositiveNumber(int number) => number > 0;
    }
}