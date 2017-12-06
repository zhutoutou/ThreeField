using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using ZIT.ThreeField.Model;
using ZIT.ThreeField.Controller;
using ZIT.ThreeField.Utility;
using ZIT.ThreeField.Utils;

namespace ZIT.ThreeField.TFWCF
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“ThreeFieldWCF”。
    public class ThreeFieldWCF : IThreeFieldWCF
    {

        private static ManualResetEvent _mre = new ManualResetEvent(false);

        public CoreService control = CoreService.GetInstance();

        public static tfReponse tfr = null;

        public delegate void AsyncMethodCaller();
        public string TFRequset(string request)
        {
            tfr = new tfReponse() { Result = false };
            _mre = new ManualResetEvent(false);
            try
            {
                tfRequest tf = new tfRequest();
                tf = (tfRequest)JSON.JsonToObject(request, tf);
                if (tf == null || string.IsNullOrEmpty(tf.Zjhm))
                {
                    tfr.Result = false;
                    tfr.ErrMsg = "消息格式错误无法序列化或者主叫号码为空";
                }
                else
                {
                    string ZJHM = tf.Zjhm;
                    LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Info, "WCF_TFReuset收到请求，主叫号码：" + ZJHM, new LogUtility.RunningPlace("ThreeFieldWCF", "TFReuset"), "软件业务处理");
                    if (control.ts != null && control.ts.OnlineClents.Count > 0)
                    {
                        control.TFReponseHandlerEvent += Control_TFReponseHandlerEvent;
                        control.ts.BroadCastMessage(BuildTFRequestFromModel(ZJHM), ClientType.TF);
                        bool blntimeout = _mre.WaitOne(new TimeSpan(0, 0, SysParameters.WCFTimeout));
                        if (blntimeout)
                        {
                            LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Info, "WCF_TFReuset正常反馈请求，主叫号码：" + ZJHM + ",Reponse:" + JSON.ObjectToJson(tfr), new LogUtility.RunningPlace("ThreeFieldWCF", "TFReuset"), "软件业务处理");
                        }
                        else
                        {
                            tfr.Result = false;
                            tfr.ErrMsg = "WCF_TFReuset反馈请求超时";
                            LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Info, "WCF_TFReuset超时反馈请求，主叫号码：" + ZJHM + ",Reponse:" + JSON.ObjectToJson(tfr), new LogUtility.RunningPlace("ThreeFieldWCF", "TFReuset"), "软件业务处理");
                        }
                        //初始化变量
                        control.TFReponseHandlerEvent -= Control_TFReponseHandlerEvent;
                    }
                    else
                    {
                        tfr.ErrMsg = "WCF尚未与三字段服务器正常连接，请检查与三字段服务器之间的TCP连接";
                        LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Info, "WCF_TFReuset三字段服务器没有连接上，主叫号码：" + ZJHM, new LogUtility.RunningPlace("ThreeFieldWCF", "TFReuset"), "软件业务处理");
                    }
                }
            }
            catch (Exception ex)
            {
                tfr.Result = false;
                tfr.ErrMsg = ex.Message;
                LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Error, ex.Message.ToString(), new LogUtility.RunningPlace("TFRequset", "ThreeFieldWCF"), "WCF错误");
            }
            string reponse = JSON.ObjectToJson(tfr);
            return reponse;
        }

        

        private void Control_TFReponseHandlerEvent(tfReponse t)
        {
            try
            {
                LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Info, "WCF_TFReuset结束TCP反馈，主叫号码：" + t.Tfinfo.Zjhm, new LogUtility.RunningPlace("Control_TFReponseHandlerEvent", "TFReuset"), "软件业务处理");
                lock (tfr)
                {
                    tfr.Result = true;
                    tfr.Tfinfo = t.Tfinfo;
                    _mre.Set();
                }
            }
            catch (Exception ex)
            {
                lock (tfr)
                {
                    tfr.Result = false;
                    tfr.ErrMsg = ex.Message;
                    LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Error, ex.Message.ToString(), new LogUtility.RunningPlace("TFRequset", "Control_TFReponseHandlerEvent"), "WCF错误");
                }
            }
        }

        /// <summary>
        /// Fun集合
        /// </summary>
        /// <param name="zJHM"></param>
        /// <returns></returns>
        #region
        private string BuildTFRequestFromModel(string zJHM)
        {
            return "[2050ZJHM:" + zJHM + "*#]";
        }
        #endregion
    }
}
