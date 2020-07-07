using System.Threading.Tasks;

namespace Niccolo.Interfaces
{
    /// <summary>
    /// Represents a Spark application in execution.
    /// </summary>
    public interface ISparkJob
    {
        /// <summary>
        /// Task that completes when the application has finished running.
        /// </summary>
        Task RunningTask { get; }
    }
}
