namespace GameLauncher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            flowLayoutPanel1 = new FlowLayoutPanel();
            contextMenuStrip1 = new ContextMenuStrip(this.components);
            addManuallyToolStripMenuItem = new ToolStripMenuItem();
            purgeAllMetadataToolStripMenuItem = new ToolStripMenuItem();
            this.TickTimer = new System.Windows.Forms.Timer(this.components);
            LoadingProgressBar = new ProgressBar();
            panel1 = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            HomeNavLabel = new Label();
            DetailNavLabel = new Label();
            SettingNavLabel = new Label();
            this.paletteExtenderProvider1 = new Models.PaletteExtenderProvider();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.ContextMenuStrip = contextMenuStrip1;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 85);
            flowLayoutPanel1.Margin = new Padding(6);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1554, 1020);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { addManuallyToolStripMenuItem, purgeAllMetadataToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(289, 80);
            // 
            // addManuallyToolStripMenuItem
            // 
            addManuallyToolStripMenuItem.Name = "addManuallyToolStripMenuItem";
            addManuallyToolStripMenuItem.Size = new Size(288, 38);
            addManuallyToolStripMenuItem.Text = "Add manually";
            addManuallyToolStripMenuItem.Click += this.addManuallyToolStripMenuItem_Click;
            // 
            // purgeAllMetadataToolStripMenuItem
            // 
            purgeAllMetadataToolStripMenuItem.Name = "purgeAllMetadataToolStripMenuItem";
            purgeAllMetadataToolStripMenuItem.Size = new Size(288, 38);
            purgeAllMetadataToolStripMenuItem.Text = "Purge all metadata";
            purgeAllMetadataToolStripMenuItem.Click += this.purgeAllMetadataToolStripMenuItem_Click;
            // 
            // TickTimer
            // 
            this.TickTimer.Enabled = true;
            this.TickTimer.Interval = 1000;
            this.TickTimer.Tick += this.TickTimer_Tick;
            // 
            // LoadingProgressBar
            // 
            LoadingProgressBar.BackColor = Color.White;
            LoadingProgressBar.Dock = DockStyle.Bottom;
            LoadingProgressBar.Location = new Point(0, 1105);
            LoadingProgressBar.Margin = new Padding(6);
            LoadingProgressBar.Name = "LoadingProgressBar";
            LoadingProgressBar.Size = new Size(1554, 49);
            LoadingProgressBar.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(47, 51, 58);
            panel1.Controls.Add(flowLayoutPanel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1554, 85);
            panel1.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(HomeNavLabel);
            flowLayoutPanel2.Controls.Add(DetailNavLabel);
            flowLayoutPanel2.Controls.Add(SettingNavLabel);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(10, 17, 0, 0);
            flowLayoutPanel2.Size = new Size(1554, 85);
            flowLayoutPanel2.TabIndex = 3;
            // 
            // HomeNavLabel
            // 
            HomeNavLabel.AutoSize = true;
            HomeNavLabel.Cursor = Cursors.Hand;
            HomeNavLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            HomeNavLabel.ForeColor = Color.FromArgb(142, 122, 181);
            HomeNavLabel.Location = new Point(30, 17);
            HomeNavLabel.Margin = new Padding(20, 0, 20, 0);
            HomeNavLabel.Name = "HomeNavLabel";
            HomeNavLabel.Size = new Size(107, 45);
            HomeNavLabel.TabIndex = 0;
            HomeNavLabel.Text = "Home";
            HomeNavLabel.Click += this.HomeNavLabel_Click;
            // 
            // DetailNavLabel
            // 
            DetailNavLabel.AutoSize = true;
            DetailNavLabel.Cursor = Cursors.Hand;
            DetailNavLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DetailNavLabel.Location = new Point(177, 17);
            DetailNavLabel.Margin = new Padding(20, 0, 20, 0);
            DetailNavLabel.Name = "DetailNavLabel";
            DetailNavLabel.Size = new Size(116, 45);
            DetailNavLabel.TabIndex = 2;
            DetailNavLabel.Text = "Details";
            DetailNavLabel.Click += this.DetailNavLabel_Click;
            // 
            // SettingNavLabel
            // 
            SettingNavLabel.AutoSize = true;
            SettingNavLabel.Cursor = Cursors.Hand;
            SettingNavLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SettingNavLabel.Location = new Point(333, 17);
            SettingNavLabel.Margin = new Padding(20, 0, 20, 0);
            SettingNavLabel.Name = "SettingNavLabel";
            SettingNavLabel.Size = new Size(135, 45);
            SettingNavLabel.TabIndex = 1;
            SettingNavLabel.Text = "Settings";
            SettingNavLabel.Click += this.SettingNavLabel_Click;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(13F, 32F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(36, 39, 45);
            this.ClientSize = new Size(1554, 1154);
            this.Controls.Add(flowLayoutPanel1);
            this.Controls.Add(LoadingProgressBar);
            this.Controls.Add(panel1);
            this.ForeColor = Color.WhiteSmoke;
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Margin = new Padding(6);
            this.MinimumSize = new Size(1580, 1225);
            this.Name = "MainForm";
            this.Text = "Game Launcher";
            this.FormClosed += this.Form1_FormClosed;
            this.Load += this.Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem purgeAllMetadataToolStripMenuItem;
        private ToolStripMenuItem addManuallyToolStripMenuItem;
        private System.Windows.Forms.Timer TickTimer;
        private ProgressBar LoadingProgressBar;
        private Panel panel1;
        private Label HomeNavLabel;
        private Label SettingNavLabel;
        private Label DetailNavLabel;
        private FlowLayoutPanel flowLayoutPanel2;
        private Models.PaletteExtenderProvider paletteExtenderProvider1;
    }
}