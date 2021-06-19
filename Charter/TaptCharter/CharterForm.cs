﻿using System;
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
        static string[] songInfoSaved;
        static string filePath;

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
            string[] chartInfo =
            {
                _bpm,
                _length,
                ""
            };

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
            }

            using (StreamWriter outputFile = new StreamWriter(songInfoPath))
            {
                foreach (string line in songInfo)
                {
                    outputFile.WriteLine(line);
                }
            }

            chartVisualizer.LoadChart(chartFilePath);
            this.Text = "Tapt Charter " + version + ": " + _name;
            saveChartToolStripMenuItem.Enabled = true;
            songInfoToolStripMenuItem.Enabled = true;
        }

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
    }
}
