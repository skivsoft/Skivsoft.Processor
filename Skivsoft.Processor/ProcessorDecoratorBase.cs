using System;

namespace Skivsoft.Processor
{
    /// <summary>
    /// The processor decorator abstract class.
    /// </summary>
    /// <typeparam name="TContext">The processor context type.</typeparam>
    public abstract class ProcessorDecoratorBase<TContext> : IProcessor<TContext>
        where TContext : class
    {
        private readonly IProcessor<TContext> processor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessorDecoratorBase{TContext}"/> class.
        /// </summary>
        /// <param name="processor">The processor context.</param>
        protected ProcessorDecoratorBase(IProcessor<TContext> processor)
        {
            this.processor = processor ?? throw new ArgumentNullException(nameof(processor));
        }

        /// <summary>
        /// Executes processor with decoration.
        /// </summary>
        /// <param name="context">The processor context.</param>
        public void Execute(TContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            BeforeExecute(context);
            processor.Execute(context);
            AfterExecute(context);
        }

        /// <summary>
        /// Executes before child processor.
        /// </summary>
        /// <param name="context">The processor context.</param>
        public abstract void BeforeExecute(TContext context);

        /// <summary>
        /// Executes after child processor.
        /// </summary>
        /// <param name="context">The processor context.</param>
        public abstract void AfterExecute(TContext context);
    }
}