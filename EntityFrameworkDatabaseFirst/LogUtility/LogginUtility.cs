using System;
using EntityFrameworkDatabaseFirst.Database_First;
using log4net;

namespace EntityFrameworkDatabaseFirst.LogUtility
{
    class LogginUtility
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Student));

        public LogginUtility()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        
        public void SetMessageError(string message, string customMessage)
        {
            logger.Error(customMessage);
            logger.Error(message);
        }

        internal void StackTraceAboutError(string stackTrace)
        {
            logger.Error(stackTrace);
        }
    }
}
