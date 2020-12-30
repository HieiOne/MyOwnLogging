using System;
using System.Drawing;

namespace Logging.Messages
{
    public sealed class MessageLevelProperties
    {
        public string PrefixMessage { get; set; }
        public Color DisplayColor { get; set; }
        public ConsoleColor ConsoleColor { get; set; }
        private int Counter { get; set; }

        public static MessageLevelProperties Info = new MessageLevelProperties("INFO");
        public static MessageLevelProperties Success = new MessageLevelProperties("OK", Color.Green, ConsoleColor.Green);
        public static MessageLevelProperties Warning = new MessageLevelProperties("WARNING", Color.Yellow, ConsoleColor.Yellow);
        public static MessageLevelProperties Error = new MessageLevelProperties("ERROR", Color.Red, ConsoleColor.Red);
        public static MessageLevelProperties Debug = new MessageLevelProperties("DEBUG", Color.Blue, ConsoleColor.Blue);

        private MessageLevelProperties(string prefixMessage, Color displayColor = default, ConsoleColor consoleColor = ConsoleColor.White)
        {
            this.PrefixMessage = prefixMessage;
            this.DisplayColor = displayColor;
            this.ConsoleColor = consoleColor;
            this.Counter = 0;
        }

        public static string GetPrefix(MessageLevel messageLevel)
        {
            switch (messageLevel)
            {
                case MessageLevel.Info:
                    return MessageLevelProperties.Info.PrefixMessage;
                case MessageLevel.Success:
                    return MessageLevelProperties.Success.PrefixMessage;
                case MessageLevel.Warning:
                    return MessageLevelProperties.Warning.PrefixMessage;
                case MessageLevel.Error:
                    return MessageLevelProperties.Error.PrefixMessage;
                case MessageLevel.Debug:
                    return MessageLevelProperties.Debug.PrefixMessage;
                default:
                    return default;
            }
        }

        public static ConsoleColor GetConsoleColor(MessageLevel messageLevel)
        {
            switch (messageLevel)
            {
                case MessageLevel.Info:
                    return MessageLevelProperties.Info.ConsoleColor;
                case MessageLevel.Success:
                    return MessageLevelProperties.Success.ConsoleColor;
                case MessageLevel.Warning:
                    return MessageLevelProperties.Warning.ConsoleColor;
                case MessageLevel.Error:
                    return MessageLevelProperties.Error.ConsoleColor;
                case MessageLevel.Debug:
                    return MessageLevelProperties.Debug.ConsoleColor;
                default:
                    return default;
            }
        }

        public static int GetCounter(MessageLevel messageLevel)
        {
            switch (messageLevel)
            {
                case MessageLevel.Info:
                    return MessageLevelProperties.Info.Counter;
                case MessageLevel.Success:
                    return MessageLevelProperties.Success.Counter;
                case MessageLevel.Warning:
                    return MessageLevelProperties.Warning.Counter;
                case MessageLevel.Error:
                    return MessageLevelProperties.Error.Counter;
                case MessageLevel.Debug:
                    return MessageLevelProperties.Debug.Counter;
                default:
                    return default;
            }
        }

        internal static void IncreaseCounter(MessageLevel messageLevel)
        {
            switch (messageLevel)
            {
                case MessageLevel.Info:
                    MessageLevelProperties.Info.Counter++;
                    break;
                case MessageLevel.Success:
                    MessageLevelProperties.Success.Counter++;
                    break;
                case MessageLevel.Warning:
                    MessageLevelProperties.Warning.Counter++;
                    break;
                case MessageLevel.Error:
                    MessageLevelProperties.Error.Counter++;
                    break;
                case MessageLevel.Debug:
                    MessageLevelProperties.Debug.Counter++;
                    break;
                default:
                    break;
            }
        }
    }
}
