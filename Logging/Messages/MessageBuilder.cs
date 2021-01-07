// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Messages
{
    using System.Text;

    /// <summary>
    /// Class that builds the string depending on the properties set on MessageLevelProperties and MessageProperties classes
    /// </summary>
    public class MessageBuilder
    {
        /// <summary>
        /// Builds a fully fledged string depending on the properties values
        /// </summary>
        /// <param name="msg">Message to build with</param>
        /// <param name="messageLevel">Message level, used to get the prefix and colors</param>
        /// <param name="messageProperties">Properties of the message</param>
        /// <param name="messageLevelProperties">Properties of each message level</param>
        /// <returns>Returns a string following the properties values</returns>
        public static string MessageStringBuilder(string msg, MessageLevel messageLevel, MessageProperties messageProperties, MessageLevelProperties messageLevelProperties /*bool showPrefix, bool showTimeStamp, string timeStampFormat = null*/)
        {
            StringBuilder stringBuilder = new StringBuilder();

            // TimeStamp configuration
            string timeStamp = null;
            if (messageProperties.ShowTimeStamp)
            {
                timeStamp = "[";

                if (messageProperties.TimeStampFormat != null)
                {
                    timeStamp += System.DateTime.Now.ToString(messageProperties.TimeStampFormat);
                }
                else
                {
                    timeStamp += System.DateTime.Now.ToString();
                }

                timeStamp += "] ";
            }

            // Prefix configuration
            string prefixMsg = null;
            if (messageProperties.ShowPrefix)
            {
                prefixMsg = messageLevelProperties.GetPrefix(messageLevel) + ": ";
            }

            stringBuilder.AppendFormat("{0}{1}{2}", timeStamp, prefixMsg, msg);
            return stringBuilder.ToString();
        }
    }
}