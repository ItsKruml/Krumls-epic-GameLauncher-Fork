namespace GameLauncher.UI.Forms
{
    partial class IGDBSearchResultsForm
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
            this.SuspendLayout();
            // 
            // ResultBox
            // 
            ResultBox.FormattingEnabled = true;
            ResultBox.ItemHeight = 15;
            ResultBox.Location = new Point(12, 40);
            ResultBox.Name = "ResultBox";
            ResultBox.Size = new Size(333, 109);
            ResultBox.TabIndex = 0;
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(82, 6);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(182, 23);
            SearchBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 2;
            label1.Text = "Term or ID:";
            // 
            // SelectButton
            // 
            SelectButton.Location = new Point(270, 155);
            SelectButton.Name = "SelectButton";
            SelectButton.Size = new Size(75, 23);
            SelectButton.TabIndex = 3;
            SelectButton.Text = "Select";
            SelectButton.UseVisualStyleBackColor = true;
            SelectButton.Click += this.SelectButton_Click;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(270, 6);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(75, 23);
            SearchButton.TabIndex = 4;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += this.SearchButton_Click;
            // 
            // IGDBSearchResultsForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(351, 185);
            this.Controls.Add(SearchButton);
            this.Controls.Add(SelectButton);
            this.Controls.Add(label1);
            this.Controls.Add(SearchBox);
            this.Controls.Add(ResultBox);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IGDBSearchResultsForm";
            this.Text = "IGDB Search Results";
            this.Load += this.IGDBSearchResultsForm_Load;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private ListBox ResultBox;
        private TextBox SearchBox;
        private Label label1;
        private Button SelectButton;
        private Button SearchButton;
    }
}