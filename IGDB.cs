﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private int currentRequests;
        private const int limit = 4;
        public IGDBClient client;

        public IGDBObj(string clientId, string clientSecret)
        {
            client = new(clientId, clientSecret);
        }

        public Game[] Search(string query, int limit = 1)
        {
            while (currentRequests >= limit)
            {
                Debug.WriteLine($"Ratelimit protection hit, waiting ({Thread.CurrentThread.ManagedThreadId})");
                Thread.Sleep(1000); 
            }

            try
            {
                currentRequests++;

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
            finally { currentRequests--; }
        }

        public string ImageUrl(Cover cover, ImageSize size)
        {
            return "https:" + cover.Url
                    .Replace("t_thumb", $"t_{size.GetString()}");
        }
    }

    public enum ImageSize
    {
        CoverSmall,
        ScreenshotMed,
        CoverBig,
        LogoMed,
        ScreenshotBig,
        ScreenshotHuge,
        Thumb,
        Micro,
        z720p,
        z1080p
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
