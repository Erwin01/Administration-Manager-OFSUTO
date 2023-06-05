using Microsoft.Extensions.Logging;
using Syntax.Ofesauto.Security.Transversal.Common;

namespace Syntax.Ofesauto.Security.Transversal.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {


        /// <summary>
        /// Globals variable
        /// </summary>
        /// 
        private readonly ILogger<T> _logger;


        #region [ ILOGGER FACTORY ]
        /// <summary>
        /// Exceptions traceability method
        /// </summary>
        /// <param name="loggerFactory"></param>
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }
        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }
        #endregion
        

    }
}
