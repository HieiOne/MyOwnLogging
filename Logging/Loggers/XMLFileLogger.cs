// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Loggers
{
    using System.Xml;

    /// <summary>
    /// This class is used to write into a XML File
    /// </summary>
    public class XMLFileLogger : LoggerBase
    {
        /// <summary>
        /// Management of the file creation
        /// </summary>
        private readonly XmlWriter xmlWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMLFileLogger"/> class is important to start the document and end document with the Logger methods.
        /// </summary>
        /// <param name="filePath">Path where the file will be stored</param>
        /// <param name="fileName">Name of the file</param>
        /// <param name="xmlWriterSettings">XML File Settings</param>
        public XMLFileLogger(string filePath, string fileName, XmlWriterSettings xmlWriterSettings = null)
        {
            this.FilePath = filePath;
            this.FileName = fileName;

            // Build full file name
            this.FullFileName = this.GetFullNamePath(this.FilePath, this.FileName) + ".xml";

            if (xmlWriterSettings != null)
            {
                this.xmlWriter = XmlWriter.Create(this.FullFileName, xmlWriterSettings);
            }
            else
            { 
                this.xmlWriter = XmlWriter.Create(this.FullFileName);
            }
        }

        /// <summary>
        /// Gets or sets file path value
        /// </summary>
        private string FilePath { get; set; }

        /// <summary>
        /// Gets or sets file name value
        /// </summary>
        private string FileName { get; set; }

        /// <summary>
        /// Gets or sets full file path and name
        /// </summary>
        private string FullFileName { get; set; }

        /// <summary>
        /// Starts the XML document
        /// </summary>
        public void StartDocument()
        {
            this.xmlWriter.WriteStartDocument();
            this.xmlWriter.WriteStartElement("Logging");
        }

        /// <summary>
        /// Closes and saves the XML document
        /// </summary>
        public void EndDocument()
        {
            this.xmlWriter.WriteEndElement();
            this.xmlWriter.Close();
        }

        /// <summary>
        /// Method to write into a XML File
        /// </summary>
        /// <param name="msg">Message that will be printed</param>
        /// <param name="messageLevel">Indicates the level of the message</param>
        internal override void WriterLogger(string msg, MessageLevel messageLevel)
        {
            this.xmlWriter.WriteStartElement("Log");
            this.xmlWriter.WriteAttributeString("messageLevel", messageLevel.ToString());
            this.xmlWriter.WriteString(msg);
            this.xmlWriter.WriteEndElement();
        }
    }
}
