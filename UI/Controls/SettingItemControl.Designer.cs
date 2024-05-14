namespace GameLauncher
{
    partial class SettingItemControl
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
            MainLabel = new Label();
            Button = new Button();
            CheckBox = new CheckBox();
            TextBox = new TextBox();
            ComboBox = new ComboBox();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            MainLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MainLabel.Location = new Point(6, 13);
            MainLabel.Margin = new Padding(6, 0, 6, 0);
            MainLabel.Name = "MainLabel";
            MainLabel.Size = new Size(357, 55);
            MainLabel.TabIndex = 0;
            MainLabel.Text = "My setting:";
            // 
            // Button
            // 
            Button.BackColor = Color.FromArgb(47, 51, 58);
            Button.FlatAppearance.BorderSize = 0;
            Button.FlatStyle = FlatStyle.Flat;
            Button.ForeColor = Color.WhiteSmoke;
            Button.Location = new Point(6, 23);
            Button.Margin = new Padding(6);
            Button.Name = "Button";
            Button.Size = new Size(360, 85);
            Button.TabIndex = 1;
            Button.Text = "Open";
            Button.UseVisualStyleBackColor = false;
            Button.Visible = false;
            // 
            // CheckBox
            // 
            CheckBox.Location = new Point(15, 75);
            CheckBox.Margin = new Padding(6);
            CheckBox.Name = "CheckBox";
            CheckBox.Size = new Size(357, 43);
            CheckBox.TabIndex = 2;
            CheckBox.UseVisualStyleBackColor = true;
            CheckBox.Visible = false;
            // 
            // TextBox
            // 
            TextBox.BackColor = Color.FromArgb(47, 51, 58);
            TextBox.BorderStyle = BorderStyle.FixedSingle;
            TextBox.ForeColor = Color.WhiteSmoke;
            TextBox.Location = new Point(11, 75);
            TextBox.Margin = new Padding(6);
            TextBox.Name = "TextBox";
            TextBox.Size = new Size(357, 39);
            TextBox.TabIndex = 3;
            TextBox.Visible = false;
            // 
            // ComboBox
            // 
            ComboBox.BackColor = Color.FromArgb(47, 51, 58);
            ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox.ForeColor = Color.WhiteSmoke;
            ComboBox.FormattingEnabled = true;
            ComboBox.Location = new Point(11, 75);
            ComboBox.Margin = new Padding(6);
            ComboBox.Name = "ComboBox";
            ComboBox.Size = new Size(357, 40);
            ComboBox.TabIndex = 4;
            ComboBox.Visible = false;
            // 
            // SettingItemControl
            // 
            this.AutoScaleDimensions = new SizeF(13F, 32F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(ComboBox);
            this.Controls.Add(TextBox);
            this.Controls.Add(CheckBox);
            this.Controls.Add(Button);
            this.Controls.Add(MainLabel);
            this.Margin = new Padding(6);
            this.Name = "SettingItemControl";
            this.Size = new Size(381, 134);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label MainLabel;
        private Button Button;
        private CheckBox CheckBox;
        private TextBox TextBox;
        private ComboBox ComboBox;
    }
}
