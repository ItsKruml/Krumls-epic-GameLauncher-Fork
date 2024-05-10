using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IGDB;
using IGDB.Models;

namespace GameLauncher.Connections
{
    internal class IGDBObj
    {
        public static int Limit = 4;
        private int currentRequests;
        public IGDBClient client;

        public IGDBObj(string clientId, string clientSecret)
        {
            this.client = new(clientId, clientSecret);
        }

        public Game[] Search(string query, int limit = 1)
        {
            while (this.currentRequests >= limit)
            {
                Debug.WriteLine($"Ratelimit protection hit, waiting ({Thread.CurrentThread.ManagedThreadId})");
                Thread.Sleep(1000);
            }

            try
            {
                this.currentRequests++;

                Match m = Regex.Match(query, @"\[(\d+)\]");

                // This allows overriding search by putting an id in [brackets]
                if (m.Success)
                {
                    return this.client.QueryAsync<Game>(IGDBClient.Endpoints.Games,
                        $"fields id,name,cover.*,summary,genres.name;" +
                        $"where id = {m.Groups[1].Value};")
                        .GetAwaiter().GetResult();
                }
                
                return this.client.QueryAsync<Game>(IGDBClient.Endpoints.Games,
                    $"search \"{query}\";" +
                    $" fields id,name,cover.*,summary,genres.name,version_parent;" +
                    // $" sort rating desc;" +
                    $"where version_parent = null;" +
                    $" limit {limit};")
                    .GetAwaiter().GetResult();
            }
            finally {
                this.currentRequests--; }
        }
        
        public void SearchAsync(string query, Action<Game[]> callback, int limit = 1)
        {
            new Thread(() =>
            {
                callback(this.Search(query, limit));
            }).Start();
        }

        public bool TestCredentials()
        {
            try
            {
                this.client.QueryAsync<Game>(IGDBClient.Endpoints.Games, "fields id,name; limit 1;").GetAwaiter().GetResult();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static bool TestConnectivity()
        {
            // try download the main page
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://www.google.com/");
                request.KeepAlive = false;
                request.Timeout = 3000;
                using HttpWebResponse _ = (HttpWebResponse)request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string ImageUrl(Cover cover, ImageSize size)
        {
            return "https:" + cover.Url
                    .Replace("t_thumb", $"t_{size.GetString()}");
        }

        public void TestCredentialsAsync(Action<bool> callback)
        {
            new Thread(() =>
            {
                callback(this.TestCredentials());
            }).Start();
        }
    }


    public static class ImageSizeMethods
    {

        public static string GetString(this ImageSize size)
        {
            return size switch
            {
                ImageSize.CoverSmall => "cover_small",
                ImageSize.ScreenshotMed => "screenshot_med",
                ImageSize.CoverBig => "cover_big",
                ImageSize.LogoMed => "logo_med",
                ImageSize.ScreenshotBig => "screenshot_big",
                ImageSize.ScreenshotHuge => "screenshot_huge",
                ImageSize.Thumb => "thumb",
                ImageSize.Micro => "micro",
                ImageSize.z720p => "720p",
                ImageSize.z1080p => "1080p",
                _ => throw new InvalidEnumArgumentException(),
            };
        }
    }
}
