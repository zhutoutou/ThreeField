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

            DBType = "Oracle";
            SharkHandsInterval = 5;
            GServerIP = ConfigurationManager.AppSettings["GServerIP"];
            GLocalPort = short.Parse(ConfigurationManager.AppSettings["GLocalPort"]);
            InsertInterval = short.Parse(ConfigurationManager.AppSettings["InsertInterval"]);
            try
            {
                DBConnectStringLocal = ConfigurationManager.AppSettings["DBConnectStringLocal"];
            }
            catch
            {
                DBConnectStringLocal = "Data Source=ORCL;User ID=appinfo;Password=appinfo;";
            }
            try
            {
                DBConnectStringRemote = ConfigurationManager.AppSettings["DBConnectStringRemote"];
            }
            catch
            {
                DBConnectStringRemote = "Data Source=ORCL;User ID=appinfo;Password=appinfo;";
            }
            VehInfoInterval = short.Parse(ConfigurationManager.AppSettings["VehInfoInterval"]);
        }
        /// <summary>
        /// 数据库类型 Oracle; Mysql
        /// </summary>
        public static string DBType;
        /// <summary>
        /// 与各服务器握手时间间隔，单位：秒
        /// </summary>
        public static int InsertInterval;// = 10
        /// 120业务服务器IP地址
        /// </summary>
        public static string GServerIP;// = "192.168.0.254";

        /// <summary>
        /// 与120业务服务器连接的本地端口
        /// </summary>
        public static short GLocalPort;// = 2000;
        /// <summary>
        /// 检查握手断开
        /// </summary>
        public static int SharkHandsInterval;
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string DBConnectStringLocal;

        public static string DBConnectStringRemote;

        public static int VehInfoInterval; // 5分钟
    }
}
