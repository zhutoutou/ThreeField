namespace ZIT.ThreeField.MainUI
{
    partial class MainUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.lblBssConnectStatus = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.lblDBRConnectStaus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDBLConnectStaus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MenuSystem = new System.Windows.Forms.MenuStrip();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemViewLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExitSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.panelStatus.SuspendLayout();
            this.MenuSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBssConnectStatus
            // 
            this.lblBssConnectStatus.AutoSize = true;
            this.lblBssConnectStatus.ForeColor = System.Drawing.Color.Red;
            this.lblBssConnectStatus.Location = new System.Drawing.Point(127, 13);
            this.lblBssConnectStatus.Name = "lblBssConnectStatus";
            this.lblBssConnectStatus.Size = new System.Drawing.Size(29, 12);
            this.lblBssConnectStatus.TabIndex = 2;
            this.lblBssConnectStatus.Text = "断开";
            // 
            // panelStatus
            // 
            this.panelStatus.AutoSize = true;
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelStatus.Controls.Add(this.lblDBRConnectStaus);
            this.panelStatus.Controls.Add(this.label4);
            this.panelStatus.Controls.Add(this.lblDBLConnectStaus);
            this.panelStatus.Controls.Add(this.label2);
            this.panelStatus.Controls.Add(this.label6);
            this.panelStatus.Controls.Add(this.lblBssConnectStatus);
            this.panelStatus.Location = new System.Drawing.Point(0, 299);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(637, 43);
            this.panelStatus.TabIndex = 10;
            // 
            // lblDBRConnectStaus
            // 
            this.lblDBRConnectStaus.AutoSize = true;
            this.lblDBRConnectStaus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDBRConnectStaus.ForeColor = System.Drawing.Color.Red;
            this.lblDBRConnectStaus.Location = new System.Drawing.Point(555, 15);
            this.lblDBRConnectStaus.Name = "lblDBRConnectStaus";
            this.lblDBRConnectStaus.Size = new System.Drawing.Size(29, 12);
            this.lblDBRConnectStaus.TabIndex = 6;
            this.lblDBRConnectStaus.Text = "断开";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(460, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "对方数据库连接：";
            // 
            // lblDBLConnectStaus
            // 
            this.lblDBLConnectStaus.AutoSize = true;
            this.lblDBLConnectStaus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDBLConnectStaus.ForeColor = System.Drawing.Color.Red;
            this.lblDBLConnectStaus.Location = new System.Drawing.Point(354, 15);
            this.lblDBLConnectStaus.Name = "lblDBLConnectStaus";
            this.lblDBLConnectStaus.Size = new System.Drawing.Size(29, 12);
            this.lblDBLConnectStaus.TabIndex = 4;
            this.lblDBLConnectStaus.Text = "断开";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "本地数据库连接：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "120业务服务器：";
            // 
            // MenuSystem
            // 
            this.MenuSystem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统ToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.MenuSystem.Location = new System.Drawing.Point(0, 0);
            this.MenuSystem.Name = "MenuSystem";
            this.MenuSystem.Size = new System.Drawing.Size(634, 25);
            this.MenuSystem.TabIndex = 11;
            this.MenuSystem.Text = "menuStrip1";
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemViewLog,
            this.menuItemExitSystem});
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.系统ToolStripMenuItem.Text = "系统(S)";
            // 
            // menuItemViewLog
            // 
            this.menuItemViewLog.Name = "menuItemViewLog";
            this.menuItemViewLog.Size = new System.Drawing.Size(139, 22);
            this.menuItemViewLog.Text = "查看日志(L)";
            this.menuItemViewLog.Click += new System.EventHandler(this.menuItemViewLog_Click);
            // 
            // menuItemExitSystem
            // 
            this.menuItemExitSystem.Name = "menuItemExitSystem";
            this.menuItemExitSystem.Size = new System.Drawing.Size(139, 22);
            this.menuItemExitSystem.Text = "退出系统(E)";
            this.menuItemExitSystem.Click += new System.EventHandler(this.menuItemExitSystem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAbout});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(H)";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Size = new System.Drawing.Size(116, 22);
            this.menuItemAbout.Text = "关于(A)";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "服务正在运行中...";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(508, 44);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(105, 30);
            this.btnTest.TabIndex = 13;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 342);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.MenuSystem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuSystem;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 381);
            this.MinimumSize = new System.Drawing.Size(650, 381);
            this.Name = "MainUI";
            this.Text = "三字段服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainUI_FormClosing);
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.MenuSystem.ResumeLayout(false);
            this.MenuSystem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBssConnectStatus;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip MenuSystem;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewLog;
        private System.Windows.Forms.ToolStripMenuItem menuItemExitSystem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblDBLConnectStaus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDBRConnectStaus;
        private System.Windows.Forms.Label label4;
    }
}

