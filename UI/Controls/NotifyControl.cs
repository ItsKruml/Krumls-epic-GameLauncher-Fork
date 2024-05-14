using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLauncher.UI.Controls
{
    public partial class NotifyControl : UserControl
    {
        public NotifyControl()
        {
            InitializeComponent();
        }

        private void NotifyControl_Load(object sender, EventArgs e)
        {

        }

        public enum NotifyLevel
        {
            Default,
            Warning,
            Error,
            Information
        }
    }
}
