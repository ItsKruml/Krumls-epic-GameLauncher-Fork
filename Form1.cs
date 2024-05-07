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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadGames();
        }

        private void LoadGames()
        {
            Games = LocalGame.GetLocalGames(ScanDir);
            foreach (LocalGame game in Games)
            {
                GamePanelControl gpc = new(game);
                flowLayoutPanel1.Controls.Add(gpc);
            }
        }

        private void purgeAllMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (LocalGame game in Games!)
                if (game.HasResources())
                    game.DeleteResources();

            flowLayoutPanel1.Controls.Clear();

            LoadGames();
        }
    }
}