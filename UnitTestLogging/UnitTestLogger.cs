using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logging;
using Logging.Messages;
using System;
using System.Collections.Generic;
using System.Text;

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
            logger.WriteMsg(sampleText, messageLevel: MessageLevel.Info);
            Assert.AreEqual(logger.GetMessageCounter(MessageLevel.Info), 1);
        }

        [TestMethod]
        public void TestSuccessCounter()
        {
            logger.WriteMsg(sampleText, messageLevel: MessageLevel.Success);
            Assert.AreEqual(logger.GetMessageCounter(MessageLevel.Success), 1);
        }

        [TestMethod]
        public void TestWarningCounter()
        {
            logger.WriteMsg(sampleText, messageLevel: MessageLevel.Warning);
            Assert.AreEqual(logger.GetMessageCounter(MessageLevel.Warning), 1);
        }

        [TestMethod]
        public void TestErrorCounter()
        {
            logger.WriteMsg(sampleText, messageLevel: MessageLevel.Error);
            Assert.AreEqual(logger.GetMessageCounter(MessageLevel.Error), 1);
        }

        [TestMethod]
        public void TestDebugCounter()
        {
            logger.WriteMsg(sampleText, messageLevel: MessageLevel.Debug);
            Assert.AreEqual(logger.GetMessageCounter(MessageLevel.Debug), 1);
        }
    }
}
