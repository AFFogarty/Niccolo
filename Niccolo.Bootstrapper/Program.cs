using Microsoft.Spark.Sql;
using Niccolo.Interfaces;
using System;

namespace Niccolo.Bootstrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use arguments to determine type name.
            string assemblyName = args[0];
            string typeName = args[1];
            var applicationType = Type.GetType($"{typeName}, {assemblyName}");

            // Create the app and run it.
            ISparkBatchApplication app = (ISparkBatchApplication)Activator.CreateInstance(applicationType);
            SparkSession sparkSession = app.BuildSparkSession();
            app.Run(sparkSession);
        }
    }
}

