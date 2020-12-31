using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Writers
{
    class ConsoleWriter
    {
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
