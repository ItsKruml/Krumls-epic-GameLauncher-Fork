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
            IconBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)IconBox).BeginInit();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.BackgroundImage = (Image)resources.GetObject("CloseButton.BackgroundImage");
            CloseButton.BackgroundImageLayout = ImageLayout.Zoom;
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.Location = new Point(810, 12);
            CloseButton.Margin = new Padding(2, 1, 2, 1);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(27, 23);
            CloseButton.TabIndex = 0;
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += this.CloseButton_Click;
            // 
            // TextLabel
            // 
            TextLabel.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            TextLabel.Location = new Point(49, 10);
            TextLabel.Margin = new Padding(2, 0, 2, 0);
            TextLabel.Name = "TextLabel";
            TextLabel.Size = new Size(702, 35);
            TextLabel.TabIndex = 1;
            TextLabel.Text = "A notification nya nya";
            // 
            // IconBox
            // 
            IconBox.Location = new Point(10, 6);
            IconBox.Margin = new Padding(2, 1, 2, 1);
            IconBox.Name = "IconBox";
            IconBox.Size = new Size(35, 35);
            IconBox.SizeMode = PictureBoxSizeMode.Zoom;
            IconBox.TabIndex = 2;
            IconBox.TabStop = false;
            // 
            // NotifyControl
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(23, 25, 28);
            this.Controls.Add(IconBox);
            this.Controls.Add(TextLabel);
            this.Controls.Add(CloseButton);
            this.ForeColor = Color.WhiteSmoke;
            this.Margin = new Padding(2, 1, 2, 1);
            this.Name = "NotifyControl";
            this.Size = new Size(851, 47);
            this.Load += this.NotifyControl_Load;
            ((System.ComponentModel.ISupportInitialize)IconBox).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Button CloseButton;
        private Label TextLabel;
        private PictureBox IconBox;
    }
}
