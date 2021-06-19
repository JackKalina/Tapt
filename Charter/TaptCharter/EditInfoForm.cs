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
    public partial class EditInfoForm : Form
    {
        static string[] songInfo;
        CharterForm charterForm;

        public EditInfoForm(string[] _songInfo, CharterForm _charterForm)
        {
            InitializeComponent();
            songInfo = _songInfo;
            charterForm = _charterForm;
        }

        private void songInfoLabel_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            charterForm.UpdateSongInfo(nameInput.Text, artistInput.Text, albumInput.Text, charterInput.Text);
            this.Close();
        }

        private void EditInfoForm_Load(object sender, EventArgs e)
        {
            nameInput.Text = songInfo[0];
            artistInput.Text = songInfo[1];
            albumInput.Text = songInfo[2];
            charterInput.Text = songInfo[3];
        }
    }
}
