namespace GameLauncher
{
    partial class IGDBDetailsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IGDBDetailsForm));
            ClientIDTextbox = new TextBox();
            ClientSecretTextbox = new TextBox();
            pictureBox1 = new PictureBox();
            SetUpButton = new Button();
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            this.SuspendLayout();
            // 
            // ClientIDTextbox
            // 
            ClientIDTextbox.Location = new Point(91, 137);
            ClientIDTextbox.Name = "ClientIDTextbox";
            ClientIDTextbox.Size = new Size(170, 23);
            ClientIDTextbox.TabIndex = 0;
            // 
            // ClientSecretTextbox
            // 
            ClientSecretTextbox.Location = new Point(91, 166);
            ClientSecretTextbox.Name = "ClientSecretTextbox";
            ClientSecretTextbox.Size = new Size(170, 23);
            ClientSecretTextbox.TabIndex = 1;
            ClientSecretTextbox.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(32, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(211, 88);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // SetUpButton
            // 
            SetUpButton.Location = new Point(186, 195);
            SetUpButton.Name = "SetUpButton";
            SetUpButton.Size = new Size(75, 23);
            SetUpButton.TabIndex = 3;
            SetUpButton.Text = "Set up";
            SetUpButton.UseVisualStyleBackColor = true;
            SetUpButton.Click += this.SetUpButton_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(208, 106);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(35, 15);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Help!";
            linkLabel1.LinkClicked += this.linkLabel1_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 140);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 5;
            label1.Text = "Client ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 169);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 6;
            label2.Text = "Client Secret:";
            // 
            // IGDBDetailsForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(274, 230);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(linkLabel1);
            this.Controls.Add(SetUpButton);
            this.Controls.Add(pictureBox1);
            this.Controls.Add(ClientSecretTextbox);
            this.Controls.Add(ClientIDTextbox);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IGDBDetailsForm";
            this.Text = "IGDB Details";
            this.Load += this.IGDBDetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private TextBox ClientIDTextbox;
        private TextBox ClientSecretTextbox;
        private PictureBox pictureBox1;
        private Button SetUpButton;
        private LinkLabel linkLabel1;
        private Label label1;
        private Label label2;
    }
}