namespace DNiD2.intForms
{
    partial class frmDisassemblyView
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
            this.reaperButton1 = new ReaperTheme.Controls.ReaperButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyBytesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyDisassemblyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reaperButton1
            // 
            this.reaperButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.reaperButton1.ButtonState = ReaperTheme.ReaperEnums.ReaperButtonState.Normal;
            this.reaperButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reaperButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.reaperButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperButton1.Location = new System.Drawing.Point(301, 338);
            this.reaperButton1.Name = "reaperButton1";
            this.reaperButton1.OverrideBackColor = true;
            this.reaperButton1.OverrideHoverColor = false;
            this.reaperButton1.Size = new System.Drawing.Size(97, 35);
            this.reaperButton1.TabIndex = 1;
            this.reaperButton1.Text = "close";
            this.reaperButton1.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.reaperButton1.UseVisualStyleBackColor = false;
            this.reaperButton1.Click += new System.EventHandler(this.reaperButton1_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(5, 32);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(689, 300);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Address:";
            this.columnHeader1.Width = 106;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Bytes:";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Disassembled:";
            this.columnHeader3.Width = 563;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAddressToolStripMenuItem,
            this.copyBytesToolStripMenuItem,
            this.copyDisassemblyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 70);
            // 
            // copyAddressToolStripMenuItem
            // 
            this.copyAddressToolStripMenuItem.Name = "copyAddressToolStripMenuItem";
            this.copyAddressToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.copyAddressToolStripMenuItem.Text = "Copy &Address...";
            this.copyAddressToolStripMenuItem.Click += new System.EventHandler(this.copyAddressToolStripMenuItem_Click);
            // 
            // copyBytesToolStripMenuItem
            // 
            this.copyBytesToolStripMenuItem.Name = "copyBytesToolStripMenuItem";
            this.copyBytesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.copyBytesToolStripMenuItem.Text = "Copy &Bytes...";
            this.copyBytesToolStripMenuItem.Click += new System.EventHandler(this.copyBytesToolStripMenuItem_Click);
            // 
            // copyDisassemblyToolStripMenuItem
            // 
            this.copyDisassemblyToolStripMenuItem.Name = "copyDisassemblyToolStripMenuItem";
            this.copyDisassemblyToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.copyDisassemblyToolStripMenuItem.Text = "Copy &Disassembly...";
            this.copyDisassemblyToolStripMenuItem.Click += new System.EventHandler(this.copyDisassemblyToolStripMenuItem_Click);
            // 
            // frmDisassemblyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 378);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.reaperButton1);
            this.MaximizeBox = false;
            this.Name = "frmDisassemblyView";
            this.Padding = new System.Windows.Forms.Padding(2, 29, 2, 2);
            this.ShowIcon = false;
            this.ShowIconInTitleBar = false;
            this.ShowInTaskbar = false;
            this.Text = "DNiD 2 - DisassemblyView [SharpDisasm]: (Reading 1kb only!)";
            this.onColorBarColorChanged += new System.EventHandler<ReaperTheme.ReaperEvents.OnColorBarColorChanged>(this.frmDisassemblyView_onColorBarColorChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ReaperTheme.Controls.ReaperButton reaperButton1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyBytesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyDisassemblyToolStripMenuItem;
    }
}