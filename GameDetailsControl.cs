using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLauncher
{
    public partial class GameDetailsControl : UserControl
    {
        private LocalGame game;
        public GameDetailsControl(LocalGame game)
        {
            this.game = game;
            InitializeComponent();
        }

        private void ExpandButton_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerRight = new(btnSender.Width - MoreMenuStrip.Width, btnSender.Height);
            ptLowerRight = btnSender.PointToScreen(ptLowerRight);
            MoreMenuStrip.Show(ptLowerRight);
        }

        private void GameDetailsControl_Load(object sender, EventArgs e)
        {
            TitleLabel.Text = game.Name;
            DescriptionLabel.Text = game.Summary;
            ThumnailImageBox.ImageLocation = game.CoverPath;

            foreach (string profile in game.LaunchNames)
                playToolStripMenuItem.DropDownItems.Add(new ToolStripLabel(profile));

            foreach (ToolStripLabel item in playToolStripMenuItem.DropDownItems)
                item.Click += this.Item_Click;

            UpdateStartButton();
        }

        private void Item_Click(object? sender, EventArgs e)
        {
            // Determine which subitem was pressed and use it as the launch name
            ToolStripLabel senderObj = (ToolStripLabel)sender!;
            game.Launch(senderObj.Text);
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (!game.IsRunning)
                game.Launch();
            else 
                game.Kill();

            UpdateStartButton();
        }

        public static GameDetailsControl Spawn(Form parent, LocalGame game)
        {
            GameDetailsControl control = new(game);
            control.Dock = DockStyle.Fill;
            control.Parent = parent;
            parent.Controls.Add(control);
            control.BringToFront();

            return control;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Parent!.Controls.Remove(this);
        }

        private void openInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", game.GamePath);
        }

        private void refreshMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (game.HasResources())
                game.DeleteResources();

            game.LoadOrDownloadResources();
        }

        private void UpdateStartButton()
        {
            PlayButton.Text = game.IsRunning ? "Stop" : "Play";
            PlayButton.ForeColor = game.IsRunning ? Color.Red : Color.Black;
        }
    }
}
