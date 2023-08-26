using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructionSite.Logger
{
    internal class Logger
    {
        private readonly NLog.Logger logger; 
        public Logger(string loggerName)
        {
            logger = NLog.LogManager.GetLogger(loggerName);
        }

        public void Info(string message) => logger.Info(message);
        public void Error(string message) => logger.Error(message);
        public void Error(Exception ex, string message) => logger.Error(ex, message);
        public void Debug(string message) => logger.Debug(message);
        public void Debug(Exception ex, string message) => logger.Debug(ex, message);

    }
}
