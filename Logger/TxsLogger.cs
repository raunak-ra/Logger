using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    class TxsLogger : ITxsLogger
    {
        public void InitLogger()
        {
            Log.Logger = new LoggerConfiguration()
                         .MinimumLevel.Information()
                         .Enrich.FromLogContext()


                         .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Verbose).WriteTo.RollingFile(@"LogsVerboseVerbose-{Date}.log"))
                         .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug).WriteTo.RollingFile(@"LogsDebugDebug-{Date}.log"))
                         .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information).WriteTo.RollingFile(@"LogsApiApi-{Date}.log"))
                         .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Warning).WriteTo.RollingFile(@"LogsWarningWarning-{Date}.log"))
                         .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error).WriteTo.RollingFile(@"LogsErrorError-{Date}.log"))
                         .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Fatal).WriteTo.RollingFile(@"LogsFatalFatal-{Date}.log"))

                         .CreateLogger();
        }

        public void LogApi(ApiLogger logger)
        {
            string message = logger.Message;
            Log.Information(message);
            if (logger.KeyValuePairs.Count != 0)
            {
                foreach (var x in logger.KeyValuePairs)
                    Log.Information("{key} : {value}", x.Key, x.Value);
            }


        }

        public void LogError(ErrorLogger logger)
        {
            Log.Error(logger.Message);
            Log.Error(logger.Ex.StackTrace);
            if (logger.KeyValuePairs.Count != 0)
            {
                foreach (var x in logger.KeyValuePairs)
                    Log.Information("{key} : {value}", x.Key, x.Value);
            }

        }

        public void LogTrace(TraceLogger logger)
        {
            throw new NotImplementedException();
        }
    }
}
