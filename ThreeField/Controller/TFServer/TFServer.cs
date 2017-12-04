using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using ZIT.Communication.Comm.Communication.EndPoints.Tcp;
using ZIT.Communication.Comm.Communication;
using ZIT.Communication.Comm.Communication.Messages;
using ZIT.Communication.Comm.Server;
using ZIT.ThreeField.Model;

namespace ZIT.ThreeField.Controller
{
    public class RouteServer
    {
        /// <summary>
        /// 与YMChannel连接客户端改变事件
        /// </summary>
        public event EventHandler<StatusEventArgs> ServerConnectedClientChanged;

        internal IScsServer ScsServer;

        public short ServerPort;

        /// <summary>
        /// 在线的客户端
        /// </summary>
        public IList<ServerClient> OnlineClents;

        public ReaderWriterLockSlim OnlineClentsLock;


        public RouteServer()
        {
            OnlineClentsLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion); ;
            OnlineClents = new List<ServerClient>();
        }

        public void Start()
        {
            //check CallInChannel client
            ThreadPool.QueueUserWorkItem(new WaitCallback(CheckConnectedStatus_Thread), SysParameters.SharkHandsInterval);

            //Create a server that listens gParam.sLocalPort TCP port for incoming connections
            ScsServer = ScsServerFactory.CreateServer(new ScsTcpEndPoint(ServerPort));

            //Register events of the server to be informed about clients
            ScsServer.ClientConnected += Server_ClientConnected;
            ScsServer.ClientDisconnected += Server_ClientDisconnected;
            //Start the server
            ScsServer.Start();
        }

        public void Stop()
        { }

        /// <summary>
        /// //客户端已连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Server_ClientConnected(object sender, ServerClientEventArgs e)
        {
            //try
            //{
            ServerClient Client = new ServerClient(this);
            Client.dtClientConnTime = DateTime.Now;
            Client.strClientIP = ((ScsTcpEndPoint)e.Client.RemoteEndPoint).IpAddress;
            Client.strClientPort = ((ScsTcpEndPoint)e.Client.RemoteEndPoint).TcpPort.ToString();
            Client.intClientID = e.Client.ClientId;
            Client.Status = NetStatus.Connected;
            e.Client.MessageReceived += new EventHandler<MessageEventArgs>(Client.MessageReceived);
            OnlineClentsLock.EnterWriteLock();
            try
            {
                OnlineClents.Add(Client);
            }
            finally
            {
                OnlineClentsLock.ExitWriteLock();
            }
            OnServerConnectedClientChanged();

        }

        /// <summary>
        /// 客户端断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Server_ClientDisconnected(object sender, ServerClientEventArgs e)
        {
            try
            {
                OnlineClentsLock.EnterWriteLock();
                try
                {
                    foreach (ServerClient Client in OnlineClents)
                    {
                        if (Client.intClientID == e.Client.ClientId)
                        {
                            Client.Status = NetStatus.DisConnected;
                            OnlineClents.Remove(Client);
                            e.Client.MessageReceived -= new EventHandler<MessageEventArgs>(Client.MessageReceived);
                            break;
                        }
                    }
                }
                finally
                {
                    OnlineClentsLock.ExitWriteLock();
                }
                OnServerConnectedClientChanged();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("Error Occurred", ex);
            }
        }

        /// <summary>
        /// 根据行政编码获取在线的ServerClient
        /// </summary>
        /// <param name="UnitCode"></param>
        /// <returns></returns>
        public ServerClient GetServerClientByUnitCode(string UnitCode)
        {
            ServerClient sc = null;
            OnlineClentsLock.EnterWriteLock();
            try
            {
                foreach (ServerClient Client in OnlineClents)
                {
                    if (Client.UnitCode == UnitCode)
                    {
                        sc = Client;
                        break;
                    }
                }
            }
            finally
            {
                OnlineClentsLock.ExitWriteLock();
            }
            return sc;
        }


        /// <summary>
        /// Raises ServerConnectedClientChanged event.
        /// </summary>
        /// <param name="message">Received message</param>
        public virtual void OnServerConnectedClientChanged()
        {
            var handler = ServerConnectedClientChanged;
            if (handler != null)
            {
                List<OnlineUnit> units = new List<OnlineUnit>();
                foreach (var item in OnlineClents)
                {
                    string status = "";
                    switch (item.Status)
                    {
                        case NetStatus.Connected:
                            status = "已连接";
                            break;
                        case NetStatus.Login:
                            status = "已登录";
                            break;
                        case NetStatus.DisConnected:
                            status = "已断开";
                            break;
                        default:
                            break;
                    }
                    OnlineUnit unit = new OnlineUnit();
                    unit.IPAddress = item.strClientIP;
                    unit.Status = status;
                    unit.UnitName = item.UnitName;
                    unit.UnitCode = item.UnitCode;
                    unit.ConnectedTime = item.dtClientConnTime.ToString("yyyy-MM-dd HH:mm:ss");

                    units.Add(unit);
                }

                handler(this, new UnitsEventArgs(units));
            }
        }

        /// <summary>
        /// 检测YMChannel client是否正常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckConnectedStatus_Thread(object e)
        {
            int SharkHandsTime = int.Parse(e.ToString());
            int CheckConnectedInterval = 5;
            while (true)
            {
                Thread.Sleep(CheckConnectedInterval * 1000);
                try
                {
                    foreach (var item in OnlineClents)
                    {
                        if (DateTime.Now.Subtract(ScsServer.Clients[item.intClientID].LastReceivedMessageTime) > new TimeSpan(0, 0, SharkHandsTime * 5 + 5)
                            || (DateTime.Now.Subtract(item.dtClientConnTime) > new TimeSpan(0, 0, 10) && item.Status != NetStatus.Login))
                        {
                            LogHelper.WriteLog("断开通讯不正常的客户端连接,IP:" + item.strClientIP + "Port:" + item.strClientPort);
                            ScsServer.Clients[item.intClientID].Disconnect();
                        }
                    }
                }
                catch (Exception ex)
                {
                    //LogHelper.WriteLog("", ex);
                }
            }
        }

    }

}
