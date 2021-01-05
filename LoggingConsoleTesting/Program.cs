using System;

namespace LoggingConsoleTesting
{
    using Logging;

    class Program
    {
        static void Main()
        {
            Logger logger = new Logger(LoggingMode.Console);
            logger.WriteMessage("Hola Test Logging");
            logger.MessageProperties.SetPrefix(MessageLevel.Info, "INFORMACION");
            logger.MessageProperties.SetConsoleColor(MessageLevel.Info, ConsoleColor.DarkCyan);
            logger.WriteMessage("Hola Test Logging");
            logger.WriteMessage("Hola Test Logging");
            logger.WriteMessage("Hola Test Logging", MessageLevel.Debug);
            logger.WriteMessage("Hola Test Logging", MessageLevel.Debug);
            logger.WriteMessage("Hola Test Logging", MessageLevel.Warning);
            logger.WriteMessage("Hola Test Logging", MessageLevel.Error);
            logger.MessageProperties.SetPrefix(MessageLevel.Error, "TEST CHANGE PREFIX");
            logger.WriteMessage("Prefix test");
            Console.WriteLine("Info Messages: " + logger.MessageProperties.GetCounter(MessageLevel.Info));
            Console.WriteLine("Success Messages: " + logger.MessageProperties.GetCounter(MessageLevel.Success));
            Console.WriteLine("Warning Messages: " + logger.MessageProperties.GetCounter(MessageLevel.Warning));
            Console.WriteLine("Error Messages: " + logger.MessageProperties.GetCounter(MessageLevel.Error));
            Console.WriteLine("Debug Messages: " + logger.MessageProperties.GetCounter(MessageLevel.Debug));

            Logger debugLogger = new Logger(LoggingMode.Debug);
            debugLogger.WriteMessage("TEST", MessageLevel.Debug);

            Logger textLogger = new Logger(@"C:\temp", "PruebaLog", LoggingMode.TextFile, WritingMode.Appending);    
            textLogger.WriteMessage("Test");
            textLogger.WriteMessage("Test2");
            textLogger.WriteMessage("Test");
            textLogger.WriteMessage("Test2");

            Logger textLogger2 = new Logger(@"C:\temp", "PruebaLog2", LoggingMode.TextFile, WritingMode.Recreating);
            textLogger2.WriteMessage("Test3");
            textLogger2.WriteMessage("Test5");
            textLogger2.WriteMessage("Test4");

            Console.ReadKey();
        }
    }
}
