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

        private string version = "v0.1";
        private static string[] songInfoSaved;
        private static string filePath;
        private static int bpm;
        private static int length;

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
        /// <summary>
        /// Creates files for the chart and song info.
        /// </summary>
        /// <param name="_bpm">Song BPM (for chart file)</param>
        /// <param name="_length">Song length (in s) (for chart file)</param>
        /// <param name="_name">Song name (for song info file)</param>
        /// <param name="_artist">Artist name (for song info file)</param>
        /// <param name="_album">Album name (for song info file)</param>
        /// <param name="_charter">Charter name(for song info file)</param>
        /// <param name="_filePath">Path of the directory for the song</param>
        public void Create(string _bpm, string _length, string _name, string _artist, string _album, string _charter, string _filePath)
        {
            string[] chartInfo =
            {
                _bpm,
                _length,
            };
            bpm = Int32.Parse(_bpm);
            length = Int32.Parse(_length);

            string[] songInfo =
            {
                _name,
                _artist,
                _album,
                _charter
            };
            filePath = _filePath;
            songInfoSaved = songInfo;

            string chartFilePath = Path.Combine(_filePath, "chart.taptchart");
            string songInfoPath = Path.Combine(_filePath, "songinfo.txt");


            using (StreamWriter outputFile = new StreamWriter(chartFilePath))
            {
                foreach (string line in chartInfo)
                {
                    outputFile.WriteLine(line);

                }
                for (int i = 0; i < ((Int32.Parse(_bpm) / 60) * Int32.Parse(_length) * 4) + 1; i++)
                {
                    outputFile.WriteLine("000000000");
                }
            }

            using (StreamWriter outputFile = new StreamWriter(songInfoPath))
            {
                foreach (string line in songInfo)
                {
                    outputFile.WriteLine(line);
                }
            }

            chartVisualizer.LoadChart(filePath);
            this.Text = "Tapt Charter " + version + ": " + _name;
            saveChartToolStripMenuItem.Enabled = true;
            songInfoToolStripMenuItem.Enabled = true;
        }
        /// <summary>
        /// Used to update the song info file when edited in the edit form. 
        /// </summary>
        /// <param name="_name">Song name</param>
        /// <param name="_artist">Artist name</param>
        /// <param name="_album">Album name</param>
        /// <param name="_charter">Charter name</param>
        public void UpdateSongInfo(string _name, string _artist, string _album, string _charter)
        {
            string songInfoPath = Path.Combine(filePath, "songinfo.txt");
            Console.WriteLine(songInfoPath);

            string[] songInfo =
            {
                _name,
                _artist,
                _album,
                _charter
            };

            using (StreamWriter outputFile = new StreamWriter(songInfoPath))
            {
                foreach (string line in songInfo)
                {
                    outputFile.WriteLine(line);
                }
            }
            songInfoSaved = songInfo;
            chartVisualizer.UpdateInfo(songInfo);
        }

        private void openChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openChartDialog.ShowDialog() == DialogResult.OK)
            {
                chartVisualizer.LoadChart(openChartDialog.SelectedPath);
                filePath = openChartDialog.SelectedPath;
                string songInfoPath = Path.Combine(openChartDialog.SelectedPath, "songinfo.txt");

                try // Pulling data from file
                {
                    songInfoSaved = File.ReadAllLines(songInfoPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error reading file in Load function: " + ex.ToString());
                    return;
                }

                saveChartToolStripMenuItem.Enabled = true;
                songInfoToolStripMenuItem.Enabled = true;
            }
        }

        private void openChartDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void songInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditInfoForm editInfoForm = new EditInfoForm(songInfoSaved, this);
            editInfoForm.Show();
        }

        private void saveChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string chartFilePath = Path.Combine(filePath, "chart.taptchart");
            chartVisualizer.Save(chartFilePath, bpm, length);
        }
    }
}
