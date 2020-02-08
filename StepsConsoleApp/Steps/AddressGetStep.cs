using StepsConsoleApp.Contracts;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Data;

namespace StepsConsoleApp.Steps
{
    public class AddressGetStep : IPipelineStep<long, AddressDto>
    {
        public AddressDto Run(long returnHeadId)
        {
            return DataValues.AdressGet(returnHeadId);
        }
    }
}
