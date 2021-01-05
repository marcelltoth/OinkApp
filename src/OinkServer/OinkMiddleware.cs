using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OinkServer.Players;

namespace OinkServer
{
    public class OinkMiddleware : IMiddleware
    {
        private readonly IPlayer _player;
        private readonly SoundProvider _soundProvider;

        public OinkMiddleware(IPlayer player, SoundProvider soundProvider)
        {
            _player = player;
            _soundProvider = soundProvider;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await using var sound = _soundProvider.GetRandomSound();

            await _player.PlaySound(sound, context.RequestAborted);
        }
    }
}