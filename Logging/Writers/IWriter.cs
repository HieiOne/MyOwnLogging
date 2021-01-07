// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Writers
{
    using Logging.Messages;

    /// <summary>
    /// Interface to set all Writers requirements
    /// </summary>
    internal interface IWriter
    {
        /// <summary>
        /// Method to write messages in writers
        /// </summary>
        /// <param name="msg">Message to be displayed</param>
        /// <param name="messageLevel">Indicates the level of the message</param>
        /// <param name="messageProperties">Properties of the message</param>
        /// <param name="messageLevelProperties">Properties of each message level</param>
        void WriteMessage(string msg, MessageLevel messageLevel, MessageProperties messageProperties, MessageLevelProperties messageLevelProperties);
    }
}