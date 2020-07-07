using System.Threading.Tasks;

namespace Niccolo.Interfaces
{
    public interface ISparkJob
    {
        Task WaitToCompletion();
    }
}
