using System.Threading.Tasks;
using StepsConsoleApp.Contracts;
using StepsConsoleApp.Data;

namespace StepsConsoleApp.Steps
{
    public class LabelDbOperationsStep : IPipelineStep
    {
        public async Task RunAsync()
        {
            await DataValues.LabelDbOperations();
        }
    }
}
