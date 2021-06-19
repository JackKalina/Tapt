namespace TaptCharter
{
    partial class NewChartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bpmInput = new System.Windows.Forms.TextBox();
            this.bpmLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.artistInput = new System.Windows.Forms.TextBox();
            this.artistLabel = new System.Windows.Forms.Label();
            this.songInfoLabel = new System.Windows.Forms.Label();
            this.albumLabel = new System.Windows.Forms.Label();
            this.albumInput = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.mp3FileNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.charterInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lengthInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bpmInput
            // 
            this.bpmInput.Location = new System.Drawing.Point(71, 144);
            this.bpmInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bpmInput.Name = "bpmInput";
            this.bpmInput.Size = new System.Drawing.Size(126, 20);
            this.bpmInput.TabIndex = 0;
            // 
            // bpmLabel
            // 
            this.bpmLabel.AutoSize = true;
            this.bpmLabel.Location = new System.Drawing.Point(9, 144);
            this.bpmLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bpmLabel.Name = "bpmLabel";
            this.bpmLabel.Size = new System.Drawing.Size(33, 13);
            this.bpmLabel.TabIndex = 1;
            this.bpmLabel.Text = "BPM:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(7, 44);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name:";
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(71, 40);
            this.nameInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(126, 20);
            this.nameInput.TabIndex = 3;
            // 
            // artistInput
            // 
            this.artistInput.Location = new System.Drawing.Point(71, 66);
            this.artistInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.artistInput.Name = "artistInput";
            this.artistInput.Size = new System.Drawing.Size(126, 20);
            this.artistInput.TabIndex = 5;
            // 
            // artistLabel
            // 
            this.artistLabel.AutoSize = true;
            this.artistLabel.Location = new System.Drawing.Point(7, 70);
            this.artistLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(33, 13);
            this.artistLabel.TabIndex = 6;
            this.artistLabel.Text = "Artist:";
            // 
            // songInfoLabel
            // 
            this.songInfoLabel.AutoSize = true;
            this.songInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songInfoLabel.Location = new System.Drawing.Point(22, 7);
            this.songInfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.songInfoLabel.Name = "songInfoLabel";
            this.songInfoLabel.Size = new System.Drawing.Size(160, 18);
            this.songInfoLabel.TabIndex = 7;
            this.songInfoLabel.Text = "Enter Song Information";
            // 
            // albumLabel
            // 
            this.albumLabel.AutoSize = true;
            this.albumLabel.Location = new System.Drawing.Point(7, 96);
            this.albumLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.albumLabel.Name = "albumLabel";
            this.albumLabel.Size = new System.Drawing.Size(39, 13);
            this.albumLabel.TabIndex = 9;
            this.albumLabel.Text = "Album:";
            // 
            // albumInput
            // 
            this.albumInput.Location = new System.Drawing.Point(71, 92);
            this.albumInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.albumInput.Name = "albumInput";
            this.albumInput.Size = new System.Drawing.Size(126, 20);
            this.albumInput.TabIndex = 8;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "mp3";
            this.openFileDialog.Filter = "wav Files (.wav)|*.wav";
            this.openFileDialog.Title = "Open File...";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(109, 244);
            this.okButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(85, 19);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(10, 244);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(84, 19);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(10, 189);
            this.openFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(186, 26);
            this.openFileButton.TabIndex = 13;
            this.openFileButton.Text = "Open wav file...";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // mp3FileNameTextBox
            // 
            this.mp3FileNameTextBox.Location = new System.Drawing.Point(10, 220);
            this.mp3FileNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mp3FileNameTextBox.Name = "mp3FileNameTextBox";
            this.mp3FileNameTextBox.ReadOnly = true;
            this.mp3FileNameTextBox.Size = new System.Drawing.Size(187, 20);
            this.mp3FileNameTextBox.TabIndex = 14;
            this.mp3FileNameTextBox.Text = "Please select a .wav file.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 119);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Charter:";
            // 
            // charterInput
            // 
            this.charterInput.Location = new System.Drawing.Point(71, 119);
            this.charterInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.charterInput.Name = "charterInput";
            this.charterInput.Size = new System.Drawing.Size(126, 20);
            this.charterInput.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 167);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Length (s):";
            // 
            // lengthInput
            // 
            this.lengthInput.Location = new System.Drawing.Point(71, 167);
            this.lengthInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lengthInput.Name = "lengthInput";
            this.lengthInput.Size = new System.Drawing.Size(126, 20);
            this.lengthInput.TabIndex = 17;
            // 
            // NewChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 272);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lengthInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.charterInput);
            this.Controls.Add(this.mp3FileNameTextBox);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.albumLabel);
            this.Controls.Add(this.albumInput);
            this.Controls.Add(this.songInfoLabel);
            this.Controls.Add(this.artistLabel);
            this.Controls.Add(this.artistInput);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.bpmLabel);
            this.Controls.Add(this.bpmInput);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NewChartForm";
            this.Text = "New Chart";
            this.Load += new System.EventHandler(this.NewChartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox bpmInput;
        private System.Windows.Forms.Label bpmLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.TextBox artistInput;
        private System.Windows.Forms.Label artistLabel;
        private System.Windows.Forms.Label songInfoLabel;
        private System.Windows.Forms.Label albumLabel;
        private System.Windows.Forms.TextBox albumInput;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.TextBox mp3FileNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox charterInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lengthInput;
    }
}