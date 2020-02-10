using System;
using System.Threading.Tasks;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Flows;

namespace StepsConsoleApp
{
    class Program
    {
        static async Task Main()
        {
            // GET controller ReturnLabelWithoutLabel
            await ReturnLabelWithoutLabel();

            // PUT controller ReturnLabelWithLabel
            await ReturnLabelWithLabel();

            Console.ReadLine();
        }

        private static async Task ReturnLabelWithLabel()
        {
            Console.WriteLine($"Start ReturnLabelWithLabel PUT controller.");

            var labelAddToDbFlow = new LabelAddToDbFlow();

            var label = new LabelDto()
            {
                ReturnHeadId = 50,
                Carrier = "DHL",
                LabelFile = "GoldenFile.pdf"
            };

            Console.WriteLine($"Start LabelAddToDbFlow.");

            await labelAddToDbFlow
                .RunAsync(Task.FromResult(label));

            Console.WriteLine($"Finish LabelAddToDbFlow.");
            Console.WriteLine($"Process {label.LabelFile} in ReturnLabelWithLabel PUT controller finished");
            Console.WriteLine();
        }

        private static async Task ReturnLabelWithoutLabel()
        {
            Console.WriteLine($"Start ReturnLabelWithoutLabel GET controller.");

            var returnLabelFlow = new ReturnLabelFlow();

            Console.WriteLine($"Start ReturnLabelFlow.");

            long returnHeadId = 100;

            var label = await returnLabelFlow
                .RunAsync(Task.FromResult(returnHeadId));

            Console.WriteLine($"Finish ReturnLabelFlow.");
            Console.WriteLine($"Process {label.LabelFile} in ReturnLabelWithoutLabel GET controller finished");
            Console.WriteLine();
        }
    }
}
