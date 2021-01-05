// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Writers
{
    using System;
    using Logging.Messages;

    /// <summary>
    /// This class is used to write into the console
    /// </summary>
    internal class ConsoleWriter : IWriter
    {
        /// <summary>
        /// Method to write into the console
        /// </summary>
        /// <param name="msg">Message to display</param>
        /// <param name="messageLevel">Indicates the level of the message</param>
        public virtual void WriteMessage(string msg, MessageLevel messageLevel)
        {
            if (MessageLevelProperties.GetDisplayColor(messageLevel))
            {
                Console.ForegroundColor = MessageLevelProperties.GetConsoleColor(messageLevel);
                Console.WriteLine(msg);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(msg);
            }
        }        
    }
}
