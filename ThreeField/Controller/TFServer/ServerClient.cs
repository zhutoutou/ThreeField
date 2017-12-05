using System;
using ZIT.Communication.Comm.Communication.Messages;
using ZIT.ThreeField.Model;

namespace ZIT.ThreeField.Controller
{
    public class ServerClient
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string strClientIP;
        /// <summary>
        /// 端口
        /// </summary>
        public string strClientPort;
        /// <summary>
        /// 客户端ID
        /// </summary>
        public long intClientID;
        /// <summary>
        /// 单位行政编号
        /// </summary>
        public string UnitCode;
        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName;
        /// <summary>
        /// 单位类型
        /// </summary>
        public ClientType UnitType;
        /// <summary>
        /// 连接时间
        /// </summary>
        public DateTime dtClientConnTime;
        /// <summary>
        /// 网络状态
        /// </summary>
        public NetStatus Status;

        /// <summary>
        /// 服务器
        /// </summary>
        public TFServer TFServer;


        private ThreeFieldMsgHandler handler;

        public ServerClient(TFServer server)
        {
            Status = NetStatus.DisConnected;
            dtClientConnTime = DateTime.MinValue;
            UnitCode = "";
            UnitName = "";
            UnitType = ClientType.UnKnow;
            TFServer = server;
            handler = new ThreeFieldMsgHandler(this);
        }

        public void MessageReceived(object sender, MessageEventArgs e)
        {
            try
            {
                handler.Message_Handler(sender, e);
            }
            catch (Exception ex)
            {
                LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Error, ex.Message.ToString(), new LogUtility.RunningPlace("ServerClient", "MessageReceived"), "通讯报错");
            }
        }

        public void SendMessage(ScsTextMessage message)
        {
            try
            {
                TFServer.ScsServer.Clients[this.intClientID].SendMessage(message);
                LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Info, "Send message Unitcode is " + UnitCode + " Port is " + TFServer.ServerPort.ToString() + ":" + message.Text, new LogUtility.RunningPlace("ServerClient", "SendMessage"), "SendMsg");
            }
            catch (Exception ex)
            {
                LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Error, ex.Message.ToString(), new LogUtility.RunningPlace("ServerClient", "SendMessage"), "通讯报错");
            }
        }
    }
}