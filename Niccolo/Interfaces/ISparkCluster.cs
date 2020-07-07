using System;

namespace Niccolo.Interfaces
{
    /// <summary>
    /// Public interface for a Spark cluster implementation.
    /// </summary>
    public interface ISparkCluster
    {
        /// <summary>
        /// Construct and run the provided application type 
        /// </summary>
        /// <param name="applicationType">This type should inherit from ISparkBatchApplication.</param>
        /// <returns>ISparkJob representing the running batch application.</returns>
        ISparkJob RunBatchApplication(Type applicationType);
    }
}
