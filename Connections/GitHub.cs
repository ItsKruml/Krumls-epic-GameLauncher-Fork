using System.Net;
using System.Text.RegularExpressions;

namespace GameLauncher.Connections;

public class GitHub
{
    public static Version GetLatestVersion()
    {
        using WebClient client = new();
        string result = client.DownloadString("https://raw.githubusercontent.com/Melodi17/GameLauncher/main/GameLauncher.csproj");
        Match m = Regex.Match(result, @"<AssemblyVersion>(\d+\.\d+\.\d+)</AssemblyVersion>");
        return Version.Parse(m.Groups[1].Value);
    }
    
    public bool IsNewerVersion() => GetLatestVersion() > Management.Version;

    public static void UpdateToVersion(Version version)
    {
        using WebClient client = new();
        // https://github.com/Melodi17/GameLauncher/releases/download/v1.4.8/GameLauncher.exe
        
        string path = Path.Combine(Path.GetDirectoryName(Management.ExecutablePath), "GameLauncher.exe.update");

        client.DownloadFile(
            $"https://github.com/Melodi17/GameLauncher/releases/download/v{version.ToString(3)}/GameLauncher.exe",
            path);

        File.Move(Management.ExecutablePath,
            Path.Combine(Path.GetDirectoryName(Management.ExecutablePath), "GameLauncher.exe.bak"));
        
        File.Move(path, Management.ExecutablePath);
        
        MessageBox.Show("Game Launcher has been updated. Please restart.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        Environment.Exit(0);
    }
}