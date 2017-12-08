using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.ThreeField.Model
{
    /// <summary>
    /// 三字段信息返回类
    /// </summary>
    public class tfReponse
    {
        private bool _result;
        /// <summary>
        /// 请求结果
        /// </summary>
        public bool Result
        {
            get { return _result; }
            set { _result = value; }

        }

        private string _errmsg;
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg
        {
            get { return _errmsg; }
            set { _errmsg = value; }

        }



        private tfInfo _tfinfo;
        /// <summary>
        /// 三字段信息
        /// </summary>
        public tfInfo Tfinfo
        {
            get { return _tfinfo; }
            set { _tfinfo = value; }

        }

        public tfReponse()
        {
            Tfinfo = new tfInfo();
        }
    }

    /// <summary>
    /// 三字段信息
    /// </summary>
    public class tfInfo
    {
        private string _zjhm;
        /// <summary>
        /// 主叫号码
        /// </summary>
        public string Zjhm
        {
            get { return _zjhm; }
            set { _zjhm = value; }
        }

        private string _hz;
        /// <summary>
        /// 户主
        /// </summary>
        public string Hz
        {
            get { return _hz; }
            set { _hz = value; }
        }

        private string _dz;
        /// <summary>
        /// 地址
        /// </summary>
        public string Dz
        {
            get { return _dz; }
            set { _dz = value; }
        }

    }
}
