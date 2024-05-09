using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using GameLauncher.Utils;
using IGDB.Models;

namespace GameLauncher
{
    public partial class Form1 : Form
    {
        public static string ScanDir = "D:/NonSteamLibrary";
        private static LocalGame[]? Games;

        private static Thread? ProcessMonitorThread;
        private static Thread? RichPresenceThread;

        public Form1()
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
            this.Text = $"Game Launcher [BETA {Application.ProductVersion}]";
            
            this.LoadGames();

            ProcessMonitorThread = new(ProcessMonitorLoop);
            ProcessMonitorThread.Start();

            RichPresenceThread = new(RichPresenceLoop);
            RichPresenceThread.Start();

            Management.ThemeChange += this.Management_ThemeChange;
        }

        private void Management_ThemeChange(LauncherTheme theme)
        {
            this.BackColor = theme.GetColor(LauncherThemeKey.PrimaryBackground);
            this.ForeColor = theme.GetColor(LauncherThemeKey.PrimaryText);
        }

        private void LoadGames()
        {
            this.flowLayoutPanel1.Controls.Clear();

            Games = LocalGame.GetLocalGames(ScanDir);

            this.LoadingProgressBar.Visible = true;
            this.LoadingProgressBar.Value = 0;
            this.LoadingProgressBar.Maximum = Games.Length;

            foreach (LocalGame game in Games)
            {
                GamePanelControl gpc = new(this, game);
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
            openDialog.InitialDirectory = ScanDir;
            DialogResult result = openDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            string executable = Path.GetFileName(openDialog.FileName);

            FolderBrowserDialog folderDialog = new();
            folderDialog.InitialDirectory = ScanDir;
            result = folderDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            string folder = folderDialog.SelectedPath;

            string launchFile = Path.Join(folder, "launch.dat");
            DatFile.Save(launchFile, new Dictionary<string, string> { { "default", executable } });

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

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            new SettingsPage().Spawn(this);
        }

        public void CheckForUpdates()
        {
            throw new NotImplementedException();
        }
    }
}