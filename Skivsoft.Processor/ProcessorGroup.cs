using System;
using System.Collections.Generic;

namespace Skivsoft.Processor
{
    /// <summary>
    /// The group of processors.
    /// </summary>
    /// <typeparam name="TContext">The processor context type.</typeparam>
    public sealed class ProcessorGroup<TContext> : IProcessor<TContext>
        where TContext : class
    {
        private readonly IEnumerable<IProcessor<TContext>> processors;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessorGroup{TContext}"/> class.
        /// </summary>
        /// <param name="processors">The processor context.</param>
        public ProcessorGroup(IEnumerable<IProcessor<TContext>> processors)
        {
            this.processors = processors ?? throw new ArgumentNullException(nameof(processors));
        }

        /// <summary>
        /// Executes all child processors.
        /// </summary>
        /// <param name="context">The processor context.</param>
        public void Execute(TContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            foreach (IProcessor<TContext> process in processors)
            {
                process.Execute(context);
            }
        }
    }
}