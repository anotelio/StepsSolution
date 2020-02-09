using System.Threading.Tasks;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Pipelines;

namespace StepsConsoleApp.Flows
{
    public class ReturnLabelFlow
    {
        private readonly ReturnLabelPipeline returnLabelPipeline;

        public ReturnLabelFlow()
        {
            this.returnLabelPipeline = new ReturnLabelPipeline();
        }

        public async Task<LabelDto> RunAsync(long returnHeadId)
        {
            return await this.returnLabelPipeline
                .RunAsync(Task.FromResult(returnHeadId));
        }
    }
}
