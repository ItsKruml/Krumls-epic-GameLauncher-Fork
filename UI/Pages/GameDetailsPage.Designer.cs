namespace GameLauncher
{
    partial class GameDetailsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameDetailsControl));
            ThumnailImageBox = new PictureBox();
            TitleLabel = new Label();
            DescriptionLabel = new Label();
            PlayButton = new Button();
            ExpandButton = new Button();
            MoreMenuStrip = new ContextMenuStrip(this.components);
            playToolStripMenuItem = new ToolStripMenuItem();
            manageToolStripMenuItem = new ToolStripMenuItem();
            uninstallToolStripMenuItem = new ToolStripMenuItem();
            refreshMetadataToolStripMenuItem = new ToolStripMenuItem();
            openInExplorerToolStripMenuItem = new ToolStripMenuItem();
            BackButton = new Button();
            ((System.ComponentModel.ISupportInitialize)ThumnailImageBox).BeginInit();
            MoreMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ThumnailImageBox
            // 
            ThumnailImageBox.Location = new Point(24, 22);
            ThumnailImageBox.Name = "ThumnailImageBox";
            ThumnailImageBox.Size = new Size(198, 264);
            ThumnailImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ThumnailImageBox.TabIndex = 0;
            ThumnailImageBox.TabStop = false;
            // 
            // TitleLabel
            // 
            TitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TitleLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            TitleLabel.Location = new Point(246, 48);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(408, 48);
            TitleLabel.TabIndex = 1;
            TitleLabel.Text = "label1";
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DescriptionLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DescriptionLabel.Location = new Point(250, 96);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(408, 145);
            DescriptionLabel.TabIndex = 2;
            DescriptionLabel.Text = "label2";
            // 
            // PlayButton
            // 
            PlayButton.Location = new Point(250, 244);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(124, 32);
            PlayButton.TabIndex = 3;
            PlayButton.Text = "Play";
            PlayButton.UseVisualStyleBackColor = true;
            PlayButton.Click += this.PlayButton_Click;
            // 
            // ExpandButton
            // 
            ExpandButton.BackgroundImage = (Image)resources.GetObject("ExpandButton.BackgroundImage");
            ExpandButton.BackgroundImageLayout = ImageLayout.Zoom;
            ExpandButton.Location = new Point(380, 244);
            ExpandButton.Name = "ExpandButton";
            ExpandButton.Size = new Size(27, 32);
            ExpandButton.TabIndex = 4;
            ExpandButton.UseVisualStyleBackColor = true;
            ExpandButton.Click += this.ExpandButton_Click;
            // 
            // MoreMenuStrip
            // 
            MoreMenuStrip.Items.AddRange(new ToolStripItem[] { playToolStripMenuItem, manageToolStripMenuItem });
            MoreMenuStrip.Name = "contextMenuStrip1";
            MoreMenuStrip.Size = new Size(118, 48);
            // 
            // playToolStripMenuItem
            // 
            playToolStripMenuItem.Name = "playToolStripMenuItem";
            playToolStripMenuItem.Size = new Size(117, 22);
            playToolStripMenuItem.Text = "Play";
            // 
            // manageToolStripMenuItem
            // 
            manageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { uninstallToolStripMenuItem, refreshMetadataToolStripMenuItem, openInExplorerToolStripMenuItem });
            manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            manageToolStripMenuItem.Size = new Size(117, 22);
            manageToolStripMenuItem.Text = "Manage";
            // 
            // uninstallToolStripMenuItem
            // 
            uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
            uninstallToolStripMenuItem.Size = new Size(166, 22);
            uninstallToolStripMenuItem.Text = "Uninstall";
            // 
            // refreshMetadataToolStripMenuItem
            // 
            refreshMetadataToolStripMenuItem.Name = "refreshMetadataToolStripMenuItem";
            refreshMetadataToolStripMenuItem.Size = new Size(166, 22);
            refreshMetadataToolStripMenuItem.Text = "Refresh metadata";
            refreshMetadataToolStripMenuItem.Click += this.refreshMetadataToolStripMenuItem_Click;
            // 
            // openInExplorerToolStripMenuItem
            // 
            openInExplorerToolStripMenuItem.Name = "openInExplorerToolStripMenuItem";
            openInExplorerToolStripMenuItem.Size = new Size(166, 22);
            openInExplorerToolStripMenuItem.Text = "Open in explorer";
            openInExplorerToolStripMenuItem.Click += this.openInExplorerToolStripMenuItem_Click;
            // 
            // BackButton
            // 
            BackButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BackButton.Location = new Point(605, 13);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(75, 23);
            BackButton.TabIndex = 5;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += this.BackButton_Click;
            // 
            // GameDetailsControl
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(BackButton);
            this.Controls.Add(ExpandButton);
            this.Controls.Add(PlayButton);
            this.Controls.Add(DescriptionLabel);
            this.Controls.Add(TitleLabel);
            this.Controls.Add(ThumnailImageBox);
            this.Name = "GameDetailsControl";
            this.Size = new Size(700, 319);
            this.Load += this.GameDetailsControl_Load;
            ((System.ComponentModel.ISupportInitialize)ThumnailImageBox).EndInit();
            MoreMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private PictureBox ThumnailImageBox;
        private Label TitleLabel;
        private Label DescriptionLabel;
        private Button PlayButton;
        private Button ExpandButton;
        private ContextMenuStrip MoreMenuStrip;
        private ToolStripMenuItem playToolStripMenuItem;
        private ToolStripMenuItem manageToolStripMenuItem;
        private ToolStripMenuItem uninstallToolStripMenuItem;
        private ToolStripMenuItem refreshMetadataToolStripMenuItem;
        private ToolStripMenuItem openInExplorerToolStripMenuItem;
        private Button BackButton;
    }
}
