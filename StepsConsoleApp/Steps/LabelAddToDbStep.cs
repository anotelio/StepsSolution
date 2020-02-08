using StepsConsoleApp.Contracts;
using StepsConsoleApp.Contracts.Dtos;
using StepsConsoleApp.Data;

namespace StepsConsoleApp.Steps
{
    public class LabelAddToDbStep : IPipelineStep<LabelDto>
    {
        public void Run(LabelDto label)
        {
            DataValues.LabelAddToDb(label.ReturnHeadId, label.Carrier, label.LabelFile);
        }
    }
}
