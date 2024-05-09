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
        private string _clientId;

        public RichPresence(string clientId)
        {
            this._clientId = clientId;
            this.client = new(clientId);
        }

        public void Start()
        {
            if (this.client.IsDisposed)
                this.client = new(this._clientId);
            this.client.Initialize();
        }
        
        public void Stop()
        {
            this.lastGame = null;
            this.client.Dispose();
        }

        public void Update(LocalGame game)
        {
            if (this.lastGame == game) return;
            this.lastGame = game;

            this.client.SetPresence(new()
            {
                Details = $"Playing {game.Name}",
                Timestamps = new(game.AttachedProcess!.StartTime.ToUniversalTime()),
                Assets = new()
                {
                    LargeImageKey = game.CoverUrl
                }
            });
        }

        public void Reset()
        {
            this.lastGame = null;
            this.client.SetPresence(null);
        }
    }
}
