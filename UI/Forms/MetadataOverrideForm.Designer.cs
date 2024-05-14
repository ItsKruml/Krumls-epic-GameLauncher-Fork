namespace GameLauncher.UI.Forms
{
    partial class MetadataOverrideForm
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
            ResultBox = new ListBox();
            SearchBox = new TextBox();
            label1 = new Label();
            SelectButton = new Button();
            SearchButton = new Button();
            CustomMetadataButton = new Button();
            CustomOverridePanel = new Panel();
            ThumnailPathLabel = new Label();
            GenresBox = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            ChooseThumbnailButton = new Button();
            DescriptionBox = new RichTextBox();
            NameBox = new TextBox();
            UpdateDirNameBox = new CheckBox();
            this.paletteExtenderProvider1 = new Models.PaletteExtenderProvider();
            CustomOverridePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResultBox
            // 
            ResultBox.BackColor = Color.FromArgb(73, 80, 92);
            ResultBox.BorderStyle = BorderStyle.FixedSingle;
            ResultBox.ForeColor = Color.WhiteSmoke;
            ResultBox.FormattingEnabled = true;
            ResultBox.ItemHeight = 32;
            ResultBox.Location = new Point(22, 85);
            ResultBox.Margin = new Padding(6);
            ResultBox.Name = "ResultBox";
            ResultBox.Size = new Size(615, 226);
            ResultBox.TabIndex = 0;
            // 
            // SearchBox
            // 
            SearchBox.BackColor = Color.FromArgb(73, 80, 92);
            SearchBox.BorderStyle = BorderStyle.FixedSingle;
            SearchBox.ForeColor = Color.WhiteSmoke;
            SearchBox.Location = new Point(154, 18);
            SearchBox.Margin = new Padding(6);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(335, 39);
            SearchBox.TabIndex = 1;
            SearchBox.KeyDown += this.SearchBox_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 21);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(131, 32);
            label1.TabIndex = 2;
            label1.Text = "Term or ID:";
            // 
            // SelectButton
            // 
            SelectButton.BackColor = Color.FromArgb(142, 122, 181);
            SelectButton.FlatAppearance.BorderSize = 0;
            SelectButton.FlatStyle = FlatStyle.Flat;
            SelectButton.Location = new Point(501, 331);
            SelectButton.Margin = new Padding(6);
            SelectButton.Name = "SelectButton";
            SelectButton.Size = new Size(139, 49);
            SelectButton.TabIndex = 3;
            SelectButton.Text = "Select";
            SelectButton.UseVisualStyleBackColor = false;
            SelectButton.Click += this.SelectButton_Click;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.FromArgb(142, 122, 181);
            SearchButton.FlatAppearance.BorderSize = 0;
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.Location = new Point(501, 13);
            SearchButton.Margin = new Padding(6);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(139, 49);
            SearchButton.TabIndex = 4;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += this.SearchButton_Click;
            // 
            // CustomMetadataButton
            // 
            CustomMetadataButton.BackColor = Color.FromArgb(73, 80, 92);
            CustomMetadataButton.FlatAppearance.BorderSize = 0;
            CustomMetadataButton.FlatStyle = FlatStyle.Flat;
            CustomMetadataButton.Location = new Point(339, 332);
            CustomMetadataButton.Name = "CustomMetadataButton";
            CustomMetadataButton.Size = new Size(150, 46);
            CustomMetadataButton.TabIndex = 5;
            CustomMetadataButton.Text = "Custom";
            CustomMetadataButton.UseVisualStyleBackColor = false;
            CustomMetadataButton.Click += this.CustomMetadataButton_Click;
            // 
            // CustomOverridePanel
            // 
            CustomOverridePanel.Controls.Add(ThumnailPathLabel);
            CustomOverridePanel.Controls.Add(GenresBox);
            CustomOverridePanel.Controls.Add(label5);
            CustomOverridePanel.Controls.Add(label4);
            CustomOverridePanel.Controls.Add(label3);
            CustomOverridePanel.Controls.Add(label2);
            CustomOverridePanel.Controls.Add(ChooseThumbnailButton);
            CustomOverridePanel.Controls.Add(DescriptionBox);
            CustomOverridePanel.Controls.Add(NameBox);
            CustomOverridePanel.Location = new Point(22, 12);
            CustomOverridePanel.Name = "CustomOverridePanel";
            CustomOverridePanel.Size = new Size(619, 301);
            CustomOverridePanel.TabIndex = 6;
            CustomOverridePanel.Visible = false;
            // 
            // ThumnailPathLabel
            // 
            ThumnailPathLabel.Font = new Font("Segoe UI", 5F, FontStyle.Regular, GraphicsUnit.Point);
            ThumnailPathLabel.Location = new Point(322, 250);
            ThumnailPathLabel.Name = "ThumnailPathLabel";
            ThumnailPathLabel.Size = new Size(276, 35);
            ThumnailPathLabel.TabIndex = 8;
            ThumnailPathLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // GenresBox
            // 
            GenresBox.BackColor = Color.FromArgb(73, 80, 92);
            GenresBox.BorderStyle = BorderStyle.FixedSingle;
            GenresBox.ForeColor = Color.WhiteSmoke;
            GenresBox.Location = new Point(166, 189);
            GenresBox.Name = "GenresBox";
            GenresBox.Size = new Size(432, 39);
            GenresBox.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 251);
            label5.Name = "label5";
            label5.Size = new Size(133, 32);
            label5.TabIndex = 6;
            label5.Text = "Thumbnail:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 192);
            label4.Name = "label4";
            label4.Size = new Size(93, 32);
            label4.TabIndex = 5;
            label4.Text = "Genres:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 76);
            label3.Name = "label3";
            label3.Size = new Size(140, 32);
            label3.TabIndex = 4;
            label3.Text = "Description:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 20);
            label2.Name = "label2";
            label2.Size = new Size(90, 32);
            label2.TabIndex = 3;
            label2.Text = "Name: ";
            // 
            // ChooseThumbnailButton
            // 
            ChooseThumbnailButton.BackColor = Color.FromArgb(73, 80, 92);
            ChooseThumbnailButton.FlatAppearance.BorderSize = 0;
            ChooseThumbnailButton.FlatStyle = FlatStyle.Flat;
            ChooseThumbnailButton.Location = new Point(166, 245);
            ChooseThumbnailButton.Name = "ChooseThumbnailButton";
            ChooseThumbnailButton.Size = new Size(150, 46);
            ChooseThumbnailButton.TabIndex = 2;
            ChooseThumbnailButton.Text = "Select";
            ChooseThumbnailButton.UseVisualStyleBackColor = false;
            // 
            // DescriptionBox
            // 
            DescriptionBox.BackColor = Color.FromArgb(73, 80, 92);
            DescriptionBox.BorderStyle = BorderStyle.FixedSingle;
            DescriptionBox.ForeColor = Color.WhiteSmoke;
            DescriptionBox.Location = new Point(166, 73);
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(432, 104);
            DescriptionBox.TabIndex = 1;
            DescriptionBox.Text = "";
            // 
            // NameBox
            // 
            NameBox.BackColor = Color.FromArgb(73, 80, 92);
            NameBox.BorderStyle = BorderStyle.FixedSingle;
            NameBox.ForeColor = Color.WhiteSmoke;
            NameBox.Location = new Point(166, 18);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(432, 39);
            NameBox.TabIndex = 0;
            // 
            // UpdateDirNameBox
            // 
            UpdateDirNameBox.AutoSize = true;
            UpdateDirNameBox.Location = new Point(23, 338);
            UpdateDirNameBox.Name = "UpdateDirNameBox";
            UpdateDirNameBox.Size = new Size(291, 36);
            UpdateDirNameBox.TabIndex = 7;
            UpdateDirNameBox.Text = "Update directory name";
            UpdateDirNameBox.UseVisualStyleBackColor = true;
            // 
            // MetadataOverrideForm
            // 
            this.AutoScaleDimensions = new SizeF(13F, 32F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(36, 39, 45);
            this.ClientSize = new Size(652, 395);
            this.Controls.Add(UpdateDirNameBox);
            this.Controls.Add(CustomOverridePanel);
            this.Controls.Add(CustomMetadataButton);
            this.Controls.Add(SearchButton);
            this.Controls.Add(SelectButton);
            this.Controls.Add(label1);
            this.Controls.Add(SearchBox);
            this.Controls.Add(ResultBox);
            this.ForeColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Margin = new Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MetadataOverrideForm";
            this.Text = "Metadata Override";
            this.Load += this.IGDBSearchResultsForm_Load;
            CustomOverridePanel.ResumeLayout(false);
            CustomOverridePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private ListBox ResultBox;
        private TextBox SearchBox;
        private Label label1;
        private Button SelectButton;
        private Button SearchButton;
        private Button CustomMetadataButton;
        private Panel CustomOverridePanel;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button ChooseThumbnailButton;
        private RichTextBox DescriptionBox;
        private TextBox NameBox;
        private TextBox GenresBox;
        private Label label5;
        private Label ThumnailPathLabel;
        private CheckBox UpdateDirNameBox;
        private Models.PaletteExtenderProvider paletteExtenderProvider1;
    }
}