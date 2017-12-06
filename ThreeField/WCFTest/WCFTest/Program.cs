using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ZIT.Communication.Comm;
using ZIT.Communication.Comm.Client;
using ZIT.Communication.Comm.Communication.EndPoints;
using ZIT.Communication.Comm.Communication.EndPoints.Tcp;
using ZIT.Communication.Comm.Communication.Messages;

namespace WCFTest
{
    class Program
    {
        private static IScsClient tcpClient = null;
        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(SendHandShake));
            th.Start();
            tcpClient = ScsClientFactory.CreateClient(new ScsTcpEndPoint("192.168.10.192",2000 ));
            ClientReConnecter crc = new ClientReConnecter(tcpClient);
            tcpClient.Disconnected += new EventHandler(ExchangeServer_Disconnected);
            tcpClient.Connected += new EventHandler(ExchangeServer_Connected);
            tcpClient.ConnectTimeout = 30;
            tcpClient.MessageReceived += new EventHandler<MessageEventArgs>(ExchangeServer_MessageReceived);
            tcpClient.MessageSent += new EventHandler<MessageEventArgs>(ExchangeServer_MessageSent);
            tcpClient.Connect();
            
        }

        private static void SendHandShake()
        {
            while (true)
            {
                string msg = "[8000TH:001*#]";
                if (tcpClient != null && tcpClient.CommunicationState == ZIT.Communication.Comm.Communication.CommunicationStates.Connected)
                {
                    tcpClient.SendMessage(new ScsTextMessage() { Text = msg });
                }
                Thread.Sleep(1000 * 5);
            }
        }
        private static void ExchangeServer_MessageSent(object sender, MessageEventArgs e)
        {
            Console.WriteLine("发送信息：" +e.Message.ToString());
        }

        private static void ExchangeServer_MessageReceived(object sender, MessageEventArgs e)
        {
            Console.WriteLine("收到消息:" + e.Message.ToString());
            string Message = FilterNetMsg(e.Message.ToString());
            switch (Message.Substring(1, 4))
            {
                case "2050":
                    string ZJHM = GetValueByKey(Message, "ZJHM");
                    tcpClient.SendMessage(new ScsTextMessage() { Text = "[2051ZJHM:" + ZJHM + "*#DZ:郁金香路17号*#HZ:张三*#]" });
                    break;
                default:
                    break;
            }
        }

        private static void ExchangeServer_Connected(object sender, EventArgs e)
        {
            Console.WriteLine("ExchangeServer_Connected");
            Console.ReadLine();
        }

        private static void ExchangeServer_Disconnected(object sender, EventArgs e)
        {
            Console.WriteLine("ExchangeServer_Disconnected");
            Console.ReadLine();
        }

        private static string FilterNetMsg(string Msg)
        {
            string returnMsg = string.Empty;
            if (!string.IsNullOrEmpty(Msg))
            {
                int StartIndex = Msg.IndexOf("[");
                int EndIndex = Msg.IndexOf("]");

                if (StartIndex >= 0 && EndIndex >= 1)
                {
                    if (EndIndex > StartIndex)
                    {
                        returnMsg = Msg.Substring(StartIndex, EndIndex + 1 - StartIndex);

                    }
                    else
                    {
                        returnMsg = "";
                    }
                }
            }
            return returnMsg;
        }
        private static string GetValueByKey(string message, string key)
        {
            string strReturn = "";

            Regex reg = new Regex(key + ":(.*?)\\*#");
            if (reg.IsMatch(message))
            {
                Match match = reg.Match(message);
                strReturn = match.Groups[1].Value.Trim();
            }
            return strReturn;
        }
    }
}
