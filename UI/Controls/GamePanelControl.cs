using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLauncher.Utils;
using IGDB.Models;

namespace GameLauncher
{
    public partial class GamePanelControl : UserControl, ITick
    {
        public LocalGame Game;
        private MainForm originForm;
        private bool stillLoading = true;
        public GamePanelControl(MainForm originForm, LocalGame game)
        {
            this.originForm = originForm;
            this.Game = game;
            this.InitializeComponent();
        }

        private void GamePanelControl_Load(object sender, EventArgs e)
        {
            // Fixes transparency issues
            this.NameLabel.Parent = this.CoverImageBox;
            this.MoreButton.Parent = this.CoverImageBox;
            this.PlayButton.Parent = this.CoverImageBox;

            this.Game.LoadOrDownloadResourcesAsync(() =>
            {
                this.stillLoading = false;

                this.Invoke(() =>
                {
                    this.UpdateStartButton();
                    this.UpdateUICover();

                    this.originForm.TaskCompleted();
                });
            });

            this.UpdateStartButton();
        }

        public void UpdateUICover()
        {
            if (this.Game.HasCover)
                this.CoverImageBox.ImageLocation = this.Game.CoverPath;
            else 
                this.CoverImageBox.Image = ResourceStore.ErrorImage;
        }

        private void All_MouseLeave(object sender, EventArgs e)
        {
            this.UpdatePos();
        }

        private void All_MouseEnter(object sender, EventArgs e)
        {
            this.UpdatePos();
        }

        private void UpdatePos()
        {
            if (this.stillLoading) return;

            bool inside = this.MouseIsOverControl(this);
            this.PlayButton.Visible = inside;
            this.MoreButton.Visible = inside;
        }

        private bool MouseIsOverControl(Control ctrl) => ctrl.ClientRectangle.Contains(ctrl.PointToClient(Cursor.Position));

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (!this.Game.IsRunning) this.Game.Launch();

            this.UpdateStartButton();
        }

        private void MoreButton_Click(object sender, EventArgs e)
        {
            if (this.stillLoading) return;

            new GameDetailsControl(this.Game).Spawn(this.ParentForm!);
        }

        private void UpdateStartButton()
        {
            this.PlayButton.Text = this.Game.IsRunning ? "Running" : "Play";
            this.PlayButton.ForeColor = this.Game.IsRunning ? Color.Green : Color.Black;
            this.PlayButton.Enabled = !this.Game.IsRunning;
            if (this.stillLoading) this.PlayButton.Enabled = false;
        }
        public void Tick() => this.UpdateStartButton();
    }
}
