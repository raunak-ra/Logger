using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    interface ITxsLogger
    {
        void InitLogger();
        void LogApi(ApiLogger logger);
        void LogTrace(TraceLogger logger);
        void LogError(ErrorLogger logger);
    }
}
