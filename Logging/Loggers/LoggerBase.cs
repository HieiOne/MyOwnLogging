// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Loggers
{
    using Messages;
    using Writers;

    /// <summary>
    /// Base class for the Loggers
    /// </summary>
    public class LoggerBase
    {
        /// <summary>
        /// Class that handles the writing depending on the Logging Mode provided
        /// </summary>
        internal IWriter MessageWriter;

        /// <summary>
        /// Gets or sets the properties that the messages have
        /// </summary>
        public MessageProperties MessageProperties { get; set; } = new MessageProperties();

        /// <summary>
        /// Gets or sets the properties that each message level has
        /// </summary>
        public MessageLevelProperties MessageLevelProperties { get; set; } = new MessageLevelProperties();

        /// <summary>
        /// Writes the message depending on the specified message level and the logging mode set in the logger class
        /// </summary>
        /// <param name="msg">Message to log</param>
        /// <param name="messageLevel">Indicates the level of the message</param>
        public void WriteMessage(string msg, MessageLevel messageLevel = MessageLevel.Info)
        {
            msg = MessageBuilder.MessageStringBuilder(msg, messageLevel, this.MessageProperties, this.MessageLevelProperties);
            MessageLevelProperties.IncreaseCounter(messageLevel);
            this.MessageWriter.WriteMessage(msg, messageLevel, this.MessageProperties, this.MessageLevelProperties);
        }
    }
}
