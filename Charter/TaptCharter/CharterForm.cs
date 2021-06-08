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
        public string Version
        {
            get
            {
                return version;
            }
        }

        public CharterForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "TaptCharter " + version;
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\songs\"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\songs");
                Console.WriteLine("Created songs directory at " + Directory.GetCurrentDirectory() + @"\songs");
            }
            openChartDialog.SelectedPath = Directory.GetCurrentDirectory() + @"\songs\";
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

            string filePath = Path.Combine(_filePath, "file.taptchart");

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
            if (openChartDialog.ShowDialog() == DialogResult.OK)
            {
                chartVisualizer.Load(openChartDialog.SelectedPath);
                saveChartToolStripMenuItem.Enabled = true;
            }
        }

        private void openChartDialog_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
