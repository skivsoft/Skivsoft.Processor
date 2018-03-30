using System.Threading.Tasks;

namespace Skivsoft.Processor
{
    /// <summary>
    /// The process interface.
    /// </summary>
    /// <typeparam name="TContext">The processor context type.</typeparam>
    public interface IAsyncProcessor<in TContext>
        where TContext : class
    {
        /// <summary>
        /// Executes some action asyncronously.
        /// </summary>
        /// <param name="context">The processor context.</param>
        /// <returns>The <see cref="Task"/></returns>
        Task ExecuteAsync(TContext context);
    }
}