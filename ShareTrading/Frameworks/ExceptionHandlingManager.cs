using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace ExceptionHandlingFramework
{
    /// <summary>
    /// Calss to manage the exception raised in the code
    /// </summary>
    public class ExceptionHandlingManager
    {
        #region Prvate members
        private static ExceptionManager exManager;
        #endregion

        #region Constructor

        /// <summary>
        /// Inititalizes the instance of Exception manager
        /// </summary>S
        static ExceptionHandlingManager()
        {
            IConfigurationSource config = ConfigurationSourceFactory.Create();
            ExceptionPolicyFactory factory = new ExceptionPolicyFactory(config);

            // Update the logger with the exception handler
            Logger.SetLogWriter(LoggingManager.Logger);
            // create the exception manager
            exManager = factory.CreateManager();
        }
        #endregion

        #region Singleton instance

        /// <summary>
        /// Exception manager
        /// </summary>
        public static ExceptionManager Instance
        {
            get
            {
                return exManager;
            }
        }
        #endregion
    }
}
