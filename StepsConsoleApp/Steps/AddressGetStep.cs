using System.Threading.Tasks;
using StepsConsoleApp.Contracts;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Data;

namespace StepsConsoleApp.Steps
{
    public class AddressGetStep : IPipelineStep<long, AddressDto>
    {
        public async Task<AddressDto> RunAsync(Task<long> returnHeadId)
        {
            return await DataValues.AdressGet(returnHeadId.Result);
        }
    }
}
