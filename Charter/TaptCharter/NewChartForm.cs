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
    public partial class NewChartForm : Form
    {
        public NewChartForm(CharterForm _charterForm)
        {
            InitializeComponent();
            CharterForm charterForm = _charterForm;
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
    }
}
