using System;

namespace ZIT.EMERGENCY.Model
{
    /// <summary>
    /// 在线的网络单元
    /// </summary>
    public class OnlineUnit
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 单位行政编码
        /// </summary>
        public string UnitCode { get; set; }
        /// <summary>
        /// 连接状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 连接时间
        /// </summary>
        public string ConnectedTime { get; set; }
    }
}
