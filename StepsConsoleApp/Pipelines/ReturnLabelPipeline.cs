using StepsConsoleApp.Contracts;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Steps;

namespace StepsConsoleApp.Pipelines
{
    public class ReturnLabelPipeline : Pipeline<long, LabelDto>
    {
        public ReturnLabelPipeline()
        {
            PipelineSteps = (input) =>
            {
                var label = input
                    .Step(new AddressGetStep())
                    .Step(new DhlLabelGetStep());

                label.Step(new LabelAddToDbStep());

                return label;
            };
        }
    }
}
