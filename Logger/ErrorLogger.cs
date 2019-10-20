using System;
using System.Collections.Generic;

namespace Logger
{
    public class ErrorLogger
    {
        public string Message { get; set; }
        public Exception Ex { get; set; }

        public Dictionary<string, string> KeyValuePairs = new Dictionary<string, string>();
    }
}