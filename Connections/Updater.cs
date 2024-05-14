using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace GameLauncher.Connections;

public class Updater
{
    public static Version GetLatestVersion()
    {
        using WebClient client = new();
        client.Headers[HttpRequestHeader.UserAgent] = "Game launcher updater";
        string result = client.DownloadString("https://api.github.com/repos/Melodi17/GameLauncher/releases/latest");
        RootObject root = JsonConvert.DeserializeObject<RootObject>(result)!;
        Version v = Version.Parse(root.name.Replace("v", ""));
        return v;
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
        
        File.WriteAllText(Path.Combine(Path.GetDirectoryName(Management.ExecutablePath), ".update"), Management.VersionString);
        
        MessageBox.Show("Game Launcher has been updated. Please restart.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        Environment.Exit(0);
    }
    
    public static bool DidUpdate(out Version? ver)
    {
        string path = Path.Combine(Path.GetDirectoryName(Management.ExecutablePath), ".update");
        if (!File.Exists(path))
        {
            ver = null;
            return false;
        }
        
        ver = Version.Parse(File.ReadAllText(path));
        File.Delete(path);
        return true;
    }
    
    public class RootObject
    {
        public string url { get; set; }
        public string assets_url { get; set; }
        public string upload_url { get; set; }
        public string html_url { get; set; }
        public int id { get; set; }
        public Author author { get; set; }
        public string node_id { get; set; }
        public string tag_name { get; set; }
        public string target_commitish { get; set; }
        public string name { get; set; }
        public bool draft { get; set; }
        public bool prerelease { get; set; }
        public string created_at { get; set; }
        public string published_at { get; set; }
        public Assets[] assets { get; set; }
        public string tarball_url { get; set; }
        public string zipball_url { get; set; }
        public string body { get; set; }
    }

    public class Author
    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
    }

    public class Assets
    {
        public string url { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string name { get; set; }
        public object label { get; set; }
        public Uploader uploader { get; set; }
        public string content_type { get; set; }
        public string state { get; set; }
        public int size { get; set; }
        public int download_count { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string browser_download_url { get; set; }
    }

    public class Uploader
    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
    }
}