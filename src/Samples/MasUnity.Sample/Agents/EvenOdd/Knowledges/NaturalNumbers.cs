using System;
using MasUnity.Decision.Abstractions;

namespace MasUnity.Sample.Agents.EvenOdd.Knowledges
{
    public class NaturalNumbers: IKnowledge
    {
        private int _number;
        private static NaturalNumbers _natural;

        public static NaturalNumbers Current => _natural ??= new NaturalNumbers();
        public int Number => _number;

        private NaturalNumbers()
        {
            GenerateNumber();
        }
        
        public void GenerateNumber()
        {
            var rd = new Random();
            _number = rd.Next(1, 100);
        }
    }
}