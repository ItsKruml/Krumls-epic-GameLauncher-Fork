using Newtonsoft.Json;

namespace GameLauncher;

public class Config
{
    public static readonly string AppDir = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "GameLauncher");
    public static readonly string SavePath = Path.Join(AppDir, "config.json");

    public string? IGDBId;
    public string? IGDBSecret;
    public int IGDBRateLimit = 4;

    public bool DiscordRPCEnabled = true;
    public string ScanDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    public void Save()
    {
        Directory.CreateDirectory(AppDir);
        File.WriteAllText(SavePath, JsonConvert.SerializeObject(this));
    }

    public static Config Load()
    {
        if (!File.Exists(SavePath)) new Config().Save();
        return JsonConvert.DeserializeObject<Config>(File.ReadAllText(SavePath))!;
    }
}

public class Stat
{
    public int TimesLaunched;
    public DateTime LastLaunched;
    public TimeSpan PlayTime;
}