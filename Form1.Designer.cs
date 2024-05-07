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
            flowLayoutPanel1 = new FlowLayoutPanel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            gamesToolStripMenuItem = new ToolStripMenuItem();
            changeScanDirectoryToolStripMenuItem = new ToolStripMenuItem();
            purgeAllMetadataToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 24);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(899, 431);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, gamesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(899, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // gamesToolStripMenuItem
            // 
            gamesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changeScanDirectoryToolStripMenuItem, purgeAllMetadataToolStripMenuItem });
            gamesToolStripMenuItem.Name = "gamesToolStripMenuItem";
            gamesToolStripMenuItem.Size = new Size(55, 20);
            gamesToolStripMenuItem.Text = "Games";
            // 
            // changeScanDirectoryToolStripMenuItem
            // 
            changeScanDirectoryToolStripMenuItem.Name = "changeScanDirectoryToolStripMenuItem";
            changeScanDirectoryToolStripMenuItem.Size = new Size(192, 22);
            changeScanDirectoryToolStripMenuItem.Text = "Change scan directory";
            // 
            // purgeAllMetadataToolStripMenuItem
            // 
            purgeAllMetadataToolStripMenuItem.Name = "purgeAllMetadataToolStripMenuItem";
            purgeAllMetadataToolStripMenuItem.Size = new Size(192, 22);
            purgeAllMetadataToolStripMenuItem.Text = "Purge all metadata";
            purgeAllMetadataToolStripMenuItem.Click += this.purgeAllMetadataToolStripMenuItem_Click;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(899, 455);
            this.Controls.Add(flowLayoutPanel1);
            this.Controls.Add(menuStrip1);
            this.MainMenuStrip = menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += this.Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem gamesToolStripMenuItem;
        private ToolStripMenuItem changeScanDirectoryToolStripMenuItem;
        private ToolStripMenuItem purgeAllMetadataToolStripMenuItem;
    }
}