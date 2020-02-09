using StepsConsoleApp.Contracts;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Steps;

namespace StepsConsoleApp.Pipelines
{
    public class LabelAddToDbPipeline : Pipeline<LabelDto>
    {
        private readonly LabelAddToDbStep labelAddToDbStep;

        public LabelAddToDbPipeline()
        {
            this.labelAddToDbStep = new LabelAddToDbStep();

            PipelineSteps = async(input) =>
            {
                await input.Step(this.labelAddToDbStep);
            };
        }
    }
}
