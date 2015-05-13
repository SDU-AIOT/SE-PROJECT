using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugTrackerCommonLib
{
    /// <summary>
    /// Represents a message that can be sent and received by users.
    /// </summary>
    [Serializable]
    public class BugTrackerMessage
    {
        public static int NEW_ISSUE = 1, NEW_USER = 2, NEW_PROJECT = 3;
        private int messageType;
        /// <summary>
        /// Message text.
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// Message type.
        /// </summary>
        public int MessageType { 
            get
            {
                return messageType;
            }
            set 
            {
                messageType = value;
            }
        }

        /// <summary>
        /// Creates a new BugTrackerMessage.
        /// </summary>
        public BugTrackerMessage()
        {
            MessageText = "";
        }

        /// <summary>
        /// Creates a new BugTrackerMessage.
        /// </summary>
        /// <param name="messageText">Message text</param>
        public BugTrackerMessage(string messageText)
        {
            MessageText = messageText;
        }
    }
}
