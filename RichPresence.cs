using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;

namespace GameLauncher
{
    internal class RichPresence
    {
        private DiscordRpcClient client;
        private LocalGame? lastGame;

        public RichPresence(string clientId)
        {
            client = new(clientId);
        }

        public void Start()
        {
            client.Initialize();
        }

        public void Update(LocalGame game)
        {
            if (lastGame == game) return;
            lastGame = game;

            client.SetPresence(new()
            {
                Details = $"Playing {game.Name}",
                Timestamps = new Timestamps(game.AttachedProcess!.StartTime.ToUniversalTime()),
                Assets = new()
                {
                    LargeImageKey = game.CoverUrl
                }
            });
        }

        private static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddMilliseconds(unixTime);
        }

        public void Reset() => client.SetPresence(null);
    }
}
