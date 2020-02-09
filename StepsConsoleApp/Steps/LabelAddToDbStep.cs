using System.Threading.Tasks;
using StepsConsoleApp.Contracts;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Data;

namespace StepsConsoleApp.Steps
{
    public class LabelAddToDbStep : IPipelineStep<LabelDto>
    {
        public async Task RunAsync(Task<LabelDto> label)
        {
            var param = await label;
            await DataValues.LabelAddToDb(param.ReturnHeadId,
                param.Carrier,
                param.LabelFile);
        }
    }
}
