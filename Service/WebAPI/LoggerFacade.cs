using DevelopmentInProgress.DipCore.Logger;
using log4net;

namespace DevelopmentInProgress.AuthorisationManager.WebAPI
{
    /// <summary>
    /// The logger facade implementing a log4net logger.
    /// </summary>
    public class LoggerFacade : IDipLog
    {
        /// <summary>
        /// Instance if the log4net logger.
        /// </summary>
        private readonly ILog logger;

        /// <summary>
        /// Initializes a new instance of the LoggerFacade class that implements the log4net logger.
        /// </summary>
        public LoggerFacade()
        {
            // Log4net requires a call to configure the logger from 
            // the App.config file prior to calling GetLogger().
            log4net.Config.XmlConfigurator.Configure();
            logger = LogManager.GetLogger(typeof(LoggerFacade));
            logger.Info("*********************************************");
            logger.Info("*********************************************");
            logger.Info("AuthorisationManager.WCFServiceHost");
            logger.Info("Copyright © Development In Progress Ltd 2016");
            logger.Info("Start Service");
        }

        /// <summary>
        /// Log a message.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public void Log(string message)
        {
            Log(message, LogCategory.Info);
        }

        /// <summary>
        /// Log a message.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="category">The message category.</param>
        public void Log(string message, LogCategory category)
        {
            Log(message, category, LogPriority.None);
        }

        /// <summary>
        /// Writes a message to the log.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="category">The message category.</param>
        /// <param name="priority">The log priority.</param>
        public void Log(string message, LogCategory category, LogPriority priority)
        {
            switch (category)
            {
                case LogCategory.Debug:
                    logger.Debug(message);
                    break;
                case LogCategory.Warn:
                    logger.Warn(message);
                    break;
                case LogCategory.Exception:
                    logger.Error(message);
                    break;
                case LogCategory.Info:
                    logger.Info(message);
                    break;
            }
        }
    }
}