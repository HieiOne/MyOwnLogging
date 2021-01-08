// Licensed under the GNU General Public License v3.0. See LICENSE in the project root for license information.

namespace Logging.Loggers
{
    using Writers;

    /// <summary>
    /// Logging to the attached debugger
    /// </summary>
    public class DebugLogger : LoggerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugLogger"/> class
        /// </summary>
        public DebugLogger()
        {
            this.MessageWriter = new DebuggerWriter();
        }
    }
}