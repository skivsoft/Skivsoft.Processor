namespace Skivsoft.Processor
{
    /// <summary>
    /// The process interface.
    /// </summary>
    /// <typeparam name="TContext">The processor context type.</typeparam>
    public interface IProcessor<in TContext>
        where TContext : class
    {
        /// <summary>
        /// Executes some action.
        /// </summary>
        /// <param name="context">The processor context.</param>
        void Execute(TContext context);
    }
}