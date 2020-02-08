using System;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Flows;

namespace StepsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // GET controller ReturnLabelWithoutLabel
            {
                var returnLabelFlow = new ReturnLabelFlow();

                var label = returnLabelFlow.Run(100);

                Console.WriteLine($"Process {label.LabelFile} in GET controller");
                Console.WriteLine();
            }

            // PUT controller ReturnLabelWithLabel
            {
                var labelAddToDbFlow = new LabelAddToDbFlow();

                var label = new LabelDto()
                {
                    ReturnHeadId = 50,
                    Carrier = "DHL",
                    LabelFile = "BestEverFile.pdf"
                };

                labelAddToDbFlow.Run(label);

                Console.WriteLine($"Process {label.LabelFile} in PUT controller");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
