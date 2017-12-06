using ZIT.Communication.Comm.Communication;
using ZIT.Communication.Comm.Communication.Messengers;

namespace ZIT.Communication.Comm.Client
{
    /// <summary>
    /// Represents a client to connect to server.
    /// </summary>
    public interface IScsClient : IMessenger, IConnectableClient
    {
        //Does not define any additional member
    }
}
