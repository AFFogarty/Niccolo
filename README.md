# Niccolo

Niccolo is an easy-to-use orchestration framework for
[.NET for Apache Spark](https://github.com/dotnet/spark) applications. Niccolo makes it quick and
easy to write .NET applications and submit them to Apache Spark clusters.

## Use cases

Niccolo can be used for:

1. Rapid development and prototyping of applications.
2. [POCO](https://en.wikipedia.org/wiki/Plain_old_CLR_object) code-first approach to application
scheduling and management.

## Sample

The following example shows how to use Niccolo to write a simple .Net for Apache Spark application
and submit it to a local cluster.

```csharp
using Microsoft.Spark.Sql;
using Niccolo.Cluster.Local;
using Niccolo.Interfaces;

namespace Niccolo.Example
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

```
