using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLauncher.UI.Forms;
using GameLauncher.Utils;

namespace GameLauncher
{
    public partial class GameDetailsPage : UserControl, ITick
    {
        public MainForm originForm;
        private LocalGame game;
        public GameDetailsPage(LocalGame game)
        {
            this.game = game;
            this.InitializeComponent();
        }

        private void ExpandButton_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerRight = new(btnSender.Width - this.MoreMenuStrip.Width, btnSender.Height);
            ptLowerRight = btnSender.PointToScreen(ptLowerRight);
            this.MoreMenuStrip.Show(ptLowerRight);
        }

        private void GameDetailsControl_Load(object sender, EventArgs e)
        {
            this.originForm = (this.ParentForm as MainForm)!;

            this.UpdateUIFromMetadata();

            foreach (string profile in this.game.LaunchNames) this.playToolStripMenuItem.DropDownItems.Add(new ToolStripLabel(profile));

            foreach (ToolStripLabel item in this.playToolStripMenuItem.DropDownItems)
                item.Click += this.Item_Click;

            this.UpdateStartButton();
        }

        private void UpdateUIFromMetadata()
        {
            this.TitleLabel.Text = this.game.Name;
            this.DescriptionLabel.Text = this.game.Summary ?? "No description available";
            if (this.game.HasCover)
                this.ThumnailImageBox.ImageLocation = this.game.CoverPath;
            else
                this.ThumnailImageBox.Image = ResourceStore.ErrorImage;

            this.originForm.GetPanel(this.game).UpdateUICover();
        }

        private void Item_Click(object? sender, EventArgs e)
        {
            // Determine which subitem was pressed and use it as the launch name
            ToolStripLabel senderObj = (ToolStripLabel)sender!;
            this.game.Launch(senderObj.Text);
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (!this.game.IsRunning)
                this.game.Launch();
            else
                this.game.Kill();

            this.UpdateStartButton();
        }

        private void Close()
        {
            this.originForm.Nav_Click(MainForm.NavPage.Home);
        }

        private void openInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", this.game.GamePath);
        }

        private void refreshMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RefreshMetadata();
        }

        private void RefreshMetadata()
        {
            if (this.game.HasResources()) this.game.DeleteResources();

            this.game.LoadOrDownloadResourcesAsync(() =>
            {
                this.Invoke(this.UpdateUIFromMetadata);

                MessageBox.Show("Refreshed game metadata", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void UpdateStartButton()
        {
            this.PlayButton.Text = this.game.IsRunning ? "Stop" : "Play";
            this.PlayButton.ForeColor = this.game.IsRunning ? Color.Red : Color.Black;
        }

        public void Tick() => this.UpdateStartButton();

        private void uninstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to uninstall this game? (Its files will be PERMANENTLY deleted)", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            GameItemControl item = this.originForm.GetPanel(this.game);
            item.Parent!.Controls.Remove(item);

            this.game.Uninstall();

            this.Close();
        }

        private void overrideMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MetadataOverrideForm.OverrideMetadata(this.game))
            {
                this.RefreshMetadata();
                this.UpdateUIFromMetadata();
            }
        }

        private void forgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to forget this game?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            GameItemControl item = this.originForm.GetPanel(this.game);
            item.Parent!.Controls.Remove(item);

            this.game.Forget();

            this.Close();
        }
    }
}
