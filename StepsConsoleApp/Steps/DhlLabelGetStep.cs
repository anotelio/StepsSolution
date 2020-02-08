using StepsConsoleApp.Contracts;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Data;

namespace StepsConsoleApp.Steps
{
    public class DhlLabelGetStep : IPipelineStep<AddressDto, LabelDto>
    {
        public LabelDto Run(AddressDto address)
        {
            return DataValues.DhlLabelGet(address);
        }
    }
}
