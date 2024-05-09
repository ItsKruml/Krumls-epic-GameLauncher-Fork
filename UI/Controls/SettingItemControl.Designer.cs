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
            MainLabel.Location = new Point(3, 6);
            MainLabel.Name = "MainLabel";
            MainLabel.Size = new Size(192, 26);
            MainLabel.TabIndex = 0;
            MainLabel.Text = "My setting:";
            // 
            // Button
            // 
            Button.Location = new Point(3, 11);
            Button.Name = "Button";
            Button.Size = new Size(194, 40);
            Button.TabIndex = 1;
            Button.Text = "Open";
            Button.UseVisualStyleBackColor = true;
            Button.Visible = false;
            // 
            // CheckBox
            // 
            CheckBox.Location = new Point(8, 35);
            CheckBox.Name = "CheckBox";
            CheckBox.Size = new Size(192, 20);
            CheckBox.TabIndex = 2;
            CheckBox.UseVisualStyleBackColor = true;
            CheckBox.Visible = false;
            // 
            // TextBox
            // 
            TextBox.Location = new Point(6, 35);
            TextBox.Name = "TextBox";
            TextBox.Size = new Size(194, 23);
            TextBox.TabIndex = 3;
            TextBox.Visible = false;
            // 
            // ComboBox
            // 
            ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox.FormattingEnabled = true;
            ComboBox.Location = new Point(6, 35);
            ComboBox.Name = "ComboBox";
            ComboBox.Size = new Size(194, 23);
            ComboBox.TabIndex = 4;
            ComboBox.Visible = false;
            // 
            // SettingItemControl
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(ComboBox);
            this.Controls.Add(TextBox);
            this.Controls.Add(CheckBox);
            this.Controls.Add(Button);
            this.Controls.Add(MainLabel);
            this.Name = "SettingItemControl";
            this.Size = new Size(205, 63);
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
