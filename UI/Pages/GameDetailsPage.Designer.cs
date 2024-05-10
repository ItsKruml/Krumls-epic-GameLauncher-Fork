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
            overrideMetadataToolStripMenuItem = new ToolStripMenuItem();
            refreshMetadataToolStripMenuItem = new ToolStripMenuItem();
            openInExplorerToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            uninstallToolStripMenuItem = new ToolStripMenuItem();
            BackButton = new Button();
            forgetToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)ThumnailImageBox).BeginInit();
            MoreMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ThumnailImageBox
            // 
            ThumnailImageBox.Location = new Point(45, 47);
            ThumnailImageBox.Margin = new Padding(6, 6, 6, 6);
            ThumnailImageBox.Name = "ThumnailImageBox";
            ThumnailImageBox.Size = new Size(368, 563);
            ThumnailImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ThumnailImageBox.TabIndex = 0;
            ThumnailImageBox.TabStop = false;
            // 
            // TitleLabel
            // 
            TitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TitleLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            TitleLabel.Location = new Point(457, 102);
            TitleLabel.Margin = new Padding(6, 0, 6, 0);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(758, 102);
            TitleLabel.TabIndex = 1;
            TitleLabel.Text = "label1";
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DescriptionLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DescriptionLabel.Location = new Point(464, 205);
            DescriptionLabel.Margin = new Padding(6, 0, 6, 0);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(758, 309);
            DescriptionLabel.TabIndex = 2;
            DescriptionLabel.Text = "label2";
            // 
            // PlayButton
            // 
            PlayButton.Location = new Point(464, 521);
            PlayButton.Margin = new Padding(6, 6, 6, 6);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(230, 68);
            PlayButton.TabIndex = 3;
            PlayButton.Text = "Play";
            PlayButton.UseVisualStyleBackColor = true;
            PlayButton.Click += this.PlayButton_Click;
            // 
            // ExpandButton
            // 
            ExpandButton.BackgroundImage = (Image)resources.GetObject("ExpandButton.BackgroundImage");
            ExpandButton.BackgroundImageLayout = ImageLayout.Zoom;
            ExpandButton.Location = new Point(706, 521);
            ExpandButton.Margin = new Padding(6, 6, 6, 6);
            ExpandButton.Name = "ExpandButton";
            ExpandButton.Size = new Size(50, 68);
            ExpandButton.TabIndex = 4;
            ExpandButton.UseVisualStyleBackColor = true;
            ExpandButton.Click += this.ExpandButton_Click;
            // 
            // MoreMenuStrip
            // 
            MoreMenuStrip.ImageScalingSize = new Size(32, 32);
            MoreMenuStrip.Items.AddRange(new ToolStripItem[] { playToolStripMenuItem, manageToolStripMenuItem });
            MoreMenuStrip.Name = "contextMenuStrip1";
            MoreMenuStrip.Size = new Size(301, 124);
            // 
            // playToolStripMenuItem
            // 
            playToolStripMenuItem.Name = "playToolStripMenuItem";
            playToolStripMenuItem.Size = new Size(300, 38);
            playToolStripMenuItem.Text = "Play";
            // 
            // manageToolStripMenuItem
            // 
            manageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { overrideMetadataToolStripMenuItem, refreshMetadataToolStripMenuItem, openInExplorerToolStripMenuItem, toolStripSeparator1, forgetToolStripMenuItem, uninstallToolStripMenuItem });
            manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            manageToolStripMenuItem.Size = new Size(300, 38);
            manageToolStripMenuItem.Text = "Manage";
            // 
            // overrideMetadataToolStripMenuItem
            // 
            overrideMetadataToolStripMenuItem.Name = "overrideMetadataToolStripMenuItem";
            overrideMetadataToolStripMenuItem.Size = new Size(359, 44);
            overrideMetadataToolStripMenuItem.Text = "Override metadata";
            overrideMetadataToolStripMenuItem.Click += this.overrideMetadataToolStripMenuItem_Click;
            // 
            // refreshMetadataToolStripMenuItem
            // 
            refreshMetadataToolStripMenuItem.Name = "refreshMetadataToolStripMenuItem";
            refreshMetadataToolStripMenuItem.Size = new Size(359, 44);
            refreshMetadataToolStripMenuItem.Text = "Refresh metadata";
            refreshMetadataToolStripMenuItem.Click += this.refreshMetadataToolStripMenuItem_Click;
            // 
            // openInExplorerToolStripMenuItem
            // 
            openInExplorerToolStripMenuItem.Name = "openInExplorerToolStripMenuItem";
            openInExplorerToolStripMenuItem.Size = new Size(359, 44);
            openInExplorerToolStripMenuItem.Text = "Open in explorer";
            openInExplorerToolStripMenuItem.Click += this.openInExplorerToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(356, 6);
            // 
            // uninstallToolStripMenuItem
            // 
            uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
            uninstallToolStripMenuItem.Size = new Size(359, 44);
            uninstallToolStripMenuItem.Text = "Uninstall";
            uninstallToolStripMenuItem.Click += this.uninstallToolStripMenuItem_Click;
            // 
            // BackButton
            // 
            BackButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BackButton.Location = new Point(1124, 28);
            BackButton.Margin = new Padding(6, 6, 6, 6);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(139, 49);
            BackButton.TabIndex = 5;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += this.BackButton_Click;
            // 
            // forgetToolStripMenuItem
            // 
            forgetToolStripMenuItem.Name = "forgetToolStripMenuItem";
            forgetToolStripMenuItem.Size = new Size(359, 44);
            forgetToolStripMenuItem.Text = "Forget";
            forgetToolStripMenuItem.Click += this.forgetToolStripMenuItem_Click;
            // 
            // GameDetailsControl
            // 
            this.AutoScaleDimensions = new SizeF(13F, 32F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(BackButton);
            this.Controls.Add(ExpandButton);
            this.Controls.Add(PlayButton);
            this.Controls.Add(DescriptionLabel);
            this.Controls.Add(TitleLabel);
            this.Controls.Add(ThumnailImageBox);
            this.Margin = new Padding(6, 6, 6, 6);
            this.Name = "GameDetailsControl";
            this.Size = new Size(1300, 681);
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
        private ToolStripMenuItem overrideMetadataToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem forgetToolStripMenuItem;
    }
}
