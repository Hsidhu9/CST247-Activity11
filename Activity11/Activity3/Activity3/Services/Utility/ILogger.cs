using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity3.Services.Utility
{
    // interface for our custom logger that returns basic error methods and contains the error message
    interface ILogger
    {
        void Debug(string message);

        void Info(string message, string v);

        void Info(string message);

        void Warning(string message);

        void Error(string message, string error);
    }
}
