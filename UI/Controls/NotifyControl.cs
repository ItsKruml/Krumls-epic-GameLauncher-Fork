using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLauncher.Properties;

namespace GameLauncher.UI.Controls
{
    public partial class NotifyControl : UserControl
    {
        public bool Closed { get; private set; } = false;
        public NotifyControl(string text, ImageType image)
        {
            InitializeComponent();

            this.Dock = DockStyle.Top;

            this.TextLabel.Text = text;

            this.IconBox.Image = image switch
            {
                ImageType.Check => Resources.check,
                ImageType.Warning => Resources.warning,
                ImageType.Error => Resources.error,
                ImageType.Unknown => Resources.unknown,
                ImageType.NewRelease => Resources.new_release,
                ImageType.NoConnection => Resources.no_wifi,
            };
        }

        private void NotifyControl_Load(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Close()
        {
            Closed = true;
            this.Parent.Controls.Remove(this);
        }

        public enum ImageType
        {
            Check,
            Warning,
            Error,
            Unknown,
            NewRelease,
            NoConnection
        }
    }
}
