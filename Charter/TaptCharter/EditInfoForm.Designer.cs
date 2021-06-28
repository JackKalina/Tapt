
namespace TaptCharter
{
    partial class EditInfoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.charterInput = new System.Windows.Forms.TextBox();
            this.albumLabel = new System.Windows.Forms.Label();
            this.albumInput = new System.Windows.Forms.TextBox();
            this.songInfoLabel = new System.Windows.Forms.Label();
            this.artistLabel = new System.Windows.Forms.Label();
            this.artistInput = new System.Windows.Forms.TextBox();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Charter:";
            // 
            // charterInput
            // 
            this.charterInput.Location = new System.Drawing.Point(79, 121);
            this.charterInput.Margin = new System.Windows.Forms.Padding(2);
            this.charterInput.Name = "charterInput";
            this.charterInput.Size = new System.Drawing.Size(126, 20);
            this.charterInput.TabIndex = 28;
            // 
            // albumLabel
            // 
            this.albumLabel.AutoSize = true;
            this.albumLabel.Location = new System.Drawing.Point(15, 98);
            this.albumLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.albumLabel.Name = "albumLabel";
            this.albumLabel.Size = new System.Drawing.Size(39, 13);
            this.albumLabel.TabIndex = 27;
            this.albumLabel.Text = "Album:";
            // 
            // albumInput
            // 
            this.albumInput.Location = new System.Drawing.Point(79, 94);
            this.albumInput.Margin = new System.Windows.Forms.Padding(2);
            this.albumInput.Name = "albumInput";
            this.albumInput.Size = new System.Drawing.Size(126, 20);
            this.albumInput.TabIndex = 26;
            // 
            // songInfoLabel
            // 
            this.songInfoLabel.AutoSize = true;
            this.songInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songInfoLabel.Location = new System.Drawing.Point(30, 9);
            this.songInfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.songInfoLabel.Name = "songInfoLabel";
            this.songInfoLabel.Size = new System.Drawing.Size(150, 18);
            this.songInfoLabel.TabIndex = 25;
            this.songInfoLabel.Text = "Edit Song Information";
            this.songInfoLabel.Click += new System.EventHandler(this.songInfoLabel_Click);
            // 
            // artistLabel
            // 
            this.artistLabel.AutoSize = true;
            this.artistLabel.Location = new System.Drawing.Point(15, 72);
            this.artistLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(33, 13);
            this.artistLabel.TabIndex = 24;
            this.artistLabel.Text = "Artist:";
            // 
            // artistInput
            // 
            this.artistInput.Location = new System.Drawing.Point(79, 68);
            this.artistInput.Margin = new System.Windows.Forms.Padding(2);
            this.artistInput.Name = "artistInput";
            this.artistInput.Size = new System.Drawing.Size(126, 20);
            this.artistInput.TabIndex = 23;
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(79, 42);
            this.nameInput.Margin = new System.Windows.Forms.Padding(2);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(126, 20);
            this.nameInput.TabIndex = 22;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(15, 46);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 21;
            this.nameLabel.Text = "Name:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(11, 155);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(84, 19);
            this.cancelButton.TabIndex = 31;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(113, 156);
            this.okButton.Margin = new System.Windows.Forms.Padding(2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(85, 19);
            this.okButton.TabIndex = 30;
            this.okButton.Text = "Save";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // EditInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 200);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.charterInput);
            this.Controls.Add(this.albumLabel);
            this.Controls.Add(this.albumInput);
            this.Controls.Add(this.songInfoLabel);
            this.Controls.Add(this.artistLabel);
            this.Controls.Add(this.artistInput);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.nameLabel);
            this.Name = "EditInfoForm";
            this.Text = "EditInfoForm";
            this.Load += new System.EventHandler(this.EditInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox charterInput;
        private System.Windows.Forms.Label albumLabel;
        private System.Windows.Forms.TextBox albumInput;
        private System.Windows.Forms.Label songInfoLabel;
        private System.Windows.Forms.Label artistLabel;
        private System.Windows.Forms.TextBox artistInput;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}