// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Loggers
{
    using System;

    /// <summary>
    /// This class is used to write into the console
    /// </summary>
    public class ConsoleLogger : LoggerBase
    {
        /// <summary>
        /// Method to write into the console
        /// </summary>
        /// <param name="msg">Message to display</param>
        /// <param name="messageLevel">Indicates the level of the message</param>
        internal override void WriterLogger(string msg, MessageLevel messageLevel)
        {
            if (this.MessageLevelProperties.GetDisplayColor(messageLevel))
            {
                Console.ForegroundColor = this.MessageLevelProperties.GetConsoleColor(messageLevel);
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
