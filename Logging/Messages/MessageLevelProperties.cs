// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Messages
{
    using System;
    using System.Drawing;

    /// <summary>
    /// Defines a message level properties and its construction, including the prefixes, colors and other information regarding a specific level.
    /// </summary>
    public class MessageLevelProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageLevelProperty"/> class, the constructor to create a Message Level Property used to create the message levels on the Enum MessagingLevel manually
        /// </summary>
        /// <param name="prefixMessage">Prefix message that will be used</param>
        /// <param name="formColor">Color that will be used in forms</param>
        /// <param name="consoleColor">Color that will be used in console</param>
        public MessageLevelProperty(string prefixMessage, Color formColor = default, ConsoleColor? consoleColor = null)
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
        /// Gets the color that will be used in Console
        /// </summary>
        public ConsoleColor ConsoleColor { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the prefix will be used in the creation of the log message or not
        /// </summary>
        public bool DisplayColor { get; private set; }

        /// <summary>
        /// Gets the counter of how many times each message level was used
        /// </summary>
        public int Counter { get; private set; }

        /// <summary>
        /// Sets console color and the display color property to true
        /// </summary>
        /// <param name="consoleColor">Color to set the value to</param>
        internal void SetConsoleColor(ConsoleColor consoleColor)
        {
            this.ConsoleColor = consoleColor;
            this.DisplayColor = true;
        }

        internal void IncreaseCounter()
        {
            this.Counter++;
        }
    }

    /// <summary>
    /// Defines the Message levels properties, including the prefixes, colors and other information regarding the levels.
    /// </summary>
    public class MessageLevelProperties
    {
        /// <summary>
        /// Gets the info properties and can be modified through it
        /// Initialization of Info Message Level
        /// </summary>
        public MessageLevelProperty Info { get; } = new MessageLevelProperty("INFO");

        /// <summary>
        /// Gets the success properties and can be modified through it
        /// Initialization of Success Message Level
        /// </summary>
        public MessageLevelProperty Success { get; } = new MessageLevelProperty("OK", Color.Green, ConsoleColor.Green);

        /// <summary>        
        /// Gets the warning properties and can be modified through it
        /// Initialization of Warning Message Level
        /// </summary>
        public MessageLevelProperty Warning { get; } = new MessageLevelProperty("WARNING", Color.Yellow, ConsoleColor.Yellow);

        /// <summary>
        /// Gets the error properties and can be modified through it
        /// Initialization of Error Message Level
        /// </summary>
        public MessageLevelProperty Error { get; } = new MessageLevelProperty("ERROR", Color.Red, ConsoleColor.Red);

        /// <summary>
        /// Gets the debug properties and can be modified through it
        /// Initialization of Debug Message Level
        /// </summary>
        public MessageLevelProperty Debug { get; } = new MessageLevelProperty("DEBUG", Color.Blue, ConsoleColor.Blue);

        /// <summary>
        /// Gets the prefix depending on <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to get the value from</param>
        /// <returns>String with the prefix of the message level</returns>
        public string GetPrefix(MessageLevel messageLevel)
        {
            switch (messageLevel)
            {
                case MessageLevel.Info:
                    return this.Info.PrefixMessage;
                case MessageLevel.Success:
                    return this.Success.PrefixMessage;
                case MessageLevel.Warning:
                    return this.Warning.PrefixMessage;
                case MessageLevel.Error:
                    return this.Error.PrefixMessage;
                case MessageLevel.Debug:
                    return this.Debug.PrefixMessage;
                default:
                    return default;
            }
        }

        /// <summary>
        /// Sets the prefix of the <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to set the value to</param>
        /// <param name="prefixMsg">Prefix to set the prefix to</param>
        public void SetPrefix(MessageLevel messageLevel, string prefixMsg)
        {
            switch (messageLevel)
            {
                case MessageLevel.Info:
                    this.Info.PrefixMessage = prefixMsg;
                    break;
                case MessageLevel.Success:
                    this.Success.PrefixMessage = prefixMsg;
                    break;
                case MessageLevel.Warning:
                    this.Warning.PrefixMessage = prefixMsg;
                    break;
                case MessageLevel.Error:
                    this.Error.PrefixMessage = prefixMsg;
                    break;
                case MessageLevel.Debug:
                    this.Debug.PrefixMessage = prefixMsg;
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
        public ConsoleColor GetConsoleColor(MessageLevel messageLevel)
        {
            switch (messageLevel)
            {
                case MessageLevel.Info:
                    return this.Info.ConsoleColor;
                case MessageLevel.Success:
                    return this.Success.ConsoleColor;
                case MessageLevel.Warning:
                    return this.Warning.ConsoleColor;
                case MessageLevel.Error:
                    return this.Error.ConsoleColor;
                case MessageLevel.Debug:
                    return this.Debug.ConsoleColor;
                default:
                    return default;
            }
        }

        /// <summary>
        /// Gets the counter depending on <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to get the value from</param>
        /// <returns>Integer with the counter of messages written</returns>
        public int GetCounter(MessageLevel messageLevel)
        {
            switch (messageLevel)
            {
                case MessageLevel.Info:
                    return this.Info.Counter;
                case MessageLevel.Success:
                    return this.Success.Counter;
                case MessageLevel.Warning:
                    return this.Warning.Counter;
                case MessageLevel.Error:
                    return this.Error.Counter;
                case MessageLevel.Debug:
                    return this.Debug.Counter;
                default:
                    return default;
            }
        }

        /// <summary>
        /// Gets the boolean value specifying if the color will be displayed or not depending on the <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to get the value from</param>
        /// <returns>Boolean value of the specified <paramref name="messageLevel"/></returns>
        public bool GetDisplayColor(MessageLevel messageLevel)
        {
            switch (messageLevel)
            {
                case MessageLevel.Info:
                    return this.Info.DisplayColor;
                case MessageLevel.Success:
                    return this.Success.DisplayColor;
                case MessageLevel.Warning:
                    return this.Warning.DisplayColor;
                case MessageLevel.Error:
                    return this.Error.DisplayColor;
                case MessageLevel.Debug:
                    return this.Debug.DisplayColor;
                default:
                    return default;
            }
        }

        /// <summary>
        /// Sets the Console Color of the <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to set the value to</param>
        /// <param name="consoleColor">Color to set the value to</param>
        public void SetConsoleColor(MessageLevel messageLevel, ConsoleColor consoleColor)
        {
            switch (messageLevel)
            {
                case MessageLevel.Info:
                    this.Info.SetConsoleColor(consoleColor);
                    break;
                case MessageLevel.Success:
                    this.Success.SetConsoleColor(consoleColor);
                    break;
                case MessageLevel.Warning:
                    this.Warning.SetConsoleColor(consoleColor);
                    break;
                case MessageLevel.Error:
                    this.Error.SetConsoleColor(consoleColor);
                    break;
                case MessageLevel.Debug:
                    this.Debug.SetConsoleColor(consoleColor);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Increases the counter of the specified <paramref name="messageLevel"/>
        /// </summary>
        /// <param name="messageLevel">Message level to increase the counter</param>
        internal void IncreaseCounter(MessageLevel messageLevel)
        {
            switch (messageLevel)
            {
                case MessageLevel.Info:
                    this.Info.IncreaseCounter();
                    break;
                case MessageLevel.Success:
                    this.Success.IncreaseCounter();
                    break;
                case MessageLevel.Warning:
                    this.Warning.IncreaseCounter();
                    break;
                case MessageLevel.Error:
                    this.Error.IncreaseCounter();
                    break;
                case MessageLevel.Debug:
                    this.Debug.IncreaseCounter();
                    break;
                default:
                    break;
            }
        }
    }
}
