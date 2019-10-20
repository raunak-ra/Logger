using System.Collections.Generic;

namespace Logger
{
    public class TraceLogger
    {
        public string Message { get; set; }
        public Dictionary<string, string> KeyValuePairs = new Dictionary<string, string>();
    }
}