namespace GameLauncher
{
    partial class GameItemControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameItemControl));
            CoverImageBox = new PictureBox();
            NameLabel = new Label();
            PlayButton = new Button();
            MoreButton = new Button();
            ((System.ComponentModel.ISupportInitialize)CoverImageBox).BeginInit();
            this.SuspendLayout();
            // 
            // CoverImageBox
            // 
            CoverImageBox.Dock = DockStyle.Fill;
            CoverImageBox.Image = (Image)resources.GetObject("CoverImageBox.Image");
            CoverImageBox.Location = new Point(0, 0);
            CoverImageBox.Margin = new Padding(6);
            CoverImageBox.Name = "CoverImageBox";
            CoverImageBox.Size = new Size(368, 563);
            CoverImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            CoverImageBox.TabIndex = 0;
            CoverImageBox.TabStop = false;
            CoverImageBox.Click += this.MoreButton_Click;
            CoverImageBox.MouseEnter += this.All_MouseEnter;
            CoverImageBox.MouseLeave += this.All_MouseLeave;
            // 
            // NameLabel
            // 
            NameLabel.BackColor = Color.Transparent;
            NameLabel.Dock = DockStyle.Top;
            NameLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            NameLabel.Location = new Point(0, 0);
            NameLabel.Margin = new Padding(6, 0, 6, 0);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(368, 230);
            NameLabel.TabIndex = 1;
            NameLabel.TextAlign = ContentAlignment.TopCenter;
            NameLabel.Click += this.MoreButton_Click;
            NameLabel.MouseEnter += this.All_MouseEnter;
            NameLabel.MouseLeave += this.All_MouseLeave;
            // 
            // PlayButton
            // 
            PlayButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PlayButton.BackColor = Color.FromArgb(142, 122, 181);
            PlayButton.FlatAppearance.BorderSize = 0;
            PlayButton.FlatStyle = FlatStyle.Flat;
            PlayButton.ForeColor = Color.WhiteSmoke;
            PlayButton.Location = new Point(223, 508);
            PlayButton.Margin = new Padding(6);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(139, 49);
            PlayButton.TabIndex = 2;
            PlayButton.Text = "Play";
            PlayButton.UseVisualStyleBackColor = false;
            PlayButton.Visible = false;
            PlayButton.Click += this.PlayButton_Click;
            PlayButton.MouseEnter += this.All_MouseEnter;
            PlayButton.MouseLeave += this.All_MouseLeave;
            // 
            // MoreButton
            // 
            MoreButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            MoreButton.BackColor = Color.FromArgb(73, 80, 92);
            MoreButton.FlatAppearance.BorderSize = 0;
            MoreButton.FlatStyle = FlatStyle.Flat;
            MoreButton.ForeColor = Color.WhiteSmoke;
            MoreButton.Location = new Point(154, 508);
            MoreButton.Margin = new Padding(6);
            MoreButton.Name = "MoreButton";
            MoreButton.Size = new Size(58, 49);
            MoreButton.TabIndex = 3;
            MoreButton.Text = "...";
            MoreButton.UseVisualStyleBackColor = false;
            MoreButton.Visible = false;
            MoreButton.Click += this.MoreButton_Click;
            MoreButton.MouseEnter += this.All_MouseEnter;
            MoreButton.MouseLeave += this.All_MouseLeave;
            // 
            // GamePanelControl
            // 
            this.AutoScaleDimensions = new SizeF(13F, 32F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.Controls.Add(MoreButton);
            this.Controls.Add(PlayButton);
            this.Controls.Add(NameLabel);
            this.Controls.Add(CoverImageBox);
            this.Margin = new Padding(6);
            this.Name = "GameItemControl";
            this.Size = new Size(368, 563);
            this.Load += this.GamePanelControl_Load;
            ((System.ComponentModel.ISupportInitialize)CoverImageBox).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private PictureBox CoverImageBox;
        private Label NameLabel;
        private Button PlayButton;
        private Button MoreButton;
    }
}
