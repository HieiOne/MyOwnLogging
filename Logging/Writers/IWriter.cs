using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Writers
{
    interface IWriter
    {
        void WriteMessage(string msg);
    }
}
