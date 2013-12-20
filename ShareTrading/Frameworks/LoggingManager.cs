using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace ExceptionHandlingFramework
{
    /// <summary>
    /// Class for logging the errors and messages of the application
    /// </summary>
    public class LoggingManager
    {
        #region Private members
        private static LogWriter writer;
        #endregion

        #region constructor
        /// <summary>
        /// Initializes the instance of log writer
        /// </summary>
        static LoggingManager()
        {
            IConfigurationSource config = ConfigurationSourceFactory.Create();
            LogWriterFactory factory = new LogWriterFactory(config);
            writer = factory.Create();
        }
        #endregion

        #region Singleton instance

        /// <summary>
        /// Logger to log the enteires
        /// </summary>
        public static LogWriter Logger
        {
            get
            {
                return writer;
            }
        }
        #endregion
    }
}
