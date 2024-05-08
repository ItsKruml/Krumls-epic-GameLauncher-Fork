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
        private Form1 originForm;
        private LocalGame game;
        private bool stillLoading = true;
        public GamePanelControl(Form1 originForm, LocalGame game)
        {
            this.originForm = originForm;
            this.game = game;
            InitializeComponent();
        }

        private void GamePanelControl_Load(object sender, EventArgs e)
        {
            // Fixes transparency issues
            NameLabel.Parent = CoverImageBox;
            MoreButton.Parent = CoverImageBox;
            PlayButton.Parent = CoverImageBox;

            new Thread(() =>
            {
                game.LoadOrDownloadResources();
                stillLoading = false;

                Invoke(() =>
                {
                    UpdateStartButton();
                    CoverImageBox.ImageLocation = game.CoverPath;

                    originForm.TaskCompleted();
                });
            })
            { IsBackground = true }.Start();

            UpdateStartButton();
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
            if (stillLoading) return;

            bool inside = MouseIsOverControl(this);
            PlayButton.Visible = inside;
            MoreButton.Visible = inside;
        }

        private bool MouseIsOverControl(Control ctrl) => ctrl.ClientRectangle.Contains(ctrl.PointToClient(Cursor.Position));

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (!game.IsRunning)
                game.Launch();

            UpdateStartButton();
        }

        private void MoreButton_Click(object sender, EventArgs e)
        {
            if (stillLoading) return;

            GameDetailsControl.Spawn(ParentForm!, game);
        }

        private void UpdateStartButton()
        {
            PlayButton.Text = game.IsRunning ? "Running" : "Play";
            PlayButton.ForeColor = game.IsRunning ? Color.Green : Color.Black;
            PlayButton.Enabled = !game.IsRunning;
            if (stillLoading) PlayButton.Enabled = false;
        }
    }
}
