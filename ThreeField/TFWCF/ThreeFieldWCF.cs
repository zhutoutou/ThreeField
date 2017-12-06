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

        SynchronizationContext syncContext_TFRequest;

        public CoreService control = CoreService.GetInstance();

        public tfReponse Tfr = null;
        public string TFRequset(string ZJHM)
        {
            try
            {
                LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Info, "WCF_TFReuset收到请求，主叫号码：" + ZJHM, new LogUtility.RunningPlace("ThreeFieldWCF", "TFReuset"), "软件业务处理");
                //RaiseTFRequest(ZJHM);
                if (control.ts != null && control.ts.OnlineClents.Count > 0)
                {
                    control.TFReponseHandlerEvent += Control_TFReponseHandlerEvent;
                    control.ts.BroadCastMessage(BuildTFRequestFromModel(ZJHM), ClientType.TF);
                    syncContext_TFRequest = SynchronizationContext.Current;
                }
                if (Tfr is null) return "";
                string reponse = JSON.ObjectToJson(Tfr);
                LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Info, "WCF_TFReuset反馈请求，主叫号码：" + ZJHM + ",Reponse:" + reponse, new LogUtility.RunningPlace("ThreeFieldWCF", "TFReuset"), "软件业务处理");
                return reponse;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private void Control_TFReponseHandlerEvent(tfReponse tfr)
        {
            try
            {
                LogUtility.DataLog.WriteLog(LogUtility.LogLevel.Info, "WCF_TFReuset结束TCP反馈，主叫号码：" + tfr.Zjhm, new LogUtility.RunningPlace("Control_TFReponseHandlerEvent", "TFReuset"), "软件业务处理");
                Tfr = tfr;
                control.TFReponseHandlerEvent -= Control_TFReponseHandlerEvent;
                syncContext_TFRequest.Post()
            }
            catch (Exception ex)
            { }
        }


        #region
        private string BuildTFRequestFromModel(string zJHM)
        {
            return "[2050ZJHM:" + zJHM + "*#]";
        }
        #endregion
    }
}
