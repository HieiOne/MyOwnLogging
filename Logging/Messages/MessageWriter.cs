using System;
using Logging.Writers;

namespace Logging.Messages
{
    public sealed class MessageWriter
    {
        public static void WriteMessage(LoggingMode loggingMode, string msg, MessageLevel messageLevel)
        {
            MessageLevelProperties.IncreaseCounter(messageLevel);

            //TODO detect if there's console and if there isn't change to default txt mode
            switch (loggingMode)
            {
                case LoggingMode.Console:
                    ConsoleWriter.WriteMessage(msg, MessageLevelProperties.GetConsoleColor(messageLevel), true);
                    break;
                case LoggingMode.TextFile:
                    break;
                default:
                    break;
            }
        }
    }
}
