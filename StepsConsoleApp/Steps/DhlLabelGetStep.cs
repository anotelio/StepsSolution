using System.Threading.Tasks;
using StepsConsoleApp.Contracts;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Data;

namespace StepsConsoleApp.Steps
{
    public class DhlLabelGetStep : IPipelineStep<AddressDto, LabelDto>
    {
        public async Task<LabelDto> RunAsync(Task<AddressDto> address)
        {
            return await DataValues.DhlLabelGet(address.Result);
        }
    }
}
