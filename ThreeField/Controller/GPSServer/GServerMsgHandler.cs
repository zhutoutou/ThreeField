using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZIT.ThreeField.Utility;
using ZIT.ThreeField.Model;
using System.Text.RegularExpressions;


namespace ZIT.ThreeField.Controller.BusinessServer
{
    public class GServerMsgHandler
    {
        /// <summary>
        /// WebService代理类
        /// </summary>

        Dictionary<string, DateTime> _VehMap = new Dictionary<string, DateTime>();
        public GServerMsgHandler()
        {
        }

        public void HandleMsg(string strMsg)
        {
            try
            {
                int m;
                string strMessageId = strMsg.Substring(1, 2);
                if (int.TryParse(strMessageId,out m))
                {
                   
                }
                switch (strMessageId)
                {
                    //case "70":
                    //    Handle70Message(strMsg);
                    //    break;
                    case "40":
                        Handle40Message(strMsg);
                        break;
                    default:
                    break;
                }
            }
            catch (Exception ex)
            {
               
            }
        }
        #region
       

        private void Handle40Message(string strMsg)
        {
            string strcarID, strLSH, strCCXH;
            try
            {
                strcarID = GetValueByKey(strMsg, "ID");
                strLSH = GetValueByKey(strMsg, "LSH");
                if (_VehMap.ContainsKey(strcarID))
                {
                    TimeSpan ts = DateTime.Now - _VehMap[strcarID];
                    if (ts.TotalMinutes < SysParameters.VehInfoInterval)
                    {
                        return;
                    }
                }
                if (strMsg.Substring(0, 1) == "(" && strMsg.Substring(strMsg.Length - 1, 1) == ")")
                {
                    
                    switch (strLSH.Length)
                    {
                        case 12:
                        case 19:
                            strCCXH = "";
                            break;
                        case 14:
                        case 21:
                                strCCXH = strLSH.Substring(strLSH.Length - 2, 2);
                                strLSH = strLSH.Substring(0, strLSH.Length - 2);
                            break;
                        default :
                            strLSH = "";
                            strCCXH = "";
                            break;
                    }
                   
                }
            }
            catch(Exception ex)
            {
               
            }
        }
        #endregion







        private string GetValueByKey(string message, string key)
        {
            string strReturn = "";

            Regex reg = new Regex(key + ":(.*?)\\%");
            if (reg.IsMatch(message))
            {
                Match match = reg.Match(message);
                strReturn = match.Groups[1].Value.Trim();
            }
            return strReturn;
        }


       
    }

}
