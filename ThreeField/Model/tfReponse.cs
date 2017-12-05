using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.ThreeField.Model
{
    public class tfReponse
    { 
        private string _zjhm;

        private string _hz;

        private string _dz;

        public string Zjhm { get => _zjhm; set => _zjhm = value; }
        public string Hz { get => _hz; set => _hz = value; }
        public string Dz { get => _dz; set => _dz = value; }
    }
}
