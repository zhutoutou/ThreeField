using System;

namespace ZIT.ThreeField.Model
{
    public class ExMsg
    {
        private int _msgno;

        private string _data;

        private DateTime _recvtime;

        private string _ipep;

        public int Msgno { get => _msgno; set => _msgno = value; }
        public string Data { get => _data; set => _data = value; }
        public DateTime Recvtime { get => _recvtime; set => _recvtime = value; }
        public string Ipep { get => _ipep; set => _ipep = value; }
    }
}