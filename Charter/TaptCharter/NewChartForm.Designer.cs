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
            this.albumTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.mp3FileNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bpmInput
            // 
            this.bpmInput.Location = new System.Drawing.Point(70, 169);
            this.bpmInput.Name = "bpmInput";
            this.bpmInput.Size = new System.Drawing.Size(155, 22);
            this.bpmInput.TabIndex = 0;
            // 
            // bpmLabel
            // 
            this.bpmLabel.AutoSize = true;
            this.bpmLabel.Location = new System.Drawing.Point(14, 172);
            this.bpmLabel.Name = "bpmLabel";
            this.bpmLabel.Size = new System.Drawing.Size(41, 17);
            this.bpmLabel.TabIndex = 1;
            this.bpmLabel.Text = "BPM:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(14, 54);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(49, 17);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name:";
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(70, 48);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(155, 22);
            this.nameInput.TabIndex = 3;
            // 
            // artistInput
            // 
            this.artistInput.Location = new System.Drawing.Point(70, 89);
            this.artistInput.Name = "artistInput";
            this.artistInput.Size = new System.Drawing.Size(155, 22);
            this.artistInput.TabIndex = 5;
            // 
            // artistLabel
            // 
            this.artistLabel.AutoSize = true;
            this.artistLabel.Location = new System.Drawing.Point(15, 92);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(44, 17);
            this.artistLabel.TabIndex = 6;
            this.artistLabel.Text = "Artist:";
            // 
            // songInfoLabel
            // 
            this.songInfoLabel.AutoSize = true;
            this.songInfoLabel.Location = new System.Drawing.Point(17, 13);
            this.songInfoLabel.Name = "songInfoLabel";
            this.songInfoLabel.Size = new System.Drawing.Size(115, 17);
            this.songInfoLabel.TabIndex = 7;
            this.songInfoLabel.Text = "Song Information";
            // 
            // albumLabel
            // 
            this.albumLabel.AutoSize = true;
            this.albumLabel.Location = new System.Drawing.Point(14, 131);
            this.albumLabel.Name = "albumLabel";
            this.albumLabel.Size = new System.Drawing.Size(51, 17);
            this.albumLabel.TabIndex = 9;
            this.albumLabel.Text = "Album:";
            // 
            // albumTextBox
            // 
            this.albumTextBox.Location = new System.Drawing.Point(70, 128);
            this.albumTextBox.Name = "albumTextBox";
            this.albumTextBox.Size = new System.Drawing.Size(155, 22);
            this.albumTextBox.TabIndex = 8;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "mp3";
            this.openFileDialog.Filter = "mp3 Files (.mp3)|*.mp3";
            this.openFileDialog.Title = "Open File...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(17, 270);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(13, 206);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(231, 23);
            this.openFileButton.TabIndex = 13;
            this.openFileButton.Text = "Open mp3 file...";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // mp3FileNameTextBox
            // 
            this.mp3FileNameTextBox.Location = new System.Drawing.Point(13, 236);
            this.mp3FileNameTextBox.Name = "mp3FileNameTextBox";
            this.mp3FileNameTextBox.ReadOnly = true;
            this.mp3FileNameTextBox.Size = new System.Drawing.Size(231, 22);
            this.mp3FileNameTextBox.TabIndex = 14;
            // 
            // NewChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 305);
            this.Controls.Add(this.mp3FileNameTextBox);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.albumLabel);
            this.Controls.Add(this.albumTextBox);
            this.Controls.Add(this.songInfoLabel);
            this.Controls.Add(this.artistLabel);
            this.Controls.Add(this.artistInput);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.bpmLabel);
            this.Controls.Add(this.bpmInput);
            this.Name = "NewChartForm";
            this.Text = "NewChartForm";
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
        private System.Windows.Forms.TextBox albumTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.TextBox mp3FileNameTextBox;
    }
}