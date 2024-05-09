namespace GameLauncher
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            flowLayoutPanel1 = new FlowLayoutPanel();
            contextMenuStrip1 = new ContextMenuStrip(this.components);
            addManuallyToolStripMenuItem = new ToolStripMenuItem();
            purgeAllMetadataToolStripMenuItem = new ToolStripMenuItem();
            this.TickTimer = new System.Windows.Forms.Timer(this.components);
            SettingsButton = new Button();
            LoadingProgressBar = new ProgressBar();
            contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.ContextMenuStrip = contextMenuStrip1;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(782, 406);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { addManuallyToolStripMenuItem, purgeAllMetadataToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(174, 48);
            // 
            // addManuallyToolStripMenuItem
            // 
            addManuallyToolStripMenuItem.Name = "addManuallyToolStripMenuItem";
            addManuallyToolStripMenuItem.Size = new Size(173, 22);
            addManuallyToolStripMenuItem.Text = "Add manually";
            addManuallyToolStripMenuItem.Click += this.addManuallyToolStripMenuItem_Click;
            // 
            // purgeAllMetadataToolStripMenuItem
            // 
            purgeAllMetadataToolStripMenuItem.Name = "purgeAllMetadataToolStripMenuItem";
            purgeAllMetadataToolStripMenuItem.Size = new Size(173, 22);
            purgeAllMetadataToolStripMenuItem.Text = "Purge all metadata";
            purgeAllMetadataToolStripMenuItem.Click += this.purgeAllMetadataToolStripMenuItem_Click;
            // 
            // TickTimer
            // 
            this.TickTimer.Enabled = true;
            this.TickTimer.Interval = 1000;
            this.TickTimer.Tick += this.TickTimer_Tick;
            // 
            // SettingsButton
            // 
            SettingsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SettingsButton.BackgroundImage = (Image)resources.GetObject("SettingsButton.BackgroundImage");
            SettingsButton.BackgroundImageLayout = ImageLayout.Zoom;
            SettingsButton.FlatAppearance.BorderSize = 0;
            SettingsButton.Location = new Point(712, 369);
            SettingsButton.Margin = new Padding(2, 1, 2, 1);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(40, 35);
            SettingsButton.TabIndex = 2;
            SettingsButton.UseVisualStyleBackColor = true;
            SettingsButton.Click += this.SettingsButton_Click;
            // 
            // LoadingProgressBar
            // 
            LoadingProgressBar.Dock = DockStyle.Bottom;
            LoadingProgressBar.Location = new Point(0, 406);
            LoadingProgressBar.Name = "LoadingProgressBar";
            LoadingProgressBar.Size = new Size(782, 23);
            LoadingProgressBar.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(782, 429);
            this.Controls.Add(SettingsButton);
            this.Controls.Add(flowLayoutPanel1);
            this.Controls.Add(LoadingProgressBar);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Name = "Form1";
            this.Text = "Game Launcher";
            this.FormClosed += this.Form1_FormClosed;
            this.Load += this.Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem purgeAllMetadataToolStripMenuItem;
        private ToolStripMenuItem addManuallyToolStripMenuItem;
        private System.Windows.Forms.Timer TickTimer;
        private Button SettingsButton;
        private ProgressBar LoadingProgressBar;
    }
}