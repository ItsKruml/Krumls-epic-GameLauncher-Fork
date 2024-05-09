namespace GameLauncher
{
    partial class SettingsPage
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
            label1 = new Label();
            BackButton = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(18, 15);
            label1.Name = "label1";
            label1.Size = new Size(319, 46);
            label1.TabIndex = 0;
            label1.Text = "Settings";
            // 
            // BackButton
            // 
            BackButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BackButton.Location = new Point(701, 15);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(75, 23);
            BackButton.TabIndex = 6;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += this.BackButton_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(18, 62);
            flowLayoutPanel1.Margin = new Padding(2, 1, 2, 1);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(758, 389);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // SettingsPage
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(flowLayoutPanel1);
            this.Controls.Add(BackButton);
            this.Controls.Add(label1);
            this.Name = "SettingsPage";
            this.Size = new Size(798, 468);
            this.Load += this.SettingsPage_Load;
            this.ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button BackButton;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
