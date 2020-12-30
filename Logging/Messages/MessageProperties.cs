namespace Logging.Messages
{
    /// <summary>
    /// Defines the properties of the message, indicating if it will have prefixes, timestamps or different colors
    /// </summary>
    public class MessageProperties
    {
        public bool ShowTimeStamp { get; set; }

        public bool ShowPrefix { get; set; }

        /// <summary>
        /// Modify the time stamp format, the default value is the current system culture
        /// </summary>
        public string TimeStampFormat { get; set; } //= "hh:mm:ss";

        public int GetMessageCounter(MessageLevel messageLevel) { return MessageLevelProperties.GetCounter(messageLevel); }
    }
}