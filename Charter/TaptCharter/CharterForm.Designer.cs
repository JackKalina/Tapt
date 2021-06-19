namespace TaptCharter
{
    partial class CharterForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openChartDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartVisualizer1 = new TaptCharter.ChartVisualizer();
            this.chartVisualizer = new TaptCharter.ChartVisualizer();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(742, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newChartToolStripMenuItem,
            this.openChartToolStripMenuItem,
            this.saveChartToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newChartToolStripMenuItem
            // 
            this.newChartToolStripMenuItem.Name = "newChartToolStripMenuItem";
            this.newChartToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.newChartToolStripMenuItem.Text = "New Chart";
            this.newChartToolStripMenuItem.Click += new System.EventHandler(this.newChartToolStripMenuItem_Click);
            // 
            // openChartToolStripMenuItem
            // 
            this.openChartToolStripMenuItem.Name = "openChartToolStripMenuItem";
            this.openChartToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.openChartToolStripMenuItem.Text = "Open Chart";
            this.openChartToolStripMenuItem.Click += new System.EventHandler(this.openChartToolStripMenuItem_Click);
            // 
            // saveChartToolStripMenuItem
            // 
            this.saveChartToolStripMenuItem.Enabled = false;
            this.saveChartToolStripMenuItem.Name = "saveChartToolStripMenuItem";
            this.saveChartToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.saveChartToolStripMenuItem.Text = "Save Chart";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.songInfoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // songInfoToolStripMenuItem
            // 
            this.songInfoToolStripMenuItem.Enabled = false;
            this.songInfoToolStripMenuItem.Name = "songInfoToolStripMenuItem";
            this.songInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.songInfoToolStripMenuItem.Text = "Song Info";
            this.songInfoToolStripMenuItem.Click += new System.EventHandler(this.songInfoToolStripMenuItem_Click);
            // 
            // chartVisualizer1
            // 
            this.chartVisualizer1.Location = new System.Drawing.Point(9, 25);
            this.chartVisualizer1.Margin = new System.Windows.Forms.Padding(2);
            this.chartVisualizer1.MouseHoverUpdatesOnly = false;
            this.chartVisualizer1.Name = "chartVisualizer1";
            this.chartVisualizer1.Size = new System.Drawing.Size(724, 549);
            this.chartVisualizer1.TabIndex = 6;
            this.chartVisualizer1.Text = "chartVisualizer1";
            // 
            // chartVisualizer
            // 
            this.chartVisualizer.Location = new System.Drawing.Point(0, 0);
            this.chartVisualizer.Margin = new System.Windows.Forms.Padding(2);
            this.chartVisualizer.MouseHoverUpdatesOnly = false;
            this.chartVisualizer.Name = "chartVisualizer";
            this.chartVisualizer.Size = new System.Drawing.Size(0, 0);
            this.chartVisualizer.TabIndex = 0;
            // 
            // CharterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 584);
            this.Controls.Add(this.chartVisualizer1);
            this.Controls.Add(this.chartVisualizer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CharterForm";
            this.Text = "Charter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChartVisualizer chartVisualizer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveChartToolStripMenuItem;
        private ChartVisualizer chartVisualizer1;
        private System.Windows.Forms.FolderBrowserDialog openChartDialog;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem songInfoToolStripMenuItem;
    }
}

