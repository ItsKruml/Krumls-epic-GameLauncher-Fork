using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using IGDB.Models;

namespace GameLauncher
{
    public partial class Form1 : Form
    {
        public static string ScanDir = "D:/NonSteamLibrary";
        private static LocalGame[]? Games;

        private static Thread? ProcessMonitorThread;

        public Form1()
        {
            InitializeComponent();

            ProcessMonitorThread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    Process[] processes = Process.GetProcesses();

                    foreach (LocalGame game in Games)
                        game.ScanForExistingProcess(processes);
                }
            });

            ProcessMonitorThread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadGames();
        }

        private void LoadGames()
        {
            flowLayoutPanel1.Controls.Clear();

            Games = LocalGame.GetLocalGames(ScanDir);

            LoadingProgressBar.Visible = true;
            LoadingProgressBar.Value = 0;
            LoadingProgressBar.Maximum = Games.Length;

            foreach (LocalGame game in Games)
            {
                GamePanelControl gpc = new(this, game);
                flowLayoutPanel1.Controls.Add(gpc);
            }
        }

        private void purgeAllMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (LocalGame game in Games!)
                if (game.HasResources())
                    game.DeleteResources();

            LoadGames();
        }

        private void addManuallyToolStripMenuItem_Click(object sender, EventArgs e)
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

            MessageBox.Show("Game successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadGames();
        }

        public void TaskCompleted()
        {
            if (!this.LoadingProgressBar.Visible) return;

            this.LoadingProgressBar.Value++;
            if (this.LoadingProgressBar.Value >= this.LoadingProgressBar.Maximum) this.LoadingProgressBar.Visible = false;
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            foreach (ITick item in GetAllTickables(this))
                item.Tick();
        }

        private IEnumerable<Control> GetAllTickables(Control parent)
        {
            var controls = parent.Controls.Cast<Control>();

            return controls.SelectMany(GetAllTickables)
                                      .Concat(controls)
                                      .Where(x => x is ITick);
        }
    }
}