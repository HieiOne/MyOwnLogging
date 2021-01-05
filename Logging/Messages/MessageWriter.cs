﻿// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

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
        public void WriteMessage(string msg, Logger logger, MessageLevel messageLevel)
        {
            MessageLevelProperties.IncreaseCounter(messageLevel);

            switch (logger.LoggingMode)
            {
                case LoggingMode.Console:
                    ConsoleWriter.WriteMessage(msg, MessageLevelProperties.GetConsoleColor(messageLevel), MessageLevelProperties.GetDisplayColor(messageLevel));
                    break;
                case LoggingMode.Debug:
                    DebuggerWriter.WriteMessage(msg);
                    break;
                case LoggingMode.TextFile:
                    TextFileWriter.WriteMessage(msg, logger.FilePath, logger.FileName, logger.WritingMode);
                    break;
                default:
                    break;
            }
        }
    }
}
