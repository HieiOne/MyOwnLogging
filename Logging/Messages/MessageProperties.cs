// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Messages
{
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
    }
}