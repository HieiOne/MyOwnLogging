// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.


namespace Logging.Writers
{
    using System;
    using System.IO;
    using Logging.Messages;

    /// <summary>
    /// This class is used to write into a TXT File
    /// </summary>
    internal class TextFileWriter
    {
        /// <summary>
        /// Static method to write into a TXT File
        /// </summary>
        /// <param name="msg">Message to display</param>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        public static void WriteMessage(string msg, string filePath, string fileName, WritingMode writingMode)
        {
            // Build full file name
            string fullFileName = MessageProperties.GetFullNamePath(filePath,fileName)+".txt";

            if (!(File.Exists(fullFileName)))
            {
                if (!(Directory.Exists(filePath)))
                {
                    Directory.CreateDirectory(filePath);
                }
                File.Create(fullFileName).Close();
            }
            // BUG: It should be checked in the initiation of the class
            else if (writingMode == WritingMode.Recreating)
            {
                // Even if it exists, in recreating mode, create it again
                File.Create(fullFileName).Close();
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fullFileName, true))
            {
                file.WriteLine(msg);
            }
        }
    }
}
