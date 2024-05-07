using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using IGDB.Models;

namespace GameLauncher
{
    public partial class Form1 : Form
    {
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
            string[] games = Management.GetGames();
            foreach (string game in games)
            {
                GamePanelControl gpc = new(game);
                flowLayoutPanel1.Controls.Add(gpc);
            }
        }

        private void purgeAllMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] games = Management.GetGames();
            foreach (string game in games)
                if (Management.HasResources(game))
                    Management.DeleteResources(game);

            flowLayoutPanel1.Controls.Clear();

            LoadGames();
        }
    }
}