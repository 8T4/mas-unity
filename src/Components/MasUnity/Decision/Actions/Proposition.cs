namespace MasUnity.Decision.Actions
{
    /// <summary>
    /// It's a assertion about Environment
    /// </summary>
    public sealed class Proposition
    {
        private bool Value { get; }
        public bool IsTrue => Value;
        public bool IsFalse => !Value;        
        public string Description { get; }

        private Proposition(string description, bool logicalValue)
        {
            Description = description;
            Value = logicalValue;
        }
        
        public static Proposition Assertion(string description, bool value)
        {
            return new Proposition(description, value);
        }          
    }
}