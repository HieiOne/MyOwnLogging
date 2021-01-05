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
        /// Console color to display the message with, mostly specified in the MessageLevelProperties
        /// </summary>
        public ConsoleColor consoleColor;

        /// <summary>
        /// Indicates if the color that is passed should be used or not
        /// </summary>
        public bool displayColor;

        /// <summary>
        /// Initializes a new instance of the Console Writer
        /// </summary>
        /// <param name="consoleColor"></param>
        /// <param name="displayColor"></param>
        public ConsoleWriter(ConsoleColor consoleColor, bool displayColor)
        {
            this.consoleColor = consoleColor;
            this.displayColor = displayColor;
        }

        /// <summary>
        /// Method to write into the console
        /// </summary>
        /// <param name="msg">Message to display</param>
        public virtual void WriteMessage(string msg)
        {
            if (displayColor)
            {
                Console.ForegroundColor = consoleColor;
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
