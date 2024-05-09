using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GameLauncher
{
    public partial class SettingsPage : UserControl
    {
        public Form1? MainForm;
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        private void SettingsPage_Load(object sender, EventArgs e)
        {
            this.MainForm = (this.ParentForm as Form1)!;

            Dictionary<string, object> settings = new();
            settings.Add("Add custom game", new Action(this.MainForm.AddGameManually));
            settings.Add("Purge all metadata", new Action(this.MainForm.PurgeAllMetadata));
            settings.Add("Check for updates", new Action(this.MainForm.CheckForUpdates));

            settings.Add("IGDB ID", Management.Config.IGDBId ?? "");
            settings.Add("IGDB Secret", Management.Config.IGDBSecret ?? "");
            settings.Add("IGDB Rate limit", Management.Config.IGDBRateLimit);

            settings.Add("Discord RPC", Management.Config.DiscordRPCEnabled);
            settings.Add("Theme", Management.Config.Theme);
            settings.Add("Scan Dir", Management.Config.ScanDir);

            foreach (KeyValuePair<string, object> item in settings)
            {
                SettingItemControl control = SettingItemControl.ForObject(item.Key, item.Value, v =>
                {
                    settings[item.Key] = v;
                    this.SettingChanged(item.Key, v);
                });
                this.flowLayoutPanel1.Controls.Add(control);
            }
        }

        private void SettingChanged(string key, object value)
        {
            if (key == "Theme")
            {
                Management.Config.Theme = (LauncherTheme)value;
                Management.ThemeChanged();
            }

            if (key == "Discord RPC")
            {
                Management.Config.DiscordRPCEnabled = (bool)value;
                if (Management.Config.DiscordRPCEnabled)
                    Management.RichPresence.Start();
                else
                    Management.RichPresence.Stop();
            }
            
            if (key == "IGDB ID")
                Management.Config.IGDBId = (string)value;
            
            if (key == "IGDB Secret")
                Management.Config.IGDBSecret = (string)value;
            
            if (key == "IGDB Rate limit")
                Management.Config.IGDBRateLimit = (int)value;
            
            if (key == "Scan Dir")
            {
                if (Directory.Exists((string)value))
                {
                    Management.Config.ScanDir = (string)value;
                    MessageBox.Show("Scan directory changed, please restart the launcher for changes to take effect.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
            Management.Config.Save();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.MainForm!.Controls.Remove(this);
        }
    }

    public class Config
    {
        public static readonly string AppDir = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "GameLauncher");
        public static readonly string SavePath = Path.Join(AppDir, "config.json");
        
        public string? IGDBId;
        public string? IGDBSecret;
        public int IGDBRateLimit = 4;

        public LauncherTheme Theme = LauncherTheme.Light;
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
}
