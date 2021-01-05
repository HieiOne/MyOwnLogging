﻿using System;

namespace LoggingConsoleTesting
{
    using Logging;

    class Program
    {
        static void Main()
        {
            Logger logger = new Logger(LoggingMode.Console);
            logger.WriteMessage("Hola Test Logging");
            logger.SetPrefix(MessageLevel.Info, "INFORMACION");
            logger.SetConsoleColor(MessageLevel.Info, ConsoleColor.DarkCyan);
            logger.WriteMessage("Hola Test Logging");
            logger.WriteMessage("Hola Test Logging");
            logger.WriteMessage("Hola Test Logging", MessageLevel.Debug);
            logger.WriteMessage("Hola Test Logging", MessageLevel.Debug);
            logger.WriteMessage("Hola Test Logging", MessageLevel.Warning);
            logger.WriteMessage("Hola Test Logging", MessageLevel.Error);
            logger.SetPrefix(MessageLevel.Error, "TEST CHANGE PREFIX");
            logger.WriteMessage("Prefix test");
            Console.WriteLine("Info Messages: " + logger.GetCounter(MessageLevel.Info));
            Console.WriteLine("Success Messages: " + logger.GetCounter(MessageLevel.Success));
            Console.WriteLine("Warning Messages: " + logger.GetCounter(MessageLevel.Warning));
            Console.WriteLine("Error Messages: " + logger.GetCounter(MessageLevel.Error));
            Console.WriteLine("Debug Messages: " + logger.GetCounter(MessageLevel.Debug));

            Logger debugLogger = new Logger(LoggingMode.Debug);
            debugLogger.WriteMessage("TEST", MessageLevel.Debug);

            Logger textLogger = new Logger(@"C:\temp", "PruebaLog", LoggingMode.TextFile, WritingMode.Appending);    
            textLogger.WriteMessage("Test");
            textLogger.WriteMessage("Test2");
            textLogger.WriteMessage("Test");
            textLogger.WriteMessage("Test2");

            Console.ReadKey();
        }
    }
}
