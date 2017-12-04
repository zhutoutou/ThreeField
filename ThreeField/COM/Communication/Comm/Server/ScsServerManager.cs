using System.Threading;

namespace ZIT.Communication.Comm.Server
{
    /// <summary>
    /// Provides some functionality that are used by servers.
    /// </summary>
    internal static class ScsServerManager
    {
        /// <summary>
        /// Used to set an auto incremential unique identifier to clients.
        /// </summary>
        private static long _lastClientId;

        /// <summary>
        /// Gets an unique number to be used as idenfitier of a client.
        /// </summary>
        /// <returns></returns>
        public static long GetClientId()
        {
            long clientid =  Interlocked.Increment(ref _lastClientId);
            if (0 == clientid)  //Reserve number 0.
            {
                clientid = Interlocked.Increment(ref _lastClientId);
            }
            return clientid;
        }
    }
}
