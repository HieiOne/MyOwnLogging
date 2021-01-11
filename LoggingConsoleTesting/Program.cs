using System;

namespace LoggingConsoleTesting
{
    using Logging;
    using Logging.Writers;

    internal class Program
    {
        private static void Main()
        {
            ConsoleWriter logger = new ConsoleWriter();
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

            DebuggerWriter debugLogger = new DebuggerWriter();
            debugLogger.WriteMessage("TEST", MessageLevel.Debug);

            TextFileWriter textLogger = new TextFileWriter(@"C:\temp", "PruebaLog", WritingMode.Appending);
            textLogger.MessageProperties.TimeStampFormat = "hh:mm:ss";
            textLogger.WriteMessage("Test");
            textLogger.WriteMessage("Test2");
            textLogger.WriteMessage("Test");
            textLogger.WriteMessage("Test2");

            TextFileWriter textLogger2 = new TextFileWriter(@"C:\temp", "PruebaLog2", WritingMode.Recreating);
            textLogger2.WriteMessage("Test3");
            textLogger2.WriteMessage("Test5");
            textLogger2.WriteMessage("Test4");

            Console.ReadKey();
        }
    }
}