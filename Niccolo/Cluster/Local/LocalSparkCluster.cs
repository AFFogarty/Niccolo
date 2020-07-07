using Niccolo.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Niccolo.Cluster.Local
{
    /// <summary>
    /// <see cref="ISparkCluster"/> implementation that submits jobs to a local cluster via spark-submit.
    /// </summary>
    public class LocalSparkCluster : ISparkCluster
    {
        public string SparkHome { get; set; } = Environment.GetEnvironmentVariable("SPARK_HOME");
        public string Mode { get; set; } = "local";
        public string DotNetJar { get; set; } = "microsoft-spark-2.4.x-0.12.1.jar";

        public ISparkJob RunBatchApplication(Type application)
        {
            string sparkSubmitCommand = Path.Combine(SparkHome, "bin", IsWindows() ? "spark-submit.cmd" : "spark-submit");
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string exePath = Path.Combine(assemblyDirectory, "Niccolo.Bootstrapper.exe");
            string jarPath = Path.Combine(assemblyDirectory, DotNetJar);
            string arguments = $@"--class org.apache.spark.deploy.dotnet.DotnetRunner --master {Mode}  ""{jarPath}""  ""{exePath}"" ""{application.Assembly.FullName}"" ""{application.FullName}""";

            return new LocalSparkJob(Process.Start(sparkSubmitCommand, arguments));
        }

        /// <summary>
        /// True iff current platform is Windows.
        /// </summary>
        private bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    }
}
