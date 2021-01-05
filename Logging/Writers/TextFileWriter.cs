// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Writers
{
    using System;
    using System.IO;
    using Logging.Messages;

    /// <summary>
    /// This class is used to write into a TXT File
    /// </summary>
    internal class TextFileWriter : IWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileWriter"/> class
        /// </summary>
        /// <param name="filePath">Path where the file will be stored</param>
        /// <param name="fileName">Name of the file</param>
        /// <param name="writingMode">Used writing mode</param>
        public TextFileWriter(string filePath, string fileName, WritingMode writingMode)
        {
            this.FilePath = filePath;
            this.FileName = fileName;
            this.WritingMode = writingMode;
        }

        /// <summary>
        /// Gets or sets file path value
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets file name value
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the writing mode
        /// </summary>
        public WritingMode WritingMode { get; set; }

        /// <summary>
        /// Method to write into a TXT File
        /// </summary>
        /// <param name="msg">Message that will be printed</param>
        public virtual void WriteMessage(string msg)
        {
            // Build full file name
            string fullFileName = MessageProperties.GetFullNamePath(this.FilePath, this.FileName) + ".txt";

            if (!File.Exists(fullFileName))
            {
                if (!Directory.Exists(this.FilePath))
                {
                    Directory.CreateDirectory(this.FilePath);
                }

                File.Create(fullFileName).Close();
            }
            else if (WritingMode == WritingMode.Recreating)
            {
                // BUG: It should be checked in the initiation of the class
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
