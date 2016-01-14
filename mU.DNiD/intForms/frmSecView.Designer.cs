namespace DNiD2.intForms
{
    partial class frmSecView
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
            this.components = new System.ComponentModel.Container();
            this.reaperListView1 = new ReaperTheme.Controls.ReaperListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reaperButton1 = new ReaperTheme.Controls.ReaperButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hexViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dissassembleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reaperListView1
            // 
            this.reaperListView1.BackColor = System.Drawing.Color.White;
            this.reaperListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reaperListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.reaperListView1.ForeColor = System.Drawing.Color.Gray;
            this.reaperListView1.FullRowSelect = true;
            this.reaperListView1.GridLines = true;
            this.reaperListView1.Location = new System.Drawing.Point(12, 12);
            this.reaperListView1.MultiSelect = false;
            this.reaperListView1.Name = "reaperListView1";
            this.reaperListView1.OverrideSelectedItemColor = false;
            this.reaperListView1.OwnerDraw = true;
            this.reaperListView1.SelectedItemBorder = false;
            this.reaperListView1.SelectedItemColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperListView1.Size = new System.Drawing.Size(470, 118);
            this.reaperListView1.TabIndex = 0;
            this.reaperListView1.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Light;
            this.reaperListView1.UseCompatibleStateImageBehavior = false;
            this.reaperListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name:";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "V.Offset:";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "V.Size:";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "R.Offset:";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "R.Size:";
            this.columnHeader5.Width = 74;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Flags:";
            this.columnHeader6.Width = 94;
            // 
            // reaperButton1
            // 
            this.reaperButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.reaperButton1.ButtonState = ReaperTheme.ReaperEnums.ReaperButtonState.Normal;
            this.reaperButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reaperButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.reaperButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.reaperButton1.Location = new System.Drawing.Point(190, 136);
            this.reaperButton1.Name = "reaperButton1";
            this.reaperButton1.OverrideBackColor = true;
            this.reaperButton1.OverrideHoverColor = false;
            this.reaperButton1.Size = new System.Drawing.Size(107, 31);
            this.reaperButton1.TabIndex = 1;
            this.reaperButton1.Text = "close";
            this.reaperButton1.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.reaperButton1.UseVisualStyleBackColor = false;
            this.reaperButton1.Click += new System.EventHandler(this.reaperButton1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dissassembleToolStripMenuItem,
            this.hexViewToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 48);
            // 
            // hexViewToolStripMenuItem
            // 
            this.hexViewToolStripMenuItem.Name = "hexViewToolStripMenuItem";
            this.hexViewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hexViewToolStripMenuItem.Text = "HexView";
            // 
            // dissassembleToolStripMenuItem
            // 
            this.dissassembleToolStripMenuItem.Name = "dissassembleToolStripMenuItem";
            this.dissassembleToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.dissassembleToolStripMenuItem.Text = "Disassemble";
            // 
            // frmSecView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 170);
            this.Controls.Add(this.reaperButton1);
            this.Controls.Add(this.reaperListView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSecView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Section Viewer";
            this.Load += new System.EventHandler(this.frmSecView_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaperTheme.Controls.ReaperListView reaperListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private ReaperTheme.Controls.ReaperButton reaperButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hexViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dissassembleToolStripMenuItem;
    }
}