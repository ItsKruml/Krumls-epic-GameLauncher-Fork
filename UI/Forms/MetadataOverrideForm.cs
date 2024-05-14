using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLauncher.Connections;
using GameLauncher.Utils;
using IGDB.Models;

namespace GameLauncher.UI.Forms
{
    public partial class MetadataOverrideForm : Form
    {
        public Game? SelectedGame => this._results?.ElementAtOrDefault(this.ResultBox.SelectedIndex);
        private string _initialResult;
        private Game[]? _results;
        private bool inCustomMode => CustomOverridePanel.Visible;
        public MetadataOverrideForm(string initialResult, LocalGame? oldGame = null)
        {
            this._initialResult = initialResult;

            InitializeComponent();

            this.NameBox.Text = initialResult;
            this.DialogResult = DialogResult.Cancel;

            if (oldGame != null)
            {
                this.NameBox.Text = oldGame.Name ?? initialResult;
                this.DescriptionBox.Text = oldGame.Summary ?? "";
                this.GenresBox.Text = oldGame.Genres ?? "";
                this.ThumnailPathLabel.Text = oldGame.CoverUrl ?? "No cover";
            }
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
            this.SelectButton.Enabled = false;
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
                    this.SelectButton.Enabled = true;
                });
            }, 25);
        }

        private void SelectButton_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PerformSearch();
        }

        private void CustomMetadataButton_Click(object sender, EventArgs e)
        {
            CustomOverridePanel.Visible = !CustomOverridePanel.Visible;
            CustomMetadataButton.Text = inCustomMode ? "IGDB Search" : "Custom";
        }

        public static bool OverrideMetadata(LocalGame game)
        {
            MetadataOverrideForm form = new(game.Name, game);
            DialogResult result = form.ShowDialog();

            if (result != DialogResult.OK) return false;

            if (form.inCustomMode)
            {
                // Download image as cover.

                WebClient client = new();
                byte[] imageBytes = client.DownloadData(form.ThumnailPathLabel.Text);
                File.WriteAllBytes(game.CoverPath, imageBytes);

                game.GameMetaData = new()
                {
                    { "name", form.NameBox.Text },
                    { "genres", form.GenresBox.Text },
                    { "summary", form.DescriptionBox.Text },
                    { "cover_url", form.ThumnailPathLabel.Text }
                };

                DatFile.Save(game.GameMetadataPath, game.GameMetaData);

                if (form.UpdateDirNameBox.Checked)
                {
                    // change folder name to match the game name.
                    string dir = Path.GetDirectoryName(game.GamePath)!;

                    string newGamePath = Path.Join(dir, game.Name.CleanFileName());
                    Directory.Move(game.GamePath, newGamePath);
                    game.GamePath = newGamePath;
                }
            }
            else
            {
                Game? selectedGame = form.SelectedGame;
                if (selectedGame == null) return false;

                string dir = Path.GetDirectoryName(game.GamePath)!;
                string name = Path.GetFileName(game.GamePath);
                if (form.UpdateDirNameBox.Checked)
                    name = selectedGame.Name;

                name = Regex.Replace(name, @"\[(\d+)\]", "");
                name = $"{name.TrimEnd()} [{selectedGame.Id}]";

                string newPath = Path.Join(dir, name.CleanFileName());
                Directory.Move(game.GamePath, newPath);
                game.GamePath = newPath;
            }

            return true;
        }
    }
}
