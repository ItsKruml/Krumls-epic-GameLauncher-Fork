namespace GameLauncher.UI.Controls
{
    partial class NotifyControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyControl));
            CloseButton = new Button();
            TextLabel = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.BackgroundImage = (Image)resources.GetObject("CloseButton.BackgroundImage");
            CloseButton.BackgroundImageLayout = ImageLayout.Zoom;
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.Location = new Point(1504, 25);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(50, 50);
            CloseButton.TabIndex = 0;
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // TextLabel
            // 
            TextLabel.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            TextLabel.Location = new Point(124, 25);
            TextLabel.Name = "TextLabel";
            TextLabel.Size = new Size(1271, 47);
            TextLabel.TabIndex = 1;
            TextLabel.Text = "A notification nya nya";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(19, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(75, 75);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // NotifyControl
            // 
            this.AutoScaleDimensions = new SizeF(13F, 32F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(23, 25, 28);
            this.Controls.Add(pictureBox1);
            this.Controls.Add(TextLabel);
            this.Controls.Add(CloseButton);
            this.ForeColor = Color.WhiteSmoke;
            this.Name = "NotifyControl";
            this.Size = new Size(1580, 100);
            this.Load += this.NotifyControl_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Button CloseButton;
        private Label TextLabel;
        private PictureBox pictureBox1;
    }
}
