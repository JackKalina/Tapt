using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaptCharter
{
    public partial class CharterForm : Form
    {
        public CharterForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewChartForm newChartForm = new NewChartForm(this);
            newChartForm.Show();
        }
    }
}
