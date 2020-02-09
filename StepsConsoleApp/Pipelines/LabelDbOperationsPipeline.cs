using System.Threading.Tasks;
using StepsConsoleApp.Contracts;
using StepsConsoleApp.Steps;

namespace StepsConsoleApp.Pipelines
{
    public class LabelDbOperationsPipeline : Pipeline<object>
    {
        private readonly LabelDbOperationsStep labelDbOperationsStep;

        public LabelDbOperationsPipeline()
        {
            this.labelDbOperationsStep = new LabelDbOperationsStep();

            PipelineSteps = async (input) =>
            {
                await input.Step(this.labelDbOperationsStep);
            };
        }
    }
}
