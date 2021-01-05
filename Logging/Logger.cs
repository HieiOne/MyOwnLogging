﻿// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging
{
    using Messages;
    using Writers;

    /// <summary>
    /// Indicates how the logging into a file will be written
    /// </summary>
    public enum WritingMode
    { 
        /// <summary>
        /// Indicates that all logs will be appended into the file
        /// </summary>
        Appending,

        /// <summary>
        /// Indicates that the file will be re-created before writing into the file
        /// </summary>
        Recreating
    }

    /// <summary>
    /// Depending on the logging mode the message will be displayed or stored in the specified format
    /// </summary>
    public enum LoggingMode
    {
        /// <summary>
        /// Represents that the log will go to the console
        /// </summary>
        Console,

        /// <summary>
        /// Represents that the log will go to the attached debugger
        /// </summary>
        Debug,

        /// <summary>
        /// Represents that the log will go to a file
        /// </summary>
        TextFile
    }

    /// <summary>
    /// Specifies the level of the message, it will also modify the message adding colors and prefixes like "OK: [message]"
    /// These prefixes and colors can be configured within the logger class properties.
    /// </summary>
    public enum MessageLevel
    {
        /// <summary>
        /// Represents a info message
        /// </summary>
        Info,

        /// <summary>
        /// Represents a success message
        /// </summary>
        Success,

        /// <summary>
        /// Represents a warning message
        /// </summary>
        Warning,

        /// <summary>
        /// Represents a error message
        /// </summary>
        Error,

        /// <summary>
        /// Represents a debug message
        /// </summary>
        Debug
    }

    /// <summary>
    /// All user event logger handler
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Class that handles the writing depending on the Logging Mode provided
        /// </summary>
        private IWriter messageWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class with the specified logging mode format
        /// </summary>
        /// <param name="filePath">Path where the file will be stored</param>
        /// <param name="fileName">Name of the file</param>
        /// <param name="loggingMode">Logging mode that will be used</param>
        /// <param name="writingMode">Used writing mode</param>
        public Logger(string filePath, string fileName, LoggingMode loggingMode, WritingMode writingMode = WritingMode.Appending)
        {
            this.LoggingMode = loggingMode;
            this.FilePath = filePath;
            this.FileName = fileName;
            this.WritingMode = writingMode;
            this.InstantiateWriters();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class with a logging mode with any specified mode
        /// </summary>
        /// <param name="loggingMode">Logging mode that will be used</param>
        public Logger(LoggingMode loggingMode)
        {
            this.LoggingMode = loggingMode;
            this.InstantiateWriters();
        }

        /// <summary>
        /// Gets or sets the properties that the messages have
        /// </summary>
        public MessageProperties MessageProperties { get; set; } = new MessageProperties();

        /// <summary>
        /// Gets the file path where the logging files will be stored, has to be set with the override constructor
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// Gets the fileName that will be used to store the logging, has to be set with the override constructor
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets the usage mode, it cannot be modified after instantiation
        /// </summary>
        public LoggingMode LoggingMode { get; private set; }

        /// <summary>
        /// Gets the writing mode, it cannot be modified after instantiation, has to be set with the override constructor
        /// </summary>
        public WritingMode WritingMode { get; private set; }

        /// <summary>
        /// Writes the message depending on the specified message level and the logging mode set in the logger class
        /// </summary>
        /// <param name="msg">Message to log</param>
        /// <param name="messageLevel">Indicates the level of the message</param>
        public void WriteMessage(string msg, MessageLevel messageLevel = MessageLevel.Info)
        {
            msg = MessageBuilder.MessageStringBuilder(msg, messageLevel, this.MessageProperties.ShowPrefix, this.MessageProperties.ShowTimeStamp, this.MessageProperties.TimeStampFormat);
            MessageLevelProperties.IncreaseCounter(messageLevel);
            this.messageWriter.WriteMessage(msg, messageLevel);
        }
        
        /// <summary>
        /// This class initializes the Message Write depending on the provided logging mode
        /// </summary>
        private void InstantiateWriters()
        {
            switch (LoggingMode)
            {
                case LoggingMode.Console:
                    this.messageWriter = new ConsoleWriter();
                    break;
                case LoggingMode.Debug:
                    this.messageWriter = new DebuggerWriter();
                    break;
                case LoggingMode.TextFile:
                    this.messageWriter = new TextFileWriter(this.FilePath, this.FileName, this.WritingMode);
                    break;
                default:
                    break;
            }
        }
    }   
}