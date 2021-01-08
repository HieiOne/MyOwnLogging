using System;

namespace LoggingConsoleTesting
{
    using Logging;
    using Logging.Loggers;

    internal class Program
    {
        private static void Main()
        {
            ConsoleLogger logger = new ConsoleLogger();
            logger.WriteMessage("Hola Test Logging");
            logger.MessageLevelProperties.SetPrefix(MessageLevel.Info, "INFORMACION");
            logger.MessageLevelProperties.SetConsoleColor(MessageLevel.Info, ConsoleColor.DarkCyan);
            logger.WriteMessage("Hola Test Logging");
            logger.WriteMessage("Hola Test Logging");
            logger.WriteMessage("Hola Test Logging", MessageLevel.Debug);
            logger.WriteMessage("Hola Test Logging", MessageLevel.Debug);
            logger.WriteMessage("Hola Test Logging", MessageLevel.Warning);
            logger.WriteMessage("Hola Test Logging", MessageLevel.Error);
            logger.MessageLevelProperties.SetPrefix(MessageLevel.Error, "TEST CHANGE PREFIX");
            logger.WriteMessage("Prefix test");
            Console.WriteLine("Info Messages: " + logger.MessageLevelProperties.GetCounter(MessageLevel.Info));
            Console.WriteLine("Success Messages: " + logger.MessageLevelProperties.GetCounter(MessageLevel.Success));
            Console.WriteLine("Warning Messages: " + logger.MessageLevelProperties.GetCounter(MessageLevel.Warning));
            Console.WriteLine("Error Messages: " + logger.MessageLevelProperties.GetCounter(MessageLevel.Error));
            Console.WriteLine("Debug Messages: " + logger.MessageLevelProperties.GetCounter(MessageLevel.Debug));

            DebugLogger debugLogger = new DebugLogger();
            debugLogger.WriteMessage("TEST", MessageLevel.Debug);

            FileLogger textLogger = new FileLogger(@"C:\temp", "PruebaLog", WritingMode.Appending);
            textLogger.MessageProperties.TimeStampFormat = "hh:mm:ss";
            textLogger.WriteMessage("Test");
            textLogger.WriteMessage("Test2");
            textLogger.WriteMessage("Test");
            textLogger.WriteMessage("Test2");

            FileLogger textLogger2 = new FileLogger(@"C:\temp", "PruebaLog2", WritingMode.Recreating);
            textLogger2.WriteMessage("Test3");
            textLogger2.WriteMessage("Test5");
            textLogger2.WriteMessage("Test4");

            Console.ReadKey();
        }
    }
}