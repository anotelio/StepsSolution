using System;
using System.Threading.Tasks;

namespace StepsConsoleApp.Contracts
{
    /// <summary>
    /// A base interface required so that reflection code can create a Step from its type name,
    /// without needing to understand its generic parameters first.
    /// </summary>
    public interface IPipelineStep
    {
        Task RunAsync();
    }

    /// <summary>
    /// Base type for individual pipeline steps.
    /// Descendants of this type map an input value to an output value.
    /// The input and output types can differ.
    /// </summary>
    public interface IPipelineStep<INPUT, OUTPUT>
    {
        Task<OUTPUT> RunAsync(Task<INPUT> input);
    }

    public interface IPipelineStep<INPUT>
    {
        Task RunAsync(Task<INPUT>input);
    }

    /// <summary>
    /// An extension method for combining PipelineSteps together into a data flow.
    /// </summary>
    public static class PipelineStepExtensions
    {
        public static async Task Step(IPipelineStep step)
        {
            await step.RunAsync();
        }

        public static async Task<OUTPUT> Step<INPUT, OUTPUT>(this Task<INPUT> input, IPipelineStep<INPUT, OUTPUT> step)
        {
            return await step.RunAsync(input);
        }

        public static async Task Step<INPUT>(this Task<INPUT> input, IPipelineStep<INPUT> step)
        {
            await step.RunAsync(input);
        }
    }

    /// <summary>
    /// The base type for a complete pipeline.
    /// Descendant types can use their constructor to compile a set of PipelineSteps together
    /// the PipelineStepExtensions.Step() method, and assign this to the PipelineSteps property here.
    /// The initial and final types of the set of steps must match the input and output types of this class,
    /// but the intermediate types can vary.
    /// </summary>
    public partial class Pipeline : IPipelineStep
    {
        public Action<Task> PipelineSteps { get; protected set; }

        public async Task RunAsync()
        {
            await Task.Run(() => PipelineSteps);
        }
    }

    public partial class Pipeline<INPUT, OUTPUT> : IPipelineStep<INPUT, OUTPUT>
    {
        public Func<Task<INPUT>, Task<OUTPUT>> PipelineSteps { get; protected set; }

        public async Task<OUTPUT> RunAsync(Task<INPUT> input)
        {
            return await PipelineSteps(input);
        }
    }

    public partial class Pipeline<INPUT> : IPipelineStep<INPUT>
    {
        public Action<Task<INPUT>> PipelineSteps { get; protected set; }

        public async Task RunAsync(Task<INPUT> input)
        {
            await Task.Run(() => PipelineSteps(input));
        }
    }
}
