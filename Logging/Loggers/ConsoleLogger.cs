// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Loggers
{
    using Writers;

    /// <summary>
    /// Logging to console
    /// </summary>
    public class ConsoleLogger : LoggerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleLogger"/> class
        /// </summary>
        public ConsoleLogger()
        {
            this.MessageWriter = new ConsoleWriter();
        }
    }
}
