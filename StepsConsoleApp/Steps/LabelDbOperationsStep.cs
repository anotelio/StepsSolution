using System.Threading.Tasks;
using StepsConsoleApp.Contracts;
using StepsConsoleApp.Data;

namespace StepsConsoleApp.Steps
{
    public class LabelDbOperationsStep : IPipelineStep<object>
    {
        public async Task RunAsync(Task<object> obj)
        {
            await DataValues.LabelDbOperations();
        }
    }
}
