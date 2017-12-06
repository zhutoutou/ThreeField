using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.Communication.Comm.Communication.Messages
{
    /// <summary>
    /// Represents a message that is sent and received by server and client.
    /// </summary>
    public interface IScsMessage
    {
        /// <summary>
        /// Unique identified for this message. 
        /// </summary>
        string MessageId { get; }

        /// <summary>
        /// Unique identified for this message. 
        /// </summary>
        string RepliedMessageId { get; set; }

        /// <summary>
        /// Creates a short string to represents this object.
        /// </summary>
        /// <returns>A short string to represents this object</returns>
        string ToShortString(); 
    }
}
