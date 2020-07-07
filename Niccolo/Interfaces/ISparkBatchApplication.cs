using Microsoft.Spark.Sql;

namespace Niccolo.Interfaces
{
    /// <summary>
    /// Public interface representing a batch application.
    /// 
    /// There are 2 fundamental components:
    /// 
    /// 1. BuildSparkSession(): This method is called first and is expected to construct the SparkSession.
    /// 2. Run(): This method is called second and is expected to execute the business logic of the application.
    /// </summary>
    public interface ISparkBatchApplication
    {
        /// <summary>
        /// Construct the SparkSession.
        /// </summary>
        /// <returns>The built SparkSession.</returns>
        SparkSession BuildSparkSession();

        /// <summary>
        /// Execute the business logic of the batch application.
        /// </summary>
        /// <param name="session">The SparkSession constructed by BuildSparkSession().</param>
        void Run(SparkSession session);
    }
}
