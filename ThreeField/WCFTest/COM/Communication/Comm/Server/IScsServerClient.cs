using System;
using ZIT.Communication.Comm.Communication;
using ZIT.Communication.Comm.Communication.EndPoints;
using ZIT.Communication.Comm.Communication.Messengers;


namespace ZIT.Communication.Comm.Server
{
    /// <summary>
    /// Represents a client from a perspective of a server.
    /// </summary>
    public interface IScsServerClient : IMessenger
    {
        /// <summary>
        /// This event is raised when client disconnected from server.
        /// </summary>
        event EventHandler Disconnected;

        /// <summary>
        /// Unique identifier for this client in server.
        /// </summary>
        long ClientId { get; }

        ///<summary>
        /// Gets endpoint of remote application.
        ///</summary>
        ScsEndPoint RemoteEndPoint { get; }

        /// <summary>
        /// Gets the current communication state.
        /// </summary>
        CommunicationStates CommunicationState { get; }

        /// <summary>
        /// Disconnects from server.
        /// </summary>
        void Disconnect();

    }
}
