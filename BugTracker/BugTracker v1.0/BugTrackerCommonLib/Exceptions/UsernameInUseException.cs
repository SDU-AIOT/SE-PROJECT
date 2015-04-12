using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerCommonLib
{
    /// <summary>
    /// This exception is thrown by BugTracker server if a user wants to register
    /// with a username that is being used by another user.
    /// </summary>
    [Serializable]
    public class UsernameInUseException : ApplicationException
    {        
        /// <summary>
        /// Contstructor.
        /// </summary>
        public UsernameInUseException()
        {

        }

        /// <summary>
        /// Contstructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        public UsernameInUseException(string message) : base(message)
        {

        }
    }
}
