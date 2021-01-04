// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Writers
{
    using System.Diagnostics;

    class DebuggerWriter
    {
        /// <summary>
        /// Static method to write into the console
        /// </summary>
        /// <param name="msg">Message to display</param>
        public static void WriteMessage(string msg)
        {
            Debug.WriteLine(msg);            
        }
    }
}
