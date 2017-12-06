﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.Communication.Comm.Communication.Channels
{
    /// <summary>
    /// Stores communication channel information to be used by an event.
    /// </summary>
    internal class CommunicationChannelEventArgs : EventArgs
    {
        /// <summary>
        /// Communication channel that is associated with this event.
        /// </summary>
        public ICommunicationChannel Channel { get; private set; }

        /// <summary>
        /// Creates a new CommunicationChannelEventArgs object.
        /// </summary>
        /// <param name="channel">Communication channel that is associated with this event</param>
        public CommunicationChannelEventArgs(ICommunicationChannel channel)
        {
            Channel = channel;
        }
    }
}
