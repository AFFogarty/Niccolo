using Microsoft.Spark.Sql;
using Niccolo.Cluster.Local;
using Niccolo.Interfaces;

namespace NiccoloExample
{
    /// <summary>
    /// Example Spark batch application.
    /// </summary>
    class TestSparkApp : ISparkBatchApplication
    {
        public SparkSession BuildSparkSession()
        {
            return SparkSession.Builder().GetOrCreate();
        }

        public void Run(SparkSession spark)
        {
            var data = spark.Range(25);
            data.Show();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Reference to the local Spark cluster.
            var cluster = new LocalSparkCluster();

            // Start the batch application on the local cluster.
            ISparkJob job = cluster.RunBatchApplication(typeof(TestSparkApp));

            // Wait for the batch application to finish.
            job.RunningTask.Wait();
        }
    }
}
