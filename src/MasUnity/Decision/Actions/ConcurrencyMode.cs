namespace MasUnity.Decision.Actions
{
    /// <summary>
    /// The Task asynchronous programming model (TAP) provides an abstraction over asynchronous code.
    /// You write code as a sequence of statements, just like always. You can read that code as though
    /// each statement completes before the next begins. The compiler performs many transformations because
    /// some of those statements may start work and return a Task that represents the ongoing work.
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/"/>
    /// </summary>    
    public enum ConcurrencyMode
    {
        Asynchronous,
        Synchronous
    }
}