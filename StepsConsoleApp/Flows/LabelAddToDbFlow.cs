using System;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Pipelines;

namespace StepsConsoleApp.Flows
{
    public class LabelAddToDbFlow
    {
        public void Run(LabelDto label)
        {
            Console.WriteLine($"Start LabelAddToDbFlow.");

            var pipeline = new LabelAddToDbPipeline();
            pipeline.Run(label);

            Console.WriteLine($"Finish LabelAddToDbFlow.");
        }
    }
}
