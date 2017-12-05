using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using ZIT.ThreeField.Model;
using ZIT.ThreeField.Controller;

namespace ZIT.ThreeField.TFWCF
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“ThreeFieldWCF”。
    public class ThreeFieldWCF : IThreeFieldWCF
    {

        public static Mutex Mutex = new Mutex();

        public CoreService control = CoreService.GetInstance();

        public tfReponse Tfr = null;
        public tfReponse TFReuset(string ZJHM)
        {
            //RaiseTFRequest(ZJHM);
            if (control.ts != null && control.ts.OnlineClents.Count > 0)
            {
                control.TFReponseHandlerEvent += Control_TFReponseHandlerEvent;
                control.ts.BroadCastMessage(BuildTFRequestFromModel(ZJHM), ClientType.TF);
                Mutex.WaitOne();
            }
            return Tfr;

        }

        private void Control_TFReponseHandlerEvent(tfReponse tfr)
        {
            Tfr = tfr;
            control.TFReponseHandlerEvent -= Control_TFReponseHandlerEvent;
            Mutex.ReleaseMutex();
        }


        #region
        private string BuildTFRequestFromModel(string zJHM)
        {
            return "[2050ZJHM:" + zJHM + "*#]";
        }
        #endregion
    }
}
