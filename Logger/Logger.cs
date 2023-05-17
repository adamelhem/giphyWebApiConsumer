using NLog;
using System;

namespace Logger
{
    public sealed class Logger : ILogger
    {
        private static NLog.ILogger _logger;

        private static ILogger _instance;
        private static readonly object InstanceLoker = new object();

        private Logger()
        {
            _logger = LogManager.GetCurrentClassLogger(); ;
        }

        public static ILogger Instance
        {
            get
            {
                if (_instance == null && _logger == null)
                {
                    lock (InstanceLoker)
                    {
                        if (_instance == null && _logger == null)
                        {
                            _instance = new Logger();
                        }
                    }
                }
                return _instance;
            }
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
