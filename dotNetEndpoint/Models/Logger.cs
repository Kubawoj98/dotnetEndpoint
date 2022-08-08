using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetEndpoint.Models
{
    public enum LogLevel
    {
        Off,
        Critical,
        Error,
        Warning,
        Information,
        Trace
    }

    public class Logger
    {
        public LogLevel EnabledLevel { get; init; } = LogLevel.Error;

        public void LogMessage(LogLevel level, string msg)
        {
            if (EnabledLevel < level) return;
            Console.WriteLine(msg);
        }
        public void LogMessage(LogLevel level, LogInterpolatedStringHandler builder)
        {
            if (EnabledLevel < level) return;
            Console.WriteLine(builder.GetFormattedText());
        }
        public static void writeInterpolatedString() 
        {
            var logger = new Logger() { EnabledLevel = LogLevel.Warning };
            var time = DateTime.Now;

            logger.LogMessage(LogLevel.Error, $"Error Level. CurrentTime: {time}. This is an error. It will be printed.");
            logger.LogMessage(LogLevel.Trace, $"Trace Level. CurrentTime: {time}. This won't be printed.");
            logger.LogMessage(LogLevel.Warning, "Warning Level. This warning is a string, not an interpolated string expression.");
            RevDeBugAPI.Snapshot.RecordSnapshot("interpolated_string_handler");
        }
    }
}
