using System;
using System.Linq;
using System.Threading.Tasks;

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
        internal Action WhenNotRealize { get; private set; }
        
        private Perception(bool value)
        {
            Value = value;
            WhenNotRealize = () => { };
        }
        
        public Task<Perception> IfNotRealize(Action action)
        {
            if (IsFalse)
            {
                WhenNotRealize = action;
            }

            return Task.FromResult(this);
        }        
        
        public static Task<Perception> Assertion(params (string description, bool value)[] propositions)
        {
            var p = propositions.Select(q => Proposition.Assertion(q.description, q.value));
            return Assertion(p.ToArray());
        }

        private static Task<Perception> Assertion(params Proposition[] propositions)
        {
            var result = new Perception(propositions.All(p => p.IsTrue));
            return Task.FromResult(result);
        }

        public static Task<Perception> Assertion(Func<bool> func)
        {
            var result = new Perception(func.Invoke());
            return Task.FromResult(result);
        }
    }
}