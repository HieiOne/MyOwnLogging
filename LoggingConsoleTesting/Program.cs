using System;

namespace LoggingConsoleTesting
{
    using Logging;
    using Logging.Messages;

    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            logger.ShowPrefix = true;
            logger.ShowTimeStamp = true;            
            logger.WriteMessage("Hola Test Logging");
            logger.WriteMessage("Hola Test Logging");
            logger.WriteMessage("Hola Test Logging");
            logger.WriteMessage("Hola Test Logging", MessageLevel.Debug);
            logger.WriteMessage("Hola Test Logging", MessageLevel.Debug);
            logger.WriteMessage("Hola Test Logging", MessageLevel.Warning);
            logger.WriteMessage("Hola Test Logging", MessageLevel.Error);            
            Console.WriteLine("Info Messages: " + logger.GetCounter(MessageLevel.Info));
            Console.WriteLine("Success Messages: " + logger.GetCounter(MessageLevel.Success));
            Console.WriteLine("Warning Messages: " + logger.GetCounter(MessageLevel.Warning));
            Console.WriteLine("Error Messages: " + logger.GetCounter(MessageLevel.Error));
            Console.WriteLine("Debug Messages: " + logger.GetCounter(MessageLevel.Debug));
            Console.ReadKey();
        }
    }
}
