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
            this.paletteExtenderProvider1 = new Models.PaletteExtenderProvider();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            this.SuspendLayout();
            // 
            // ClientIDTextbox
            // 
            ClientIDTextbox.BackColor = Color.FromArgb(73, 80, 92);
            ClientIDTextbox.BorderStyle = BorderStyle.FixedSingle;
            ClientIDTextbox.ForeColor = Color.WhiteSmoke;
            ClientIDTextbox.Location = new Point(169, 292);
            ClientIDTextbox.Margin = new Padding(6);
            ClientIDTextbox.Name = "ClientIDTextbox";
            ClientIDTextbox.Size = new Size(312, 39);
            ClientIDTextbox.TabIndex = 0;
            // 
            // ClientSecretTextbox
            // 
            ClientSecretTextbox.BackColor = Color.FromArgb(73, 80, 92);
            ClientSecretTextbox.BorderStyle = BorderStyle.FixedSingle;
            ClientSecretTextbox.ForeColor = Color.WhiteSmoke;
            ClientSecretTextbox.Location = new Point(169, 354);
            ClientSecretTextbox.Margin = new Padding(6);
            ClientSecretTextbox.Name = "ClientSecretTextbox";
            ClientSecretTextbox.Size = new Size(312, 39);
            ClientSecretTextbox.TabIndex = 1;
            ClientSecretTextbox.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(59, 32);
            pictureBox1.Margin = new Padding(6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(392, 188);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // SetUpButton
            // 
            SetUpButton.BackColor = Color.FromArgb(142, 122, 181);
            SetUpButton.FlatAppearance.BorderSize = 0;
            SetUpButton.FlatStyle = FlatStyle.Flat;
            SetUpButton.Location = new Point(345, 416);
            SetUpButton.Margin = new Padding(6);
            SetUpButton.Name = "SetUpButton";
            SetUpButton.Size = new Size(139, 49);
            SetUpButton.TabIndex = 3;
            SetUpButton.Text = "Set up";
            SetUpButton.UseVisualStyleBackColor = false;
            SetUpButton.Click += this.SetUpButton_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.FromArgb(142, 122, 181);
            linkLabel1.Location = new Point(386, 226);
            linkLabel1.Margin = new Padding(6, 0, 6, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(71, 32);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Help!";
            linkLabel1.LinkClicked += this.linkLabel1_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 299);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(111, 32);
            label1.TabIndex = 5;
            label1.Text = "Client ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 361);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(154, 32);
            label2.TabIndex = 6;
            label2.Text = "Client Secret:";
            // 
            // IGDBDetailsForm
            // 
            this.AutoScaleDimensions = new SizeF(13F, 32F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(36, 39, 45);
            this.ClientSize = new Size(509, 491);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(linkLabel1);
            this.Controls.Add(SetUpButton);
            this.Controls.Add(pictureBox1);
            this.Controls.Add(ClientSecretTextbox);
            this.Controls.Add(ClientIDTextbox);
            this.ForeColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Margin = new Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IGDBDetailsForm";
            this.ShowInTaskbar = false;
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
        private Models.PaletteExtenderProvider paletteExtenderProvider1;
    }
}