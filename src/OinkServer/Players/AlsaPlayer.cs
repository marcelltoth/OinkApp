using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Iot.Device.Media;

namespace OinkServer.Players
{
    public class AlsaPlayer: IPlayer
    {
        public async Task PlaySound(Stream stream, CancellationToken ct = default)
        {
            SoundConnectionSettings settings = new SoundConnectionSettings();
            using SoundDevice device = SoundDevice.Create(settings);
            device.PlaybackVolume = 80; 
            device.Play(stream);
        }
    }
}