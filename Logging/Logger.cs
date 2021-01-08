// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging
{
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
}