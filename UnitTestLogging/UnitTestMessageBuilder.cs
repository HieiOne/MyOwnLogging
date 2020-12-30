using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Logging;
using Logging.Messages;

namespace UnitTestLogging
{
    [TestClass]
    public class UnitTestMessageBuilder
    {
        readonly string text = "Hello World";

        [TestMethod]
        public void TestBasicBuild()
        {
            foreach (MessageLevel messageLevel in Enum.GetValues(typeof(MessageLevel)))
            {
                string msg = MessageBuilder.MessageStringBuilder(text, messageLevel, false, false);
                Assert.AreEqual(msg, text);
            }
        }

        [TestMethod]
        public void TestPrefixes()
        {
            foreach (MessageLevel messageLevel in Enum.GetValues(typeof(MessageLevel)))
            {
                string msg = MessageBuilder.MessageStringBuilder(text, messageLevel, true, false);
                Assert.AreEqual(msg, MessageLevelProperties.GetPrefix(messageLevel) + ": " + text);
            }
        }

        [TestMethod]
        public void TestTimeStamps()
        {
            foreach (MessageLevel messageLevel in Enum.GetValues(typeof(MessageLevel)))
            {
                string timeStampFormat = "hh:mm:ss";
                string timeStamp = "[" + System.DateTime.Now.ToString(timeStampFormat) + "] ";
                string msg = MessageBuilder.MessageStringBuilder(text, messageLevel, false, true, timeStampFormat);
                Assert.AreEqual(msg, timeStamp + text);
            }
        }
    }
}
