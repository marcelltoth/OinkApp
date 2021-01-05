using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OinkServer.Players
{
    public interface IPlayer
    {
        Task PlaySound(Stream stream, CancellationToken ct = default);
    }
}