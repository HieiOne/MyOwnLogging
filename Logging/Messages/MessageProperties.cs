// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Messages
{
    using System;

    /// <summary>
    /// Defines the properties of the message, indicating if it will have prefixes, timestamps or different colors
    /// </summary>
    public class MessageProperties
    {
        /// <summary>
        /// Gets or sets a value indicating whether the message will display a timestamp or not, by default false
        /// </summary>
        public bool ShowTimeStamp { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the message will display the prefix or not, by default false
        /// </summary>
        public bool ShowPrefix { get; set; } = true;

        /// <summary>
        /// Gets or sets the time stamp format, the default value is the current system culture
        /// </summary>
        public string TimeStampFormat { get; set; } ////= "hh:mm:ss";

        /// <summary>
        /// Gets the full name of the file including the path, checking if the filePath ends or not with the directory separator char
        /// </summary>
        /// <param name="filePath">File path of the file</param>
        /// <param name="fileName">Filename of the file</param>
        /// <returns>Returns a full path with fileName included</returns>
        public static string GetFullNamePath(string filePath, string fileName)
        {
            // Check if the file path includes the directory separator char
            if (filePath[filePath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
            {
                return filePath + System.IO.Path.DirectorySeparatorChar + fileName;
            }
            else
            {
                return filePath + fileName;
            }
        }

        /// <summary>
        /// Gets the counter depending on <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to get the value from</param>
        /// <returns>Integer with the counter of messages written</returns>
        public int GetCounter(MessageLevel messageLevel) 
        { 
            return MessageLevelProperties.GetCounter(messageLevel); 
        }

        /// <summary>
        /// Gets the prefix depending on <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to get the value from</param>
        /// <returns>String with the prefix of the message level</returns>
        public string GetPrefix(MessageLevel messageLevel) 
        { 
            return MessageLevelProperties.GetPrefix(messageLevel); 
        }

        /// <summary>
        /// Sets the prefix of the <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to set the value to</param>
        /// <param name="prefixMsg">Prefix to set the prefix to</param>
        public void SetPrefix(MessageLevel messageLevel, string prefixMsg) 
        { 
            MessageLevelProperties.SetPrefix(messageLevel, prefixMsg); 
        }

        /// <summary>
        /// Sets the Console Color of the <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to set the value to</param>
        /// <param name="consoleColor">Color to set the value to</param>
        public void SetConsoleColor(MessageLevel messageLevel, ConsoleColor consoleColor) 
        { 
            MessageLevelProperties.SetConsoleColor(messageLevel, consoleColor); 
        }
    }
}