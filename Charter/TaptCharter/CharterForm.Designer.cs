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
            this.chartVisualizer = new TaptCharter.ChartVisualizer();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(990, 28);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newChartToolStripMenuItem
            // 
            this.newChartToolStripMenuItem.Name = "newChartToolStripMenuItem";
            this.newChartToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newChartToolStripMenuItem.Text = "New Chart";
            this.newChartToolStripMenuItem.Click += new System.EventHandler(this.newChartToolStripMenuItem_Click);
            // 
            // openChartToolStripMenuItem
            // 
            this.openChartToolStripMenuItem.Name = "openChartToolStripMenuItem";
            this.openChartToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openChartToolStripMenuItem.Text = "Open Chart";
            this.openChartToolStripMenuItem.Click += new System.EventHandler(this.openChartToolStripMenuItem_Click);
            // 
            // saveChartToolStripMenuItem
            // 
            this.saveChartToolStripMenuItem.Enabled = false;
            this.saveChartToolStripMenuItem.Name = "saveChartToolStripMenuItem";
            this.saveChartToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveChartToolStripMenuItem.Text = "Save Chart";
            // 
            // chartVisualizer
            // 
            this.chartVisualizer.Location = new System.Drawing.Point(12, 31);
            this.chartVisualizer.MouseHoverUpdatesOnly = false;
            this.chartVisualizer.Name = "chartVisualizer";
            this.chartVisualizer.Size = new System.Drawing.Size(966, 676);
            this.chartVisualizer.TabIndex = 1;
            this.chartVisualizer.Text = "chartVisualizer";
            this.chartVisualizer.Click += new System.EventHandler(this.chartVisualizer_Click);
            // 
            // CharterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 719);
            this.Controls.Add(this.chartVisualizer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
    }
}

