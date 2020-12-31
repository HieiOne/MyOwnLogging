using System;
using System.Drawing;

namespace Logging.Messages
{
    public sealed class MessageLevelProperties
    {
        public string PrefixMessage { get; set; }
        public Color FormColor { get; set; }
        public ConsoleColor ConsoleColor { get; set; }
        public bool DisplayColor { get; private set; }
        private int Counter { get; set; }

        public static MessageLevelProperties Info = new MessageLevelProperties("INFO");
        public static MessageLevelProperties Success = new MessageLevelProperties("OK", Color.Green, ConsoleColor.Green);
        public static MessageLevelProperties Warning = new MessageLevelProperties("WARNING", Color.Yellow, ConsoleColor.Yellow);
        public static MessageLevelProperties Error = new MessageLevelProperties("ERROR", Color.Red, ConsoleColor.Red);
        public static MessageLevelProperties Debug = new MessageLevelProperties("DEBUG", Color.Blue, ConsoleColor.Blue);

        private MessageLevelProperties(string prefixMessage, Color formColor = default, ConsoleColor? consoleColor = null)
        {
            this.PrefixMessage = prefixMessage;
            this.FormColor = formColor;
            this.Counter = 0;
            if (consoleColor != null)
            {
                this.ConsoleColor = (ConsoleColor)consoleColor;
                this.DisplayColor = true;
            }
            else
                this.DisplayColor = false;
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

        public static bool GetDisplayColor(MessageLevel messageLevel)
        {
            switch (messageLevel)
            {
                case MessageLevel.Info:
                    return MessageLevelProperties.Info.DisplayColor;
                case MessageLevel.Success:
                    return MessageLevelProperties.Success.DisplayColor;
                case MessageLevel.Warning:
                    return MessageLevelProperties.Warning.DisplayColor;
                case MessageLevel.Error:
                    return MessageLevelProperties.Error.DisplayColor;
                case MessageLevel.Debug:
                    return MessageLevelProperties.Debug.DisplayColor;
                default:
                    return default;
            }
        }

        public static void SetConsoleColor(MessageLevel messageLevel, ConsoleColor consoleColor)
        {
            switch (messageLevel)
            {
                case MessageLevel.Info:
                    MessageLevelProperties.Info.ConsoleColor = consoleColor;
                    MessageLevelProperties.Info.DisplayColor = true;
                    break;
                case MessageLevel.Success:
                    MessageLevelProperties.Success.ConsoleColor = consoleColor;
                    MessageLevelProperties.Success.DisplayColor = true;
                    break;
                case MessageLevel.Warning:
                    MessageLevelProperties.Warning.ConsoleColor = consoleColor;
                    MessageLevelProperties.Warning.DisplayColor = true;
                    break;
                case MessageLevel.Error:
                    MessageLevelProperties.Error.ConsoleColor = consoleColor;
                    MessageLevelProperties.Error.DisplayColor = true;
                    break;
                case MessageLevel.Debug:
                    MessageLevelProperties.Debug.ConsoleColor = consoleColor;
                    MessageLevelProperties.Debug.DisplayColor = true;
                    break;
                default:
                    break;
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
