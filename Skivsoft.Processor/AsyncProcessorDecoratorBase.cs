using System;
using System.Threading.Tasks;

namespace Skivsoft.Processor
{
    /// <summary>
    /// The processor decorator abstract class.
    /// </summary>
    /// <typeparam name="TContext">The processor context type.</typeparam>
    public abstract class AsyncProcessorDecoratorBase<TContext> : IAsyncProcessor<TContext>
        where TContext : class
    {
        private readonly IAsyncProcessor<TContext> processor;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncProcessorDecoratorBase{TContext}"/> class.
        /// </summary>
        /// <param name="processor">The child processor.</param>
        protected AsyncProcessorDecoratorBase(IAsyncProcessor<TContext> processor)
        {
            this.processor = processor ?? throw new ArgumentNullException(nameof(processor));
        }

        /// <summary>
        /// Executes asyncronous processor with decoration.
        /// </summary>
        /// <param name="context">The processor context.</param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task ExecuteAsync(TContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            await BeforeExecuteAsync(context);
            await processor.ExecuteAsync(context);
            await AfterExecuteAsync(context);
        }

        /// <summary>
        /// Executes before asyncronous child processor.
        /// </summary>
        /// <param name="context">The processor context.</param>
        /// <returns>The <see cref="Task"/></returns>
        public abstract Task BeforeExecuteAsync(TContext context);

        /// <summary>
        /// Executes after asyncronous child processor.
        /// </summary>
        /// <param name="context">The processor context.</param>
        /// <returns>The <see cref="Task"/></returns>
        public abstract Task AfterExecuteAsync(TContext context);
    }
}