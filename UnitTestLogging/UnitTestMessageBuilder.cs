using Logging;
using Logging.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestLogging
{
    [TestClass]
    public class UnitTestMessageBuilder
    {
        private readonly ConsoleLogger logger = new ConsoleLogger();
        private readonly string text = "Hello World";

        [TestMethod]
        public void TestBasicBuild()
        {
            foreach (MessageLevel messageLevel in Enum.GetValues(typeof(MessageLevel)))
            {
                logger.MessageProperties.ShowPrefix = false;
                logger.MessageProperties.ShowTimeStamp = false;

                string msg = MessageBuilder.MessageStringBuilder(text, messageLevel, logger.MessageProperties, logger.MessageLevelProperties);
                Assert.AreEqual(msg, text);
            }
        }

        [TestMethod]
        public void TestPrefixes()
        {
            foreach (MessageLevel messageLevel in Enum.GetValues(typeof(MessageLevel)))
            {
                logger.MessageProperties.ShowPrefix = true;
                logger.MessageProperties.ShowTimeStamp = false;

                string msg = MessageBuilder.MessageStringBuilder(text, messageLevel, logger.MessageProperties, logger.MessageLevelProperties);
                Assert.AreEqual(msg, logger.MessageLevelProperties.GetPrefix(messageLevel) + ": " + text);
            }
        }

        [TestMethod]
        public void TestPrefixChange()
        {
            logger.MessageProperties.ShowPrefix = true;
            logger.MessageProperties.ShowTimeStamp = false;

            logger.MessageLevelProperties.SetPrefix(MessageLevel.Info, "TEST");
            string msg = MessageBuilder.MessageStringBuilder(text, MessageLevel.Info, logger.MessageProperties, logger.MessageLevelProperties);
            Assert.AreEqual(msg, "TEST: " + text);
        }

        [TestMethod]
        public void TestTimeStamps()
        {
            foreach (MessageLevel messageLevel in Enum.GetValues(typeof(MessageLevel)))
            {
                logger.MessageProperties.ShowPrefix = false;
                logger.MessageProperties.ShowTimeStamp = true;
                logger.MessageProperties.TimeStampFormat = "hh:mm:ss";

                string timeStamp = "[" + System.DateTime.Now.ToString(logger.MessageProperties.TimeStampFormat) + "] ";
                string msg = MessageBuilder.MessageStringBuilder(text, messageLevel, logger.MessageProperties, logger.MessageLevelProperties);
                Assert.AreEqual(msg, timeStamp + text);
            }
        }
    }
}