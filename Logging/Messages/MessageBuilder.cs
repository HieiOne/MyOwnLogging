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
        /// <param name="showPrefix">Indicates if the prefix has to be displayed</param>
        /// <param name="showTimeStamp">Indicates if the timeStamp has to be displayed</param>
        /// <param name="timeStampFormat">The timeStamp format that will be used</param>
        /// <returns>Returns a string following the properties values</returns>
        public static string MessageStringBuilder(string msg, MessageLevel messageLevel, bool showPrefix, bool showTimeStamp, string timeStampFormat = null)
        {
            StringBuilder stringBuilder = new StringBuilder();

            // TimeStamp configuration
            string timeStamp = null;
            if (showTimeStamp)
            {
                timeStamp = "[";
                
                if (timeStampFormat != null)
                {
                    timeStamp += System.DateTime.Now.ToString(timeStampFormat);
                }
                else
                {
                    timeStamp += System.DateTime.Now.ToString();
                }

                timeStamp += "] ";
            }

            // Prefix configuration
            string prefixMsg = null;
            if (showPrefix)
            {
                prefixMsg = MessageLevelProperties.GetPrefix(messageLevel) + ": ";
            }

            stringBuilder.AppendFormat("{0}{1}{2}", timeStamp, prefixMsg, msg);
            return stringBuilder.ToString();
        }
    }
}