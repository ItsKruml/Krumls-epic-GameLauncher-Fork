using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IGDB.Models;

namespace GameLauncher.UI.Forms
{
    public partial class IGDBSearchResultsForm : Form
    {
        public Game? SelectedGame => this._results?.ElementAtOrDefault(this.ResultBox.SelectedIndex);
        private string _initialResult;
        private Game[]? _results;
        public IGDBSearchResultsForm(string initialResult)
        {
            this._initialResult = initialResult;
            this.DialogResult = DialogResult.Cancel;
            InitializeComponent();
        }

        private void IGDBSearchResultsForm_Load(object sender, EventArgs e)
        {
            this.SearchBox.Text = this._initialResult;
            this.PerformSearch();
        }

        private void SearchButton_Click(object? sender, EventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            this.SearchButton.Enabled = false;
            string query = this.SearchBox.Text;
            if (query.All(char.IsNumber))
                query = $"[{query}]";

            Management.IGDBObj.SearchAsync(query, results =>
            {
                this._results = results;

                this.Invoke(() =>
                {
                    this.ResultBox.BeginUpdate();
                    this.ResultBox.Items.Clear();

                    // ReSharper disable once CoVariantArrayConversion
                    this.ResultBox.Items.AddRange(results.Select(x => x.Name).ToArray());

                    this.ResultBox.EndUpdate();

                    this.SearchButton.Enabled = true;
                });
            }, 25);
        }

        private void SelectButton_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
