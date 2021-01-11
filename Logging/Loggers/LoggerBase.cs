// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Loggers
{
    using Logging.Messages;

    /// <summary>
    /// Base for all Writers use the specific Loggers instead of the base to log.
    /// </summary>
    public abstract class LoggerBase
    {
        /// <summary>
        /// Gets or sets the properties that the messages have
        /// </summary>
        public MessageProperties MessageProperties { get; set; } = new MessageProperties();

        /// <summary>
        /// Gets or sets the properties that each message level has
        /// </summary>
        public MessageLevelProperties MessageLevelProperties { get; set; } = new MessageLevelProperties();

        /// <summary>
        /// Builds the message and increases counter of the message level
        /// </summary>
        /// <param name="msg">Message to build</param>
        /// <param name="messageLevel">Message level of the message</param>
        public void WriteMessage(string msg, MessageLevel messageLevel = MessageLevel.Info)
        {
            msg = MessageBuilder.MessageStringBuilder(msg, messageLevel, this.MessageProperties, this.MessageLevelProperties);
            MessageLevelProperties.IncreaseCounter(messageLevel);
            this.WriterLogger(msg, messageLevel);
        }

        /// <summary>
        /// Method to write messages in writers
        /// </summary>
        /// <param name="msg">Message to be displayed</param>
        /// <param name="messageLevel">Indicates the level of the message</param>
        internal abstract void WriterLogger(string msg, MessageLevel messageLevel);
    }
}
