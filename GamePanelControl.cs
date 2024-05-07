using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IGDB.Models;

namespace GameLauncher
{
    public partial class GamePanelControl : UserControl
    {
        public string GamePath;
        public GamePanelControl(string gamePath)
        {
            this.GamePath = gamePath;
            InitializeComponent();
        }

        private void GamePanelControl_Load(object sender, EventArgs e)
        {
            NameLabel.Parent = CoverImageBox;
            MoreButton.Parent = CoverImageBox;
            PlayButton.Parent = CoverImageBox;

            new Thread(() =>
            {
                if (!Management.HasResources(GamePath))
                {
                    Game? game = Management.IGDBObj.Search(Path.GetFileNameWithoutExtension(GamePath))
                        .FirstOrDefault() ?? throw new Exception("Could not find game in IGDB");
                    Management.DownloadResources(GamePath, game);
                }

                Invoke(() =>
                {
                    string info = Management.GetResources(GamePath, "info.dat");
                    string cover = Management.GetResources(GamePath, "cover.png");

                    Dictionary<string, string> infoData = Management.ParseDatFile(info);

                    //NameLabel.Text = infoData["name"];
                    CoverImageBox.ImageLocation = Path.GetFullPath(cover);
                });
            })
            { IsBackground = true }.Start();
        }

        private void All_MouseLeave(object sender, EventArgs e)
        {
            UpdatePos();
        }

        private void All_MouseEnter(object sender, EventArgs e)
        {
            UpdatePos();
        }

        public void UpdatePos()
        {
            bool inside = MouseIsOverControl(this);
            PlayButton.Visible = inside;
            MoreButton.Visible = inside;
        }

        private bool MouseIsOverControl(Control ctrl) => ctrl.ClientRectangle.Contains(ctrl.PointToClient(Cursor.Position));

        private void PlayButton_Click(object sender, EventArgs e)
        {
            Management.LaunchGame(GamePath);
        }

        private void MoreButton_Click(object sender, EventArgs e)
        {

        }
    }
}
