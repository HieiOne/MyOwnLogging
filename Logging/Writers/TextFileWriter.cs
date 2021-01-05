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

            // Build full file name
            this.FullFileName = MessageProperties.GetFullNamePath(this.FilePath, this.FileName) + ".txt";

            // Checks for file path and file name
            this.FileInitialization();
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
        /// Gets or sets full file path and name
        /// </summary>
        public string FullFileName { get; set; }

        /// <summary>
        /// Gets or sets the writing mode
        /// </summary>
        public WritingMode WritingMode { get; set; }

        /// <summary>
        /// Method to write into a TXT File
        /// </summary>
        /// <param name="msg">Message that will be printed</param>
        /// <param name="messageLevel">Indicates the level of the message</param>
        public virtual void WriteMessage(string msg, MessageLevel messageLevel)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.FullFileName, true))
            {
                file.WriteLine(msg);
            }
        }

        /// <summary>
        /// Checks that the file path exists (if not, is created) same with the file name, depending on the Logging Mode, messages will be appended or re-created
        /// </summary>
        private void FileInitialization()
        {
            if (!File.Exists(this.FullFileName))
            {
                if (!Directory.Exists(this.FilePath))
                {
                    Directory.CreateDirectory(this.FilePath);
                }

                File.Create(this.FullFileName).Close();
            }
            else if (WritingMode == WritingMode.Recreating)
            {
                // Even if it exists, in recreating mode, create it again
                File.Create(this.FullFileName).Close();
            }
        }
    }
}
