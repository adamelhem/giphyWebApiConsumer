using System;

namespace Logger
{
    public interface ILogger
    {
        void Debug(string message, params object[] args);
        void Error(string message, Exception ex);
        void Info(string message, params object[] args);
    }
}