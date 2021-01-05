// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Writers
{
    /// <summary>
    /// Interface to set all Writers requirements
    /// </summary>
    internal interface IWriter
    {
        /// <summary>
        /// Method to write messages in writers
        /// </summary>
        /// <param name="msg">Message to be displayed</param>
        void WriteMessage(string msg);
    }
}
