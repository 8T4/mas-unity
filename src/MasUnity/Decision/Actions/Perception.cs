using System;
using System.Linq;

namespace MasUnity.Decision.Actions
{
    /// <summary>
    /// results from a set of propositions about Environment
    /// <code>
    ///     Perception is E -> P
    ///     E: is Realize
    ///     P: is propositions S={S1(x,y), S2(x,!y), S3(!x,y), S4(!x,!y)}
    /// 
    ///     Action is P* -> A
    ///     P*: is a sequence of perceptions
    ///     A: Actions    
    /// </code>
    /// </summary>
    public sealed class Perception
    {
        private bool Value { get; }
        public bool IsTrue => Value;
        public bool IsFalse => !Value;
        
        private Perception(bool value)
        {
            Value = value;
        }
        
        public static Perception Assertion(params (string description, bool value)[] propositions)
        {
            var p = propositions.Select(q => Proposition.Assertion(q.description, q.value));
            return Assertion(p.ToArray());
        }

        private static Perception Assertion(params Proposition[] propositions)
        {
            return new Perception(propositions.All(p => p.IsTrue));
        }

        public static Perception Assertion(Func<bool> func)
        {
            return new Perception(func.Invoke());
        }
    }
}