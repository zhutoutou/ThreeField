using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.ThreeField.Controller
{
    /// <summary>
    /// Stores message to be used by an event.
    /// </summary>
    public class StatusEventArgs : EventArgs
    {
        /// <summary>
        /// NetStatus object that is associated with this event.
        /// </summary>
        public NetStatus Status { get; private set; }

        /// <summary>
        /// Creates a new StatusEventArgs object.
        /// </summary>
        /// <param name="status">NetStatus object that is associated with this event</param>
        public StatusEventArgs(NetStatus status)
        {
            Status = status;
        }
    }
}
