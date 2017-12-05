using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.Communication.Comm.Communication.Messages
{
    /// <summary>
    /// Stores message to be used by an event.
    /// </summary>
    public class MessageEventArgs : EventArgs
    {
        /// <summary>
        /// Message object that is associated with this event.
        /// </summary>
        public IScsMessage Message { get; private set; }

        /// <summary>
        /// Creates a new MessageEventArgs object.
        /// </summary>
        /// <param name="message">Message object that is associated with this event</param>
        public MessageEventArgs(IScsMessage message)
        {
            Message = message;
        }
    }
}
