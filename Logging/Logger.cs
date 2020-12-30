namespace Logging
{
    using System;
    using Messages;

    /// <summary>
    /// Depending on the logging mode the message will be displayed in one way or stored in other
    /// </summary>
    public enum LoggingModes
    {
        Console,
        TXT
    }

    /// <summary>
    /// Specifies the level of the message, it will also modify the message adding colors and prefixes like "OK: [msg]"
    /// </summary>
    public enum MessageLevel
    {
        Info,
        Success,
        Warning,
        Error,
        Debug
    }

    public class Logger : MessageProperties
    {
        /// <summary>
        /// Specifies the filePath where the logging files will be stored
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Specifies the fileName that will be used to store the logging
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// By default console mode will be used
        /// </summary>
        /// <param name="msg">Message to log</param>
        /// <param name="loggingMode"></param>
        public void WriteMsg(string msg, MessageLevel messageLevel = MessageLevel.Info, LoggingModes loggingMode = LoggingModes.Console)
        {            
            msg = MessageBuilder.MessageStringBuilder(msg, messageLevel, ShowPrefix, ShowTimeStamp, TimeStampFormat);

            MessageLevelProperties.IncreaseCounter(messageLevel);

            //TODO detect if there's console and if there isn't change to default txt mode
            switch (loggingMode)
            {
                case LoggingModes.Console:
                    Console.ForegroundColor = MessageLevelProperties.GetConsoleColor(messageLevel);
                    Console.WriteLine(msg);
                    Console.ResetColor();
                    break;
                case LoggingModes.TXT:
                    break;
                default:
                    break;
            }
        }
    }   
}