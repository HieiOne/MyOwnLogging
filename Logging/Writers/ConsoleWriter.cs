// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Writers
{
    using System;

    /// <summary>
    /// This class is used to write into the console
    /// </summary>
    internal class ConsoleWriter : IWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleWriter"/> class
        /// </summary>
        /// <param name="consoleColor">Console color that will be used</param>
        /// <param name="displayColor">Indicates whether or not color will be used</param>
        public ConsoleWriter(ConsoleColor consoleColor, bool displayColor)
        {
            this.ConsoleColor = consoleColor;
            this.DisplayColor = displayColor;
        }

        /// <summary>
        /// Gets or sets the console color to display the message with, mostly specified in the MessageLevelProperties
        /// </summary>
        public ConsoleColor ConsoleColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the color that is passed should be used or not
        /// </summary>
        public bool DisplayColor { get; set; }

        /// <summary>
        /// Method to write into the console
        /// </summary>
        /// <param name="msg">Message to display</param>
        public virtual void WriteMessage(string msg)
        {
            if (this.DisplayColor)
            {
                Console.ForegroundColor = this.ConsoleColor;
                Console.WriteLine(msg);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(msg);
            }
        }        
    }
}
