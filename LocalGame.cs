using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using IGDB.Models;

namespace GameLauncher
{
    public class LocalGame
    {
        public readonly string GamePath;

        public string[] LaunchNames => LaunchData.Keys.ToArray();
        public Dictionary<string, string> LaunchData;
        public Dictionary<string, string>? GameMetaData;

        public Process? AttachedProcess;
        public bool IsRunning => AttachedProcess != null && !AttachedProcess.HasExited;

        public string? Name => GameMetaData?["name"];
        public string? Genres => GameMetaData?["genres"];
        public string? Summary => GameMetaData?["summary"];

        private readonly string resourcePath;
        private readonly string gameMetadataPath;
        private readonly string coverPath;
        private readonly string launchPath;

        public string? CoverPath => coverPath;

        public LocalGame(string filePath)
        {
            GamePath = filePath;
            launchPath = Path.Join(GamePath, "launch.dat");
            resourcePath = Path.Join(GamePath, "gl.resources");
            gameMetadataPath = Path.Combine(resourcePath, "metadata.dat");
            coverPath = Path.Combine(resourcePath, "cover.png");

            LaunchData = DatFile.Open(launchPath);
        }

        public static LocalGame[] GetLocalGames(string scanDir)
        {
            foreach (string file in Directory.GetFiles(scanDir, "HOW TO RUN GAME!!.txt", SearchOption.AllDirectories))
                GenerateLaunchFromHowToLaunch(file);

            return Directory.GetFiles(scanDir, "launch.dat", SearchOption.AllDirectories)
                .Select(x => new LocalGame(Path.GetDirectoryName(x)))
                .ToArray();
        }

        private static void GenerateLaunchFromHowToLaunch(string filePath)
        {
            string dir = Path.GetDirectoryName(filePath);
            string launchFile = Path.Combine(dir, "launch.dat");

            // Do not overwrite if theres already a launch file!!
            if (File.Exists(launchFile))
                return;

            Match m = Regex.Match(File.ReadAllText(filePath), "right click and run '(.*?)' as administrator");
            string file = m.Groups[1].Value + ".exe";

            DatFile.Save(launchFile, new Dictionary<string, string> { { "default", file } });
        }

        public Process Launch(string mode = "default")
        {
            if (!LaunchData.ContainsKey(mode))
                throw new RestorableError("Specified launch mode not found");

            string fileName = LaunchData[mode];

            string fileExt = Path.GetExtension(fileName.Trim());
            string[] results = Directory.GetFiles(GamePath, "*" + fileExt, SearchOption.AllDirectories)
                .Where(x => Path.GetFileName(x) == fileName.Trim()).ToArray();

            if (results.Length != 1)
                throw new RestorableError("No, or multiple results found");

            AttachedProcess = Process.Start(results.First());
            return AttachedProcess;
        }

        public bool HasResources()
        {
            bool exists = Directory.Exists(resourcePath);
            if (exists && Directory.GetFiles(resourcePath).Length != 2)
            {
                DeleteResources();
                return false;
            }
            return exists;
        }

        public void DeleteResources()
        {
            Directory.Delete(resourcePath, true);
        }

        public void LoadOrDownloadResources()
        {
            if (!HasResources())
            {
                Game? game = Management.IGDBObj.Search(Path.GetFileNameWithoutExtension(GamePath))
                        .FirstOrDefault() ?? throw new Exception("Could not find game in IGDB");

                WebClient client = new();

                Directory.CreateDirectory(resourcePath);

                byte[] coverData = client.DownloadData("https:" + game.Cover.Value.Url
                    .Replace("t_thumb", "t_cover_big"));

                GameMetaData = new()
                {
                    { "name", game.Name },
                    { "genres", string.Join(", ", game.Genres.Values.Select(x => x.Name)) },
                    { "summary", game.Summary }
                };

                File.WriteAllBytes(coverPath, coverData);
                DatFile.Save(gameMetadataPath, GameMetaData);

            }

            // We set this above, theres no point reloading it.
            // ??= allows modifications only when initial value is null;
            GameMetaData ??= DatFile.Open(gameMetadataPath);
        }

        public void Kill()
        {
            if (!IsRunning)
                throw new RestorableError("Game not running");

            AttachedProcess.Kill();
            AttachedProcess = null;
        }

        public void ScanForExistingProcess(Process[] processes)
        {
            // Look for processes with the same name
            Process? process = LaunchData.Values
                .SelectMany(x => processes.Where(z=> z.ProcessName + ".exe" == x))
                .Where(x => x.GetMainModuleFilepath()?.IsSubPathOf(GamePath) ?? false).FirstOrDefault();

            if (process != null)
            {
                AttachedProcess = process;
                return;
            }

            // Look for ones in the same dir (can't, its too expensive)
            //process = processes
            //    .Where(x => x.GetMainModuleFilepath()?.IsSubPathOf(GamePath) ?? false).FirstOrDefault();

            //if (process != null) AttachedProcess = process;
        }
    }
}
