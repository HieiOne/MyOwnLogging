// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Messages
{
    using System;
    using System.Drawing;

    /// <summary>
    /// Defines the Message levels properties, including the prefixes, colors and other information regarding the levels.
    /// This class creates statics objects representing each Enum Value (manually)
    /// </summary>
    internal sealed class MessageLevelProperties
    {
        /// <summary>
        /// Initialization of Info Message Level
        /// </summary>
        private static readonly MessageLevelProperties Info = new MessageLevelProperties("INFO");

        /// <summary>
        /// Initialization of Success Message Level
        /// </summary>
        private static readonly MessageLevelProperties Success = new MessageLevelProperties("OK", Color.Green, ConsoleColor.Green);

        /// <summary>
        /// Initialization of Warning Message Level
        /// </summary>
        private static readonly MessageLevelProperties Warning = new MessageLevelProperties("WARNING", Color.Yellow, ConsoleColor.Yellow);

        /// <summary>
        /// Initialization of Error Message Level
        /// </summary>
        private static readonly MessageLevelProperties Error = new MessageLevelProperties("ERROR", Color.Red, ConsoleColor.Red);

        /// <summary>
        /// Initialization of Debug Message Level
        /// </summary>
        private static readonly MessageLevelProperties Debug = new MessageLevelProperties("DEBUG", Color.Blue, ConsoleColor.Blue);

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageLevelProperties"/> class, the constructor to create a Message Level Property used to create the message levels on the Enum MessagingLevel manually
        /// </summary>
        /// <param name="prefixMessage">Prefix message that will be used</param>
        /// <param name="formColor">Color that will be used in forms</param>
        /// <param name="consoleColor">Color that will be used in console</param>
        public MessageLevelProperties(string prefixMessage, Color formColor = default, ConsoleColor? consoleColor = null)
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
            {
                this.DisplayColor = false;
            }
        }

        /// <summary>
        /// Gets or sets the prefix message
        /// </summary>
        public string PrefixMessage { get; set; }

        /// <summary>
        /// Gets or sets the color that will be used in Forms
        /// </summary>
        public Color FormColor { get; set; }

        /// <summary>
        /// Gets or sets the color that will be used in Console
        /// </summary>
        public ConsoleColor ConsoleColor { get; set; }

        /// <summary>
        /// Gets a value indicating whether the prefix will be used in the creation of the log message or not
        /// </summary>
        public bool DisplayColor { get; private set; }

        /// <summary>
        /// Gets or sets privately the counter of how many times each message level was used
        /// </summary>
        private int Counter { get; set; }

        /// <summary>
        /// Gets the prefix depending on <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to get the value from</param>
        /// <returns>String with the prefix of the message level</returns>
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

        /// <summary>
        /// Sets the prefix of the <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to set the value to</param>
        /// <param name="prefixMsg">Prefix to set the prefix to</param>
        public static void SetPrefix(MessageLevel messageLevel, string prefixMsg)
        {
            switch (messageLevel)
            {
                case MessageLevel.Info:
                    MessageLevelProperties.Info.PrefixMessage = prefixMsg;
                    break;
                case MessageLevel.Success:
                    MessageLevelProperties.Success.PrefixMessage = prefixMsg;
                    break;
                case MessageLevel.Warning:
                    MessageLevelProperties.Warning.PrefixMessage = prefixMsg;
                    break;
                case MessageLevel.Error:
                    MessageLevelProperties.Error.PrefixMessage = prefixMsg;
                    break;
                case MessageLevel.Debug:
                    MessageLevelProperties.Debug.PrefixMessage = prefixMsg;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Gets the Console color depending on the <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to get the value from</param>
        /// <returns>ConsoleColor of the specified <paramref name="messageLevel"/></returns>
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

        /// <summary>
        /// Gets the counter depending on <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to get the value from</param>
        /// <returns>Integer with the counter of messages written</returns>
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

        /// <summary>
        /// Gets the boolean value specifying if the color will be displayed or not depending on the <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to get the value from</param>
        /// <returns>Boolean value of the specified <paramref name="messageLevel"/></returns>
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

        /// <summary>
        /// Sets the Console Color of the <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to set the value to</param>
        /// <param name="consoleColor">Color to set the value to</param>
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

        /// <summary>
        /// Increases the counter of the specified <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to increase the counter</param>
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
