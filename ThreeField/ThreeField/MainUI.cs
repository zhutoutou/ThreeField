using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using ZIT.ThreeField.Controller;

namespace ZIT.ThreeField.MainUI
{
    public partial class MainUI : Form
    {
        /// <summary>
        /// 调用初始化网络委托
        /// </summary>
        public delegate void InvokeInitNetwork();

        /// <summary>
        /// 构造函数
        /// </summary>
        public MainUI()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainUI_Load(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                MethodInvoker init = new MethodInvoker(InitProgram);
                init.BeginInvoke(null, null);
            }
            catch (Exception ex)
            {
                LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Error, ex.Message.ToString(), new LogUtility.RunningPlace("MainUI", "MainUI_Load"), "主窗体报错");
            }

        }

        /// <summary>
        /// 初始化应用程序
        /// </summary>
        private void InitProgram()
        {
            CoreService control = CoreService.GetInstance();
            control. += BServer_ConnectionStatusChanged;
            control.StartService();
        }

        /// <summary>
        /// 与120业务服务器连接状态改变事件
        /// </summary>
        private void BServer_ConnectionStatusChanged(object sender, StatusEventArgs e)
        {
            lblBssConnectStatus.BeginInvoke(new MethodInvoker(() =>
            {
                switch (e.Status)
                {
                    case NetStatus.DisConnected:
                        lblBssConnectStatus.Text = "断开";
                        lblBssConnectStatus.ForeColor = Color.Red;
                        break;
                    case NetStatus.Connected:
                        lblBssConnectStatus.Text = "已连接";
                        lblBssConnectStatus.ForeColor = Color.Green;
                        break;
                    case NetStatus.Login:
                        lblBssConnectStatus.Text = "已登录";
                        lblBssConnectStatus.ForeColor = Color.Green;
                        break;
                    default:
                        break;
                }
            }));
        }

        /// <summary>
        /// 与数据库连接状态改变事件
        /// </summary>
        private void DBL_ConnectionStatusChanged(object sender, StatusEventArgs e)
        {
            lblDBLConnectStaus.BeginInvoke(new MethodInvoker(() =>
            {
                switch (e.Status)
                {
                    case NetStatus.DisConnected:
                        lblDBLConnectStaus.Text = "断开";
                        lblDBLConnectStaus.ForeColor = Color.Red;
                        break;
                    case NetStatus.Connected:
                        lblDBLConnectStaus.Text = "已连接";
                        lblDBLConnectStaus.ForeColor = Color.Green;
                        break;
                    default:
                        break;
                }
            }));
        }


        /// <summary>
        /// 与数据库连接状态改变事件
        /// </summary>
        private void DBR_ConnectionStatusChanged(object sender, StatusEventArgs e)
        {
            lblDBRConnectStaus.BeginInvoke(new MethodInvoker(() =>
            {
                switch (e.Status)
                {
                    case NetStatus.DisConnected:
                        lblDBRConnectStaus.Text = "断开";
                        lblDBRConnectStaus.ForeColor = Color.Red;
                        break;
                    case NetStatus.Connected:
                        lblDBRConnectStaus.Text = "已连接";
                        lblDBRConnectStaus.ForeColor = Color.Green;
                        break;
                    default:
                        break;
                }
            }));
        }
        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainUI_FormClosing(object sender, FormClosingEventArgs e)
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
            catch (System.Exception ex)
            {
                LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Error, ex.Message.ToString(), new LogUtility.RunningPlace("MainUI", "MainUI_FormClosing"), "主窗体报错");
            }
        }

        private void menuItemViewLog_Click(object sender, EventArgs e)
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
    

        private void menuItemExitSystem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "确定要退出么？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    CoreService.GetInstance().StopService();
                    Thread.Sleep(1000);
                    System.Environment.Exit(System.Environment.ExitCode);
                }
            }
            catch (System.Exception ex)
            {
                LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Error, ex.Message.ToString(), new LogUtility.RunningPlace("MainUI", "menuItemExitSystem_Click"), "主窗体报错");

            }
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
         

        }
    }
}
