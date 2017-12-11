using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZIT.ThreeField.Controller;
using System.ServiceModel;
using ZIT.ThreeField.TFWCF;

namespace ZIT.ThreeField.MainUI
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// 将WCF发布在本机上
        /// </summary>
        public ServiceHost host;

        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化应用程序
        /// </summary>
        private void InitProgram()
        {
            CoreService control = CoreService.GetInstance();
            control.ServerConnectedClientChanged += Server_ConnectedClientChanged;
            control.StartService();

            //本机发布WCF服务
            host = new ServiceHost(typeof(ThreeFieldWCF));
            host.Open();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "确定要退出么？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    CoreService.GetInstance().StopService();
                    Thread.Sleep(1000);
                    System.Environment.Exit(System.Environment.ExitCode);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Error, ex.Message, new LogUtility.RunningPlace("frmMain", "frmMain_FormClosing"), "UI报错");
            }
        }


        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                InitGridTF();

                Application.DoEvents();
                MethodInvoker init = new MethodInvoker(InitProgram);
                init.BeginInvoke(null, null);
            }
            catch (Exception ex)
            {
                LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Error, ex.Message, new LogUtility.RunningPlace("frmMain", "frmMain_Load"), "UI报错");
            }
        }   
        
        /// <summary>
        /// 处理服务连接客户端改变事件
        /// </summary>
        private void Server_ConnectedClientChanged(object sender, UnitsEventArgs e)
        {

            tabPageTFChannel.BeginInvoke(new MethodInvoker(() =>
            {
                tabPageTFChannel.Text = "服务通道连接(" + e.Units.Count.ToString() + ")";
            }));

            GridTF.BeginInvoke(new MethodInvoker(() =>
            {
                GridTF.DataSource = e.Units;
                GridTF.Refresh();
            }));
        }
        
        /// <summary>
        /// 初始化GridYM列
        /// </summary>
        private void InitGridTF()
        {
            GridTF.ReadOnly = true;
            GridTF.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.Name = "IPAddress";
            c1.HeaderText = "IP地址";
            c1.DataPropertyName = "IPAddress";
            c1.Width = 120;

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.Name = "UnitName";
            c2.HeaderText = "单位类型";
            c2.DataPropertyName = "UnitName";
            c2.Width = 190;

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.Name = "UnitCode";
            c3.HeaderText = "行政编码";
            c3.DataPropertyName = "UnitCode";
            c3.Width = 80;

            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
            c4.Name = "Status";
            c4.DataPropertyName = "Status";
            c4.HeaderText = "连接状态";
            c4.Width = 80;

            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
            c5.Name = "ConnectedTime";
            c5.DataPropertyName = "ConnectedTime";
            c5.HeaderText = "连接时间";
            c5.Width = 130;

            GridTF.Columns.Add(c1);
            GridTF.Columns.Add(c2);
            GridTF.Columns.Add(c3);
            GridTF.Columns.Add(c4);
            GridTF.Columns.Add(c5);
        }

        private void GridYM_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (GridTF.CurrentRow != null)
            {
                GridTF.CurrentRow.Selected = false;
            }  
        }



        /// <summary>
        /// 查看日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuViewLog_Click(object sender, EventArgs e)
        {
            try
            {
                string strLogPath;
                strLogPath = Directory.GetCurrentDirectory();
                strLogPath += "\\Log\\";
                if (Directory.Exists(strLogPath))
                {
                    Process.Start("explorer.exe", strLogPath);
                }
                else
                {
                    MessageBox.Show("未检测到日志文件目录！");
                }
            }
            catch { }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        private void cmdtest_Click(object sender, EventArgs e)
        {
            if (CoreService.GetInstance().ts != null) {
                CoreService.GetInstance().ts.BroadCastMessage("[2050ZJHM: " + txtPhone.Text.Trim() + " *#]", Model.ClientType.TF);
            }
        }
    }
}
