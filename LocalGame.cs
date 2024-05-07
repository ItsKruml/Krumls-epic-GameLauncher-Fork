using System.Text.RegularExpressions;

namespace GameLauncher
{
    public class LocalGame
    {
        public string FilePath;
        public LocalGame(string filePath)
        {
            FilePath = filePath;
        }

        public static LocalGame[] GetLocalGames(string scanDir)
        {
            foreach (string file in Directory.GetFiles(scanDir, "HOW TO RUN GAME!!.txt", SearchOption.AllDirectories))
                GenerateLaunchFromHowToLaunch(file);
        }

        private static void GenerateLaunchFromHowToLaunch(string filePath)
        {
            string dir = Path.GetDirectoryName(filePath);
            string launchFile = Path.Combine(dir, "launch.dat");

            Match m = Regex.Match(File.ReadAllText(filePath), "right click and run '(.*?)' as administrator");
            string file = m.Groups[1].Value + ".exe";

            DatFile.Save(launchFile, new Dictionary<string, string> { { "default", file } });
        }
    }

    public static class DatFile
    {
        public static void Save(string datFile, Dictionary<string, string> values)
        {
            File.WriteAllLines(datFile, values.Select(x => $"{x.Key}={x.Value.Replace("\n", " ")}"));
        }

        public static Dictionary<string, string> Open(string datFile)
        {
            string[] linesFile = File.ReadAllLines(datFile);
            return linesFile.ToDictionary(x => x.Split("=", 2)[0],
                y => y.Split("=", 2).ElementAtOrDefault(1) ?? "");
        }
    }
}
