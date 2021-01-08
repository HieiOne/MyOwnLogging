// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Loggers
{
    using Writers;

    /// <summary>
    /// Logging to a file
    /// </summary>
    public class FileLogger : LoggerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class
        /// </summary>
        /// <param name="filePath">File path where the logging files will be stored, cannot be modified later</param>
        /// <param name="fileName">File name where the logging files will be stored, cannot be modified later</param>
        /// <param name="writingMode">Writing mode that will be used, cannot be modified later</param>
        public FileLogger(string filePath, string fileName, WritingMode writingMode = WritingMode.Appending)
        {
            this.MessageWriter = new TextFileWriter(filePath, fileName, writingMode);
        }
    }
}
