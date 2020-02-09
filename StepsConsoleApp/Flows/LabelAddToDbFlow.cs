using System.Threading.Tasks;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Pipelines;

namespace StepsConsoleApp.Flows
{
    public class LabelAddToDbFlow
    {
        private readonly LabelAddToDbPipeline labelAddToDbPipeline;

        public LabelAddToDbFlow()
        {
            this.labelAddToDbPipeline = new LabelAddToDbPipeline();
        }

        public async Task RunAsync(LabelDto label)
        {
            await this.labelAddToDbPipeline
                .RunAsync(Task.FromResult(label));

            await new LabelDbOperationsPipeline()
                .RunAsync(null);
        }
    }
}
