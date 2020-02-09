using StepsConsoleApp.Contracts;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Steps;

namespace StepsConsoleApp.Pipelines
{
    public class ReturnLabelPipeline : Pipeline<long, LabelDto>
    {
        private readonly AddressGetStep addressGetStep;

        private readonly DhlLabelGetStep dhlLabelGetStep;

        private readonly LabelAddToDbStep labelAddToDbStep;

        public ReturnLabelPipeline()
        {
            this.addressGetStep = new AddressGetStep();
            this.dhlLabelGetStep = new DhlLabelGetStep();
            this.labelAddToDbStep = new LabelAddToDbStep();

            PipelineSteps = async(input) =>
            {
                var dhlLabel = input
                    .Step(this.addressGetStep)
                    .Step(this.dhlLabelGetStep);

                await dhlLabel
                    .Step(this.labelAddToDbStep);

                // Possibility to use other pipelines
                //await dhlLabel
                //    .Step(new LabelAddToDbPipeline());

                return await dhlLabel;
            };
        }
    }
}
