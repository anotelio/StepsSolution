using System;

namespace StepsConsoleApp.Contracts
{
    /// <summary>
    /// A base interface required so that reflection code can create a Step from its type name,
    /// without needing to understand its generic parameters first.
    /// </summary>
    public interface IPipelineStep
    {
    }


    /// <summary>
    /// Base type for individual pipeline steps.
    /// Descendants of this type map an input value to an output value.
    /// The input and output types can differ.
    /// </summary>
    public interface IPipelineStep<INPUT, OUTPUT> : IPipelineStep
    {
        OUTPUT Run(INPUT input);
    }

    public interface IPipelineStep<INPUT> : IPipelineStep
    {
        void Run(INPUT input);
    }

    /// <summary>
    /// An extension method for combining PipelineSteps together into a data flow.
    /// </summary>
    public static class PipelineStepExtensions
    {
        public static OUTPUT Step<INPUT, OUTPUT>(this INPUT input, IPipelineStep<INPUT, OUTPUT> step)
        {
            return step.Run(input);
        }

        public static void Step<INPUT>(this INPUT input, IPipelineStep<INPUT> step)
        {
            step.Run(input);
        }
    }

    /// <summary>
    /// The base type for a complete pipeline.
    /// Descendant types can use their constructor to compile a set of PipelineSteps together
    /// the PipelineStepExtensions.Step() method, and assign this to the PipelineSteps property here.
    /// The initial and final types of the set of steps must match the input and output types of this class,
    /// but the intermediate types can vary.
    /// </summary>
    public class Pipeline<INPUT, OUTPUT> : IPipelineStep<INPUT, OUTPUT>
    {
        public Func<INPUT, OUTPUT> PipelineSteps { get; protected set; }

        public OUTPUT Run(INPUT input)
        {
            return PipelineSteps(input);
        }
    }

    //public partial class Pipeline<INPUT> : IPipelineStep<INPUT>
    //{
    //    public Func<INPUT, INPUT> PipelineInputSteps { get; protected set; }

    //    public INPUT Run(INPUT input)
    //    {
    //        return PipelineInputSteps(input);
    //    }
    //}
}
