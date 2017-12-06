using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.ThreeField.Model
{
    public class tfRequest
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
    }
}
