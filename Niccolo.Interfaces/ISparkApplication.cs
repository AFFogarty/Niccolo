using Microsoft.Spark.Sql;

namespace Niccolo.Interfaces
{
    public interface ISparkApplication
    {
        SparkSession BuildSparkSession();

        void Run(SparkSession session);
    }
}
