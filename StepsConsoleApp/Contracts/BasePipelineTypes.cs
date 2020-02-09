using System;
using System.Threading.Tasks;

namespace StepsConsoleApp.Contracts
{
    /// <summary>
    /// Base type for individual pipeline steps.
    /// </summary>
    public interface IPipelineStep
    {
        Task RunAsync(Task input);
    }

    /// <summary>
    /// Descendants of this type map an input value to an output value.
    /// The input and output types can differ.
    /// </summary>
    public interface IPipelineStep<INPUT, OUTPUT>
    {
        Task<OUTPUT> RunAsync(Task<INPUT> input);
    }

    /// <summary>
    /// Descendants of this type has an input value.
    /// </summary>
    public interface IPipelineStep<INPUT>
    {
        Task RunAsync(Task<INPUT>input);
    }

    /// <summary>
    /// An extension method for combining PipelineSteps together into a data flow.
    /// </summary>
    public static class PipelineStepExtensions
    {
        public static async Task Step(this Task input, IPipelineStep step)
        {
            await step.RunAsync(input);
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
    /// The initial and final types of the set of steps must have the input Task type of this class.
    /// </summary>
    public partial class Pipeline : IPipelineStep
    {
        public Action<Task> PipelineSteps { get; protected set; }

        public async Task RunAsync(Task input)
        {
            await Task.Run(() => PipelineSteps(input));
        }
    }

    /// <summary>
    /// Descendant types can use their constructor to compile a set of PipelineSteps together
    /// the PipelineStepExtensions.Step() method, and assign this to the PipelineSteps property here.
    /// The initial and final types of the set of steps must have the input and output types of this class,
    /// but the intermediate types can vary.
    /// </summary>
    public partial class Pipeline<INPUT, OUTPUT> : IPipelineStep<INPUT, OUTPUT>
    {
        public Func<Task<INPUT>, Task<OUTPUT>> PipelineSteps { get; protected set; }

        public async Task<OUTPUT> RunAsync(Task<INPUT> input)
        {
            return await PipelineSteps(input);
        }
    }

    /// <summary>
    /// Descendant types can use their constructor to compile a set of PipelineSteps together
    /// the PipelineStepExtensions.Step() method, and assign this to the PipelineSteps property here.
    /// The initial and final types of the set of steps must have the input type of this class,
    /// and the intermediate type can vary.
    /// </summary>
    public partial class Pipeline<INPUT> : IPipelineStep<INPUT>
    {
        public Action<Task<INPUT>> PipelineSteps { get; protected set; }

        public async Task RunAsync(Task<INPUT> input)
        {
            await Task.Run(() => PipelineSteps(input));
        }
    }
}
