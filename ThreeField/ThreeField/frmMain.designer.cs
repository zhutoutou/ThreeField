namespace ZIT.ThreeField.MainUI
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuViewLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tabChannel = new System.Windows.Forms.TabControl();
            this.tabPageTFChannel = new System.Windows.Forms.TabPage();
            this.GridTF = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.tabChannel.SuspendLayout();
            this.tabPageTFChannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridTF)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "SysMenu";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuViewLog,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(59, 21);
            this.menuFile.Text = "系统(S)";
            // 
            // MenuViewLog
            // 
            this.MenuViewLog.Name = "MenuViewLog";
            this.MenuViewLog.Size = new System.Drawing.Size(139, 22);
            this.MenuViewLog.Text = "查看日志(L)";
            this.MenuViewLog.Click += new System.EventHandler(this.MenuViewLog_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(139, 22);
            this.menuExit.Text = "退出系统(E)";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(61, 21);
            this.menuHelp.Text = "帮助(H)";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(116, 22);
            this.menuAbout.Text = "关于(A)";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // tabChannel
            // 
            this.tabChannel.Controls.Add(this.tabPageTFChannel);
            this.tabChannel.Location = new System.Drawing.Point(0, 28);
            this.tabChannel.Name = "tabChannel";
            this.tabChannel.SelectedIndex = 0;
            this.tabChannel.Size = new System.Drawing.Size(624, 328);
            this.tabChannel.TabIndex = 2;
            // 
            // tabPageTFChannel
            // 
            this.tabPageTFChannel.Controls.Add(this.GridTF);
            this.tabPageTFChannel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.tabPageTFChannel.Location = new System.Drawing.Point(4, 22);
            this.tabPageTFChannel.Name = "tabPageTFChannel";
            this.tabPageTFChannel.Size = new System.Drawing.Size(616, 302);
            this.tabPageTFChannel.TabIndex = 0;
            this.tabPageTFChannel.Text = "三字段服务通道连接(0)";
            this.tabPageTFChannel.UseVisualStyleBackColor = true;
            // 
            // GridTF
            // 
            this.GridTF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridTF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridTF.Location = new System.Drawing.Point(0, 0);
            this.GridTF.Name = "GridTF";
            this.GridTF.ReadOnly = true;
            this.GridTF.RowHeadersVisible = false;
            this.GridTF.RowTemplate.Height = 23;
            this.GridTF.Size = new System.Drawing.Size(616, 302);
            this.GridTF.TabIndex = 0;
            this.GridTF.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GridYM_DataBindingComplete);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(624, 404);
            this.Controls.Add(this.tabChannel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(640, 443);
            this.MinimumSize = new System.Drawing.Size(640, 443);
            this.Name = "frmMain";
            this.Text = "三字段服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabChannel.ResumeLayout(false);
            this.tabPageTFChannel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridTF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.TabControl tabChannel;
        private System.Windows.Forms.TabPage tabPageTFChannel;
        private System.Windows.Forms.DataGridView GridTF;
        private System.Windows.Forms.ToolStripMenuItem MenuViewLog;
    }
}

