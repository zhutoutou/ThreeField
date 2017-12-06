using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ZIT.Communication.Comm.Communication.Messages;
using ZIT.ThreeField.Model;
using ZIT.ThreeField.Utils;

namespace ZIT.ThreeField.Controller
{
    public class ThreeFieldMsgHandler
    {

        private ServerClient Client;

       

        public ThreeFieldMsgHandler(ServerClient client)
        {
            Client = client;
        }

        public void Message_Handler(object sender, MessageEventArgs Args)
        {
            try
            {
                ScsTextMessage Message = (ScsTextMessage)Args.Message;
                string strOneMsg = FilterNetMsg(Message.Text);
                if (strOneMsg != string.Empty)
                {
                    string strMessageId = strOneMsg.Substring(1, 4);
                    if (strMessageId != "8000")
                    {
                        LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Info, "Recieved message Unitcode is " + Client.UnitCode + " Port is " + Client.TFServer.ServerPort.ToString() + ":" + strOneMsg, new LogUtility.RunningPlace("ThreeFieldMsgHandler", "Message_Handler"), "RecvMsg");
                    }
                    switch (strMessageId)
                    {
                        case "8000":
                            Handle8000Message(strOneMsg);
                            break;
                        case "2051":
                            Handle2051Message(strOneMsg);
                            break;
                        default:
                            break;
                    }
                }
                
               
            }
            catch (Exception ex)
            {
                LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Error, ex.Message.ToString(), new LogUtility.RunningPlace("ThreeFieldMsgHandler", "Message_Handler"), "业务逻辑错误");
            }
        }

        private void Handle8000Message(string strOneMsg)
        {
            try
            {
                if (string.IsNullOrEmpty(this.Client.UnitCode))
                {
                    Client.UnitCode = "001";
                    Client.UnitName = "三字段服务器";
                    Client.Status = NetStatus.Login;
                    Client.UnitType = ClientType.TF;
                    LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Info,"三字段服务器登陆，IP：" + Client.strClientIP + "，Port：" + Client.strClientPort,new LogUtility.RunningPlace("ThreeFieldMsgHandler", "Handle8000Message"),"软件业务处理");
                    Client.TFServer.OnServerConnectedClientChanged();
                }
            }
            catch (Exception ex) { }
        }

        private void Handle2051Message(string msg)
        {
            try
            {
                tfReponse tfr = new tfReponse();
                tfr.Tfinfo.Zjhm = GetValueByKey(msg, "ZJHM");
                tfr.Tfinfo.Dz = GetValueByKey(msg, "DZ");
                tfr.Tfinfo.Hz = GetValueByKey(msg, "HZ");
                LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Info, "三字段服务器登陆", new LogUtility.RunningPlace("ThreeFieldMsgHandler", "Handle8000Message"), "软件业务处理");
                CoreService.GetInstance().OnTFReponseHandlerEvent(tfr);
            }
            catch (Exception ex)
            {

            }
        }

        private string FilterNetMsg(string Msg)
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
        private string GetValueByKey(string message, string key)
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
