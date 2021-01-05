// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Writers
{
    using System.Diagnostics;

    /// <summary>
    /// This class is used to write into the attached debugger
    /// </summary>
    internal class DebuggerWriter : IWriter
    {
        /// <summary>
        /// Method to write into the debugger
        /// </summary>
        /// <param name="msg">Message to display</param>
        /// <param name="messageLevel">Indicates the level of the message</param>
        public virtual void WriteMessage(string msg, MessageLevel messageLevel)
        {
            Debug.WriteLine(msg);            
        }
    }
}
