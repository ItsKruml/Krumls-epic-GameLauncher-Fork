using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLauncher.UI.Forms
{
    public partial class IGDBSearchResultsForm : Form
    {
        private string _initialResult;
        public IGDBSearchResultsForm(string initialResult)
        {
            this._initialResult = initialResult;
            InitializeComponent();
        }

        private void IGDBSearchResultsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
