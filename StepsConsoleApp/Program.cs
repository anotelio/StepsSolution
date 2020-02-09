using System;
using System.Threading.Tasks;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Flows;

namespace StepsConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // GET controller ReturnLabelWithoutLabel
            {
                Console.WriteLine($"Start ReturnLabelWithoutLabel GET controller.");

                var returnLabelFlow = new ReturnLabelFlow();

                Console.WriteLine($"Start ReturnLabelFlow.");

                var label = await returnLabelFlow.RunAsync(100);

                Console.WriteLine($"Finish ReturnLabelFlow.");
                Console.WriteLine($"Process {label.LabelFile} in ReturnLabelWithoutLabel GET controller finished");
                Console.WriteLine();
            }

            // PUT controller ReturnLabelWithLabel
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

                await labelAddToDbFlow.RunAsync(label);

                Console.WriteLine($"Finish LabelAddToDbFlow.");
                Console.WriteLine($"Process {label.LabelFile} in ReturnLabelWithLabel PUT controller finished");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
