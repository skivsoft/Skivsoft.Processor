# Skivsoft.Processor

Simple data processing library.

## Example of usage

````csharp
using System;
using Skivsoft.Processor;

namespace ConsoleApp1
{
    public class HelloContext
    {
        public string Name { get; set; }
    }

    public class InputName : IProcessor<HelloContext>
    {
        public void Execute(HelloContext context)
        {
            Console.WriteLine("Enter your name:");
            context.Name = Console.ReadLine();
        }
    }

    public class OutputGreetings : IProcessor<HelloContext>
    {
        public void Execute(HelloContext context)
        {
            Console.WriteLine($"Hello {context.Name}!");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            IProcessor<HelloContext>[] steps = {
                new InputName(),
                new OutputGreetings()
            };
            IProcessor<HelloContext> processor = new ProcessorGroup<HelloContext>(steps);
            processor.Execute(new HelloContext());
        }
    }
}
````