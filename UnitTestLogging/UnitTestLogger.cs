using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logging;

namespace UnitTestLogging
{
    [TestClass]
    public class UnitTestLoggerCounter
    {
        Logger logger = new Logger();
        string sampleText = "Text";

        [TestMethod]
        public void TestInfoCounter()
        {           
            logger.WriteMessage(sampleText, messageLevel: MessageLevel.Info);
            Assert.AreEqual(logger.GetCounter(MessageLevel.Info), 1);
        }

        [TestMethod]
        public void TestSuccessCounter()
        {
            logger.WriteMessage(sampleText, messageLevel: MessageLevel.Success);
            Assert.AreEqual(logger.GetCounter(MessageLevel.Success), 1);
        }

        [TestMethod]
        public void TestWarningCounter()
        {
            logger.WriteMessage(sampleText, messageLevel: MessageLevel.Warning);
            Assert.AreEqual(logger.GetCounter(MessageLevel.Warning), 1);
        }

        [TestMethod]
        public void TestErrorCounter()
        {
            logger.WriteMessage(sampleText, messageLevel: MessageLevel.Error);
            Assert.AreEqual(logger.GetCounter(MessageLevel.Error), 1);
        }

        [TestMethod]
        public void TestDebugCounter()
        {
            logger.WriteMessage(sampleText, messageLevel: MessageLevel.Debug);
            Assert.AreEqual(logger.GetCounter(MessageLevel.Debug), 1);
        }
    }
}
