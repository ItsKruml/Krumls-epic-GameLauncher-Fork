using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IGDB.Models;

namespace GameLauncher
{
    internal static class Management
    {
        public static string ScanDir = "D:/NonSteamLibrary";
        public static IGDBObj IGDBObj = new("0h7tabwhz9sediiyafjefsyk2nz115", "6gq5e87pm2cs79mnejml1vizattrt9");
        public static string[] GetGames()
        {
            return Directory.GetFiles(ScanDir, "launch.dat", SearchOption.AllDirectories)
                .Concat(Directory.GetFiles(ScanDir, "HOW TO RUN GAME!!.txt", SearchOption.AllDirectories))
                .Select(Path.GetDirectoryName).Distinct()
                .ToArray()!;
        }

        public static Process LaunchGame(string gamePath, string mode = "default")
        {
            string launchFile = Path.Combine(gamePath, "launch.dat");
            if (File.Exists(launchFile))
            {
                Dictionary<string, string> values = ParseDatFile(launchFile);
                if (values.ContainsKey(mode))
                    return FindLaunchFile(gamePath, values[mode]);
            }

            string howToRunGame = Path.Combine(gamePath, "HOW TO RUN GAME!!.txt");
            if (File.Exists(howToRunGame))
            {
                Match m = Regex.Match(File.ReadAllText(howToRunGame), "right click and run '(.*?)' as administrator");
                string file = m.Groups[1].Value + ".exe";
                return FindLaunchFile(gamePath, file);
            }

            throw new RestorableError($"Could not find launch in {gamePath}");
        }

        public static Process FindLaunchFile(string dir, string fileName)
        {
            string fileExt = Path.GetExtension(fileName.Trim());
            string[] results = Directory.GetFiles(dir, "*" + fileExt, SearchOption.AllDirectories)
                .Where(x => Path.GetFileName(x) == fileName.Trim()).ToArray();
            if (results.Length == 0)
                throw new RestorableError("No results found");
            else if (results.Length == 1)
            {
                Process proc = Process.Start(results[0]);
                return proc;
            }
            else
                throw new RestorableError("Multiple results found");
        }

        public static string[] GetGameModes(string gamePath)
        {
            string launchFile = Path.Combine(gamePath, "launch.dat");
            if (File.Exists(launchFile))
            {
                Dictionary<string, string> values = ParseDatFile(launchFile);
                return values.Keys.ToArray();
            }

            string howToRunGame = Path.Combine(gamePath, "HOW TO RUN GAME!!.txt");
            if (File.Exists(howToRunGame))
            {
                return new string[] { "default" };
            }

            throw new RestorableError($"Could not find launch in {gamePath}");
        }

        public static Dictionary<string, string> ParseDatFile(string datFile)
        {
            string[] linesFile = File.ReadAllLines(datFile);
            return linesFile.ToDictionary(x => x.Split("=", 2)[0],
                y => y.Split("=", 2).ElementAtOrDefault(1) ?? "");
        }

        public static void SaveDatFile(string datFile, Dictionary<string, string> values)
        {
            File.WriteAllLines(datFile, values.Select(x => $"{x.Key}={x.Value.Replace("\n", " ")}"));
        }

        public static bool HasResources(string gamePath)
        {
            string dir = GetResources(gamePath);
            bool exists = Directory.Exists(dir);
            if (exists && Directory.GetFiles(dir).Length != 2)
            {
                DeleteResources(gamePath);
                return false;
            }
            return exists;
        }

        public static void DownloadResources(string gamePath, Game game)
        {
            WebClient client = new();

            string resourcesPath = GetResources(gamePath);
            string info = Path.Combine(resourcesPath, "info.dat");
            string cover = Path.Combine(resourcesPath, "cover.png");

            Directory.CreateDirectory(resourcesPath);

            byte[] coverData = client.DownloadData("https:" + game.Cover.Value.Url
                .Replace("t_thumb", "t_cover_big"));

            Dictionary<string, string> infoData = new()
            {
                { "name", game.Name },
                { "genres", string.Join(", ", game.Genres.Values.Select(x=>x.Name)) },
                { "summary", game.Summary }
            };

            File.WriteAllBytes(cover, coverData);
            SaveDatFile(info, infoData);

            Thread.Sleep(1000);
        }

        public static string GetResources(string gamePath)
        {
            return Path.Combine(gamePath, "gl.resources");
        }

        public static string GetResources(string gamePath, string sub)
        {
            return Path.Combine(gamePath, "gl.resources", sub);
        }

        public static void DeleteResources(string gamePath)
        {
            Directory.Delete(GetResources(gamePath), true);
        }
    }

    public class RestorableError : Exception
    {
        public RestorableError(string desc) : base(desc) { }
    }
}
