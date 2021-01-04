// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Messages
{
    using Logging.Writers;

    /// <summary>
    /// This class receives the message and redirects it to the proper class depending on the logging mode
    /// </summary>
    internal sealed class MessageWriter
    {
        /// <summary>
        /// Redirects the message to the proper class depending on the logging mode
        /// </summary>
        /// <param name="msg">Message to display or store</param>
        /// <param name="loggingMode">Logging mode that will be used</param>
        /// <param name="messageLevel">Indicates the level of the message</param>
        public static void WriteMessage(string msg, LoggingMode loggingMode, MessageLevel messageLevel)
        {
            MessageLevelProperties.IncreaseCounter(messageLevel);

            // TODO detect if there's console and if there isn't change to default txt mode
            switch (loggingMode)
            {
                case LoggingMode.Console:
                    ConsoleWriter.WriteMessage(msg, MessageLevelProperties.GetConsoleColor(messageLevel), MessageLevelProperties.GetDisplayColor(messageLevel));
                    break;
                case LoggingMode.Debug:
                    DebuggerWriter.WriteMessage(msg);
                    break;
                case LoggingMode.TextFile:
                    break;
                default:
                    break;
            }
        }
    }
}
