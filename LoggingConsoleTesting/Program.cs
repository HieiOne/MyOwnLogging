using System;

namespace LoggingConsoleTesting
{
    using Logging;

    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            logger.ShowPrefix = true;
            logger.ShowTimeStamp = true;
            logger.WriteMsg("Hola Test Logging");
            logger.WriteMsg("Hola Test Logging");
            logger.WriteMsg("Hola Test Logging");
            logger.WriteMsg("Hola Test Logging", MessageLevel.Debug);
            logger.WriteMsg("Hola Test Logging", MessageLevel.Debug);
            logger.WriteMsg("Hola Test Logging", MessageLevel.Warning);
            logger.WriteMsg("Hola Test Logging", MessageLevel.Error);
            Console.WriteLine("Info Messages: " + logger.GetMessageCounter(MessageLevel.Info));
            Console.WriteLine("Success Messages: " + logger.GetMessageCounter(MessageLevel.Success));
            Console.WriteLine("Warning Messages: " + logger.GetMessageCounter(MessageLevel.Warning));
            Console.WriteLine("Error Messages: " + logger.GetMessageCounter(MessageLevel.Error));
            Console.WriteLine("Debug Messages: " + logger.GetMessageCounter(MessageLevel.Debug));
            Console.ReadKey();
        }
    }
}
