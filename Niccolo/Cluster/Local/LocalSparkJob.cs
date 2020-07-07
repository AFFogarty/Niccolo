using Niccolo.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Niccolo.Cluster.Local
{
    /// <summary>
    /// <see cref="ISparkJob"/> implementation for a job running on a <see cref="LocalSparkCluster"/>.
    /// </summary>
    class LocalSparkJob : ISparkJob
    {
        public LocalSparkJob(Process applicationProcess)
        {
            // Wrap the running application in an async task.
            RunningTask = new Task(applicationProcess.WaitForExit);
            RunningTask.Start();
        }

        public Task RunningTask { get; private set; }
    }
}
