using System;

namespace Niccolo.Interfaces
{
    public interface ISparkCluster
    {
        ISparkJob RunBatchApplication(Type applicationType);
    }
}
