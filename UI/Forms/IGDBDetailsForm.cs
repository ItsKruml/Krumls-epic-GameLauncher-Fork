using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLauncher.Connections;

namespace GameLauncher
{
    public partial class IGDBDetailsForm : Form
    {
        public IGDBDetailsForm()
        {
            this.InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo si = new("https://api-docs.igdb.com/#getting-started:~:text=NOW%2C%20IT%27S%20FREE!-,Account%20Creation,usage%20under%20the%20terms%20of%20the%20Twitch%20Developer%20Service%20Agreement.,-Note%3A%20We");
            si.UseShellExecute = true;
            Process.Start(si);
            this.linkLabel1.LinkVisited = true;
        }

        private void IGDBDetailsForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("The credentials stored are either invalid or not present, please enter your IGDB client details to continue", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void SetUpButton_Click(object sender, EventArgs e)
        {
            string clientId = this.ClientIDTextbox.Text;
            string clientSecret = this.ClientSecretTextbox.Text;
            
            this.SetUpButton.Enabled = false;
            
            new IGDBObj(clientId, clientSecret).TestAsync(valid =>
            {
                if (!valid)
                {
                    this.Invoke(() => this.SetUpButton.Enabled = true);
                    MessageBox.Show("Invalid client details provided, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("IGDB database now connected", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Management.Config.IGDBId = clientId;
                Management.Config.IGDBSecret = clientSecret;
                Management.Config.Save();
                
                this.Invoke(this.Close); 
            });
        }
    }
}
