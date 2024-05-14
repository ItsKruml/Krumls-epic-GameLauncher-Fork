namespace GameLauncher
{
    partial class GameDetailsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameDetailsPage));
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
            forgetToolStripMenuItem = new ToolStripMenuItem();
            uninstallToolStripMenuItem = new ToolStripMenuItem();
            this.paletteExtenderProvider1 = new Models.PaletteExtenderProvider();
            ((System.ComponentModel.ISupportInitialize)ThumnailImageBox).BeginInit();
            MoreMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ThumnailImageBox
            // 
            ThumnailImageBox.Location = new Point(45, 47);
            ThumnailImageBox.Margin = new Padding(6);
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
            PlayButton.BackColor = Color.FromArgb(142, 122, 181);
            PlayButton.FlatAppearance.BorderSize = 0;
            PlayButton.FlatStyle = FlatStyle.Flat;
            PlayButton.Location = new Point(464, 521);
            PlayButton.Margin = new Padding(6);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(230, 68);
            PlayButton.TabIndex = 3;
            PlayButton.Text = "Play";
            PlayButton.UseVisualStyleBackColor = false;
            PlayButton.ForeColor = Color.WhiteSmoke;
            PlayButton.Click += this.PlayButton_Click;
            // 
            // ExpandButton
            // 
            ExpandButton.BackColor = Color.FromArgb(47, 51, 58);
            ExpandButton.BackgroundImage = (Image)resources.GetObject("ExpandButton.BackgroundImage");
            ExpandButton.BackgroundImageLayout = ImageLayout.Zoom;
            ExpandButton.FlatAppearance.BorderSize = 0;
            ExpandButton.FlatStyle = FlatStyle.Flat;
            ExpandButton.Location = new Point(706, 521);
            ExpandButton.Margin = new Padding(6);
            ExpandButton.Name = "ExpandButton";
            ExpandButton.Size = new Size(50, 68);
            ExpandButton.TabIndex = 4;
            ExpandButton.UseVisualStyleBackColor = false;
            ExpandButton.Click += this.ExpandButton_Click;
            // 
            // MoreMenuStrip
            // 
            MoreMenuStrip.ImageScalingSize = new Size(32, 32);
            MoreMenuStrip.Items.AddRange(new ToolStripItem[] { playToolStripMenuItem, manageToolStripMenuItem });
            MoreMenuStrip.Name = "contextMenuStrip1";
            MoreMenuStrip.Size = new Size(176, 80);
            // 
            // playToolStripMenuItem
            // 
            playToolStripMenuItem.Name = "playToolStripMenuItem";
            playToolStripMenuItem.Size = new Size(175, 38);
            playToolStripMenuItem.Text = "Play";
            // 
            // manageToolStripMenuItem
            // 
            manageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { overrideMetadataToolStripMenuItem, refreshMetadataToolStripMenuItem, openInExplorerToolStripMenuItem, toolStripSeparator1, forgetToolStripMenuItem, uninstallToolStripMenuItem });
            manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            manageToolStripMenuItem.Size = new Size(175, 38);
            manageToolStripMenuItem.Text = "Manage";
            // 
            // overrideMetadataToolStripMenuItem
            // 
            overrideMetadataToolStripMenuItem.Name = "overrideMetadataToolStripMenuItem";
            overrideMetadataToolStripMenuItem.Size = new Size(346, 44);
            overrideMetadataToolStripMenuItem.Text = "Override metadata";
            overrideMetadataToolStripMenuItem.Click += this.overrideMetadataToolStripMenuItem_Click;
            // 
            // refreshMetadataToolStripMenuItem
            // 
            refreshMetadataToolStripMenuItem.Name = "refreshMetadataToolStripMenuItem";
            refreshMetadataToolStripMenuItem.Size = new Size(346, 44);
            refreshMetadataToolStripMenuItem.Text = "Refresh metadata";
            refreshMetadataToolStripMenuItem.Click += this.refreshMetadataToolStripMenuItem_Click;
            // 
            // openInExplorerToolStripMenuItem
            // 
            openInExplorerToolStripMenuItem.Name = "openInExplorerToolStripMenuItem";
            openInExplorerToolStripMenuItem.Size = new Size(346, 44);
            openInExplorerToolStripMenuItem.Text = "Open in explorer";
            openInExplorerToolStripMenuItem.Click += this.openInExplorerToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(343, 6);
            // 
            // forgetToolStripMenuItem
            // 
            forgetToolStripMenuItem.Name = "forgetToolStripMenuItem";
            forgetToolStripMenuItem.Size = new Size(346, 44);
            forgetToolStripMenuItem.Text = "Forget";
            forgetToolStripMenuItem.Click += this.forgetToolStripMenuItem_Click;
            // 
            // uninstallToolStripMenuItem
            // 
            uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
            uninstallToolStripMenuItem.Size = new Size(346, 44);
            uninstallToolStripMenuItem.Text = "Uninstall";
            uninstallToolStripMenuItem.Click += this.uninstallToolStripMenuItem_Click;
            // 
            // GameDetailsControl
            // 
            this.AutoScaleDimensions = new SizeF(13F, 32F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(36, 39, 45);
            this.Controls.Add(ExpandButton);
            this.Controls.Add(PlayButton);
            this.Controls.Add(DescriptionLabel);
            this.Controls.Add(TitleLabel);
            this.Controls.Add(ThumnailImageBox);
            this.ForeColor = Color.WhiteSmoke;
            this.Margin = new Padding(6);
            this.Name = "GameDetailsPage";
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
        private ToolStripMenuItem overrideMetadataToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem forgetToolStripMenuItem;
        private Models.PaletteExtenderProvider paletteExtenderProvider1;
    }
}
