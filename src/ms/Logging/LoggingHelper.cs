using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms.Logging
{
    public static class LoggingHelper
    {
        static LoggingHelper()
        {
        }
        public static void WriteControllerInfoLog(string methodName)
        {
            Log.Information("{methodName} method called.", methodName);
        }
    }
}
