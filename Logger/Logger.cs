using NLog;
using System;

namespace Logger
{
    public class Logger : ILogger
    {
        private NLog.ILogger _logger;
        public Logger()
        {
            _logger = LogManager.GetCurrentClassLogger(); ;
        }

        public void Error(string message, Exception ex)
        {
            _logger.Error(ex,message);
        }

        public void Info(string message, params object[] args)
        {
            _logger.Info(message, args);
        }

        public void Debug(string message, params object[] args)
        {
            _logger.Info(message, args);
        }
    }
}
