// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Writers
{
    using System;

    /// <summary>
    /// This class is used to write into the console
    /// </summary>
    internal class ConsoleWriter
    {
        /// <summary>
        /// Static method to write into the console
        /// </summary>
        /// <param name="msg">Message to display</param>
        /// <param name="consoleColor">Console color to display the message with, mostly specified in the MessageLevelProperties</param>
        /// <param name="displayColor">Indicates if the color that is passed should be used or not</param>
        public static void WriteMessage(string msg, ConsoleColor consoleColor, bool displayColor)
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
