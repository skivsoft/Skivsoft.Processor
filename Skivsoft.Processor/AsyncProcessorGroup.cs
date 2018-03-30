using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skivsoft.Processor
{
    /// <summary>
    /// The group of processors.
    /// </summary>
    /// <typeparam name="TContext">The processor context type.</typeparam>
    public sealed class AsyncProcessorGroup<TContext> : IAsyncProcessor<TContext>
        where TContext : class
    {
        private readonly IEnumerable<IAsyncProcessor<TContext>> processors;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncProcessorGroup{TContext}"/> class.
        /// </summary>
        /// <param name="processors">The processor context.</param>
        public AsyncProcessorGroup(IEnumerable<IAsyncProcessor<TContext>> processors)
        {
            this.processors = processors ?? throw new ArgumentNullException(nameof(processors));
        }

        /// <summary>
        /// Executes all asyncronous child processors.
        /// </summary>
        /// <param name="context">The processor context.</param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task ExecuteAsync(TContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            foreach (IAsyncProcessor<TContext> process in processors)
            {
                await process.ExecuteAsync(context);
            }
        }
    }
}