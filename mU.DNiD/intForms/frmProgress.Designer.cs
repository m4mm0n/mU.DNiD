namespace DNiD2.intForms
{
    partial class frmProgress
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
            this.szProgress = new System.Windows.Forms.Label();
            this.pBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // szProgress
            // 
            this.szProgress.AutoSize = true;
            this.szProgress.Location = new System.Drawing.Point(12, 52);
            this.szProgress.Name = "szProgress";
            this.szProgress.Size = new System.Drawing.Size(0, 13);
            this.szProgress.TabIndex = 1;
            // 
            // pBar1
            // 
            this.pBar1.Location = new System.Drawing.Point(12, 12);
            this.pBar1.Maximum = 1024;
            this.pBar1.Name = "pBar1";
            this.pBar1.Size = new System.Drawing.Size(391, 29);
            this.pBar1.TabIndex = 2;
            this.pBar1.Value = 50;
            // 
            // frmProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 83);
            this.ControlBox = false;
            this.Controls.Add(this.pBar1);
            this.Controls.Add(this.szProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProgress";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProgress";
            this.Load += new System.EventHandler(this.frmProgress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label szProgress;
        private System.Windows.Forms.ProgressBar pBar1;
    }
}