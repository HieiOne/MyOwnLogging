namespace Logging
{
    using System;
    using Messages;

    /// <summary>
    /// Depending on the logging mode the message will be displayed in one way or stored in other
    /// </summary>
    public enum LoggingMode
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
        /// Specifies the logging mode of the class, it cannot be modified after instantiation
        /// </summary>
        public LoggingMode LoggingMode { get; private set; }

        /// <summary>
        /// Logger to console
        /// </summary>
        public Logger()
        {
            this.LoggingMode = LoggingMode.Console;
        }

        /// <summary>
        /// Logger to the specified file with the specified format
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        public Logger(string filePath, string fileName, LoggingMode loggingMode)
        {
            this.LoggingMode = loggingMode;
            this.FilePath = filePath;
            this.FileName = fileName;
        }

        /// <summary>
        /// By default console mode will be used
        /// </summary>
        /// <param name="msg">Message to log</param>
        /// <param name="loggingMode"></param>
        public void WriteMsg(string msg, MessageLevel messageLevel = MessageLevel.Info)
        {            
            msg = MessageBuilder.MessageStringBuilder(msg, messageLevel, ShowPrefix, ShowTimeStamp, TimeStampFormat);

            MessageLevelProperties.IncreaseCounter(messageLevel);

            //TODO detect if there's console and if there isn't change to default txt mode
            switch (LoggingMode)
            {
                case LoggingMode.Console:
                    Console.ForegroundColor = MessageLevelProperties.GetConsoleColor(messageLevel);
                    Console.WriteLine(msg);
                    Console.ResetColor();
                    break;
                case LoggingMode.TXT:
                    break;
                default:
                    break;
            }
        }
    }   
}