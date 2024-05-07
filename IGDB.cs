using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IGDB;
using IGDB.Models;

namespace GameLauncher
{
    internal class IGDBObj
    {
        public IGDBClient client;

        public IGDBObj(string clientId, string clientSecret)
        {
            client = new(clientId, clientSecret);
        }

        public Game[] Search(string query, int limit = 1)
        {
            Match m = Regex.Match(query, @"\[(\d+)\]");

            // This allows overriding search by putting an id in [brackets]
            if (m.Success)
            {
                return client.QueryAsync<Game>(IGDBClient.Endpoints.Games,
                    $"fields id,name,cover.*,summary,genres.name;" +
                    $"where id = {m.Groups[1].Value};")
                    .GetAwaiter().GetResult();
            }

            return client.QueryAsync<Game>(IGDBClient.Endpoints.Games,
                $"search \"{query}\";" +
                $" fields id,name,cover.*,summary,genres.name;" +
                $" limit {limit};")
                .GetAwaiter().GetResult();
        }
    }
}
