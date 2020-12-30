using System.Text;

namespace Logging.Messages
{
    public class MessageBuilder
    {
        public static string MessageStringBuilder(string msg, MessageLevel messageLevel, bool showPrefix, bool showTimeStamp, string timeStampFormat = null)
        {
            StringBuilder stringBuilder = new StringBuilder();

            #region TimeStamp
            string timeStamp = null;
            if (showTimeStamp)
            {
                timeStamp = "[";
                if (timeStampFormat != null)
                {
                    timeStamp += System.DateTime.Now.ToString(timeStampFormat);
                }
                else
                {
                    timeStamp += System.DateTime.Now.ToString();
                }
                timeStamp += "] ";
            }
            #endregion

            #region PrefixMsg
            string prefixMsg = null;
            if (showPrefix)
                prefixMsg = MessageLevelProperties.GetPrefix(messageLevel) + ": ";
            #endregion

            stringBuilder.AppendFormat("{0}{1}{2}", timeStamp, prefixMsg, msg);
            return stringBuilder.ToString();
        }
    }
}