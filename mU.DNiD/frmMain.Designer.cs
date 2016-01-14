namespace DNiDGUI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtFilePath = new ReaperTheme.Controls.ReaperTextbox();
            this.reaperLabel1 = new ReaperTheme.Controls.ReaperLabel();
            this.reaperButton1 = new ReaperTheme.Controls.ReaperButton();
            this.txtEntrypoint = new ReaperTheme.Controls.ReaperTextbox();
            this.txtFileOffset = new ReaperTheme.Controls.ReaperTextbox();
            this.txtLinkerInfo = new ReaperTheme.Controls.ReaperTextbox();
            this.txtEPSection = new ReaperTheme.Controls.ReaperTextbox();
            this.txtFirstBytes = new ReaperTheme.Controls.ReaperTextbox();
            this.txtSubSystem = new ReaperTheme.Controls.ReaperTextbox();
            this.reaperLabel2 = new ReaperTheme.Controls.ReaperLabel();
            this.reaperLabel3 = new ReaperTheme.Controls.ReaperLabel();
            this.reaperLabel4 = new ReaperTheme.Controls.ReaperLabel();
            this.reaperLabel5 = new ReaperTheme.Controls.ReaperLabel();
            this.reaperLabel6 = new ReaperTheme.Controls.ReaperLabel();
            this.reaperLabel7 = new ReaperTheme.Controls.ReaperLabel();
            this.reaperButton2 = new ReaperTheme.Controls.ReaperButton();
            this.reaperButton3 = new ReaperTheme.Controls.ReaperButton();
            this.reaperButton4 = new ReaperTheme.Controls.ReaperButton();
            this.reaperTextbox8 = new ReaperTheme.Controls.ReaperTextbox();
            this.reaperButton5 = new ReaperTheme.Controls.ReaperButton();
            this.reaperButton6 = new ReaperTheme.Controls.ReaperButton();
            this.reaperButton7 = new ReaperTheme.Controls.ReaperButton();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtFilePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtFilePath.Location = new System.Drawing.Point(53, 32);
            this.txtFilePath.MultiLine = false;
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.OverrideColorBarColor = false;
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(540, 24);
            this.txtFilePath.TabIndex = 0;
            this.txtFilePath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFilePath.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.txtFilePath.UsePasswordChar = false;
            this.txtFilePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragDrop);
            this.txtFilePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragEnter);
            // 
            // reaperLabel1
            // 
            this.reaperLabel1.AutoSize = true;
            this.reaperLabel1.BackColor = System.Drawing.Color.Transparent;
            this.reaperLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperLabel1.Location = new System.Drawing.Point(5, 38);
            this.reaperLabel1.Name = "reaperLabel1";
            this.reaperLabel1.OverrideColorBarColor = false;
            this.reaperLabel1.ShowSeperator = false;
            this.reaperLabel1.Size = new System.Drawing.Size(42, 14);
            this.reaperLabel1.TabIndex = 1;
            this.reaperLabel1.Text = "File:";
            this.reaperLabel1.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            // 
            // reaperButton1
            // 
            this.reaperButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.reaperButton1.ButtonState = ReaperTheme.ReaperEnums.ReaperButtonState.Normal;
            this.reaperButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reaperButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.reaperButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperButton1.Location = new System.Drawing.Point(599, 32);
            this.reaperButton1.Name = "reaperButton1";
            this.reaperButton1.OverrideBackColor = true;
            this.reaperButton1.OverrideHoverColor = false;
            this.reaperButton1.Size = new System.Drawing.Size(50, 24);
            this.reaperButton1.TabIndex = 2;
            this.reaperButton1.Text = "...";
            this.reaperButton1.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.reaperButton1.UseVisualStyleBackColor = false;
            // 
            // txtEntrypoint
            // 
            this.txtEntrypoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtEntrypoint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtEntrypoint.Location = new System.Drawing.Point(102, 62);
            this.txtEntrypoint.MultiLine = false;
            this.txtEntrypoint.Name = "txtEntrypoint";
            this.txtEntrypoint.OverrideColorBarColor = false;
            this.txtEntrypoint.ReadOnly = true;
            this.txtEntrypoint.Size = new System.Drawing.Size(155, 24);
            this.txtEntrypoint.TabIndex = 3;
            this.txtEntrypoint.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEntrypoint.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.txtEntrypoint.UsePasswordChar = false;
            // 
            // txtFileOffset
            // 
            this.txtFileOffset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtFileOffset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtFileOffset.Location = new System.Drawing.Point(102, 92);
            this.txtFileOffset.MultiLine = false;
            this.txtFileOffset.Name = "txtFileOffset";
            this.txtFileOffset.OverrideColorBarColor = false;
            this.txtFileOffset.ReadOnly = true;
            this.txtFileOffset.Size = new System.Drawing.Size(155, 24);
            this.txtFileOffset.TabIndex = 4;
            this.txtFileOffset.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFileOffset.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.txtFileOffset.UsePasswordChar = false;
            // 
            // txtLinkerInfo
            // 
            this.txtLinkerInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtLinkerInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtLinkerInfo.Location = new System.Drawing.Point(102, 122);
            this.txtLinkerInfo.MultiLine = false;
            this.txtLinkerInfo.Name = "txtLinkerInfo";
            this.txtLinkerInfo.OverrideColorBarColor = false;
            this.txtLinkerInfo.ReadOnly = true;
            this.txtLinkerInfo.Size = new System.Drawing.Size(155, 24);
            this.txtLinkerInfo.TabIndex = 5;
            this.txtLinkerInfo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLinkerInfo.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.txtLinkerInfo.UsePasswordChar = false;
            // 
            // txtEPSection
            // 
            this.txtEPSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtEPSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtEPSection.Location = new System.Drawing.Point(438, 62);
            this.txtEPSection.MultiLine = false;
            this.txtEPSection.Name = "txtEPSection";
            this.txtEPSection.OverrideColorBarColor = false;
            this.txtEPSection.ReadOnly = true;
            this.txtEPSection.Size = new System.Drawing.Size(155, 24);
            this.txtEPSection.TabIndex = 6;
            this.txtEPSection.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEPSection.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.txtEPSection.UsePasswordChar = false;
            // 
            // txtFirstBytes
            // 
            this.txtFirstBytes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtFirstBytes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtFirstBytes.Location = new System.Drawing.Point(438, 92);
            this.txtFirstBytes.MultiLine = false;
            this.txtFirstBytes.Name = "txtFirstBytes";
            this.txtFirstBytes.OverrideColorBarColor = false;
            this.txtFirstBytes.ReadOnly = true;
            this.txtFirstBytes.Size = new System.Drawing.Size(155, 24);
            this.txtFirstBytes.TabIndex = 7;
            this.txtFirstBytes.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFirstBytes.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.txtFirstBytes.UsePasswordChar = false;
            // 
            // txtSubSystem
            // 
            this.txtSubSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtSubSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtSubSystem.Location = new System.Drawing.Point(438, 122);
            this.txtSubSystem.MultiLine = false;
            this.txtSubSystem.Name = "txtSubSystem";
            this.txtSubSystem.OverrideColorBarColor = false;
            this.txtSubSystem.ReadOnly = true;
            this.txtSubSystem.Size = new System.Drawing.Size(155, 24);
            this.txtSubSystem.TabIndex = 8;
            this.txtSubSystem.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSubSystem.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.txtSubSystem.UsePasswordChar = false;
            // 
            // reaperLabel2
            // 
            this.reaperLabel2.AutoSize = true;
            this.reaperLabel2.BackColor = System.Drawing.Color.Transparent;
            this.reaperLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperLabel2.Location = new System.Drawing.Point(12, 68);
            this.reaperLabel2.Name = "reaperLabel2";
            this.reaperLabel2.OverrideColorBarColor = false;
            this.reaperLabel2.ShowSeperator = false;
            this.reaperLabel2.Size = new System.Drawing.Size(84, 14);
            this.reaperLabel2.TabIndex = 9;
            this.reaperLabel2.Text = "Entrypoint:";
            this.reaperLabel2.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            // 
            // reaperLabel3
            // 
            this.reaperLabel3.AutoSize = true;
            this.reaperLabel3.BackColor = System.Drawing.Color.Transparent;
            this.reaperLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperLabel3.Location = new System.Drawing.Point(5, 98);
            this.reaperLabel3.Name = "reaperLabel3";
            this.reaperLabel3.OverrideColorBarColor = false;
            this.reaperLabel3.ShowSeperator = false;
            this.reaperLabel3.Size = new System.Drawing.Size(91, 14);
            this.reaperLabel3.TabIndex = 10;
            this.reaperLabel3.Text = "File Offset:";
            this.reaperLabel3.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            // 
            // reaperLabel4
            // 
            this.reaperLabel4.AutoSize = true;
            this.reaperLabel4.BackColor = System.Drawing.Color.Transparent;
            this.reaperLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperLabel4.Location = new System.Drawing.Point(5, 128);
            this.reaperLabel4.Name = "reaperLabel4";
            this.reaperLabel4.OverrideColorBarColor = false;
            this.reaperLabel4.ShowSeperator = false;
            this.reaperLabel4.Size = new System.Drawing.Size(91, 14);
            this.reaperLabel4.TabIndex = 11;
            this.reaperLabel4.Text = "Linker Info:";
            this.reaperLabel4.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            // 
            // reaperLabel5
            // 
            this.reaperLabel5.AutoSize = true;
            this.reaperLabel5.BackColor = System.Drawing.Color.Transparent;
            this.reaperLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperLabel5.Location = new System.Drawing.Point(348, 68);
            this.reaperLabel5.Name = "reaperLabel5";
            this.reaperLabel5.OverrideColorBarColor = false;
            this.reaperLabel5.ShowSeperator = false;
            this.reaperLabel5.Size = new System.Drawing.Size(84, 14);
            this.reaperLabel5.TabIndex = 12;
            this.reaperLabel5.Text = "EP Section:";
            this.reaperLabel5.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            // 
            // reaperLabel6
            // 
            this.reaperLabel6.AutoSize = true;
            this.reaperLabel6.BackColor = System.Drawing.Color.Transparent;
            this.reaperLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperLabel6.Location = new System.Drawing.Point(341, 98);
            this.reaperLabel6.Name = "reaperLabel6";
            this.reaperLabel6.OverrideColorBarColor = false;
            this.reaperLabel6.ShowSeperator = false;
            this.reaperLabel6.Size = new System.Drawing.Size(91, 14);
            this.reaperLabel6.TabIndex = 13;
            this.reaperLabel6.Text = "First Bytes:";
            this.reaperLabel6.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            // 
            // reaperLabel7
            // 
            this.reaperLabel7.AutoSize = true;
            this.reaperLabel7.BackColor = System.Drawing.Color.Transparent;
            this.reaperLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperLabel7.Location = new System.Drawing.Point(355, 128);
            this.reaperLabel7.Name = "reaperLabel7";
            this.reaperLabel7.OverrideColorBarColor = false;
            this.reaperLabel7.ShowSeperator = false;
            this.reaperLabel7.Size = new System.Drawing.Size(77, 14);
            this.reaperLabel7.TabIndex = 14;
            this.reaperLabel7.Text = "Subsystem:";
            this.reaperLabel7.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            // 
            // reaperButton2
            // 
            this.reaperButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.reaperButton2.ButtonState = ReaperTheme.ReaperEnums.ReaperButtonState.Normal;
            this.reaperButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reaperButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.reaperButton2.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperButton2.Location = new System.Drawing.Point(610, 62);
            this.reaperButton2.Name = "reaperButton2";
            this.reaperButton2.OverrideBackColor = true;
            this.reaperButton2.OverrideHoverColor = false;
            this.reaperButton2.Size = new System.Drawing.Size(30, 24);
            this.reaperButton2.TabIndex = 15;
            this.reaperButton2.Text = ">";
            this.reaperButton2.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.reaperButton2.UseVisualStyleBackColor = false;
            this.reaperButton2.Click += new System.EventHandler(this.reaperButton2_Click);
            // 
            // reaperButton3
            // 
            this.reaperButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.reaperButton3.ButtonState = ReaperTheme.ReaperEnums.ReaperButtonState.Normal;
            this.reaperButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reaperButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.reaperButton3.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperButton3.Location = new System.Drawing.Point(610, 92);
            this.reaperButton3.Name = "reaperButton3";
            this.reaperButton3.OverrideBackColor = true;
            this.reaperButton3.OverrideHoverColor = false;
            this.reaperButton3.Size = new System.Drawing.Size(30, 24);
            this.reaperButton3.TabIndex = 16;
            this.reaperButton3.Text = ">";
            this.reaperButton3.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.reaperButton3.UseVisualStyleBackColor = false;
            this.reaperButton3.Click += new System.EventHandler(this.reaperButton3_Click);
            // 
            // reaperButton4
            // 
            this.reaperButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.reaperButton4.ButtonState = ReaperTheme.ReaperEnums.ReaperButtonState.Normal;
            this.reaperButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reaperButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.reaperButton4.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperButton4.Location = new System.Drawing.Point(610, 122);
            this.reaperButton4.Name = "reaperButton4";
            this.reaperButton4.OverrideBackColor = true;
            this.reaperButton4.OverrideHoverColor = false;
            this.reaperButton4.Size = new System.Drawing.Size(30, 24);
            this.reaperButton4.TabIndex = 17;
            this.reaperButton4.Text = ">";
            this.reaperButton4.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.reaperButton4.UseVisualStyleBackColor = false;
            this.reaperButton4.Click += new System.EventHandler(this.reaperButton4_Click);
            // 
            // reaperTextbox8
            // 
            this.reaperTextbox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.reaperTextbox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperTextbox8.Location = new System.Drawing.Point(8, 181);
            this.reaperTextbox8.MultiLine = false;
            this.reaperTextbox8.Name = "reaperTextbox8";
            this.reaperTextbox8.OverrideColorBarColor = false;
            this.reaperTextbox8.ReadOnly = true;
            this.reaperTextbox8.Size = new System.Drawing.Size(648, 24);
            this.reaperTextbox8.TabIndex = 18;
            this.reaperTextbox8.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.reaperTextbox8.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.reaperTextbox8.UsePasswordChar = false;
            this.reaperTextbox8.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragDrop);
            this.reaperTextbox8.DragEnter += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragEnter);
            // 
            // reaperButton5
            // 
            this.reaperButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.reaperButton5.ButtonState = ReaperTheme.ReaperEnums.ReaperButtonState.Normal;
            this.reaperButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reaperButton5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.reaperButton5.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperButton5.Location = new System.Drawing.Point(571, 211);
            this.reaperButton5.Name = "reaperButton5";
            this.reaperButton5.OverrideBackColor = true;
            this.reaperButton5.OverrideHoverColor = false;
            this.reaperButton5.Size = new System.Drawing.Size(85, 24);
            this.reaperButton5.TabIndex = 19;
            this.reaperButton5.Text = "exit";
            this.reaperButton5.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.reaperButton5.UseVisualStyleBackColor = false;
            this.reaperButton5.Click += new System.EventHandler(this.reaperButton5_Click);
            // 
            // reaperButton6
            // 
            this.reaperButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.reaperButton6.ButtonState = ReaperTheme.ReaperEnums.ReaperButtonState.Normal;
            this.reaperButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reaperButton6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.reaperButton6.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperButton6.Location = new System.Drawing.Point(277, 211);
            this.reaperButton6.Name = "reaperButton6";
            this.reaperButton6.OverrideBackColor = true;
            this.reaperButton6.OverrideHoverColor = false;
            this.reaperButton6.Size = new System.Drawing.Size(85, 24);
            this.reaperButton6.TabIndex = 20;
            this.reaperButton6.Text = "about";
            this.reaperButton6.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.reaperButton6.UseVisualStyleBackColor = false;
            this.reaperButton6.Click += new System.EventHandler(this.reaperButton6_Click);
            // 
            // reaperButton7
            // 
            this.reaperButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.reaperButton7.ButtonState = ReaperTheme.ReaperEnums.ReaperButtonState.Normal;
            this.reaperButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reaperButton7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.reaperButton7.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reaperButton7.Location = new System.Drawing.Point(8, 211);
            this.reaperButton7.Name = "reaperButton7";
            this.reaperButton7.OverrideBackColor = true;
            this.reaperButton7.OverrideHoverColor = false;
            this.reaperButton7.Size = new System.Drawing.Size(85, 24);
            this.reaperButton7.TabIndex = 21;
            this.reaperButton7.Text = "scan";
            this.reaperButton7.Theme = ReaperTheme.ReaperEnums.ReaperTheme.Dark;
            this.reaperButton7.UseVisualStyleBackColor = false;
            this.reaperButton7.Click += new System.EventHandler(this.reaperButton7_Click);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 243);
            this.Controls.Add(this.reaperButton7);
            this.Controls.Add(this.reaperButton6);
            this.Controls.Add(this.reaperButton5);
            this.Controls.Add(this.reaperTextbox8);
            this.Controls.Add(this.reaperButton4);
            this.Controls.Add(this.reaperButton3);
            this.Controls.Add(this.reaperButton2);
            this.Controls.Add(this.reaperLabel7);
            this.Controls.Add(this.reaperLabel6);
            this.Controls.Add(this.reaperLabel5);
            this.Controls.Add(this.reaperLabel4);
            this.Controls.Add(this.reaperLabel3);
            this.Controls.Add(this.reaperLabel2);
            this.Controls.Add(this.txtSubSystem);
            this.Controls.Add(this.txtFirstBytes);
            this.Controls.Add(this.txtEPSection);
            this.Controls.Add(this.txtLinkerInfo);
            this.Controls.Add(this.txtFileOffset);
            this.Controls.Add(this.txtEntrypoint);
            this.Controls.Add(this.reaperButton1);
            this.Controls.Add(this.reaperLabel1);
            this.Controls.Add(this.txtFilePath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(2, 29, 2, 2);
            this.Text = "DNiD 2";
            this.onColorBarColorChanged += new System.EventHandler<ReaperTheme.ReaperEvents.OnColorBarColorChanged>(this.frmMain_onColorBarColorChanged);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaperTheme.Controls.ReaperTextbox txtFilePath;
        private ReaperTheme.Controls.ReaperLabel reaperLabel1;
        private ReaperTheme.Controls.ReaperButton reaperButton1;
        private ReaperTheme.Controls.ReaperTextbox txtEntrypoint;
        private ReaperTheme.Controls.ReaperTextbox txtFileOffset;
        private ReaperTheme.Controls.ReaperTextbox txtLinkerInfo;
        private ReaperTheme.Controls.ReaperTextbox txtEPSection;
        private ReaperTheme.Controls.ReaperTextbox txtFirstBytes;
        private ReaperTheme.Controls.ReaperTextbox txtSubSystem;
        private ReaperTheme.Controls.ReaperLabel reaperLabel2;
        private ReaperTheme.Controls.ReaperLabel reaperLabel3;
        private ReaperTheme.Controls.ReaperLabel reaperLabel4;
        private ReaperTheme.Controls.ReaperLabel reaperLabel5;
        private ReaperTheme.Controls.ReaperLabel reaperLabel6;
        private ReaperTheme.Controls.ReaperLabel reaperLabel7;
        private ReaperTheme.Controls.ReaperButton reaperButton2;
        private ReaperTheme.Controls.ReaperButton reaperButton3;
        private ReaperTheme.Controls.ReaperButton reaperButton4;
        private ReaperTheme.Controls.ReaperTextbox reaperTextbox8;
        private ReaperTheme.Controls.ReaperButton reaperButton5;
        private ReaperTheme.Controls.ReaperButton reaperButton6;
        private ReaperTheme.Controls.ReaperButton reaperButton7;
    }
}

