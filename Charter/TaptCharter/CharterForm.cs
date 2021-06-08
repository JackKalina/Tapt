using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TaptCharter
{
    public partial class CharterForm : Form
    {
        string version = "v0.1";
        public CharterForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "TaptCharter " + version;
        }

        private void newChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewChartForm newChartForm = new NewChartForm(this);
            newChartForm.Show();
        }

        private void chartVisualizer_Click(object sender, EventArgs e)
        {

        }
        public void Create(string _bpm, string _length, string _name, string _artist, string _album, string _charter, string _filePath)
        {
            string[] basicInfo =
            {
                _bpm,
                _length,
                "",
                _name,
                _artist,
                _album,
                _charter,
                ""
            };

            string filePath = Path.Combine(_filePath, _name + ".taptchart");

            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                foreach (string line in basicInfo)
                {
                    outputFile.WriteLine(line);
                }
            }

            chartVisualizer.Load(filePath);
            this.Text = "Tapt Charter" + version + ": " + _name;
            saveChartToolStripMenuItem.Enabled = true;
        }

        private void openChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
