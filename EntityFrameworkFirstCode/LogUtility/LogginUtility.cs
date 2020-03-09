using log4net;

namespace EntityFrameworkFirstCode.LogUtility
{
    class LogginUtility
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Student));
        
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
