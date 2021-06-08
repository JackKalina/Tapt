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
    public partial class NewChartForm : Form
    {
        CharterForm charterForm;
        public NewChartForm(CharterForm _charterForm)
        {
            InitializeComponent();
            charterForm = _charterForm;
        }

        private void NewChartForm_Load(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mp3FileNameTextBox.Text = openFileDialog.FileName;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (mp3FileNameTextBox.Text == null)
            {
                MessageBox.Show("Please select a music file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { 
                try
                {
                    string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                    // if there is no songs folder, make one
                    if (!Directory.Exists(path + @"\songs"))
                    {
                        Directory.CreateDirectory(path + @"\songs");
                        Console.WriteLine("Created songs directory at " + path + @"\songs");
                    }
                    // If there isn't a folder by the same name, make it
                    if (!Directory.Exists(path + @"\songs\" + nameInput.Text))
                    {
                        Directory.CreateDirectory(path + @"\songs\" + nameInput.Text);
                        string currentPath = path + @"\songs\" + nameInput.Text;
                        File.Copy(mp3FileNameTextBox.Text, currentPath + @"\song.mp3");
                        charterForm.Create(bpmInput.Text, lengthInput.Text, nameInput.Text, artistInput.Text, albumInput.Text, charterInput.Text, currentPath);
                        this.Close();
                    } // If there is, pop up an error and tell the user what to do. 
                    else
                    {
                        MessageBox.Show("There is already a song by that name.\nPlease delete the other folder or change the song name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred at directory creation: " + ex.ToString());
                    MessageBox.Show("Error occurred at directory creation: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
    }
}
