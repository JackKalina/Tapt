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
            this.bpmInput.Location = new System.Drawing.Point(95, 177);
            this.bpmInput.Name = "bpmInput";
            this.bpmInput.Size = new System.Drawing.Size(166, 22);
            this.bpmInput.TabIndex = 0;
            // 
            // bpmLabel
            // 
            this.bpmLabel.AutoSize = true;
            this.bpmLabel.Location = new System.Drawing.Point(12, 177);
            this.bpmLabel.Name = "bpmLabel";
            this.bpmLabel.Size = new System.Drawing.Size(41, 17);
            this.bpmLabel.TabIndex = 1;
            this.bpmLabel.Text = "BPM:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(9, 54);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(49, 17);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name:";
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(95, 49);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(166, 22);
            this.nameInput.TabIndex = 3;
            // 
            // artistInput
            // 
            this.artistInput.Location = new System.Drawing.Point(95, 81);
            this.artistInput.Name = "artistInput";
            this.artistInput.Size = new System.Drawing.Size(166, 22);
            this.artistInput.TabIndex = 5;
            // 
            // artistLabel
            // 
            this.artistLabel.AutoSize = true;
            this.artistLabel.Location = new System.Drawing.Point(9, 86);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(44, 17);
            this.artistLabel.TabIndex = 6;
            this.artistLabel.Text = "Artist:";
            // 
            // songInfoLabel
            // 
            this.songInfoLabel.AutoSize = true;
            this.songInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songInfoLabel.Location = new System.Drawing.Point(29, 9);
            this.songInfoLabel.Name = "songInfoLabel";
            this.songInfoLabel.Size = new System.Drawing.Size(202, 24);
            this.songInfoLabel.TabIndex = 7;
            this.songInfoLabel.Text = "Enter Song Information";
            // 
            // albumLabel
            // 
            this.albumLabel.AutoSize = true;
            this.albumLabel.Location = new System.Drawing.Point(9, 118);
            this.albumLabel.Name = "albumLabel";
            this.albumLabel.Size = new System.Drawing.Size(51, 17);
            this.albumLabel.TabIndex = 9;
            this.albumLabel.Text = "Album:";
            // 
            // albumInput
            // 
            this.albumInput.Location = new System.Drawing.Point(95, 113);
            this.albumInput.Name = "albumInput";
            this.albumInput.Size = new System.Drawing.Size(166, 22);
            this.albumInput.TabIndex = 8;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "mp3";
            this.openFileDialog.Filter = "mp3 Files (.mp3)|*.mp3";
            this.openFileDialog.Title = "Open File...";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(148, 292);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(113, 23);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 291);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(13, 233);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(248, 23);
            this.openFileButton.TabIndex = 13;
            this.openFileButton.Text = "Open mp3 file...";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // mp3FileNameTextBox
            // 
            this.mp3FileNameTextBox.Location = new System.Drawing.Point(13, 263);
            this.mp3FileNameTextBox.Name = "mp3FileNameTextBox";
            this.mp3FileNameTextBox.ReadOnly = true;
            this.mp3FileNameTextBox.Size = new System.Drawing.Size(248, 22);
            this.mp3FileNameTextBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Charter:";
            // 
            // charterInput
            // 
            this.charterInput.Location = new System.Drawing.Point(95, 146);
            this.charterInput.Name = "charterInput";
            this.charterInput.Size = new System.Drawing.Size(166, 22);
            this.charterInput.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Length (s):";
            // 
            // lengthInput
            // 
            this.lengthInput.Location = new System.Drawing.Point(95, 205);
            this.lengthInput.Name = "lengthInput";
            this.lengthInput.Size = new System.Drawing.Size(166, 22);
            this.lengthInput.TabIndex = 17;
            // 
            // NewChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 327);
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