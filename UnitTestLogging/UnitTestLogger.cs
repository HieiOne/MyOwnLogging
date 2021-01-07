using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logging;

namespace UnitTestLogging
{
    [TestClass]
    public class UnitTestLoggerCounter
    {
        readonly Logger logger = new Logger(LoggingMode.Console);
        readonly string sampleText = "Text";

        [TestMethod]
        public void TestInfoCounter()
        {           
            logger.WriteMessage(sampleText, messageLevel: MessageLevel.Info);
            Assert.AreEqual(logger.MessageLevelProperties.GetCounter(MessageLevel.Info), 1);
        }

        [TestMethod]
        public void TestSuccessCounter()
        {
            logger.WriteMessage(sampleText, messageLevel: MessageLevel.Success);
            Assert.AreEqual(logger.MessageLevelProperties.GetCounter(MessageLevel.Success), 1);
        }

        [TestMethod]
        public void TestWarningCounter()
        {
            logger.WriteMessage(sampleText, messageLevel: MessageLevel.Warning);
            Assert.AreEqual(logger.MessageLevelProperties.GetCounter(MessageLevel.Warning), 1);
        }

        [TestMethod]
        public void TestErrorCounter()
        {
            logger.WriteMessage(sampleText, messageLevel: MessageLevel.Error);
            Assert.AreEqual(logger.MessageLevelProperties.GetCounter(MessageLevel.Error), 1);
        }

        [TestMethod]
        public void TestDebugCounter()
        {
            logger.WriteMessage(sampleText, messageLevel: MessageLevel.Debug);
            Assert.AreEqual(logger.MessageLevelProperties.GetCounter(MessageLevel.Debug), 1);
        }
    }
}
