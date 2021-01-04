using System;

namespace LoggingConsoleTesting
{
    using Logging;

    class Program
    {
        static void Main()
        {
            Logger logger = new Logger
            {
                ShowPrefix = true,
                ShowTimeStamp = true
            };
            logger.WriteMessage("Hola Test Logging");
            logger.WriteMessage("Hola Test Logging");
            logger.WriteMessage("Hola Test Logging");
            logger.WriteMessage("Hola Test Logging", MessageLevel.Debug);
            logger.WriteMessage("Hola Test Logging", MessageLevel.Debug);
            logger.WriteMessage("Hola Test Logging", MessageLevel.Warning);
            logger.WriteMessage("Hola Test Logging", MessageLevel.Error);
            logger.SetPrefix(MessageLevel.Info, "TEST CHANGE PREFIX");
            logger.WriteMessage("Prefix test");
            Console.WriteLine("Info Messages: " + logger.GetCounter(MessageLevel.Info));
            Console.WriteLine("Success Messages: " + logger.GetCounter(MessageLevel.Success));
            Console.WriteLine("Warning Messages: " + logger.GetCounter(MessageLevel.Warning));
            Console.WriteLine("Error Messages: " + logger.GetCounter(MessageLevel.Error));
            Console.WriteLine("Debug Messages: " + logger.GetCounter(MessageLevel.Debug));

            Logger debugLogger = new Logger(LoggingMode.Debug);
            debugLogger.ShowPrefix = true;
            debugLogger.ShowTimeStamp = true;
            debugLogger.WriteMessage("TEST", MessageLevel.Debug);
            Console.ReadKey();
        }
    }
}
