using ZIT.Communication.Comm.Communication.Channels;
using ZIT.Communication.Comm.Communication.Channels.Tcp;
using ZIT.Communication.Comm.Communication.EndPoints.Tcp;

namespace ZIT.Communication.Comm.Server.Tcp
{
    /// <summary>
    /// This class is used to create a TCP server.
    /// </summary>
    internal class ScsTcpServer : ScsServerBase
    {
        /// <summary>
        /// The endpoint address of the server to listen incoming connections.
        /// </summary>
        private readonly ScsTcpEndPoint _endPoint;

        /// <summary>
        /// Creates a new ScsTcpServer object.
        /// </summary>
        /// <param name="endPoint">The endpoint address of the server to listen incoming connections</param>
        public ScsTcpServer(ScsTcpEndPoint endPoint)
        {
            _endPoint = endPoint;
        }

        /// <summary>
        /// Creates a TCP connection listener.
        /// </summary>
        /// <returns>Created listener object</returns>
        protected override IConnectionListener CreateConnectionListener()
        {
            return new TcpConnectionListener(_endPoint);
        }
    }
}
