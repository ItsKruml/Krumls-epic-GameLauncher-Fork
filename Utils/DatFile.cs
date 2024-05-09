namespace GameLauncher.Utils
{
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
