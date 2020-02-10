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

        public async Task<LabelDto> RunAsync(Task<long> returnHeadId)
        {
            var output = await this.returnLabelPipeline
                .RunAsync(returnHeadId);

            //await new LabelDbOperationsPipeline()
            //    .RunAsync();

            return output;
        }
    }
}
