using System;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Pipelines;

namespace StepsConsoleApp.Flows
{
    public class ReturnLabelFlow
    {
        public LabelDto Run(long returnHeadId)
        {
            Console.WriteLine($"Start ReturnLabelFlow.");

            var pipeline = new ReturnLabelPipeline();
            var output = pipeline.Run(returnHeadId);

            Console.WriteLine($"Finish ReturnLabelFlow.");

            return output;
        }
    }
}
