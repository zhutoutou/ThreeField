using System;

namespace ZIT.Communication.Comm.Communication.Channels
{
    /// <summary>
    /// Represents a communication listener.
    /// A connection listener is used to accept incoming client connection requests.
    /// </summary>
    internal interface IConnectionListener
    {
        /// <summary>
        /// This event is raised when a new communication channel connected.
        /// </summary>
        event EventHandler<CommunicationChannelEventArgs> CommunicationChannelConnected;

        /// <summary>
        /// This event is raised when ConnectionListener crushed.
        /// </summary>
        event EventHandler<EventArgs> ConnectionListenerCrushed;

        /// <summary>
        /// Starts listening incoming connections.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops listening incoming connections.
        /// </summary>
        void Stop();
    }
}
