using System.Collections;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using GameLauncher.Connections;
using GameLauncher.Models;
using GameLauncher.Utils;
using IGDB.Models;

namespace GameLauncher
{
    public partial class MainForm : Form
    {
        private static LocalGame[]? Games;

        private static Thread? ProcessMonitorThread;
        private static Thread? RichPresenceThread;

        public SettingsPage? SettingsPage;
        public GameDetailsPage? DetailsPage;
        private NavPage SelectedPage = NavPage.Home;

        public MainForm()
        {
            this.InitializeComponent();
        }

        private static void ProcessMonitorLoop()
        {
            while (Management.Running)
            {
                Thread.Sleep(1000);
                Process[] processes = Process.GetProcesses();

                foreach (LocalGame game in Games)
                    game.ScanForExistingProcess(processes);
            }
        }

        private static void RichPresenceLoop()
        {
            if (Management.Config.DiscordRPCEnabled)
                Management.RichPresence.Start();

            while (Management.Running)
            {
                Thread.Sleep(1000);

                if (!Management.Config.DiscordRPCEnabled) continue;

                // get active game
                LocalGame? game = Games.FirstOrDefault(x => x.IsRunning);
                if (game != null)
                    Management.RichPresence.Update(game);
                else
                    Management.RichPresence.Reset();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = $"Game Launcher [BETA {Management.VersionString}]";

            if (!Management.Online)
            {
                this.Text += " [OFFLINE MODE]";
                this.Notify("You are in offline mode", UI.Controls.NotifyControl.ImageType.NoConnection);
            }

            this.LoadGames();

            if (Management.Online)
            {
                ProcessMonitorThread = new(ProcessMonitorLoop);
                ProcessMonitorThread.Start();

                RichPresenceThread = new(RichPresenceLoop);
                RichPresenceThread.Start();
            }
        }

        private void LoadGames()
        {
            this.flowLayoutPanel1.Controls.Clear();

            Games = LocalGame.GetLocalGames(Management.Config.ScanDir);

            this.LoadingProgressBar.Visible = true;
            this.LoadingProgressBar.Value = 0;
            this.LoadingProgressBar.Maximum = Games.Length;

            foreach (LocalGame game in Games)
            {
                GameItemControl gpc = new(this, game);
                this.flowLayoutPanel1.Controls.Add(gpc);
            }
        }

        private void purgeAllMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PurgeAllMetadata();
        }

        private void addManuallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AddGameManually();
        }

        public void PurgeAllMetadata()
        {
            foreach (LocalGame game in Games!)
                if (game.HasResources())
                    game.DeleteResources();

            this.LoadGames();
        }

        public void AddGameManually()
        {
            OpenFileDialog openDialog = new();
            openDialog.Title = "Select your executable";
            openDialog.Multiselect = false;
            openDialog.InitialDirectory = Management.Config.ScanDir;
            DialogResult result = openDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            string executable = Path.GetFileName(openDialog.FileName);

            FolderBrowserDialog folderDialog = new();
            folderDialog.InitialDirectory = Management.Config.ScanDir;
            result = folderDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            string folder = folderDialog.SelectedPath;

            string launchFile = Path.Join(folder, "launch.dat");
            DatFile.Save(launchFile, new() { { "default", executable } });

            MessageBox.Show("Game successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.LoadGames();
        }

        public void TaskCompleted()
        {
            if (!this.LoadingProgressBar.Visible) return;

            this.LoadingProgressBar.Value++;
            if (this.LoadingProgressBar.Value >= this.LoadingProgressBar.Maximum) this.LoadingProgressBar.Visible = false;
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            if (Program.QueuedNotifications.Count > 0)
            {
                (string message, UI.Controls.NotifyControl.ImageType image) = 
                    Program.QueuedNotifications.Dequeue();
                this.Notify(message, image);
            }

            foreach (ITick item in this.GetAllTickables(this))
                item.Tick();
        }

        private IEnumerable<Control> GetAllTickables(Control parent)
        {
            var controls = parent.Controls.Cast<Control>();

            return controls.SelectMany(this.GetAllTickables)
                                      .Concat(controls)
                                      .Where(x => x is ITick);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Management.Running = false;
        }

        public void CheckForUpdates(Action callback)
        {
            if (!Management.Online)
            {
                this.Notify("Cannot check for updates in offline mode", UI.Controls.NotifyControl.ImageType.NoConnection);
                callback();
                return;
            }

            Version newVer = Updater.GetLatestVersion();
            if (newVer > Management.Version)
            {
                DialogResult result = MessageBox.Show($"New version is available: {newVer}\nWould you like to update?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                try
                {
                    if (result == DialogResult.Yes)
                        Updater.UpdateToVersion(newVer);
                }
                catch (Exception ex)
                {
                    string backupFile = Path.Combine(Path.GetDirectoryName(Management.ExecutablePath), "GameLauncher.exe.bak");
                    if (File.Exists(backupFile))
                        File.Move(backupFile, Management.ExecutablePath);
                    this.Notify($"Failed to update: {ex.Message}", UI.Controls.NotifyControl.ImageType.Error);
                }
                callback();
            }
            else
            {
                this.Notify("No new updates available", UI.Controls.NotifyControl.ImageType.NewRelease);
                callback();
            }
        }

        public GameItemControl GetPanel(LocalGame game)
            => this.flowLayoutPanel1.Controls.OfType<GameItemControl>()
                .First(x => x.Game == game);

        private void HomeNavLabel_Click(object sender, EventArgs e) => Nav_Click(NavPage.Home);

        private void DetailNavLabel_Click(object sender, EventArgs e) => Nav_Click(NavPage.Details);

        private void SettingNavLabel_Click(object sender, EventArgs e) => Nav_Click(NavPage.Settings);

        public void Nav_Click(NavPage page)
        {
            if (this.SelectedPage == page) return;

            SettingsPage?.Despawn(this);
            DetailsPage?.Despawn(this);
            SettingsPage = null;

            if (page == NavPage.Home)
            {

            }
            else if (page == NavPage.Details)
            {
                if (DetailsPage == null)
                {
                    Nav_Click(NavPage.Home);
                    return;
                }

                DetailsPage.Spawn(this);
            }
            else if (page == NavPage.Settings)
            {
                SettingsPage = new SettingsPage();
                SettingsPage.Spawn(this);
            }

            this.SelectedPage = page;
            RefreshVisuallySelectedPage();
        }

        private void RefreshVisuallySelectedPage()
        {
            this.HomeNavLabel.ForeColor = this.SelectedPage == NavPage.Home ? Palette.ActivePrimary : Palette.TextPrimary;
            this.DetailNavLabel.ForeColor = this.SelectedPage == NavPage.Details ? Palette.ActivePrimary : Palette.TextPrimary;
            this.SettingNavLabel.ForeColor = this.SelectedPage == NavPage.Settings ? Palette.ActivePrimary : Palette.TextPrimary;
        }

        public enum NavPage
        {
            Home,
            Details,
            Settings
        }
    }
}