using StepsConsoleApp.Contracts;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Steps;

namespace StepsConsoleApp.Pipelines
{
    public class LabelAddToDbPipeline : Pipeline<LabelDto, object>
    {
        public LabelAddToDbPipeline()
        {
            PipelineSteps = (input) =>
            {
                input.Step(new LabelAddToDbStep());
                return new object();
            };
        }
    }
}
