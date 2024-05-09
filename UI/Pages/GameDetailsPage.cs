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
    public partial class GameDetailsControl : UserControl, ITick
    {
        public Form1? MainForm;
        private LocalGame game;
        public GameDetailsControl(LocalGame game)
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
            this.MainForm = (this.ParentForm as Form1)!;
            
            this.UpdateUIFromMetadata();

            foreach (string profile in this.game.LaunchNames) this.playToolStripMenuItem.DropDownItems.Add(new ToolStripLabel(profile));

            foreach (ToolStripLabel item in this.playToolStripMenuItem.DropDownItems)
                item.Click += this.Item_Click;

            this.UpdateStartButton();
        }

        private void UpdateUIFromMetadata()
        {
            this.TitleLabel.Text = this.game.Name ?? Path.GetFileName(game.GamePath);
            this.DescriptionLabel.Text = this.game.Summary ?? "No description available";
            if (this.game.HasCover)
                this.ThumnailImageBox.ImageLocation = this.game.CoverPath;
            else 
                this.ThumnailImageBox.Image = ResourceStore.ErrorImage;
            
            this.MainForm.GetPanel(this.game).UpdateUICover();
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

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Parent!.Controls.Remove(this);
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
            game.Uninstall();
        }

        private void overrideMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IGDBSearchResultsForm form = new(Path.GetFileName(this.game.GamePath));
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK && form.SelectedGame != null)
            {
                string dir = Path.GetDirectoryName(this.game.GamePath);
                string name = Path.GetFileName(this.game.GamePath); 
                name = Regex.Replace(name, @"\[(\d+)\]", "");
                name = $"{name.TrimEnd()} [{form.SelectedGame.Id}]";
                
                string newPath = Path.Join(dir, name);
                Directory.Move(this.game.GamePath, newPath);
                this.game.GamePath = newPath;
                    
                this.RefreshMetadata();
                this.UpdateUIFromMetadata();
            }
        }
    }
}
