namespace DNiD2.intForms
{
    partial class frmHexView
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
            this.button1 = new System.Windows.Forms.Button();
            this.hexBox1 = new Be.Windows.Forms.HexBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = ".close.";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hexBox1
            // 
            this.hexBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hexBox1.Location = new System.Drawing.Point(12, 12);
            this.hexBox1.Name = "hexBox1";
            this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox1.Size = new System.Drawing.Size(846, 307);
            this.hexBox1.TabIndex = 3;
            // 
            // frmHexView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 363);
            this.Controls.Add(this.hexBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmHexView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DNiD 2 - HexView [Be.HeBox]: (Reading 1kb only!)";
            this.Load += new System.EventHandler(this.frmHexView_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private Be.Windows.Forms.HexBox hexBox1;
    }
}