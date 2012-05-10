using NLog;

namespace JBSoft.Logging
{
    /// <summary>
    /// Class to handle the logging throughout the system.
    /// To be accessed via a singleton only.
    /// </summary>
    public class Logger
    {
        #region Singleton Pattern

        private static Logger logger;

        /// <summary>
        /// Private constructor to enforce singleton pattern.
        /// </summary>
        private Logger()
        {
            log = LogManager.GetCurrentClassLogger();
        }

        public static Logger Instance
        {
            get
            {
                if (logger == null)
                    logger = new Logger();

                return logger;
            }
        }

        #endregion

        #region Properties

        NLog.Logger log;

        /// <summary>
        /// Returns an instance of the Nlog logger.
        /// Singleton ensures only single logger for the whole application.
        /// </summary>
        public NLog.Logger Log
        {
            get
            {
                if (log == null)
                    log = LogManager.GetCurrentClassLogger();

                return log;
            }
        }

        #endregion
    }
}
