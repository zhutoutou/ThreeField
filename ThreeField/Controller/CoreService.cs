using System;
using ZIT.ThreeField.Utility;
using ZIT.ThreeField.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace ZIT.ThreeField.Controller
{
    /// <summary>
    /// 核心服务类
    /// </summary>
    public class CoreService
    {
        /// <summary>
        /// 确保CoreService只有一个实例。
        /// </summary>
        private static CoreService instance = null;

        /// <summary>
        /// 与TFServer连接客户端改变事件
        /// </summary>
        public event EventHandler<UnitsEventArgs> ServerConnectedClientChanged;

        /// <summary>
        /// 返回三字段信息的委托
        /// </summary>
        public event TFReponseHandler TFReponseHandlerEvent;
        public delegate void TFReponseHandler(tfReponse tfr);



        public TFServer ts;

        /// <summary>
        /// 获取当前类实例
        /// </summary>
        /// <returns></returns>
        public static CoreService GetInstance()
        {
            if (null == instance)
            {
                instance = new CoreService();
            }
            return instance;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        private CoreService()
        {
            ts = new TFServer();
            ts.ServerPort = SysParameters.LocalPort;
        }


        /// <summary>
        /// 开始数据交换服务
        /// </summary>
        public void StartService()
        {
            try
            {
                //三字段服务器启动
                ts.Start();
                ts.ServerConnectedClientChanged += Ts_ServerConnectedClientChanged;
            }
            catch (Exception ex) { LogUtility.DataLog.WriteError(ex, "StartService"); }

        }

       



        /// <summary>
        /// 停止数据交换服务
        /// </summary>
        public void StopService()
        {
            ts.Stop();
        }


        private void Ts_ServerConnectedClientChanged(object sender, UnitsEventArgs e)
        {
            OnServerConnectedClientChanged(e.Units);
        }

        protected virtual void OnServerConnectedClientChanged(List<OnlineUnit> units)
        {
            var handler = ServerConnectedClientChanged;
            if (handler != null)
            {
                handler(this, new UnitsEventArgs(units));
            }
        }

        /// <summary>
        /// 通知WCF信息反馈
        /// </summary>
        /// <param name="tfr"></param>
        public void OnTFReponseHandlerEvent(tfReponse tfr)
        {
            var handler = TFReponseHandlerEvent;
            if (handler != null)
            {
                handler(tfr);
            }
        }




    }
}
