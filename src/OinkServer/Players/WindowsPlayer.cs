using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

namespace OinkServer.Players
{
    public class WindowsPlayer : IPlayer
    {
        public async Task PlaySound(Stream stream, CancellationToken ct)
        {
            using(var audioFile = new WaveFileReader(stream))
            using(var outputDevice = new WaveOutEvent())
            {
                try
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        await Task.Delay(500, ct);
                    }
                }
                finally
                {
                    outputDevice.Stop();
                }
            }
        }
    }
}