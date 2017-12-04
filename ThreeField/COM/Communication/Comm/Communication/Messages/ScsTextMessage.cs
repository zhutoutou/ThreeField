using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.Communication.Comm.Communication.Messages
{
    /// <summary>
    /// This message is used to send/receive a text as message data.
    /// </summary>
    [Serializable]
    public class ScsTextMessage : ScsMessage
    {
        /// <summary>
        /// Message text that is being transmitted.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Creates a new ScsTextMessage object.
        /// </summary>
        public ScsTextMessage()
        {

        }

        /// <summary>
        /// Creates a new ScsTextMessage object with Text property.
        /// </summary>
        /// <param name="text">Message text that is being transmitted</param>
        public ScsTextMessage(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Creates a new reply ScsTextMessage object with Text property.
        /// </summary>
        /// <param name="text">Message text that is being transmitted</param>
        /// <param name="repliedMessageId">
        /// Replied message id if this is a reply for
        /// a message.
        /// </param>
        public ScsTextMessage(string text, string repliedMessageId)
            : this(text)
        {
            RepliedMessageId = repliedMessageId;
        }

        /// <summary>
        /// Creates a string to represents this object.
        /// </summary>
        /// <returns>A string to represents this object</returns>
        public override string ToString()
        {
            return string.Format("{0}", Text);
            //return string.IsNullOrEmpty(RepliedMessageId)
            //          ? string.Format("ScsMessage [{0}]:{1}", MessageId, Text)
            //          : string.Format("ScsMessage [{0}] Replied To [{1}]:{2}", MessageId, RepliedMessageId, Text);
        }

        /// <summary>
        /// Creates a short string to represents this object.
        /// </summary>
        /// <returns>A short string to represents this object</returns>
        public override string ToShortString()
        {
            return string.IsNullOrEmpty(RepliedMessageId)
                       ? string.Format("对象名: ScsTextMessage 消息ID:[{0}]", MessageId)
                       : string.Format("对象名: ScsTextMessage 消息ID:[{0}] 回复消息ID:[{1}]", MessageId, RepliedMessageId);
        }
    }
}
