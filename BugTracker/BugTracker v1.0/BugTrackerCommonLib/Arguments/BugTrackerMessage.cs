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
        /// <summary>
        /// Message text.
        /// </summary>
        public string MessageText { get; set; }

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
