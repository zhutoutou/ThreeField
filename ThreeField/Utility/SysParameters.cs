using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ZIT.ThreeField.Utility
{
    public class SysParameters
    {
        static SysParameters()
        {
            SharkHandsInterval = 5;
            LocalPort = short.Parse(ConfigurationManager.AppSettings["LocalPort"]);
            WCFTimeout = int.Parse(ConfigurationManager.AppSettings["WCFTimeout"]);
        }
        /// <summary>
        /// 与120业务服务器连接的本地端口
        /// </summary>
        public static short LocalPort;// = 2000;
        /// <summary>
        /// 检查握手断开
        /// </summary>
        public static int SharkHandsInterval;

        public static int WCFTimeout;
        
    }
}
